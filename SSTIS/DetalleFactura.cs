using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL.Interfaces;
using SSTIS.Interfaces;

namespace SSTIS
{
    public partial class DetalleFactura : Form, IDetalleFactura
    {
        private List<Factura> FacturaBD;
        private List<DetalleFacturaUI> DetalleUI;
        private IServicio<Factura> ServicioFactura;

        public DetalleFactura(IServicio<Factura> ServicioFactura)
        {
            this.ServicioFactura = ServicioFactura;
            InitializeComponent();
        }

        private void DetalleFactura_Load(object sender, EventArgs e)
        {
            FacturaBD= new List<Factura>();
            DetalleUI = new List<DetalleFacturaUI>();
            TraerFacturas();
            MapFacturaWithDetalleUI();
            CargarGrilla();
        }

        private void TraerFacturas()
        {
            FacturaBD = ServicioFactura.Retrive().ToList();
        }

        private void MapFacturaWithDetalleUI()
        {
            DetalleUI.Clear();

            foreach (var fac in FacturaBD)
            {
                var detalle = new DetalleFacturaUI();
                detalle.NumeroFactura = fac.NumeroFactura;
                detalle.Estado = fac.Estado ? "Generada" : "Anulada";
                detalle.Cliente = fac.DetalleFactura.Cliente.Nombre + " " + fac.DetalleFactura.Cliente.Apellido;
                detalle.NumeroCuota = fac.NumeroCuota.ToString();
                detalle.Importe = fac.DetalleFactura.Importe.ToString();
                detalle.Paga = fac.Paga ? "Abonada" : "Sin abonar";
                detalle.Vencimiento = fac.Vencimiento.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                detalle.Poliza = fac.Poliza.NroPoliza.ToString();
                detalle.Vehiculo = fac.DetalleFactura.Vehiculo.Patente;

                DetalleUI.Add(detalle);
            }
        }

        private void CargarGrilla()
        {
            dgvFacturas.DataSource = null;
            dgvFacturas.DataSource = DetalleUI;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumFac.Text.Trim()))
            {
                //ClienteBD.Clear();
                var facturaEncontrada =
                    FacturaBD.FirstOrDefault(x => x.NumeroFactura == int.Parse(txtNumFac.Text.Trim()));
                if (facturaEncontrada != null)
                {
                    FacturaBD.Clear();
                    FacturaBD.Add(facturaEncontrada);
                    MapFacturaWithDetalleUI();
                }
                else
                {
                    DetalleUI.Clear();
                    MessageBox.Show("Factura inexistente.");
                }

                CargarGrilla();
            }
            else
            {
                MessageBox.Show("Por favor ingrese un Número de factura.");
            }
        }

        private void DetalleFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void llQuitar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TraerFacturas();
            MapFacturaWithDetalleUI();
            CargarGrilla();
        }

        private void txtNumFac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
    }

    internal class DetalleFacturaUI
    {
        public int NumeroFactura { get; set; }
        public string NumeroCuota { get; set; }
        public string Estado { get; set; }
        public string Paga { get; set; }
        public string Importe { get; set; }
        public string Vencimiento { get; set; }
        public string Cliente { get; set; }
        public string Poliza { get; set; }
        public string Vehiculo { get; set; }
    }
}
