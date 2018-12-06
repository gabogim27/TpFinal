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

        private decimal CantidadSumaAsegurada;

        public PolizaWizard(IServicioPoliza ServicioPolizaImplementor, IServicioUsuario ServicioUsuarioImplementor,
            IServicioLocalidad ServicioLocalidadImplementor, IServicio<Localidad> ServicioLocalidad, IServicio<Provincia> ServicioProvincia,
            IServicio<Cliente> ServicioCliente, IServicioVehiculo ServicioVehiculoImplementor)
        {
            this.ServicioUsuarioImplementor = ServicioUsuarioImplementor;
            this.ServicioPolizaImplementor = ServicioPolizaImplementor;
            this.ServicioLocalidadImplementor = ServicioLocalidadImplementor;
            this.ServicioLocalidad = ServicioLocalidad;
            this.ServicioProvincia = ServicioProvincia;
            this.ServicioCliente = ServicioCliente;
            this.ServicioVehiculoImplementor = ServicioVehiculoImplementor;
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
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"; ;
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
                                btnBorrarImagen1.Visible = true;
                            }
                            else if (PictureBoxIsNullOrEmpty(pbFoto2))
                            {
                                pbFoto2.Image = new Bitmap(foto);
                                btnBorrarImagen2.Visible = true;
                            }
                            else if (PictureBoxIsNullOrEmpty(pbFoto3))
                            {
                                pbFoto3.Image = new Bitmap(foto);
                                btnBorrarImagen3.Visible = true;
                            }
                            else if (PictureBoxIsNullOrEmpty(pbFoto4))
                            {
                                pbFoto4.Image = new Bitmap(foto);
                                btnBorrarImagen4.Visible = true;
                            }
                            else
                            {
                                MessageBox.Show("Solo se pueden agregar hasta 4 imágenes");
                            }
                        //}
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
    }
}
