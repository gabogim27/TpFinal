using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL.Interfaces;
using DAL.Utils;
using log4net;
using Microsoft.VisualBasic;
using SSTIS.Interfaces;
using SSTIS.MessageBoxHelper;
using SSTIS.Properties;
using SSTIS.Providers;
using SSTIS.Resources;
using SSTIS.Utils;

namespace SSTIS
{
    public partial class frmLogin : Form, ILogin
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frmLogin));

        public IServicio<Usuario> ServicioUsuario { get; set; }
        public IServicioUsuario ServicioUsuarioImplementor { get; set; }
        public IPrincipal Principal;
        public IServicioIdioma ServicioIdioma;
        public ISessionInfo SesionInfo;
        private static readonly string ResourcesFilePath = "C:\\\\TPFinalDiploma\\\\TpFinal\\\\SSTIS\\\\\\Resources\\\\SpanishResources.resx";
        
        public frmLogin(IServicio<Usuario> servicioUsuario, IServicioUsuario servicioUsuarioImplementor, 
            IPrincipal principal, IServicioIdioma servicioIdioma, ISessionInfo SesionInfo)
        {
            this.ServicioUsuario = servicioUsuario;
            this.ServicioUsuarioImplementor = servicioUsuarioImplementor;
            this.Principal = principal;
            this.ServicioIdioma = servicioIdioma;
            this.SesionInfo = SesionInfo;
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //LIMPIAR EL DICCIONARIO EN LA CARGA DE CADA FORMULARIO YA QUE POR CADA UNO 
            //SE ACTUALIZA CON LAS TRADUCCIONES DE CADA FORM
            CargarCombo();
            this.AcceptButton = btnIngresar;
            cboIdioma.SelectedIndex = 1;//por default le dejamos español
            LimpiarRecursos();
            LoginInfo.LenguajeSeleccionado = (IdiomaUsuario)cboIdioma.SelectedItem;
            GetTraducciones();
            AplicarTraducciones();
        }

        private void CargarCombo()
        {
            var idiomas = ServicioIdioma.GetAllLanguages();
            cboIdioma.DataSource = idiomas;
            cboIdioma.ValueMember = "IdIdioma";
            cboIdioma.DisplayMember = "Descripcion";
        }

        protected override bool ProcessCmdKey(ref Message mensaje, Keys KeyData)
        {
            if (KeyData == Keys.F1)
            {
                Help.ShowHelp(this, "C:\\TPFinalDiploma\\TpFinal\\SSTIS\\Ayuda\\Manual de Usuario.chm");
            }

            return false;
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string contraseña = txtContrasenia.Text;
            var usuarioActivo = ServicioUsuarioImplementor.ObtenerUsuarioConEmail(email);
            var lenguajeSeleccionado = (IdiomaUsuario)cboIdioma.SelectedItem;

            if (txtEmail.Text.Trim() != string.Empty && ControlsUtils.ValidarEmail(txtEmail.Text.Trim()) && 
                !string.IsNullOrEmpty(txtContrasenia.Text.Trim()))
            {
                if (ServicioUsuarioImplementor.LogIn(email, contraseña))
                {
                    LoginInfo.Usuario = usuarioActivo;
                    LoginInfo.LenguajeSeleccionado = lenguajeSeleccionado;
                    SesionInfo.GuardarDatosSesionUsuario(LoginInfo.Usuario);
                    ComprobarSiEsPrimerLogin();
                    this.Hide();
                   
                    Principal.Show();
                }
                else
                {
                    Alert.ShowSimpleAlert("Login Fallido.");
                }
            }
            else
            {
                Alert.ShowAlterWithButtonAndIcon("", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, "MSJ002");
            }
            
        }

        public void ComprobarSiEsPrimerLogin()
        {
            var usu = LoginInfo.Usuario;
            if (usu.PrimerLogin)
            {
                var nuevaContraseña = Interaction.InputBox("Ingrese su nueva contraseña", "Nuevo contraseña", "");
                var cambioExitoso = ServicioUsuarioImplementor.CambiarContraseña(usu, nuevaContraseña, true);
                if (cambioExitoso)
                {
                    //Log.Info("Password Actualizado");
                    MessageBox.Show("Su contraseña fue actualizada");
                }
                else
                {
                    //Log.Info("Fallo la actualizacion del password");
                    MessageBox.Show("Error contraseña no actualizada");
                }
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboIdioma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var lenguajeSeleccionado = (IdiomaUsuario) cboIdioma.SelectedItem;
            LoginInfo.LenguajeSeleccionado = lenguajeSeleccionado;
            //Disposea los recursos
            using (ResXResourceWriter resxWriter = new ResXResourceWriter(ResourcesFilePath))
            {
                resxWriter.Dispose();
            }
            AplicarTraducciones();
        }

        private void AplicarTraducciones()
        {
            LoginInfo.Traducciones.Clear();
            LoginInfo.Traducciones = GetTraducciones();
            IdiomaProvider.FillResources(LoginInfo.Traducciones, LoginInfo.LenguajeSeleccionado.IdIdioma,
                Application.OpenForms[0].Name);
            IdiomaProvider.ReadResources(this.Controls);
        }

        private IDictionary<string, string> GetTraducciones()
        {
            LoginInfo.Traducciones =
                ServicioIdioma.GetTranslationsByLanguageAndForm(Utils.LoginInfo.LenguajeSeleccionado.IdIdioma,
                    Application.OpenForms[0].Name).ToDictionary(k => k.ControlName ?? k.MensajeCodigo, v => v.Traduccion);
            return LoginInfo.Traducciones;
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            LimpiarRecursos();
        }

        private void LimpiarRecursos()
        {
            using (ResXResourceWriter resxWriter = new ResXResourceWriter(ResourcesFilePath))
            {
                resxWriter.Dispose();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (Alert.ConfirmationMessage("MSJ001", "Salir del sistema", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }

        private void txtContrasenia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
    }
}
