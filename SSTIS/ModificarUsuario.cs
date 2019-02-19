using System;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL.Interfaces;
using DAL.Interfaces;
using SSTIS.Interfaces;

namespace SSTIS
{
    public partial class ModificarUsuario : Form, IModificarUsuario
    {
        public IServicio<Usuario> ServicioUsuario { get; set; }
        public IServicio<Localidad> ServicioLocalidad { get; set; }
        public IServicio<Provincia> ServicioProvincia { get; set; }
        public IServicioLocalidad ServicioLocalidadImplementor;
        public IServicioUsuario ServicioUsuarioImplementor;
        private IDigitoVerificador DigitoVerificador;
        public const string Key = "bZr2URKx";
        public const string Iv = "HNtgQw0w";
        private const string Entidad = "Usuario";

        public ModificarUsuario(IServicio<Usuario> ServicioUsuario,
            IServicio<Localidad> ServicioLocalidad,
            IServicio<Provincia> ServicioProvincia,
            IServicioLocalidad ServicioLocalidadImplementor,
            IDigitoVerificador DigitoVerificador, IServicioUsuario ServicioUsuarioImplementor)
        {
            this.ServicioUsuario = ServicioUsuario;
            this.ServicioLocalidad = ServicioLocalidad;
            this.ServicioProvincia = ServicioProvincia;
            this.ServicioLocalidadImplementor = ServicioLocalidadImplementor;
            this.DigitoVerificador = DigitoVerificador;
            this.ServicioUsuarioImplementor = ServicioUsuarioImplementor;
            InitializeComponent();
        }

        private Usuario UsuarioSeleccionado = new Usuario();

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (UsuarioSeleccionado != null)
            {
                if (ValidarDatosIngresados())
                {
                    //VALIDAR LOS CAMPOS DE DOMICILIO
                    if (string.IsNullOrEmpty(txtDomicilio.Text.Trim()) || string.IsNullOrEmpty(txtCp.Text.Trim()) ||
                        cboLocalidad.SelectedIndex == -1 || cboProvincia.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe completar todos los datos del domicilio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    UpdatePropertiesToUser();
                    var usuarios = ServicioUsuario.Retrive();
                    usuarios.RemoveAll(x => x.IdUsuario == UsuarioSeleccionado.IdUsuario);

                    if (usuarios.Any(x => x.Email == UsuarioSeleccionado.Email))
                    {
                        MessageBox.Show("E-mail ya existente.");
                        return;
                    }

                    if (ServicioUsuario.Update(UsuarioSeleccionado))
                    {
                        if (DigitoVerificador.ComprobarPrimerDigito(DigitoVerificador.Entidades.Find(x => x.ToUpper() == Entidad.ToUpper())))
                        {
                            DigitoVerificador.InsertarDVVertical(DigitoVerificador.Entidades.Find(x => x.ToUpper() == Entidad.ToUpper()));
                        }
                        else
                        {
                            DigitoVerificador.ActualizarDVVertical(DigitoVerificador.Entidades.Find(x => x.ToUpper() == Entidad.ToUpper()));
                        }

                        MessageBox.Show("Usuario actualizado correctamente");

                        DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("Por favor verifique los datos ingresados.", "Error",
                        MessageBoxButtons.OK);
                }
            }
            else
            {
                RestablecerControles();
                MessageBox.Show("Ocurrio un error al actualizar los datos del usuario.", "Error",
                    MessageBoxButtons.OK);
            }

            return;
        }

        private void UpdatePropertiesToUser()
        {
            UsuarioSeleccionado.Nombre = txtNombre.Text.Trim();
            UsuarioSeleccionado.Apellido = txtApellido.Text.Trim();
            UsuarioSeleccionado.Email = txtEmail.Text.Trim();
            UsuarioSeleccionado.Domicilio.Direccion = txtDomicilio.Text.Trim();
            UsuarioSeleccionado.Domicilio.CodPostal = txtCp.Text.Trim();
            UsuarioSeleccionado.Contacto.Telefono = txtTelFijo.Text.Trim();
            UsuarioSeleccionado.Contacto.Celular = txtCelular.Text.Trim();
            if (rdbSexo.Checked)
            {
                UsuarioSeleccionado.Sexo = "Hombre";
            }
            else
            {
                UsuarioSeleccionado.Sexo = "Mujer";
            }
            var localidad = (Localidad)cboLocalidad.SelectedItem;
            UsuarioSeleccionado.Domicilio.Localidad.Descripcion = localidad.Descripcion;
            var provincia = (Provincia)cboProvincia.SelectedItem;
            UsuarioSeleccionado.Domicilio.Provincia.Descripcion = provincia.Descripcion;
        }

        private void ModificarUsuario_Load(object sender, EventArgs e)
        {
            cboLocalidad.Enabled = true;
            CargarComboProvincia();
            UsuarioSeleccionado = Program.simpleInyectorContainer.GetInstance<IABMUsuarios>().usuarioSeleccionado();
            txtNombre.Text = UsuarioSeleccionado.Nombre;
            txtApellido.Text = UsuarioSeleccionado.Apellido;
            txtDomicilio.Text = UsuarioSeleccionado.Domicilio.Direccion;
            txtCelular.Text = UsuarioSeleccionado.Contacto.Celular;
            txtTelFijo.Text = UsuarioSeleccionado.Contacto.Telefono;
            txtCp.Text = UsuarioSeleccionado.Domicilio.CodPostal;
            txtEmail.Text = UsuarioSeleccionado.Email;
            if (UsuarioSeleccionado.Sexo == "Hombre")
            {
                rdbSexo.Checked = true;
            }
            else
            {
                rdbSexo2.Checked = true;
            }
            cboProvincia.SelectedIndex = cboProvincia.FindString(UsuarioSeleccionado.Domicilio.Provincia.Descripcion);
            LlenarComboLocalidadesPorProvinciaId(UsuarioSeleccionado.Domicilio.Provincia.IdProvincia);
            cboLocalidad.SelectedIndex = cboLocalidad.FindString(UsuarioSeleccionado.Domicilio.Localidad.Descripcion);
        }

        private bool ValidarDatosIngresados()
        {
            var returnValue = true;
            //Verificamos todos los controles de tipo textbox
            foreach (TextBox tb in Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(tb.Text.Trim()))
                {
                    MessageBox.Show("Todos los datos deben estar completos");
                    returnValue = false;
                    break;
                }
            }
            //Verificamois todos los controles de tipo combo
            foreach (ComboBox tb in Controls.OfType<ComboBox>())
            {
                if (tb.SelectedIndex < -1)
                {
                    MessageBox.Show("Por favor elija una Provincia y Localidad");
                    returnValue = false;
                    break;
                }
            }
            //Verificamos que se haya ingresado un mail valido
            if (!ServicioUsuarioImplementor.ValidarEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("El e-mail ingresado esta en formato incorrecto. Por favor corrijalo!!!");
                returnValue = false;
            }

            return returnValue;
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

        private void RestablecerControles()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtCp.Text = string.Empty;
            txtDomicilio.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelFijo.Text = string.Empty;
            cboProvincia.SelectedIndex = -1;
            cboLocalidad.SelectedIndex = -1;
            cboLocalidad.Enabled = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
