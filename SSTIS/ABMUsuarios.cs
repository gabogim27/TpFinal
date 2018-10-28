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
using BLL.Interfaces;
using DAL.Interfaces;
using log4net;
using SSTIS.Interfaces;
using SSTIS.Utils;

namespace SSTIS
{
    public partial class ABMUsuarios : Form, IABMUsuarios
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ABMUsuarios));

        public IServicio<Usuario> ServicioUsuario { get; set; }
        public IServicio<Localidad> ServicioLocalidad { get; set; }
        public IServicio<Provincia> ServicioProvincia { get; set; }
        public IServicioLocalidad ServicioLocalidadImplementor;

        public INuevoUsuario nuevoUsuario { get; set; }

        public ABMUsuarios(IServicio<Usuario> servicioUsuario, INuevoUsuario nuevoUsuario,
            IServicio<Localidad> servicioLocalidad, IServicio<Provincia> servicioProvincia,
            IServicioLocalidad servicioLocalidadImplementor)
        {
            InitializeComponent();
            this.ServicioUsuario = servicioUsuario;
            this.nuevoUsuario = nuevoUsuario;
            this.ServicioLocalidad = servicioLocalidad;
            this.ServicioProvincia = servicioProvincia;
            this.ServicioLocalidadImplementor = servicioLocalidadImplementor;
        }

        //public ABMUsuarios(IRepository<Usuario> repository)
        //{
        //    InitializeComponent();
        //    this.Repository = repository;
        //}

        //public IRepository<Usuario> Repository { get; set; }

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
            nuevoUsuario.Show();
        }

        private void ABMUsuarios_Load(object sender, EventArgs e)
        {
            RestablecerControles();
            cboLocalidad.Enabled = true;
            CargarComboProvincia();
            cboProvincia.SelectedIndex = -1;
            CargarColumnas();
            CargarGrilla();
            dgvUsuarios.ClearSelection();
        }

        private void RestablecerControles()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtCp.Text = string.Empty;
            txtDomicilio.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelFijo.Text = string.Empty;
            cboProvincia.SelectedIndex = -1;
            cboLocalidad.SelectedIndex = -1;
            cboLocalidad.Enabled = false;
            //CargarGrilla();
        }

        private void CargarColumnas()
        {
            dgvUsuarios.Columns.Add("IdUsuario", "IdUsuario");
            dgvUsuarios.Columns[0].Visible = false;
            dgvUsuarios.Columns.Add("IdProvincia", "IdProvincia");
            dgvUsuarios.Columns[1].Visible = false;
            dgvUsuarios.Columns.Add("IdLocalidad", "IdLocalidad");
            dgvUsuarios.Columns[2].Visible = false;
            dgvUsuarios.Columns.Add("Nombre", "Nombre");
            dgvUsuarios.Columns.Add("Apellido", "Apellido");
            dgvUsuarios.Columns.Add("E-mail", "Email");
            dgvUsuarios.Columns.Add("Sexo", "Sexo");
            dgvUsuarios.Columns.Add("Direccion", "Direccion");
            dgvUsuarios.Columns.Add("CP", "CP");
            dgvUsuarios.Columns.Add("Descripcion", "Descripcion");
            dgvUsuarios.Columns.Add("Descripcion", "Descripcion");
            dgvUsuarios.Columns.Add("Telefono", "Telefono");
            dgvUsuarios.Columns.Add("Celular", "Celular");
            dgvUsuarios.Columns.Add("IdDomicilio", "IdDomicilio");
            dgvUsuarios.Columns[13].Visible = false;
        }

        private void CargarGrilla()
        {
            var usuarios = ServicioUsuario.Retrive();
            for (int i = 0; i < usuarios.Count; i++)
            {
                dgvUsuarios.Rows.Add(new string[]
                {
                    usuarios[i].IdUsuario.ToString(), usuarios[i].Domicilio.Provincia.IdProvincia.ToString(),
                    usuarios[i].Domicilio.Localidad.IdLocalidad.ToString(),
                    usuarios[i].Nombre, usuarios[i].Apellido, usuarios[i].Email,
                    usuarios[i].Sexo, usuarios[i].Domicilio.Direccion, usuarios[i].Domicilio.CodPostal,
                    usuarios[i].Domicilio.Provincia.Descripcion, usuarios[i].Domicilio.Localidad.Descripcion,
                    !string.IsNullOrEmpty(usuarios[i].Contacto.Telefono) ? usuarios[i].Contacto.Telefono : String.Empty,
                    !string.IsNullOrEmpty(usuarios[i].Contacto.Celular) ? usuarios[i].Contacto.Celular : String.Empty,
                    usuarios[i].Domicilio.IdDomicilio.ToString()
                });
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

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0)
                {
                    var usuarioToUpdate = ConvertToUsuario();
                    if (usuarioToUpdate != null)
                    {
                        if (ServicioUsuario.Update(usuarioToUpdate))
                        {
                            MessageBox.Show("Usuario actualizado correctamente");
                            RestablecerControles();
                            return;
                        }
                    }
                    else
                    {
                        RestablecerControles();
                        MessageBox.Show("Ocurrio un error al actualizar los datos del usuario.", "Error",
                            MessageBoxButtons.OK);
                    }

                    return;
                }
                MessageBox.Show("Debe seleccionar un usuario para proceder con la edicion de los datos.");
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Ocurrio un error al actualizar el usuario: {0}", ex.Message);
            }            
        }

        private Usuario ConvertToUsuario()
        {
            try
            {
                if (ControlsUtils.ValidarControles(txtNombre.Text, txtApellido.Text, txtDomicilio.Text, txtCp.Text,
                        txtCelular.Text, txtTelFijo.Text) && cboLocalidad.SelectedIndex != -1 &&
                    cboProvincia.SelectedIndex != -1)
                {
                    var idUsuarioSeleccionado = Guid.Parse(dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString());
                    var usuario = ServicioUsuario.GetById(idUsuarioSeleccionado);

                    usuario.Nombre = txtNombre.Text.Trim();
                    usuario.Apellido = txtApellido.Text.Trim();
                    usuario.Email = txtEmail.Text;
                    if (rdbSexo.Checked)
                    {
                        usuario.Sexo = "Hombre";
                    }
                    else
                    {
                        usuario.Sexo = "Mujer";
                    }

                    usuario.Domicilio.Direccion = txtDomicilio.Text;
                    usuario.Domicilio.CodPostal = txtCp.Text;                    
                    var localidad = (Localidad)cboLocalidad.SelectedItem;
                    usuario.Domicilio.Localidad.Descripcion = localidad.Descripcion;
                    var provincia = (Provincia)cboProvincia.SelectedItem;
                    usuario.Domicilio.Provincia.Descripcion = provincia.Descripcion;
                    usuario.Contacto.Telefono = txtTelFijo.Text.Trim();
                    usuario.Contacto.Celular = txtCelular.Text.Trim();

                    return usuario;
                }

                return null;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Ocurrio un error al mapear el objeto. Error: {0}", ex.Message);
                return null;
            }
            

            
        }

        private void dgvUsuarios_RowEnter(object sender, DataGridViewCellEventArgs e)
        {          
        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cboLocalidad.Enabled = true;
                txtNombre.Text = dgvUsuarios.SelectedRows[0].Cells[3].Value.ToString();
                txtApellido.Text = dgvUsuarios.SelectedRows[0].Cells[4].Value.ToString();
                txtEmail.Text = dgvUsuarios.SelectedRows[0].Cells[5].Value.ToString();
                if (dgvUsuarios.SelectedRows[0].Cells[6].Value.ToString() == "Hombre")
                {
                    rdbSexo.Checked = true;
                }
                else
                {
                    rdbSexo2.Checked = true;
                }

                txtDomicilio.Text = dgvUsuarios.SelectedRows[0].Cells[7].Value.ToString();
                txtCp.Text = dgvUsuarios.SelectedRows[0].Cells[8].Value.ToString();
                cboProvincia.SelectedIndex = cboProvincia.FindString(dgvUsuarios.SelectedRows[0].Cells[9].Value.ToString());
                LlenarComboLocalidadesPorProvinciaId(Guid.Parse(dgvUsuarios.SelectedRows[0].Cells[1].Value.ToString()));
                cboLocalidad.SelectedIndex = cboLocalidad.FindString(dgvUsuarios.SelectedRows[0].Cells[10].Value.ToString());
                txtTelFijo.Text = !string.IsNullOrEmpty(dgvUsuarios.SelectedRows[0].Cells[11].Value.ToString()) ?
                    dgvUsuarios.SelectedRows[0].Cells[11].Value.ToString() : string.Empty;
                txtCelular.Text = !string.IsNullOrEmpty(dgvUsuarios.SelectedRows[0].Cells[12].Value.ToString()) ?
                    dgvUsuarios.SelectedRows[0].Cells[12].Value.ToString() : string.Empty;
            }
            catch (Exception exception)
            {
                log.Error("Ocurrio un error al mapear los datos.");
            }
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

        private void LlenarComboLocalidadesPorProvinciaId(Guid provinciaId)
        {
            var localidadesByProvinciaId = ServicioLocalidadImplementor.GetLocalidadesByProvinciaId(provinciaId);
            cboLocalidad.DataSource = localidadesByProvinciaId;
            cboLocalidad.DisplayMember = "Descripcion";
            cboLocalidad.ValueMember = "IdLocalidad";
        }
    }
}
