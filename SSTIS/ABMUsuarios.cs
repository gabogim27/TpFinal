using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL.Interfaces;

namespace SSTIS
{
    public partial class ABMUsuarios : Form
    {

        public ABMUsuarios(IRepository<Usuario> repository)
        {
            InitializeComponent();
            this.Repository = repository;
        }

        public IRepository<Usuario> Repository { get; set; }

        //public ABMUsuarios()
        //{
        //    InitializeComponent();
        //}

        //public Usuario Usuario {
        //    get
        //    {
        //        var usuario = new Usuario();

        //        return usuario;
        //    }
        //    set
        //    {

        //    };
        //} 

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
                {
                    var mailValido = ValidarEmail(txtEmail.Text);
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

                if (!string.IsNullOrEmpty(txtNombre.Text.Trim()) && !string.IsNullOrEmpty(txtNombre.Text.Trim()) &&
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
                    nuevoUsuario.Contacto = new BE.Contacto();
                    nuevoUsuario.Contacto.Celular = txtCelular.Text;
                    nuevoUsuario.Contacto.Telefono = txtTelFijo.Text;
                    nuevoUsuario.Sexo = sexo;
                    nuevoUsuario.Domicilio.Localidad = new BE.Localidad();
                    nuevoUsuario.Domicilio.Localidad.IdLocalidad = Guid.Parse(cboLocalidad.SelectedValue.ToString());
                    nuevoUsuario.Domicilio.Localidad._Provincia = new Provincia();
                    nuevoUsuario.Domicilio.Localidad._Provincia.IdProvincia = Guid.Parse(cboProvincia.SelectedValue.ToString());
                    this.Repository.Create(nuevoUsuario);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private bool ValidarEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void ABMUsuarios_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        private void CargarCombos()
        {
            //Retrieve provincias
            var provincias = BLL.ProvinciaBLL.Getinstancia().Retrive();
            cboProvincia.DataSource = provincias; 
            cboProvincia.DisplayMember = "Descripcion";
            cboProvincia.ValueMember = "IdProvincia";
            //Retrieve Localidades
            var localidades = BLL.LocalidadBLL.Getinstancia().Retrive();
            cboLocalidad.DataSource = localidades;
            cboLocalidad.DisplayMember = "Descripcion";
            cboLocalidad.ValueMember = "IdLocalidad";
        }
    }
}
