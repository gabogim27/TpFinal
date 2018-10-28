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
using BLL;
using BLL.Interfaces;
using DAL.Repositorios;
using SSTIS.Interfaces;

namespace SSTIS
{
    public partial class NuevoUsuario : Form, INuevoUsuario
    {
        public IServicio<Usuario> ServicioUsuario { get; set; }
        public IServicio<Localidad> ServicioLocalidad;
        public IServicio<Provincia> ServicioProvincia { get; set; }
        public IServicioUsuario ServicioUsuarioImplementor;
        public IServicioLocalidad ServicioLocalidadImplementor;

        public NuevoUsuario(IServicio<Usuario> servicioUsuario, IServicio<Localidad> servicioLocalidad,
            IServicio<Provincia> servicioProvincia, IServicioUsuario servicioUsuarioImplementor,
            IServicioLocalidad servicioLocalidadImplementor)
        {
            this.ServicioUsuario = servicioUsuario;
            this.ServicioLocalidad = servicioLocalidad;
            this.ServicioProvincia = servicioProvincia;
            this.ServicioUsuarioImplementor = servicioUsuarioImplementor;
            this.ServicioLocalidadImplementor = servicioLocalidadImplementor;
            InitializeComponent();
        }
       
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
                {
                    var mailValido = ServicioUsuarioImplementor.ValidarEmail(txtEmail.Text.Trim());
                    if (!mailValido)
                    {
                        MessageBox.Show("El e-mail ingresado esta en formato incorrecto. Por favor corrijalo!!!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un E-mail");
                    return;
                }

                if (!string.IsNullOrEmpty(txtNombre.Text.Trim()) && !string.IsNullOrEmpty(txtApellido.Text.Trim()) &&
                    !string.IsNullOrEmpty(txtDomicilio.Text.Trim()) && !string.IsNullOrEmpty(txtCelular.Text.Trim()) &&
                    !string.IsNullOrEmpty(txtTelFijo.Text.Trim()) && cboLocalidad.SelectedIndex != -1 &&
                    cboProvincia.SelectedIndex != -1)
                {
                    var nuevoUsuario = new BE.Usuario();

                    var sexo = "";
                    var isChecked = rdbSexo.Checked;
                    if (isChecked)
                        sexo = rdbSexo.Text;
                    else
                        sexo = rdbSexo2.Text;
                    nuevoUsuario.Nombre = txtNombre.Text;
                    nuevoUsuario.Apellido = txtApellido.Text;
                    nuevoUsuario.Email = txtEmail.Text;
                    nuevoUsuario.Domicilio = new BE.Domicilio();
                    nuevoUsuario.Domicilio.Direccion = txtDomicilio.Text;
                    nuevoUsuario.Domicilio.CodPostal = txtCp.Text.Trim();
                    nuevoUsuario.Contacto = new BE.Contacto();
                    nuevoUsuario.Contacto.Celular = txtCelular.Text;
                    nuevoUsuario.Contacto.Telefono = txtTelFijo.Text;
                    nuevoUsuario.Sexo = sexo;
                    nuevoUsuario.Domicilio.Localidad = new BE.Localidad();
                    nuevoUsuario.Domicilio.Localidad.IdLocalidad = Guid.Parse(cboLocalidad.SelectedValue.ToString());
                    nuevoUsuario.Domicilio.Provincia = new Provincia();
                    nuevoUsuario.Domicilio.Provincia.IdProvincia = Guid.Parse(cboProvincia.SelectedValue.ToString());
                    this.ServicioUsuario.Create(nuevoUsuario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor verifique los datos ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboProvincia()
        {
            //Retrieve provincias
            var provincias = ServicioProvincia.Retrive();
            cboProvincia.DataSource = provincias;
            cboProvincia.DisplayMember = "Descripcion";
            cboProvincia.ValueMember = "IdProvincia";
        }

        private void NuevoUsuario_Load(object sender, EventArgs e)
        {
            cboLocalidad.Enabled = false;
            CargarComboProvincia();
            cboProvincia.SelectedIndex = -1;
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {            
        }

        private void cboProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cboLocalidad.Enabled = true;
            var selectedProvincia = Guid.Parse(cboProvincia.SelectedValue.ToString());
            var localidadesByProvinciaId = ServicioLocalidadImplementor.GetLocalidadesByProvinciaId(selectedProvincia);
            cboLocalidad.DataSource = localidadesByProvinciaId;
            cboLocalidad.DisplayMember = "Descripcion";
            cboLocalidad.ValueMember = "IdLocalidad";
            cboLocalidad.SelectedIndex = -1;
        }
    }
}
