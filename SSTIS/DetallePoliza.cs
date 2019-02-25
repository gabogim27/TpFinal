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
    public partial class DetallePoliza : Form, IDetallePoliza
    {
        private IServicioPoliza ServicioPolizaImplementor;
        private List<Poliza> PolizaBD { get; set; }
        private List<PolizaUI> PolizaUI { get; set; }
        private DetallePolizaUI DetalleUI { get; set; }
        private List<DetallePolizaUI> Lista { get; set; }
        private IJustificacionPopUp JustificacionPopUp;

        public DetallePoliza(IServicioPoliza ServicioPolizaImplementor, IJustificacionPopUp JustificacionPopUp)
        {
            this.ServicioPolizaImplementor = ServicioPolizaImplementor;
            this.JustificacionPopUp = JustificacionPopUp;
            InitializeComponent();
        }

        private void btnBuscarPoliza_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumeroPolizaBuscar.Text.Trim()))
            {
                PolizaBD.Clear();
                var polizaEncontrada =
                    ServicioPolizaImplementor.TraerPolizaPorNumero(int.Parse(txtNumeroPolizaBuscar.Text.Trim()));
                if (polizaEncontrada != null)
                {
                    PolizaBD.Add(polizaEncontrada);
                    MapPolizaWithPolizaUI();
                }
                else
                {
                    PolizaUI.Clear();
                    MessageBox.Show("Póliza inexistente");
                }

                CargarGrillaPoliza();
            }
            else
            {
                MessageBox.Show("Por favor ingrese un número de póliza");
            }
        }

        private void DetallePoliza_Load(object sender, EventArgs e)
        {
            PolizaBD = new List<Poliza>();
            PolizaUI = new List<PolizaUI>();
            DetalleUI = new DetallePolizaUI();
            Lista = new List<DetallePolizaUI>();
            TraerPolizas();
            MapPolizaWithPolizaUI();
            CargarGrillaPoliza();
        }

        private void CargarGrillaPoliza()
        {
            dgvPolizas.DataSource = null;
            dgvPolizas.DataSource = PolizaUI;
        }

        private void TraerPolizas()
        {
            PolizaBD = ServicioPolizaImplementor.Retrive().ToList();
        }

        private void MapPolizaWithPolizaUI()
        {
            PolizaUI.Clear();
            //Refrescar el listado
            TraerPolizas();
            foreach (var poliza in PolizaBD)
            {
                var polizaUI = new PolizaUI();
                polizaUI.NroPoliza = poliza.NroPoliza;
                polizaUI.Estado = !poliza.Estado.HasValue ? "En emisión" : (poliza.Estado.Value ? "Aprobada" : "Anulada");
                polizaUI.FechaEmision = poliza.FechaEmision.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                polizaUI.Nombre = poliza.Cliente.Nombre;
                polizaUI.Apellido = poliza.Cliente.Apellido;
                polizaUI.Email = poliza.Cliente.Email;
                polizaUI.Dni = poliza.Cliente.Dni;

                PolizaUI.Add(polizaUI);                
            }
        }

        private void txtNumeroPolizaBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void MapPolizaWithDetalleUI(int numeroPoliza)
        {
            var poliza = PolizaBD.FirstOrDefault(x => x.NroPoliza == numeroPoliza);

            var coberturas = poliza.Detalle.Coberturas.Select(x => x.Descripcion).ToList();

            var cobertura = new StringBuilder();

            for (var i = 0; i < coberturas.Count; i++)
            {
                cobertura.Append(coberturas[i]);
                cobertura.AppendLine();
            }

            DetalleUI.Coberturas = cobertura.ToString();
            DetalleUI.SumaAsegurada = poliza.Detalle.SumaAsegurada;
            DetalleUI.Prima = poliza.Detalle.Prima;
            DetalleUI.Año = poliza.Detalle.Vehiculo.Año;
            DetalleUI.CantPuertas = poliza.Detalle.Vehiculo.CantPuertas;
            DetalleUI.Color = poliza.Detalle.Vehiculo.Color;
            DetalleUI.Combustible = poliza.Detalle.Vehiculo.Combustible;
            DetalleUI.Marca = poliza.Detalle.Vehiculo.Marca.Descripcion;
            DetalleUI.Modelo = poliza.Detalle.Vehiculo.Modelo.Descripcion;
            DetalleUI._TipoUso = poliza.Detalle.Vehiculo._TipoUso.Descripcion;
            DetalleUI.NumChasis = poliza.Detalle.Vehiculo.NumChasis;
            DetalleUI.NumSerie = poliza.Detalle.Vehiculo.NumSerie;
            DetalleUI.Patente = poliza.Detalle.Vehiculo.Patente;

            Lista.Add(DetalleUI);
        }

        private void dgvPolizas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPolizas.SelectedRows.Count > 0)
            {
                DetalleUI = new DetallePolizaUI();
                Lista.Clear();
                var polizaSeleccionada = (PolizaUI)dgvPolizas.CurrentRow.DataBoundItem;
                MapPolizaWithDetalleUI(polizaSeleccionada.NroPoliza);
                CargarGrillaDetalle();
            }
            else
            {
                MessageBox.Show("Seleccione un item de la grilla.");
            }
        }

        private void CargarGrillaDetalle()
        {
            dgvDetalle.DataSource = null;
            dgvDetalle.AutoGenerateColumns = true;
            //dgvDetalle.DataSource = DetalleUI;
            dgvDetalle.DataSource = Lista;
        }

        private void DetallePoliza_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            if (dgvPolizas.SelectedRows.Count > 0)
            {
                if (polizaSeleccionada() != null)
                {
                    if (polizaSeleccionada().Estado.HasValue && polizaSeleccionada().Estado.Value)
                    {
                        MessageBox.Show("La póliza ya se encuentra aprobada.");
                        return;
                    }

                    var p = polizaSeleccionada();

                    p.Estado = true;

                    if (ServicioPolizaImplementor.ActualizarAprobacion(p))
                    {
                        MessageBox.Show("Poliza aprobada correctamente.");
                        MapPolizaWithPolizaUI();
                        CargarGrillaPoliza();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al actualizar la póliza seleccionada.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una póliza.");
            }
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (dgvPolizas.SelectedRows.Count > 0)
            {
                if (polizaSeleccionada() != null && (!polizaSeleccionada().Estado.HasValue || !polizaSeleccionada().Estado.Value))
                {
                    JustificacionPopUp.ShowDialog();
                    MapPolizaWithPolizaUI();
                    CargarGrillaPoliza();
                }
                else if (polizaSeleccionada() != null &&
                         (polizaSeleccionada().Estado.HasValue || polizaSeleccionada().Estado.Value))
                {
                    MessageBox.Show("No se puede rechazar una póliza que ya fué aprobada. Para darla de baja debe ir al modulo de emisión y anularla.");
                }
                else
                {
                    MessageBox.Show("La póliza ya se encuentra anulada.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una póliza.");
            }
        }

        public Poliza polizaSeleccionada()
        {
            var polSelec = (PolizaUI)dgvPolizas.CurrentRow.DataBoundItem;
            return ServicioPolizaImplementor.TraerPolizaPorNumero(polSelec.NroPoliza);
        }

        private void llQuitar_Click(object sender, EventArgs e)
        {
            TraerPolizas();
            MapPolizaWithPolizaUI();
            CargarGrillaPoliza();
        }
    }

    internal class PolizaUI
    {
        public int NroPoliza { get; set; }
        public string Estado { get; set; }
        public string FechaEmision { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
    }

    internal class DetallePolizaUI
    {
        //Coberturas
        public decimal Prima { get; set; }
        public decimal SumaAsegurada { get; set; }
        public string Coberturas { get; set; }
        //Vehiculo
        public string _TipoUso { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CantPuertas { get; set; }
        public string Color { get; set; }
        public string Combustible { get; set; }
        public string NumChasis { get; set; }
        public string NumSerie { get; set; }
        public string Patente { get; set; }
        public string Año { get; set; }
    }
}
