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
using DAL.Interfaces;
using SSTIS.Interfaces;

namespace SSTIS
{
    public partial class DetalleCliente : Form, IDetalleCliente
    {
        private IServicio<Cliente> ServicioCliente;
        private List<Cliente> ClienteBD;
        private List<ClienteUI> ClienteFromUI;

        public DetalleCliente(IServicio<Cliente> ServicioCliente)
        {
            this.ServicioCliente = ServicioCliente;
            InitializeComponent();
        }

        private void DetalleCliente_Load(object sender, EventArgs e)
        {
            ClienteBD = new List<Cliente>();
            ClienteFromUI = new List<ClienteUI>();
            TraerClientes();
            MapClienteWithClienteUI();
            CargarGrillaCliente();
        }

        private void TraerClientes()
        {
            ClienteBD = ServicioCliente.Retrive().ToList();
        }

        private void MapClienteWithClienteUI()
        {
            ClienteFromUI.Clear();

            foreach (var cliente in ClienteBD)
            {
                var clienteUI = new ClienteUI();
                clienteUI.Nombre = cliente.Nombre;
                clienteUI.Apellido = cliente.Nombre;
                clienteUI.Dni = cliente.Dni;
                clienteUI.FechaNacimiento = cliente.FechaNacimiento.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                clienteUI.Email = cliente.Email;
                clienteUI.Sexo = cliente.Sexo;
                clienteUI.Domicilio = cliente.Domicilio.Direccion;
                clienteUI.Cp = cliente.Domicilio.CodPostal;
                clienteUI.Provincia = cliente.Domicilio.Provincia.Descripcion;
                clienteUI.Localidad = cliente.Domicilio.Localidad.Descripcion;
                clienteUI.Telefono = cliente.Contacto.Telefono;
                clienteUI.Celular = cliente.Contacto.Celular;

                ClienteFromUI.Add(clienteUI);
            }
        }

        private void CargarGrillaCliente()
        {
            dgvCliente.DataSource = null;
            dgvCliente.DataSource = ClienteFromUI;
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDni.Text.Trim()))
            {
                //ClienteBD.Clear();
                var clienteEncontrado =
                    ClienteBD.FirstOrDefault(x => x.Dni == int.Parse(txtDni.Text.Trim()));
                if (clienteEncontrado != null)
                {
                    ClienteBD.Clear();
                    ClienteBD.Add(clienteEncontrado);
                    MapClienteWithClienteUI();
                }
                else
                {
                    ClienteFromUI.Clear();
                    MessageBox.Show("Cliente inexistente");
                }

                CargarGrillaCliente();
            }
            else
            {
                MessageBox.Show("Por favor ingrese el DNI del cliente");
            }
        }

        private void llQuitar_Click(object sender, EventArgs e)
        {
            TraerClientes();
            MapClienteWithClienteUI();
            CargarGrillaCliente();
        }

        private void DetalleCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }

    internal class ClienteUI
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public string FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Domicilio { get; set; }
        public string Cp { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
    }
}
