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
        public IModificarUsuario modificarUsuario { get; set; }
        public static Usuario usuario { get; set; }
        public const string Key = "bZr2URKx";
        public const string Iv = "HNtgQw0w";
        private const string Entidad = "Usuario";
        private static bool MostrarActivos { get; set; }
        bool cargaInicial = true;

        public frmABMUsuarios(
            IServicio<Usuario> ServicioUsuario,
            INuevoUsuario nuevoUsuario,
            IModificarUsuario modificarUsuario,
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
            this.modificarUsuario = modificarUsuario;
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
            //usuario.Familia = new List<Familia>();
            //usuario.Familia = ServicioFamiliaImplementor.ObtenerFamiliasPorUsuario(usuario.IdUsuario);

            var idUsuario = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();

            var usFromBD = ServicioUsuario.Retrive().FirstOrDefault(x => x.IdUsuario == Guid.Parse(idUsuario));

            return usFromBD;
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
            CargarColumnas();
            RestablecerControles();
            MostrarActivos = true;
            //cboLocalidad.Enabled = true;
            gbGrillaUsuarios.Text = "Usuarios Activos";
            //CargarComboProvincia();
            //cboProvincia.SelectedIndex = -1;
            CargarGrilla();
            dgvUsuarios.ClearSelection();
        }

        private void RestablecerControles()
        {
            //txtNombre.Text = string.Empty;
            //txtApellido.Text = string.Empty;
            //txtCelular.Text = string.Empty;
            //txtCp.Text = string.Empty;
            //txtDomicilio.Text = string.Empty;
            //txtEmail.Text = string.Empty;
            //txtTelFijo.Text = string.Empty;
            //cboProvincia.SelectedIndex = -1;
            //cboLocalidad.SelectedIndex = -1;
            //cboLocalidad.Enabled = false;
            CargarGrilla();
        }

        private void CargarColumnas()
        {
            if (cargaInicial)
            {
                dgvUsuarios.AutoGenerateColumns = false;
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

            cargaInicial = false;
        }

        private void CargarGrilla()
        {
            var usuarios = new List<Usuario>();
            if (MostrarActivos)
            {
                gbGrillaUsuarios.Text = "Usuarios Activos";
                usuarios = ServicioUsuario.Retrive().Where(x => x.Estado && !x.Bloqueado).OrderBy(x => x.Email).ToList();
            }
            else
            {
                gbGrillaUsuarios.Text = "Usuarios Inactivos";
                usuarios = ServicioUsuario.Retrive().Where(x => !x.Estado || x.Bloqueado).OrderBy(x => x.Email).ToList();
            }

            dgvUsuarios.Rows.Clear();
            dgvUsuarios.Refresh();

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

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0)
                {
                    modificarUsuario.ShowDialog();
                    CargarGrilla();
                }
                MessageBox.Show("Debe seleccionar un usuario para proceder con la edicion de los datos.");
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Ocurrio un error al actualizar el usuario: {0}", ex.Message);
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
            var user = GetUsuarioById(Guid.Parse(dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString()));
            btnBloquear.Enabled = !user.Bloqueado;
            btnDesbloquear.Enabled = user.Bloqueado;
            btnEliminarUsuario.Enabled = user.Estado;
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
            if ((dgvUsuarios.SelectedRows.Count == 1 && !usuarioSeleccionado().Bloqueado))
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
                        btnDesbloquear.Enabled = true;
                        btnBloquear.Enabled = false;
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
                    var desbloqueado = ServicioUsuarioImplementor.DesbloquearUsuario(usuarioSeleccionado().IdUsuario);
                    if (desbloqueado)
                    {
                        MessageBox.Show("Usuario desbloqueado correctamente.");
                        btnDesbloquear.Enabled = false;
                        btnBloquear.Enabled = true;
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

        private void Button8_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado() != null)
            {
                //Actualizamos primer ingreso en = 1
                Random randomPass = new Random();
                var nuevoPass = randomPass.Next();
                usuarioSeleccionado().PrimerLogin = true;
                usuarioSeleccionado().Password = randomPass.ToString();
                if (ServicioUsuario.Update(usuarioSeleccionado()))
                {
                    //Guardamos una password en el txt
                    ServicioUsuarioImplementor.SavePasswordOnFile(nuevoPass, usuarioSeleccionado().Email);
                    MessageBox.Show("Contraseña blanqueada correctamente. Se ha creado una password temporal en el archivo SistemaTIS.txt." +
                                    " Por favor ingresela y luego el sistema le pedira que la cambie nuevamente.");
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al tratar de blanquear la contraseña.");
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un usuario.");
            }
        }
    }
}
