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

namespace SSTIS
{
    public partial class JustificacionPopUp : Form, IJustificacionPopUp
    {
        private Poliza PolizaSeleccionada = null;
        private IServicioPoliza ServicioPolizaImplementor;

        public JustificacionPopUp(IServicioPoliza ServicioPolizaImplementor)
        {
            this.ServicioPolizaImplementor = ServicioPolizaImplementor;
            InitializeComponent();
        }

        private void JustificacionPopUp_Load(object sender, EventArgs e)
        {
            PolizaSeleccionada = Program.simpleInyectorContainer.GetInstance<IDetallePoliza>().polizaSeleccionada();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtJustificacion.Text.Trim()))
            {
                PolizaSeleccionada.Estado = false;
                PolizaSeleccionada.Justificacion = txtJustificacion.Text.Trim();

                if (ServicioPolizaImplementor.ActualizarAprobacion(PolizaSeleccionada))
                {
                    MessageBox.Show("Poliza rechazada correctamente.");
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al rechazar la póliza.");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar una justificacion de rechazo.");
            }
        }
    }
}
