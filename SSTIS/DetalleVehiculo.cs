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
    public partial class DetalleVehiculo : Form, IDetalleVehiculo
    {
        private List<Vehiculo> VehiculoBD;
        private List<VehiculoUI> VehiculoFromUI;
        private IServicio<Vehiculo> ServicioVehiculo;

        public DetalleVehiculo(IServicio<Vehiculo> ServicioVehiculo)
        {
            InitializeComponent();
            this.ServicioVehiculo = ServicioVehiculo;
        }

        private void DetalleVehiculo_Load(object sender, EventArgs e)
        {
            VehiculoBD = new List<Vehiculo>();
            VehiculoFromUI = new List<VehiculoUI>();
            TraerVehiculos();
            MapVehiculoWithVehiculoUI();
            CargarGrilla();
        }

        private void TraerVehiculos()
        {
            VehiculoBD = ServicioVehiculo.Retrive().ToList();
        }

        private void MapVehiculoWithVehiculoUI()
        {
            VehiculoFromUI.Clear();
            TraerVehiculos();
            foreach (var veh in VehiculoBD)
            {
                var vehiculoUI = new VehiculoUI();
                vehiculoUI.Año = veh.Año;
                vehiculoUI.CantPuertas = veh.CantPuertas;
                vehiculoUI.Color = veh.Color;
                vehiculoUI.Combustible = veh.Combustible;
                vehiculoUI.Marca = veh.Marca.Descripcion;
                vehiculoUI.Modelo = veh.Modelo.Descripcion;
                vehiculoUI._TipoUso = veh._TipoUso.Descripcion;
                vehiculoUI.NumChasis = veh.NumChasis;
                vehiculoUI.NumSerie = veh.NumSerie;
                vehiculoUI.Patente = veh.Patente;

                VehiculoFromUI.Add(vehiculoUI);
            }
        }

        private void CargarGrilla()
        {
            dgvVehiculo.DataSource = null;
            dgvVehiculo.DataSource = VehiculoFromUI;
        }

        private void txtPatente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPatente.Text.Trim()))
            {
                //ClienteBD.Clear();
                var vehiculoEncontrado =
                    VehiculoBD.FirstOrDefault(x => x.Patente == txtPatente.Text.Trim());
                if (vehiculoEncontrado != null)
                {
                    VehiculoBD.Clear();
                    VehiculoBD.Add(vehiculoEncontrado);
                    MapVehiculoWithVehiculoUI();
                }
                else
                {
                    VehiculoFromUI.Clear();
                    MessageBox.Show("Vehiculo inexistente");
                }

                CargarGrilla();
            }
            else
            {
                MessageBox.Show("Por favor ingrese una Patente");
            }
        }

        private void llQuitar_Click(object sender, EventArgs e)
        {
            TraerVehiculos();
            MapVehiculoWithVehiculoUI();
            CargarGrilla();
        }

        private void DetalleVehiculo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }

    internal class VehiculoUI
    {
        public string Patente { get; set; }
        public string Año { get; set; }
        public string NumChasis { get; set; }
        public string NumSerie { get; set; }
        public string _TipoUso { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CantPuertas { get; set; }
        public string Color { get; set; }
        public string Combustible { get; set; }
    }
}
