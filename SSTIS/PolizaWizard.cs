using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AeroWizard;
using BE;
using BLL.Interfaces;
using SSTIS.Interfaces;

namespace SSTIS
{
    public partial class PolizaWizard : Form, IPolizaWizard
    {
        private IServicioPoliza ServicioPolizaImplementor;
        private IServicioUsuario ServicioUsuarioImplementor;
        private IServicioLocalidad ServicioLocalidadImplementor;
        public IServicio<Localidad> ServicioLocalidad;
        public IServicio<Provincia> ServicioProvincia;
        public IServicio<Cliente> ServicioCliente;
        public IServicioVehiculo ServicioVehiculoImplementor;
        public IServicio<Vehiculo> ServicioVehiculo;
        public IServicio<Factura> ServicioFactura;
        public ICobrarFactura CobrarFactura;

        private decimal CantidadSumaAsegurada;
        private byte[] Foto1 = null;
        private byte[] Foto2 = null;
        private byte[] Foto3 = null;
        private byte[] Foto4 = null;
        private Cliente ClienteGuardado = null;
        private Vehiculo VehiculoGuardado = null;
        private Poliza PolizaGuardada = null;
        private Factura FacturaGuardada = null;

        public PolizaWizard(IServicioPoliza ServicioPolizaImplementor, IServicioUsuario ServicioUsuarioImplementor,
            IServicioLocalidad ServicioLocalidadImplementor, IServicio<Localidad> ServicioLocalidad,
            IServicio<Provincia> ServicioProvincia,
            IServicio<Cliente> ServicioCliente, IServicioVehiculo ServicioVehiculoImplementor,
            IServicio<Vehiculo> ServicioVehiculo, IServicio<Factura> ServicioFactura,
            ICobrarFactura CobrarFactura)
        {
            this.ServicioUsuarioImplementor = ServicioUsuarioImplementor;
            this.ServicioPolizaImplementor = ServicioPolizaImplementor;
            this.ServicioLocalidadImplementor = ServicioLocalidadImplementor;
            this.ServicioLocalidad = ServicioLocalidad;
            this.ServicioProvincia = ServicioProvincia;
            this.ServicioCliente = ServicioCliente;
            this.ServicioVehiculoImplementor = ServicioVehiculoImplementor;
            this.ServicioVehiculo = ServicioVehiculo;
            this.ServicioFactura = ServicioFactura;
            this.CobrarFactura = CobrarFactura;
            InitializeComponent();
        }

        private void stwControl_SelectedPageChanged(object sender, EventArgs e)
        {
        }

        private void PolizaWizard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void PolizaWizard_Load(object sender, EventArgs e)
        {
            RestablecerControles();
            this.wizardControl.SelectedPage.NextPage = this.wizardInicio;
            //wizardInicio.NextPage.Enabled = false;

        }

