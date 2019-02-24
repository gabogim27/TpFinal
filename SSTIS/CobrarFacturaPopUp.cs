using System;
using System.Windows.Forms;
using BE;
using BLL.Interfaces;
using SSTIS.Interfaces;

namespace SSTIS
{
    public partial class CobrarFacturaPopUp : Form, ICobrarFactura
    {

        private IServicio<Factura> ServicioFactura;
        private Factura FacturaAAbonar;

        public CobrarFacturaPopUp(IServicio<Factura> ServicioFactura)
        {
            this.ServicioFactura = ServicioFactura;
            InitializeComponent();
        }

        private void btnCobrarAceptar_Click(object sender, EventArgs e)
        {
            if (ServicioFactura.Update(FacturaAAbonar))
            {
                MessageBox.Show("Cobro efectuado correctamente.");
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCobrarCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void CobrarFacturaPopUp_Load(object sender, EventArgs e)
        {
            FacturaAAbonar = Program.simpleInyectorContainer.GetInstance<IPolizaWizard>().FacturaAAbonar();
            txtMontoACobrar.Text = FacturaAAbonar.DetalleFactura.Importe.ToString();
        }

        private void CobrarFacturaPopUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
