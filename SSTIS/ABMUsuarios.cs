using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BLL;
using DAL.Interfaces;
using EasyEncryption;

namespace SSTIS
{
    using BE;
    using BLL.Interfaces;
    using log4net;
    using Interfaces;
    using Utils;
    using System;
    using System.Windows.Forms;

    public partial class frmABMUsuarios : Form, IABMUsuarios
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frmABMUsuarios));

        public IServicio<Usuario> ServicioUsuario { get; set; }
        public IServicio<Localidad> ServicioLocalidad { get; set; }
        public IServicio<Provincia> ServicioProvincia { get; set; }
        public IServicioLocalidad ServicioLocalidadImplementor;
        public IAdminFamiliaUsuario AdminFamiliaUsuario;
        public IAdminPatenteUsuario AdminPatenteUsuario;
        public IServicioPatente ServicioPatente;
        public IServicioFamilia ServicioFamiliaImplementor;
        public IServicioUsuario ServicioUsuarioImplementor;
        private IDigitoVerificador DigitoVerificador;

        public INuevoUsuario nuevoUsuario { get; set; }
        public static Usuario usuario { get; set; }
        public const string Key = "bZr2URKx";
        public const string Iv = "HNtgQw0w";
        private const string Entidad = "Usuario";
        private static bool MostrarActivos { get; set; }

        public frmABMUsuarios(
            IServicio<Usuario> ServicioUsuario,
            INuevoUsuario nuevoUsuario,
            IServicio<Localidad> ServicioLocalidad,
            IServicio<Provincia> ServicioProvincia,
            IServicioLocalidad ServicioLocalidadImplementor, IAdminFamiliaUsuario AdminFamiliaUsuario,
            IAdminPatenteUsuario AdminPatenteUsuario, IServicioPatente ServicioPatente,
            IServicioFamilia ServicioFamiliaImplementor, IServicioUsuario ServicioUsuarioImplementor,
            IDigitoVerificador DigitoVerificador)
        {
            InitializeComponent();
            this.ServicioUsuario = ServicioUsuario;
            this.nuevoUsuario = nuevoUsuario;
            this.ServicioLocalidad = ServicioLocalidad;
            this.ServicioProvincia = ServicioProvincia;
            this.ServicioLocalidadImplementor = ServicioLocalidadImplementor;
            this.AdminFamiliaUsuario = AdminFamiliaUsuario;
            this.AdminPatenteUsuario = AdminPatenteUsuario;
            this.ServicioPatente = ServicioPatente;
            this.ServicioFamiliaImplementor = ServicioFamiliaImplementor;
            this.ServicioUsuarioImplementor = ServicioUsuarioImplementor;
            this.DigitoVerificador = DigitoVerificador;
        }

        public Usuario usuarioSeleccionado()
        {
            usuario.Familia = new List<Familia>();
            usuario.Familia = ServicioFamiliaImplementor.ObtenerFamiliasPorUsuario(usuario.IdUsuario);

            return usuario;
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
            nuevoUsuario.ShowDialog();

            CargarGrilla();
        }

        private void ABMUsuarios_Load(object sender, EventArgs e)
        {
            CargarInicial();
        }

        private void CargarInicial()
        {
            RestablecerControles();
            MostrarActivos = true;
            cboLocalidad.Enabled = true;
            gbGrillaUsuarios.Text = "Usuarios Activos";
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
            var usuarios = new List<Usuario>();
            if (MostrarActivos)
            {
                gbGrillaUsuarios.Text = "Usuarios Activos";
                usuarios = ServicioUsuario.Retrive().Where(x => x.Estado).OrderBy(x => x.Email).ToList();
            }
            else
            {
                gbGrillaUsuarios.Text = "Usuarios Inactivos";
                usuarios = ServicioUsuario.Retrive().Where(x => !x.Estado).OrderBy(x => x.Email).ToList();
            }

            dgvUsuarios.Rows.Clear();

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
                            if (DigitoVerificador.ComprobarPrimerDigito(DigitoVerificador.Entidades.Find(x => x.ToUpper() == Entidad.ToUpper())))
                            {
                                DigitoVerificador.InsertarDVVertical(DigitoVerificador.Entidades.Find(x => x.ToUpper() == Entidad.ToUpper()));
                            }
                            else
                            {
                                DigitoVerificador.ActualizarDVVertical(DigitoVerificador.Entidades.Find(x => x.ToUpper() == Entidad.ToUpper()));
                            }

                            MessageBox.Show("Usuario actualizado correctamente");
                            CargarGrilla();
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
                    var usuario = GetUsuarioById(idUsuarioSeleccionado);

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

        private Usuario GetUsuarioById(Guid idUsuarioSeleccionado)
        {
            usuario = ServicioUsuario.GetById(idUsuarioSeleccionado);
            return usuario;
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
                //Cargamos en memoria el usuario seleccionado de la grilla
                GetUsuarioById(Guid.Parse(dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString()));
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
            var selectedProvincia = Guid.Parse(cboProvincia.SelectedValue.ToString());
            var localidadesByProvinciaId = ServicioLocalidadImplementor.GetLocalidadesByProvinciaId(selectedProvincia);

            cboLocalidad.Enabled = true;
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

        public bool CheckeoPatentes(Usuario usuario)
        {
            //CargarPatentesFamilia(usuario);
            var returnValue = true;
            if (usuario.Patentes.Count > 0 || usuario.Familia.Count > 0)
            {
                returnValue = ServicioPatente.CheckeoDePatentesParaBorrar(usuario);              
            }

            return returnValue;
        }

        public void CargarPatentesFamilia(Usuario usuario)
        {
            usuario.Patentes = new List<Patente>();
            usuario.Familia = new List<Familia>();

            usuario.Familia = ServicioFamiliaImplementor.ObtenerFamiliasUsuario(usuario.IdUsuario);

            usuario.Patentes.AddRange(ServicioUsuarioImplementor.ObtenerPatentesDeUsuario(usuario.IdUsuario));
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            string coma = string.Empty;
            var idsNotDelete = new List<Guid>();
            var idsToDelete = new List<Guid>();

            if (dgvUsuarios.SelectedRows.Count != 0)
            {
                //var usuariosABorrar = dgvUsuarios.SelectedRows.AsParallel();
                mensaje = "No es posible eliminar los usuarios: ";
                for (int i = 0; i < dgvUsuarios.SelectedRows.Count; i++)
                {
                    var usuario = dgvUsuarios.SelectedRows[i];
                    var idUsuario = Guid.Parse(usuario.Cells[0].Value.ToString());
                    if (i != 0)
                        coma = ", ";
                    if (idUsuario == LoginInfo.Usuario.IdUsuario)
                        idsNotDelete.Add(idUsuario);
                    idsToDelete.Add(idUsuario);
                }

                mensaje += " ya que tienen familias/patentes asignadas.";
                if (idsNotDelete.Any(x => x == LoginInfo.Usuario.IdUsuario))
                {
                    MessageBox.Show("No es posible eliminar el usuario que esta logueado.");
                    return;
                }

                var usuariosExistentes = ServicioUsuario.Retrive().ToList();

                var msjDeleteSome = string.Empty;

                if (idsNotDelete.Any() && idsToDelete.Any())
                {
                    //Verificar datos
                    var permitir = ServicioPatente.VerificarDatos(idsToDelete);
                    msjDeleteSome += mensaje + " Desea eliminar los usuarios restantes?";
                    var usuariosToDelete = usuariosExistentes
                        .Where(x => idsNotDelete.Any(y => y == x.IdUsuario));
                    var confirmResult = MessageBox.Show(msjDeleteSome,
                        "Confirme baja de usuario",
                        MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        foreach (var usuarioToDelete in usuariosToDelete)
                        {
                            ServicioUsuario.Delete(usuarioToDelete);
                        }
                        MessageBox.Show("Usuario/s eliminado/s correctamente.");
                    }
                }
                else if (idsNotDelete.Any() && !idsToDelete.Any())
                {
                    MessageBox.Show(mensaje);
                }
                else
                {
                    var usuariosToDelete = usuariosExistentes.Where(x => idsToDelete.Any(y => y == x.IdUsuario));
                    var listaUsuariosConfirmar = new List<Usuario>();
                    var listaUsuaiosNOborrar = new List<Usuario>();
                    var message = string.Empty;
                    //HACER UN CICLO PARA ITERAR POR TODOS LOS USUARIOS
                    foreach (var usuariosABorrar in usuariosToDelete)
                    {
                        var permitir = CheckeoPatentes(usuariosABorrar);
                        if (permitir)
                        {
                            listaUsuariosConfirmar.Add(usuariosABorrar);
                        }
                        else
                        {
                            message += usuariosABorrar.Email + coma;
                            listaUsuaiosNOborrar.Add(usuariosABorrar);
                        }
                    }

                    if (usuariosToDelete.Any(x => !x.Estado))
                    {
                        MessageBox.Show("No es posible eliminar usuarios inactivos.");
                        return;
                    }

                    if (listaUsuaiosNOborrar.Count > 0)
                    {
                        MessageBox.Show("Los usuarios: " + message +
                                        " no se pueden borrar ya que tienen patentes asignadas. Por favor vuelva a seleccionar.");
                        return;
                    }

                    if (listaUsuariosConfirmar.Count > 0)
                    {
                        var confirmResult = MessageBox.Show("Esta seguro que desea eliminar los usuarios seleccionados?",
                            "Confirme baja de usuario",
                            MessageBoxButtons.YesNo);
                        if (confirmResult == DialogResult.Yes)
                        {

                            foreach (var usuarioToDelete in listaUsuariosConfirmar)
                            {
                                //if (ServicioPatente.CheckeoDePatentes(usuarioToDelete))
                                var borrado = ServicioUsuario.Delete(usuarioToDelete);
                                if (borrado)
                                {
                                    if (DigitoVerificador.ComprobarPrimerDigito(DigitoVerificador.Entidades.Find(x => x.ToUpper() == Entidad.ToUpper())))
                                    {
                                        DigitoVerificador.InsertarDVVertical(DigitoVerificador.Entidades.Find(x => x.ToUpper() == Entidad.ToUpper()));
                                    }
                                    else
                                    {
                                        DigitoVerificador.ActualizarDVVertical(DigitoVerificador.Entidades.Find(x => x.ToUpper() == Entidad.ToUpper()));
                                    }
                                }
                            }
                            MessageBox.Show("Usuario/s eliminado/s correctamente.");
                        }
                    }

                }

                CargarGrilla();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario de la grilla para proceder con la baja.");
            }

        }

        private void btnAdmiFamilia_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                AdminFamiliaUsuario.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario de la grilla para poder administrar las Familias");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 1)
            {
                //El usuario logueado no puede modificar las patentes
                //if (Guid.Parse(dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString()) == LoginInfo.Usuario.IdUsuario)
                //{
                //    MessageBox.Show("No se puede modificar las patentes del usuario activo.");
                //    return;
                //}

                AdminPatenteUsuario.ShowDialog();
            }
            else if (dgvUsuarios.SelectedRows.Count > 1)
            {
                MessageBox.Show("La administracion de Patentes se hace de a un usuario por vez. Por favor seleccione solo uno.");
            }
            else if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario de la grilla para poder administrar las Patentes");
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtCp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTelFijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frmABMUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 1 && !usuarioSeleccionado().Bloqueado)
            {
                var confirmResult = MessageBox.Show("Esta seguro que desea bloquear el usuario seleccionado?",
                    "Confirme bloqueo de usuario",
                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    var bloqueado = ServicioUsuarioImplementor.BloquearUsuario(usuarioSeleccionado().IdUsuario);
                    if (bloqueado)
                    {
                        MessageBox.Show("Usuario bloqueado correctamente.");
                    }
                }
            }
            else if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario.");
            }
            else if (dgvUsuarios.SelectedRows.Count > 1)
            {
                MessageBox.Show("Se debe bloquear de a un usuario a la vez.");
            }
            else if (usuarioSeleccionado().Bloqueado)
            {
                MessageBox.Show("El usuario ya se encuentra bloqueado.");
            }
        }

        private void btnMostrarActivos_Click(object sender, EventArgs e)
        {
            MostrarActivos = true;
            CargarGrilla();
        }

        private void btnMostrarInactivos_Click(object sender, EventArgs e)
        {
            MostrarActivos = false;
            CargarGrilla();
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 1 && usuarioSeleccionado().Bloqueado)
            {
                var confirmResult = MessageBox.Show("Esta seguro que desea desbloquear el usuario seleccionado?",
                    "Confirme desbloqueo de usuario",
                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    var bloqueado = ServicioUsuarioImplementor.DesbloquearUsuario(usuarioSeleccionado().IdUsuario);
                    if (bloqueado)
                    {
                        MessageBox.Show("Usuario desbloqueado correctamente.");
                    }
                }
            }
            else if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario.");
            }
            else if (dgvUsuarios.SelectedRows.Count > 1)
            {
                MessageBox.Show("Se debe desbloquear de a un usuario a la vez.");
            }
            else if (!usuarioSeleccionado().Bloqueado)
            {
                MessageBox.Show("El usuario ya se encuentra desbloqueado.");
            }
        }

        private void frmABMUsuarios_Enter(object sender, EventArgs e)
        {
            CargarInicial();
        }
    }
}