        private void wizardPage1_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {
            if (wizardControl.SelectedPage == wizardInicio)
            {
                if (cboTransaccion.SelectedIndex == -1 && cboTipoPoliza.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor complete los datos para poder continuar a la siguiente pantalla.");
                    e.Cancel = true;
                    return;
                }

                if (cboTransaccion.SelectedIndex == 0)
                {
                    this.wizardControl.SelectedPage.NextPage = this.wizardCoberturas;
                }

                //Modificacion
                if (cboTransaccion.SelectedIndex == 1)
                {
                    if (string.IsNullOrEmpty(txtNumeroPoliza.Text))
                    {
                        MessageBox.Show("Debe ingresar un Numero de Póliza.");
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        var poliza =
                            ServicioPolizaImplementor.TraerPolizaPorNumero(int.Parse(txtNumeroPoliza.Text.Trim()));
                        if (poliza != null)
                        {
                            if (!poliza.Estado.HasValue)
                            {
                                MessageBox.Show("La Póliza con número: " + poliza.NroPoliza +
                                                " se encuentra anulada. " +
                                                "Por favor ingrese un número de póliza válido.");
                                e.Cancel = true;
                                return;
                            }

                            PolizaGuardada = poliza;
                        }
                        else
                        {
                            MessageBox.Show("Número de Póliza inválido.");
                            e.Cancel = true;
                            return;
                        }
                    }
                }

                //Anulacion
                if (cboTransaccion.SelectedIndex == 2)
                {
                    if (string.IsNullOrEmpty(txtNumeroPoliza.Text))
                    {
                        MessageBox.Show("Debe ingresar un Numero de Póliza.");
                        e.Cancel = true;
                        return;
                    }

                    var poliza =
                    ServicioPolizaImplementor.TraerPolizaPorNumero(int.Parse(txtNumeroPoliza.Text.Trim()));
                    if (poliza != null && (!poliza.Estado.HasValue || poliza.Estado.Value))
                    {
                        var confirmResult = MessageBox.Show(
                            "Esta seguro que desea anular la póliza. Confirme la operacion?",
                            "Confirme anulación de póliza",
                            MessageBoxButtons.YesNo);
                        if (confirmResult == DialogResult.Yes)
                        {
                            PolizaGuardada = poliza;
                            PolizaGuardada.Estado = false;
                            GuardarDatosPoliza();
                            MessageBox.Show("Póliza anulada correctamente.");
                            txtNumeroPoliza.Text = string.Empty;
                            e.Cancel = true;
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("La póliza es inexistente o ya se encuentra dada de baja.");
                        e.Cancel = true;
                        return;
                    }
                }
            }

            this.wizardControl.SelectedPage.NextPage = this.wizardCoberturas;
        }

        private int TraerNumeroDePoliza()
        {
            if (ServicioPolizaImplementor.TraerUlitmoNumeroDePoliza() == 0)
            {
                return 1;
            }
            else
            {
                var ultimoNumero = ServicioPolizaImplementor.TraerUlitmoNumeroDePoliza() + 1;
                return ultimoNumero;
            }
        }

        private void wizardInicio_Initialize(object sender, WizardPageInitEventArgs e)
        {
            txtNumeroPoliza.Text = TraerNumeroDePoliza().ToString();
        }

        private void wizardCoberturas_Initialize(object sender, WizardPageInitEventArgs e)
        {
            if (cboTransaccion.SelectedIndex == 0 && e.PreviousPage != wizardDatosCliente)
            {
                //Cargar todas las coberturas
                txtPrimaTotal.Enabled = false;
                txtPrimaTotal.Text = string.Empty;
                CargarGrillaCoberturas();
            }
            else
            {

                CargarGrillaCoberturas();
                //CargarCoberturasSeleccionadas();
                txtPrimaTotal.Enabled = false;
                txtPrimaTotal.Text = PolizaGuardada.Detalle.Coberturas.Sum(x => x.PrimaAsegurada).ToString();
            }

        }

        private void CargarGrillaCoberturas()
        {
            var coberturas = TraerCoberturas();

            var coberturasSeleccionadas = PolizaGuardada != null ? PolizaGuardada.Detalle.Coberturas : null;

            if (coberturasSeleccionadas != null)
            {
                foreach (var cobertura in coberturas)
                {
                    if (coberturasSeleccionadas.Any(x => x.IdCobertura == cobertura.IdCobertura))
                        cobertura.Seleccionada = true;
                }
            }

            //dgvCoberturas.DataSource = null;
            dgvCoberturas.DataSource = coberturas;
        }



        private List<Cobertura> GetSelectedCoberturas()
        {
            var coberturas = new List<Cobertura>();

            foreach (DataGridViewRow row in dgvCoberturas.Rows)
            {
                Cobertura cobOriginal = (Cobertura)row.DataBoundItem;

                if (cobOriginal.Seleccionada)
                {
                    coberturas.Add(cobOriginal);
                }
            }

            return coberturas;
        }

        private List<Cobertura> TraerCoberturas()
        {
            return ServicioPolizaImplementor.TraerCoberturas();
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            CantidadSumaAsegurada = 0;
            txtPrimaTotal.Text = CantidadSumaAsegurada.ToString();
            CargarGrillaCoberturas();
        }

        private void dgvCoberturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCoberturas.CurrentCell is DataGridViewCheckBoxCell)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dgvCoberturas.CurrentCell;

                bool isChecked = (bool)checkbox.EditedFormattedValue;
                var coberturaChequeada = (Cobertura)dgvCoberturas.CurrentRow.DataBoundItem;
                coberturaChequeada.Seleccionada = isChecked;

                if (checkbox.ColumnIndex == 1 && isChecked)
                {
                    CantidadSumaAsegurada += coberturaChequeada.PrimaAsegurada;
                }
                else if (checkbox.ColumnIndex == 1 && !isChecked)
                {
                    CantidadSumaAsegurada -= coberturaChequeada.PrimaAsegurada;
                }

