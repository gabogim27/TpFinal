using System;
using System.Collections;
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
using SSTIS.MessageBoxHelper;
using SSTIS.Utils;
using SysAnalizer;

namespace SSTIS
{
    public partial class frmNuevoUsuario : Form, INuevoUsuario
    {
        public IServicio<Usuario> ServicioUsuario { get; set; }
        public IServicio<Localidad> ServicioLocalidad;
        public IServicio<Provincia> ServicioProvincia { get; set; }
        public IServicioUsuario ServicioUsuarioImplementor;
        public IServicioLocalidad ServicioLocalidadImplementor;
        public IServicio<Familia> ServicioFamilia;
        public IServicioPatente ServicioPatente;
        public IServicioFamilia ServicioFamiliaImplementor;
        public IServicioBitacora ServicioBitacoraImplementor;
        
        private static readonly List<Familia> listaFamilas = new List<Familia>();
        private static readonly List<Patente> listaPatentes = new List<Patente>();

        public frmNuevoUsuario(IServicio<Usuario> servicioUsuario, IServicio<Localidad> servicioLocalidad,
            IServicio<Provincia> servicioProvincia, IServicioUsuario servicioUsuarioImplementor,
            IServicioLocalidad servicioLocalidadImplementor, IServicio<Familia> servicioFamilia,
            IServicioPatente servicioPatente, IServicioFamilia servicioFamiliaImplementor,
            IServicioBitacora servicioBitacoraImplementor)
        {
            this.ServicioUsuario = servicioUsuario;
            this.ServicioLocalidad = servicioLocalidad;
            this.ServicioProvincia = servicioProvincia;
            this.ServicioUsuarioImplementor = servicioUsuarioImplementor;
            this.ServicioLocalidadImplementor = servicioLocalidadImplementor;
            this.ServicioFamilia = servicioFamilia;
            this.ServicioPatente = servicioPatente;
            this.ServicioFamiliaImplementor = servicioFamiliaImplementor;
            this.ServicioBitacoraImplementor = servicioBitacoraImplementor;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {               
                if (ValidarDatosIngresados())
                {
                    if (ServicioUsuarioImplementor.ObtenerUsuarioConEmail(txtEmail.Text.Trim()) != null)
                    {
                        //Registramos el intento fallido de nuevo usuario.
                        ServicioBitacoraImplementor.RegistrarEnBitacora(Log.Level.Baja.ToString(),
                            string.Format("Creacion de usuario fallida. Usuario con E-mail: {0} existente en BD.", txtEmail.Text.Trim()));
                        MessageBox.Show("El usuario ingresado ya existe.", "Usuario existente", MessageBoxButtons.OK);
                        lblUsuarioExistente.Visible = true;
                        lblUsuarioExistente.Text = "Usuario Existente";
                        lblUsuarioExistente.BackColor = Color.Red;
                        return;
                    }

                    //Sino existe, creamos uno nuevo
                    var nuevoUsuario = NuevoUsuario();

                    lblUsuarioExistente.Visible = false;

                    var creado = this.ServicioUsuario.Create(nuevoUsuario);
                    if (creado)
                    {
                        var familiasSeleccionadas = GetSelectedFamilies();
                        ServicioFamiliaImplementor.GuardarFamiliaUsuario(familiasSeleccionadas, nuevoUsuario.IdUsuario);
                        ServicioPatente.GuardarPatentesUsuario(GetSelectedPatentes(), nuevoUsuario.IdUsuario);
                        ServicioBitacoraImplementor.RegistrarEnBitacora(Log.Level.Alta.ToString(), 
                            string.Format("Usuario con id: {0} creado correctamente.", nuevoUsuario.IdUsuario), nuevoUsuario);
                        MessageBox.Show("Usuario creado correctamente");
                    }
                    else
                    {
                        ServicioBitacoraImplementor.RegistrarEnBitacora(Log.Level.Alta.ToString(), 
                            String.Format("Hubo un error al crear el usuario: {0}", nuevoUsuario.Email), nuevoUsuario);
                        Alert.ShowSimpleAlert("El alta de nuevo usuario ha fallado");
                    }
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor verifique los datos ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Usuario NuevoUsuario()
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
            nuevoUsuario.IdIdioma = LoginInfo.LenguajeSeleccionado.IdIdioma;
            return nuevoUsuario;
        }

        private bool ValidarDatosIngresados()
        {
            var returnValue = true;
            //Verificamos todos los controles de tipo textbox
            foreach (TextBox tb in Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(tb.Text.Trim()))
                {
                    MessageBox.Show("Todos los datos deben estar completos");
                    returnValue = false;
                    break;
                }
            }
            //Verificamois todos los controles de tipo combo
            foreach (ComboBox tb in Controls.OfType<ComboBox>())
            {
                if (tb.SelectedIndex < -1)
                {
                    MessageBox.Show("Por favor elija una Provincia y Localidad");
                    returnValue = false;
                    break;
                }
            }
            //Verificamos que se haya ingresado un mail valido
            if (!ServicioUsuarioImplementor.ValidarEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("El e-mail ingresado esta en formato incorrecto. Por favor corrijalo!!!");
                returnValue = false;
            }
            //Verificamos que se haya seleccionado alguna familia
            //if (chklFamilia.CheckedItems.Count == 0)
            //{
            //    MessageBox.Show("Debe seleccionar al menos una familia");
            //    returnValue = false;
            //}
            ////Verificamos que se haya seleccionado alguna patente
            //if (chklPatente.CheckedItems.Count == 0)
            //{
            //    MessageBox.Show("Debe seleccionar al menos una patente");
            //    returnValue = false;
            //}

            return returnValue;
        }

        private List<Guid> GetSelectedFamilies()
        {
            var listaFamilia = new List<Guid>();
            for (int i = 0; i < chklFamilia.CheckedItems.Count; i++)
            {
                listaFamilia.Add(listaFamilas.FirstOrDefault(f => f.Descripcion == chklFamilia.CheckedItems[i].ToString()).IdFamilia);
            }

            return listaFamilia;
        }

        private List<Guid> GetSelectedPatentes()
        {
            var patentes = new List<Guid>();
            for (int i = 0; i < chklPatente.CheckedItems.Count; i++)
            {
                patentes.Add(listaPatentes.FirstOrDefault(p => p.Descripcion == chklPatente.CheckedItems[i].ToString()).IdPatente);
            }

            return patentes;
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
            //Cargar los checklist
            CargarCheckListFamilia();
            CargarCheckListPatente();
        }

        private void CargarCheckListFamilia()
        {
            listaFamilas.AddRange(ServicioFamilia.Retrive());
            var familiasDescripcion = listaFamilas.Select(x => x.Descripcion).ToList();
            //Add emails to checkbox list
            familiasDescripcion.ForEach(e => chklFamilia.Items.Add(e));
        }

        private void CargarCheckListPatente()
        {
            listaPatentes.AddRange(ServicioPatente.RetrievePatentes());
            var patentesDescripcion = listaPatentes.Select(x => x.Descripcion).ToList();
            patentesDescripcion.ForEach(e => chklPatente.Items.Add(e));
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            RestablecerControles();
            Hide();
        }

        private void frmNuevoUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            RestablecerControles();
            Hide();
            e.Cancel = true;
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
    }
}
