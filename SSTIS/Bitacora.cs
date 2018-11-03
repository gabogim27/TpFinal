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
using DAL.Interfaces;
using log4net;
using SSTIS.Interfaces;
using SSTIS.MessageBoxHelper;

namespace SSTIS
{
    public partial class frmBitacora : Form, IBitacora
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frmBitacora));

        public IServicio<Usuario> ServicioUsuario { get; set; }
        public IUsuarioDao ServicioUsuarioImplementor { get; set; }
        public IServicioBitacora ServicioBitacoraImplementor { get; set; }
        private IList<Usuario> UsuariosEnBitacora { get; set; }

        public frmBitacora(IServicio<Usuario> servicioUsuario, IUsuarioDao servicioUsuarioImplementor, 
            IServicioBitacora servicioBitacoraImplementor)
        {
            InitializeComponent();
            this.ServicioUsuario = servicioUsuario;
            this.ServicioUsuarioImplementor = servicioUsuarioImplementor;
            this.ServicioBitacoraImplementor = servicioBitacoraImplementor;
        }

        private void Bitacora_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            CargarCriticidades();
        }

        private void CargarCriticidades()
        {
            chklCriticidad.Items.Add("Alta");
            chklCriticidad.Items.Add("Media");
            chklCriticidad.Items.Add("Baja");
        }

        private void CargarUsuarios()
        {
            try
            {
                UsuariosEnBitacora = ServicioUsuario.Retrive();
                var emails = UsuariosEnBitacora.Select(x => x.Email).ToList();
                //Add emails to checkbox list
                emails.ForEach(e => chklUsuario.Items.Add(e));
            }
            catch (Exception e)
            {       
                log.ErrorFormat("Error inesperado: {0}", e.Message);
                Alert.ShowAlterWithButtonAndIcon("Ocurrio un error al agregar los usuarios a la lista", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var fechaDesde = dtpDesde.Value;
            var fechaHasta = dtpHasta.Value;
            var usuariosSeleccionados = new List<Usuario>();
            var prueba = new List<string>();

            //Obtenemos los usuarios seleccionados
            for (int i = 0; i < chklUsuario.CheckedItems.Count; i++)
            {
                var usuarioToAdd = UsuariosEnBitacora.FirstOrDefault(u => u.Email == (string)chklUsuario.CheckedItems[i]);
                usuariosSeleccionados.Add(usuarioToAdd);
            }
            //Obtenemos las criticidades seleccionadas
            for (int i = 0; i < chklCriticidad.CheckedItems.Count; i++)
            {
                prueba.Add("INFO");
                //criticidadesSeleccionadas[i] = (string) chklCriticidad.CheckedItems[i];
            }

            var idUsuarios = usuariosSeleccionados.Select(u => u.IdUsuario).ToList();
            //Buscamos los usuarios con parametros de fecha y criticidad en la bitacora
            var listaBitacora =
                ServicioBitacoraImplementor.LeerBitacoraPorUsuarioCriticidadYFecha(idUsuarios, prueba, fechaDesde, fechaHasta);
            CargarGrilla(listaBitacora);
        }

        private void CargarGrilla(List<BE.Bitacora> listaBitacora)
        {
            if (listaBitacora.Any())
            {
                for (int i = 0; i < listaBitacora.Count; i++)
                {
                    var email = UsuariosEnBitacora.FirstOrDefault(_ => _.IdUsuario == listaBitacora[i].IdUsuario)?.Email;
                    dgvBitacora.Rows.Add(new string[]
                    {
                        listaBitacora[i].Fecha.ToString(), email, listaBitacora[i].Actividad,
                        listaBitacora[i].InformacionAsociada, listaBitacora[i].Criticidad
                    });
                }
            }            
        }
    }
}