                txtPrimaTotal.Text = CantidadSumaAsegurada.ToString();
            }
        }

        private void wizardCoberturas_Commit(object sender, WizardPageConfirmEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrimaTotal.Text.Trim()))
            {
                MessageBox.Show("Debe seleccionar al menos una cobertura para poder continuar a la siguiente pantalla");
                e.Cancel = true;
                return;
            }

            if (Convert.ToDecimal(txtPrimaTotal.Text.Trim()) < 0)
            {
                MessageBox.Show("Debe seleccionar al menos una cobertura para poder continuar a la siguiente pantalla");
                e.Cancel = true;
                return;
            }

            if (cboTransaccion.SelectedIndex == 1 && PolizaGuardada != null)
            {
                if (ServicioPolizaImplementor.ActualizarCoberturasSeleccionadas(PolizaGuardada))
                {
                    PolizaGuardada.Detalle.Coberturas = GetSelectedCoberturas();
                    MessageBox.Show("Coberturas actualizadas correctamente.");
                }

            }

            this.wizardControl.SelectedPage.NextPage = this.wizardDatosCliente;
        }

        private bool ValidarDatosClienteIngresados()
        {
            var returnValue = true;
            //Verificamos todos los controles de tipo textbox

            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) || string.IsNullOrEmpty(txtApellido.Text.Trim()) ||
                string.IsNullOrEmpty(txtEmail.Text.Trim()) || string.IsNullOrEmpty(txtDni.Text.Trim()) ||
                string.IsNullOrEmpty(txtCelular.Text.Trim()) || string.IsNullOrEmpty(txtCp.Text.Trim()) ||
                string.IsNullOrEmpty(txtDomicilio.Text.Trim()) || string.IsNullOrEmpty(txtTelFijo.Text.Trim()))
            {
                MessageBox.Show("Todos los datos deben estar completos");
                return false;
            }

            //Verificamois todos los controles de tipo combo
            if (cboProvincia.SelectedIndex == -1 || cboLocalidad.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione provincia y localidad");
                return false;
            }


            //Verificamos que se haya ingresado un mail valido
            if (!ServicioUsuarioImplementor.ValidarEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("El e-mail ingresado esta en formato incorrecto. Por favor corrijalo!!!");
                returnValue = false;
            }

            return returnValue;
        }

        private void wizardDatosCliente_Initialize(object sender, WizardPageInitEventArgs e)
        {
            cboLocalidad.Enabled = false;
            CargarComboProvincia();
            cboProvincia.SelectedIndex = -1;

            if (cboTransaccion.SelectedIndex == 1 && PolizaGuardada != null)
            {
                //Cargamos los controles con la data.
                ClienteGuardado = PolizaGuardada.Cliente;
                txtNombre.Text = ClienteGuardado.Nombre;
                txtApellido.Text = ClienteGuardado.Apellido;
                txtDni.Text = ClienteGuardado.Dni.ToString();
                dtpFechaNacimiento.Value = ClienteGuardado.FechaNacimiento;
                txtEmail.Text = ClienteGuardado.Email;

                if (ClienteGuardado.Sexo.ToUpper() == "HOMBRE")
                {
                    rdbSexo.Checked = true;
                }
                else
                {
                    rdbSexo2.Checked = true;
                }

                txtDomicilio.Text = ClienteGuardado.Domicilio.Direccion;
                txtCp.Text = ClienteGuardado.Domicilio.CodPostal;
                cboProvincia.SelectedIndex = cboProvincia.FindString(ClienteGuardado.Domicilio.Provincia.Descripcion);
                CargarLocalidad();
                cboLocalidad.SelectedIndex = cboLocalidad.FindString(ClienteGuardado.Domicilio.Localidad.Descripcion);
                txtCelular.Text = ClienteGuardado.Contacto.Celular;
                txtTelFijo.Text = ClienteGuardado.Contacto.Telefono;
            }
        }

        private void wizardDatosCliente_Commit(object sender, WizardPageConfirmEventArgs e)
        {
            if (!ValidarDatosClienteIngresados())
            {
                MessageBox.Show("Por favor complete los datos para poder continuar a la siguiente pantalla.");
                e.Cancel = true;
                return;
            }

            if (cboTransaccion.SelectedIndex == 1 && ClienteGuardado != null)
            {
                if (GuardarDatosCliente())
                {
                    PolizaGuardada.Cliente = ClienteGuardado;
                    MessageBox.Show("Datos actualizados correctamente.");
                }
            }

            this.wizardControl.SelectedPage.NextPage = this.wizardDatosVehiculo;
        }

        private void CargarComboProvincia()
        {
            //Retrieve provincias
            var provincias = ServicioProvincia.Retrive();
            cboProvincia.DataSource = provincias;
            cboProvincia.DisplayMember = "Descripcion";
            cboProvincia.ValueMember = "IdProvincia";
        }

        private void LlenarComboLocalidadesPorProvinciaId(Guid provinciaId)
        {
            var localidadesByProvinciaId = ServicioLocalidadImplementor.GetLocalidadesByProvinciaId(provinciaId);

            cboLocalidad.DataSource = localidadesByProvinciaId;
            cboLocalidad.DisplayMember = "Descripcion";
            cboLocalidad.ValueMember = "IdLocalidad";
        }

        private void cboProvincia_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            CargarLocalidad();
        }

        private void CargarLocalidad()
        {
            cboLocalidad.Enabled = true;
            var selectedProvincia = Guid.Parse(cboProvincia.SelectedValue.ToString());
            var localidadesByProvinciaId = ServicioLocalidadImplementor.GetLocalidadesByProvinciaId(selectedProvincia);
            cboLocalidad.DataSource = localidadesByProvinciaId;
            cboLocalidad.DisplayMember = "Descripcion";
            cboLocalidad.ValueMember = "IdLocalidad";
            cboLocalidad.SelectedIndex = -1;
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter =
                "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ;
            openFileDialog1.Title = "Por favor seleccione las imagenes";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileNames.Length < 5)
                {
                    for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                    {
                        var foto = openFileDialog1.FileNames[i];
                        //if (Path.GetExtension(foto) == ".png" || Path.GetExtension(foto) == ".jpeg")
                        //{
                        if (PictureBoxIsNullOrEmpty(pbFoto1))
                        {
                            pbFoto1.Image = new Bitmap(foto);
                            Foto1 = File.ReadAllBytes(foto);
                            btnBorrarImagen1.Visible = true;
                        }
                        else if (PictureBoxIsNullOrEmpty(pbFoto2))
                        {
                            pbFoto2.Image = new Bitmap(foto);
                            Foto2 = File.ReadAllBytes(foto);
                            btnBorrarImagen2.Visible = true;
                        }
                        else if (PictureBoxIsNullOrEmpty(pbFoto3))
                        {
                            pbFoto3.Image = new Bitmap(foto);
                            Foto3 = File.ReadAllBytes(foto);
                            btnBorrarImagen3.Visible = true;
                        }
                        else if (PictureBoxIsNullOrEmpty(pbFoto4))
                        {
                            pbFoto4.Image = new Bitmap(foto);
                            Foto4 = File.ReadAllBytes(foto);
                            btnBorrarImagen4.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Solo se pueden agregar hasta 4 imágenes");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Cantidad de imágenes seleccionadas: " + openFileDialog1.FileNames.Length + " " +
                                    "Solo se procesaran 4.");
                }

            }
        }

        public static bool PictureBoxIsNullOrEmpty(PictureBox pb)
        {
            return pb?.Image == null;
        }

        private void wizardDatosVehiculo_Initialize(object sender, WizardPageInitEventArgs e)
        {
            if (cboTransaccion.SelectedIndex == 0)
            {
                //Initialize controls
                btnBorrarImagen1.Visible = false;
                btnBorrarImagen2.Visible = false;
                btnBorrarImagen3.Visible = false;
                btnBorrarImagen4.Visible = false;
                CargarControlesVehiculo();
                cboModelo.Enabled = false;
            }
            else
            {
                CargarControlesVehiculo();
                btnBorrarImagen1.Visible = false;
                btnBorrarImagen2.Visible = false;
                btnBorrarImagen3.Visible = false;
                btnBorrarImagen4.Visible = false;
                VehiculoGuardado = PolizaGuardada.Detalle.Vehiculo;
                txtPatente.Text = VehiculoGuardado.Patente;
                txtNumSerie.Text = VehiculoGuardado.NumSerie;
                txtNumChasis.Text = VehiculoGuardado.NumChasis;
                cboTipoUso.SelectedIndex = cboTipoUso.FindStringExact(VehiculoGuardado._TipoUso.Descripcion);
                cboMarca.SelectedIndex = cboMarca.FindStringExact(VehiculoGuardado.Marca.Descripcion);
                CargarComboMarca();
                cboModelo.SelectedIndex = cboModelo.FindStringExact(VehiculoGuardado.Modelo.Descripcion);
                cboCombustible.SelectedIndex = cboCombustible.FindStringExact(VehiculoGuardado.Combustible);
                cboColor.SelectedIndex = cboColor.FindStringExact(VehiculoGuardado.Color);
                cboCantPuertas.SelectedIndex = cboCantPuertas.FindStringExact(VehiculoGuardado.CantPuertas.ToString());

                if (VehiculoGuardado.Foto1 != null)
                {
                    MemoryStream ms = new MemoryStream(VehiculoGuardado.Foto1);
                    pbFoto1.Image = Image.FromStream(ms);
                    btnBorrarImagen1.Visible = true;
                }
                else if (VehiculoGuardado.Foto2 != null)
                {
                    MemoryStream ms = new MemoryStream(VehiculoGuardado.Foto2);
                    pbFoto2.Image = Image.FromStream(ms);
                    btnBorrarImagen2.Visible = true;
                }
                else if (VehiculoGuardado.Foto3 != null)
                {
                    MemoryStream ms = new MemoryStream(VehiculoGuardado.Foto3);
                    pbFoto3.Image = Image.FromStream(ms);
                    btnBorrarImagen3.Visible = true;
                }
                else if (VehiculoGuardado.Foto4 != null)
                {
                    MemoryStream ms = new MemoryStream(VehiculoGuardado.Foto4);
                    pbFoto4.Image = Image.FromStream(ms);
                    btnBorrarImagen4.Visible = true;
                }
            }
        }

        private void wizardDatosVehiculo_Commit(object sender, WizardPageConfirmEventArgs e)
        {
            if (ValidarDatosVehiculo())
            {
                MessageBox.Show("Por favor complete todos los datos del vehículo.");
                e.Cancel = true;
                return;
            }

            if (cboTransaccion.SelectedIndex == 1 && VehiculoGuardado != null)
            {
                if (GuardarDatosVehiculo())
                {
                    PolizaGuardada.Detalle.Vehiculo = VehiculoGuardado;
                    MessageBox.Show("Vehiculo actualizado correctamente.");
                }
            }

            this.wizardControl.SelectedPage.NextPage = this.wizardFactura;
        }

        private bool ValidarDatosVehiculo()
        {
            return string.IsNullOrEmpty(txtPatente.Text.Trim()) || string.IsNullOrEmpty(txtNumSerie.Text.Trim()) ||
                   string.IsNullOrEmpty(txtNumChasis.Text.Trim()) || cboTipoUso.SelectedIndex == -1 ||
                   cboModelo.SelectedIndex == -1 || cboMarca.SelectedIndex == -1 ||
                   cboCombustible.SelectedIndex == -1 ||
                   cboColor.SelectedIndex == -1 || cboCantPuertas.SelectedIndex == -1;
        }

        private void CargarControlesVehiculo()
        {
            CargarMarcas();
            CargarTipoDeUsoVehiculo();
        }

        private void CargarTipoDeUsoVehiculo()
        {
            cboTipoUso.DataSource = ServicioVehiculoImplementor.TraerTipoDeUsosDeVehiculo();
            cboTipoUso.DisplayMember = "Descripcion";
            cboTipoUso.ValueMember = "IdTipoUso";
            cboTipoUso.SelectedIndex = -1;
        }

        private void CargarMarcas()
        {
            cboMarca.DataSource = ServicioVehiculoImplementor.TraerMarcas();
            cboMarca.DisplayMember = "Descripcion";
            cboMarca.ValueMember = "IdMarca";
            cboMarca.SelectedIndex = -1;
        }


        private void btnBorrarImagen1_Click(object sender, EventArgs e)
        {
            pbFoto1.Image = null;
            pbFoto1.Refresh();
            btnBorrarImagen1.Visible = false;
        }

        private void btnBorrarImagen2_Click(object sender, EventArgs e)
        {
            pbFoto2.Image = null;
            pbFoto2.Refresh();
            btnBorrarImagen2.Visible = false;
        }

        private void btnBorrarImagen3_Click(object sender, EventArgs e)
        {
            pbFoto3.Image = null;
            pbFoto3.Refresh();
            btnBorrarImagen3.Visible = false;
        }

        private void btnBorrarImagen4_Click(object sender, EventArgs e)
        {
            pbFoto4.Image = null;
            pbFoto4.Refresh();
            btnBorrarImagen4.Visible = false;
        }

        private void cboMarca_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarComboMarca();
        }

        private void CargarComboMarca()
        {
            cboModelo.Enabled = true;
            var selectedMarca = Guid.Parse(cboMarca.SelectedValue.ToString());
            var modelosPorMarca = ServicioVehiculoImplementor.TraerModelosPorMarca(selectedMarca);
            cboModelo.DataSource = modelosPorMarca;
            cboModelo.DisplayMember = "Descripcion";
            cboModelo.ValueMember = "IdModelo";
            cboModelo.SelectedIndex = -1;
        }

        private void wizardFactura_Initialize(object sender, WizardPageInitEventArgs e)
        {
            //SI ES UNA NUEVA POLIZA TRAEMOS LOS DATOS DE LOS OTROS CONTROLES
            if (cboTransaccion.SelectedItem.ToString().ToUpper() == "NUEVA PÓLIZA")
            {
                btnNuevaFac.Enabled = false;
                btnAnular.Enabled = false;
                txtNomYApFac.Text = txtNombre.Text.Trim() + " " + txtApellido.Text.Trim();
                txtDomicilioFac.Text = txtDomicilio.Text.Trim();
                txtNumPolizaFac.Text = txtNumeroPoliza.Text.Trim();
                txtCapitalFac.Text = txtPrimaTotal.Text.Trim();
                //CoberturasChequeadas()
                //{
                //    txtSeguroContratadoFac.Text = "Todo Riesgo";
                //}
                //else
                //{
                //    txtSeguroContratadoFac.Text = "Terceros Completo";
                //}
                txtSeguroContratadoFac.Text = "Terceros Completo";
                //CAMBIAR ESTO CUANDO YA ESTE HECHA EL ALTA
                txtEstadoFac.Text = "En Emisión";
                //A diez dias de la fecha de emision
                dtpVencimientoFac.Value = DateTime.Today.AddDays(10);
                dtpFechaEmision.Value = DateTime.Today;
                //Si es una nueva emision seria 1 sino buscar la ultima paga y sumarle 1
                txtNumCuotaFac.Text = "1";
                txtPatenteFac.Text = txtPatente.Text.Trim();
                txtNumChasisFac.Text = txtNumChasis.Text.Trim();
                txtNumSerieFac.Text = txtNumSerie.Text.Trim();
                txtModeloFac.Text = ((Modelo)cboModelo.SelectedItem).Descripcion;
                txtMarcaFac.Text = ((Marca)cboMarca.SelectedItem).Descripcion;
            }
            else
            {
                //TREAMOS LOS DATOS DE LA BASE DE DATOS

            }

        }

        private bool CoberturasChequeadas()
        {
            bool data = false;
            var cont = 0;
            foreach (DataGridViewRow row in dgvCoberturas.Rows)
            {
                if (dgvCoberturas[0, row.Index].Value != null)
                {
                    data = (bool)dgvCoberturas[0, row.Index].Value;
                    if (data)
                        cont++;
                }
                else
                {
                    return false;
                }
            }

            return cont == dgvCoberturas.Rows.Count;
        }


        private void wizardFactura_Commit(object sender, WizardPageConfirmEventArgs e)
        {
            //Realizamos la persistencia de datos en la BD
            //1 - Guardamos los datos del cliente
            //2 - Guardamos los datos del vehiculo
            //3 - Guardamos los datos de la poliza
            //4 - Guardamos los datos de la factura
            if (PolizaGuardada == null && FacturaGuardada == null && SavePolicy())
            {
                this.wizardControl.SelectedPage.NextPage = this.wizardInicio;
            }

            RestablecerControles(true);
        }

        private bool SavePolicy()
        {
            if (!ValidarControlesFactura())
            {
                var guardadoCliente = GuardarDatosCliente();
                var guardadoVehiculo = GuardarDatosVehiculo();

                if (guardadoCliente && guardadoVehiculo)
                {
                    if (GuardarDatosPoliza())
                    {
                        if (GuardarDatosFactura())
                        {
                            MessageBox.Show("Poliza generada correctamente");
                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al generar la póliza.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor complete los datos faltantes de la factura.");
            }

            return false;
        }

        private void RestablecerControles(bool isCancel = false)
        {
            //Wizard inicio
            cboTransaccion.SelectedIndex = -1;
            cboTipoPoliza.SelectedIndex = -1;
            //Wizard Coberturas
            var index = 0;
            index = isCancel ? 1 : 0;

            if (dgvCoberturas.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in dgvCoberturas.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[index];
                    chk.Value = false;
                }
            }

            txtPrimaTotal.Text = string.Empty;
            //Wizard Datos cliente
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDni.Text = string.Empty;
            dtpFechaNacimiento.Value = DateTime.Today;
            txtEmail.Text = string.Empty;
            rdbSexo.Checked = false;
            rdbSexo2.Checked = false;
            txtDomicilio.Text = string.Empty;
            txtCp.Text = string.Empty;
            cboLocalidad.SelectedIndex = -1;
            cboProvincia.SelectedIndex = -1;
            txtTelFijo.Text = string.Empty;
            txtCelular.Text = string.Empty;
            //Wizard Datos Vehiculo
            txtPatente.Text = string.Empty;
            cboTipoUso.SelectedIndex = -1;
            txtAño.Text = string.Empty;
            txtNumSerie.Text = string.Empty;
            txtNumChasis.Text = string.Empty;
            cboMarca.SelectedIndex = -1;
            cboModelo.SelectedIndex = -1;
            cboCombustible.SelectedIndex = -1;
            cboColor.SelectedIndex = -1;
            cboCantPuertas.SelectedIndex = -1;
            pbFoto1.Image = null;
            pbFoto1.Refresh();
            pbFoto2.Image = null;
            pbFoto2.Refresh();
            pbFoto3.Image = null;
            pbFoto3.Refresh();
            pbFoto4.Image = null;
            pbFoto4.Refresh();
            //Wizard Datos Factura
            txtNomYApFac.Text = string.Empty;
            txtDomicilioFac.Text = string.Empty;
            txtSeguroContratadoFac.Text = string.Empty;
            txtNumPolizaFac.Text = string.Empty;
            txtCapitalFac.Text = string.Empty;
            txtEstadoFac.Text = string.Empty;
            dtpVencimientoFac.Value = DateTime.Today;
            txtNumFactura.Text = string.Empty;
            dtpFechaEmision.Value = DateTime.Today;
            txtNumCuotaFac.Text = string.Empty;
            txtPatenteFac.Text = string.Empty;
            txtNumSerieFac.Text = string.Empty;
            txtNumChasisFac.Text = string.Empty;
            txtMarcaFac.Text = string.Empty;
            txtModeloFac.Text = string.Empty;
            txtImporteFac.Text = string.Empty;
        }

        private bool GuardarDatosPoliza()
        {
            if (PolizaGuardada == null)
            {
                var poliza = new Poliza()
                {
                    IdPoliza = Guid.NewGuid(),
                    Cliente = ClienteGuardado,
                    Estado = null,
                    NroPoliza = int.Parse(txtNumPolizaFac.Text.Trim()),
                    FechaEmision = dtpFechaEmision.Value,
                    Detalle = new BE.DetallePoliza()
                    {
                        IdDetalle = Guid.NewGuid(),
                        Vehiculo = VehiculoGuardado,
                        //HAY QUE ARREGLAR ESTO.
                        Coberturas = GetSelectedCoberturas(),
                        Prima = decimal.Parse(txtPrimaTotal.Text),
                        SumaAsegurada = 200000
                    },
                };

                PolizaGuardada = poliza;

                return ServicioPolizaImplementor.Create(PolizaGuardada);
            }
            else
            {
                return ServicioPolizaImplementor.Delete(PolizaGuardada);
            }
        }

        private bool ValidarControlesFactura()
        {
            return string.IsNullOrEmpty(txtNomYApFac.Text.Trim()) ||
                   string.IsNullOrEmpty(txtDomicilioFac.Text.Trim()) ||
                   string.IsNullOrEmpty(txtSeguroContratadoFac.Text.Trim()) ||
                   string.IsNullOrEmpty(txtNumPolizaFac.Text.Trim()) ||
                   string.IsNullOrEmpty(txtCapitalFac.Text.Trim()) || string.IsNullOrEmpty(txtEstadoFac.Text.Trim()) ||
                   string.IsNullOrEmpty(txtNumFactura.Text.Trim()) ||
                   string.IsNullOrEmpty(txtNumCuotaFac.Text.Trim()) ||
                   string.IsNullOrEmpty(txtImporteFac.Text.Trim());
        }

        private bool GuardarDatosVehiculo()
        {
            var result = false;

            if (VehiculoGuardado == null)
            {
                var vehiculo = new Vehiculo()
                {
                    IdVehiculo = Guid.NewGuid(),
                    Patente = txtPatente.Text.Trim(),
                    Marca = new Marca() { IdMarca = ((Marca)cboMarca.SelectedItem).IdMarca },
                    _TipoUso = new TipoUso() { IdTipoUso = ((TipoUso)cboTipoUso.SelectedItem).IdTipoUso },
                    Modelo = new Modelo() { IdModelo = ((Modelo)cboModelo.SelectedItem).IdModelo },
                    Combustible = cboCombustible.SelectedItem.ToString(),
                    Color = cboColor.SelectedItem.ToString(),
                    CantPuertas = int.Parse(cboCantPuertas.SelectedItem.ToString()),
                    Año = txtAño.Text.Trim(),
                    NumChasis = txtNumChasis.Text.Trim(),
                    NumSerie = txtNumSerie.Text.Trim(),
                    Foto1 = Foto1,
                    Foto2 = Foto2,
                    Foto3 = Foto3,
                    Foto4 = Foto4,
                };

                VehiculoGuardado = vehiculo;
                result = ServicioVehiculo.Create(VehiculoGuardado);
            }
            else
            {
                VehiculoGuardado.Patente = txtPatente.Text.Trim();
                VehiculoGuardado.Marca.IdMarca = ((Marca)cboMarca.SelectedItem).IdMarca;
                VehiculoGuardado._TipoUso.IdTipoUso = ((TipoUso)cboTipoUso.SelectedItem).IdTipoUso;
                VehiculoGuardado.Modelo.IdModelo = ((Modelo)cboModelo.SelectedItem).IdModelo;
                VehiculoGuardado.Combustible = cboCombustible.SelectedItem.ToString();
                VehiculoGuardado.Color = cboColor.SelectedItem.ToString();
                VehiculoGuardado.CantPuertas = int.Parse(cboCantPuertas.SelectedItem.ToString());
                VehiculoGuardado.Año = txtAño.Text.Trim();
                VehiculoGuardado.NumChasis = txtNumChasis.Text.Trim();
                VehiculoGuardado.NumSerie = txtNumSerie.Text.Trim();
                VehiculoGuardado.Foto1 = Foto1;
                VehiculoGuardado.Foto2 = Foto2;
                VehiculoGuardado.Foto3 = Foto3;
                VehiculoGuardado.Foto4 = Foto4;

                result = ServicioVehiculo.Update(VehiculoGuardado);
            }

            return result;

        }

        private bool GuardarDatosCliente()
        {
            var result = false;

            if (ClienteGuardado == null)
            {
                var cliente = new Cliente()
                {
                    IdCliente = Guid.NewGuid(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Dni = int.Parse(txtDni.Text),
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Email = txtEmail.Text.Trim(),
                    Sexo = rdbSexo.Checked ? "Hombre" : "Mujer",
                    Domicilio = new Domicilio()
                    {
                        IdDomicilio = Guid.NewGuid(),
                        Direccion = txtDomicilio.Text.Trim(),
                        CodPostal = txtCp.Text.Trim(),
                        Localidad = new Localidad()
                        {
                            IdLocalidad = Guid.Parse(cboLocalidad.SelectedValue.ToString())
                        },
                        Provincia = new Provincia()
                        {
                            IdProvincia = Guid.Parse(cboProvincia.SelectedValue.ToString())
                        },
                    },
                    Estado = true,
                    Contacto = new Contacto()
                    {
                        IdContacto = Guid.NewGuid(),
                        Celular = txtCelular.Text.Trim(),
                        Telefono = txtTelFijo.Text.Trim()
                    }
                };

                ClienteGuardado = cliente;
                result = ServicioCliente.Create(ClienteGuardado);
            }
            else
            {
                ClienteGuardado.Nombre = txtNombre.Text.Trim();
                ClienteGuardado.Apellido = txtApellido.Text.Trim();
                ClienteGuardado.Dni = int.Parse(txtDni.Text);
                ClienteGuardado.FechaNacimiento = dtpFechaNacimiento.Value;
                ClienteGuardado.Email = txtEmail.Text.Trim();
                ClienteGuardado.Sexo = rdbSexo.Checked ? "Hombre" : "Mujer";
                ClienteGuardado.Domicilio.Direccion = txtDomicilio.Text.Trim();
                ClienteGuardado.Domicilio.CodPostal = txtCp.Text.Trim();
                ClienteGuardado.Domicilio.Localidad.IdLocalidad = Guid.Parse(cboLocalidad.SelectedValue.ToString());
                ClienteGuardado.Domicilio.Provincia.IdProvincia = Guid.Parse(cboProvincia.SelectedValue.ToString());
                ClienteGuardado.Contacto.Celular = txtCelular.Text.Trim();
                ClienteGuardado.Contacto.Telefono = txtTelFijo.Text.Trim();

                result = ServicioCliente.Update(ClienteGuardado);
            }


            return result;
        }

        private bool GuardarDatosFactura()
        {
            var factura = new Factura()
            {
                IdFactura = Guid.NewGuid(),
                NumeroCuota = int.Parse(txtNumCuotaFac.Text.Trim()),
                NumeroFactura = int.Parse(txtNumFactura.Text.Trim()),
                Vencimiento = dtpFechaNacimiento.Value,
                Estado = true,
                Paga = false,
                Poliza = PolizaGuardada,
                DetalleFactura = new DetalleFactura()
                {
                    IdDetalle = Guid.NewGuid(),
                    Vehiculo = VehiculoGuardado,
                    Cliente = ClienteGuardado,
                    Importe = decimal.Parse(txtImporteFac.Text.Trim())
                }
            };

            FacturaGuardada = factura;

            return ServicioFactura.Create(factura);
        }

        private void PolizaWizard_Enter(object sender, EventArgs e)
        {
        }

        private void wizardControl_Enter(object sender, EventArgs e)
        {
            //this.wizardControl.Dispose();
            //InitializeComponent();
        }

        private void wizardControl_Finished(object sender, EventArgs e)
        {
            //Arrancarlo en el primer wizard
            if (wizardControl.SelectedPage == wizardFactura)
            {
                this.wizardControl.SelectedPage.NextPage = this.wizardInicio;
            }
        }

        private void wizardControl_Cancelling(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RestablecerControles(true);
            this.wizardControl.SelectedPage.NextPage = this.wizardInicio;
        }

        private void btnCobrarFac_Click(object sender, EventArgs e)
        {
            if (FacturaGuardada != null)
            {
                CobrarFactura.ShowDialog();
            }
            else
            {
                var confirmResult = MessageBox.Show(
                    "Primero debe guardar todos los datos de la póliza. Confirma la operacion?",
                    "Confirme alta de póliza",
                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    if (SavePolicy())
                        CobrarFactura.ShowDialog();
                    return;
                }
            }
        }

        public Factura FacturaAAbonar()
        {
            return FacturaGuardada;
        }

        private Bitmap bmp;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void btnImprimirFac_Click(object sender, EventArgs e)
        {
            if (FacturaGuardada != null)
            {
                ImprimirFactura();
            }
            else
            {
                var confirmResult = MessageBox.Show(
                    "Primero debe guardar todos los datos de la póliza. Confirma la operacion?",
                    "Confirme alta de póliza",
                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    if (SavePolicy())
                        ImprimirFactura();
                    return;
                }
            }

        }

        private void ImprimirFactura()
        {
            if (!string.IsNullOrEmpty(txtNumFactura.Text.Trim()) && !string.IsNullOrEmpty(txtImporteFac.Text.Trim()))
            {
                Graphics g = this.CreateGraphics();
                bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
                Graphics mg = Graphics.FromImage(bmp);
                mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe completar todos los datos de la factura para poder imprimir.");
            }
        }

        private void cboTransaccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTransaccion.SelectedIndex == 1 || cboTransaccion.SelectedIndex == 2)
            {
                //Es una modificacion de póliza
                txtNumeroPoliza.Text = string.Empty;
                txtNumeroPoliza.Enabled = true;
                cboTipoPoliza.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
            else
            {
                txtNumeroPoliza.Text = TraerNumeroDePoliza().ToString();
                txtNumeroPoliza.Enabled = false;
                cboTipoPoliza.Enabled = true;
                dateTimePicker1.Enabled = true;
            }
        }

        private void txtNumeroPoliza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (ClienteGuardado != null)
            {
                var confirmResult = MessageBox.Show(
                    "Al eliminar el cliente automáticamente se anulará la póliza. Confirma la operacion?",
                    "Confirme anulación de póliza",
                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    ClienteGuardado.Estado = false;
                    if (GuardarDatosCliente())
                    {
                        PolizaGuardada.Estado = false;
                        GuardarDatosPoliza();
                        RestablecerControles(true);
                        this.wizardControl.SelectedPage.NextPage = this.wizardInicio;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al tratar de dar de baja el cliente. " +
                                        "Por favor contacte al Administrador.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay ningun cliente a borrar.");
            }
        }

        private void lblEliminarVehiculo_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarVehiculo_Click(object sender, EventArgs e)
        {
            if (VehiculoGuardado != null)
            {
                var confirmResult = MessageBox.Show(
                    "Al eliminar el vehículo, automáticamente se anulará la póliza. Confirma la operacion?",
                    "Confirme anulación de póliza",
                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    ClienteGuardado.Estado = false;
                    if (GuardarDatosCliente())
                    {
                        PolizaGuardada.Estado = false;
                        GuardarDatosPoliza();
                        RestablecerControles(true);
                        this.wizardControl.SelectedPage.NextPage = this.wizardInicio;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al tratar de dar de baja el vehículo. " +
                                        "Por favor contacte al Administrador.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay ningun vehículo a borrar.");
            }
        }
    }
}
