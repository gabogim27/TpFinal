using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL.Interfaces;
using SSTIS.Interfaces;
using SSTIS.Utils;

namespace SSTIS
{
    public partial class Login : Form, ILogin
    {
        public IServicio<Usuario> ServicioUsuario { get; set; }
        public IServicioUsuario ServicioUsuarioImplementor { get; set; }
        public IPrincipal Principal;

        public Login(IServicio<Usuario> servicioUsuario, IServicioUsuario servicioUsuarioImplementor, IPrincipal principal)
        {
            this.ServicioUsuario = servicioUsuario;
            this.ServicioUsuarioImplementor = servicioUsuarioImplementor;
            this.Principal = principal;
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        protected override bool ProcessCmdKey(ref Message mensaje, Keys KeyData)
        {
            if (KeyData == Keys.F1)
            {
                Help.ShowHelp(this, "C:\\TPFinalDiploma\\TpFinal\\SSTIS\\Ayuda\\Manual de Usuario.chm");
            }

            return true;
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string contraseña = txtContrasenia.Text;
            var usuarioActivo = ServicioUsuarioImplementor.ObtenerUsuarioConEmail(email);

            if (ServicioUsuarioImplementor.LogIn(email, contraseña))
            {
                LoginInfo.Usuario = usuarioActivo;
                this.Hide();
                Principal.Show();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al loguearse. Por favor verifique los datos ingresados");
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
