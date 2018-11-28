using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Interfaces;
using SSTIS.Interfaces;
using SSTIS.Utils;

namespace SSTIS
{
    public partial class frmCambiarContraseña : Form, ICambiarContraseña
    {
        private IServicioUsuario ServicioUsuarioImplementor;

        public frmCambiarContraseña(IServicioUsuario ServicioUsuarioImplementor)
        {
            this.ServicioUsuarioImplementor = ServicioUsuarioImplementor;
            InitializeComponent();
        }

        private void frmCambiarContraseña_Load(object sender, EventArgs e)
        {
            CargaInicial();
        }

        private void CargaInicial()
        {
            txtNueva.Text = string.Empty;
            txtConfirmeNueva.Text = String.Empty;
            
        }

        private void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            if (txtNueva.Text.Trim() == txtConfirmeNueva.Text.Trim())
            {
                var cambioExitoso = ServicioUsuarioImplementor.CambiarContraseña(LoginInfo.Usuario, txtNueva.Text.Trim(), true);
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
            else
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void frmCambiarContraseña_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void frmCambiarContraseña_Enter(object sender, EventArgs e)
        {
            CargaInicial();
        }
    }
}
