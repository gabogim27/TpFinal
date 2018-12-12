using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using AeroWizard;
using BE;
using BLL.Interfaces;
using SSTIS.Interfaces;
using TextBox = System.Windows.Forms.TextBox;

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

        private decimal CantidadSumaAsegurada;
        private byte[] Foto1 = null;
        private byte[] Foto2 = null;
        private byte[] Foto3 = null;
        private byte[] Foto4 = null;
        private Cliente ClienteGuardado = null;
        private Vehiculo VehiculoGuardado = null;
        private Poliza PolizaGuardada = null;

        public PolizaWizard(IServicioPoliza ServicioPolizaImplementor, IServicioUsuario ServicioUsuarioImplementor,
            IServicioLocalidad ServicioLocalidadImplementor, IServicio<Localidad> ServicioLocalidad,
            IServicio<Provincia> ServicioProvincia,
            IServicio<Cliente> ServicioCliente, IServicioVehiculo ServicioVehiculoImplementor, IServicio<Vehiculo> ServicioVehiculo)
        {
            this.ServicioUsuarioImplementor = ServicioUsuarioImplementor;
            this.ServicioPolizaImplementor = ServicioPolizaImplementor;
            this.ServicioLocalidadImplementor = ServicioLocalidadImplementor;
            this.ServicioLocalidad = ServicioLocalidad;
            this.ServicioProvincia = ServicioProvincia;
            this.ServicioCliente = ServicioCliente;
            this.ServicioVehiculoImplementor = ServicioVehiculoImplementor;
            this.ServicioVehiculo = ServicioVehiculo;
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
            }
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
            if (e.PreviousPage != wizardDatosCliente)
            {
                //Cargar todas las coberturas
                txtPrimaTotal.Enabled = false;
                txtPrimaTotal.Text = string.Empty;
                CargarGrillaCoberturas();
            }

        }

        private void CargarGrillaCoberturas()
        {
            var coberturas = TraerCoberturas();
            //dgvCoberturas.DataSource = null;
            dgvCoberturas.DataSource = coberturas;
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

                if (checkbox.ColumnIndex == 0 && isChecked)
                {
                    CantidadSumaAsegurada += coberturaChequeada.PrimaAsegurada;
                }
                else if (checkbox.ColumnIndex == 0 && !isChecked)
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
        }

        private bool ValidarDatosClienteIngresados()
        {
            var returnValue = true;
            //Verificamos todos los controles de tipo textbox

            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) && string.IsNullOrEmpty(txtApellido.Text.Trim()) &&
                string.IsNullOrEmpty(txtEmail.Text.Trim()) && string.IsNullOrEmpty(txtDni.Text.Trim()) &&
                string.IsNullOrEmpty(txtCelular.Text.Trim()) && string.IsNullOrEmpty(txtCp.Text.Trim()) &&
                string.IsNullOrEmpty(txtDomicilio.Text.Trim()) && string.IsNullOrEmpty(txtTelFijo.Text.Trim()))
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

        }

        private void wizardDatosCliente_Commit(object sender, WizardPageConfirmEventArgs e)
        {
            if (!ValidarDatosClienteIngresados())
            {
                MessageBox.Show("Por favor complete los datos para poder continuar a la siguiente pantalla.");
                e.Cancel = true;
                return;
            }
        }

        private void CargarComboProvincia()
        {
            //Retrieve provincias
            var provincias = ServicioProvincia.Retrive();
            cboProvincia.DataSource = provincias;
            cboProvincia.DisplayMember = "Descripcion";
            cboProvincia.ValueMember = "IdProvincia";
        }

        private void cboProvincia_SelectionChangeCommitted_1(object sender, EventArgs e)
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
            //Initialize controls
            btnBorrarImagen1.Visible = false;
            btnBorrarImagen2.Visible = false;
            btnBorrarImagen3.Visible = false;
            btnBorrarImagen4.Visible = false;
            CargarControlesVehiculo();
            cboModelo.Enabled = false;
        }

        private void wizardDatosVehiculo_Commit(object sender, WizardPageConfirmEventArgs e)
        {
            ValidarDatosVehiculo();
        }

        private void ValidarDatosVehiculo()
        {
            if (string.IsNullOrEmpty(txtPatente.Text.Trim()) && string.IsNullOrEmpty(txtNumSerie.Text.Trim()) &&
                string.IsNullOrEmpty(txtNumChasis.Text.Trim()) && cboTipoUso.SelectedIndex == -1 &&
                cboModelo.SelectedIndex == -1 && cboMarca.SelectedIndex == -1 && cboCombustible.SelectedIndex == -1 &&
                cboColor.SelectedIndex == -1 && cboCantPuertas.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor complete todos los datos del vehículo.");
            }
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
                txtNomYApFac.Text = txtNombre.Text.Trim() + " " + txtApellido.Text.Trim();
                txtDomicilioFac.Text = txtDomicilio.Text.Trim();
                txtNumPolizaFac.Text = txtNumeroPoliza.Text.Trim();
                txtCapitalFac.Text = txtPrimaTotal.Text.Trim();
                if (CoberturasChequeadas())
                {
                    txtSeguroContratadoFac.Text = "Todo Riesgo";
                }
                else
                {
                    txtSeguroContratadoFac.Text = "Terceros Completo";
                }

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
            if (!ValidarControlesFactura())
            {
                var guardadoCliente = GuardarDatosCliente();
                var guardadoVehiculo = GuardarDatosVehiculo();

                if (guardadoCliente && guardadoVehiculo)
                {

                    var guardadoPoliza = GuardarDatosPoliza();
                    if (guardadoPoliza)
                    {
                        MessageBox.Show("Poliza guardada correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al guardar la póliza.");
                    }
                }
            }


        }

        private bool GuardarDatosPoliza()
        {
            var poliza = new Poliza()
            {
                IdPoliza = Guid.NewGuid(),
                Cliente = ClienteGuardado,
                Estado = true,
                NroPoliza = int.Parse(txtNumPolizaFac.Text.Trim()),
                FechaEmision = dtpFechaEmision.Value,
                Detalle = new BE.DetallePoliza()
                {
                    IdDetalle = Guid.NewGuid(),
                    Vehiculo = VehiculoGuardado,
                    Cobertura = new Cobertura() { IdCobertura = TraerCoberturas().First().IdCobertura },
                    Prima = decimal.Parse(txtPrimaTotal.Text),
                    SumaAsegurada = 200000
                },
            };

            PolizaGuardada = poliza;
            return ServicioPolizaImplementor.Create(poliza);
        }

        private bool ValidarControlesFactura()
        {
            return string.IsNullOrEmpty(txtNomYApFac.Text.Trim()) &&
                   string.IsNullOrEmpty(txtDomicilioFac.Text.Trim()) &&
                   string.IsNullOrEmpty(txtSeguroContratadoFac.Text.Trim()) &&
                   string.IsNullOrEmpty(txtNumPolizaFac.Text.Trim()) &&
                   string.IsNullOrEmpty(txtCapitalFac.Text.Trim()) && string.IsNullOrEmpty(txtEstadoFac.Text.Trim()) &&
                   string.IsNullOrEmpty(txtNumFactura.Text.Trim()) &&
                   string.IsNullOrEmpty(txtNumCuotaFac.Text.Trim()) &&
                   string.IsNullOrEmpty(txtImporteFac.Text.Trim());
        }

        private bool GuardarDatosVehiculo()
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

            return ServicioVehiculo.Create(vehiculo);

        }

        private bool GuardarDatosCliente()
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

            return ServicioCliente.Create(cliente);
        }

        private void PolizaWizard_Enter(object sender, EventArgs e)
        {
        }

        private void wizardControl_Enter(object sender, EventArgs e)
        {
            //this.wizardControl.Dispose();
            //InitializeComponent();
        }
    }
}
