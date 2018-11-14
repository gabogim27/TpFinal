using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using BE;
using BLL;
using BLL.Interfaces;
using DAL.Interfaces;
using log4net;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Diagnostics.Internal;
using Microsoft.SqlServer.Management.Smo;
using SSTIS.Interfaces;
using SSTIS.MessageBoxHelper;
using SSTIS.Providers;
using SSTIS.Utils;
using DataSet = System.Data.DataSet;

namespace SSTIS
{
    public partial class frmBitacora : Form, IBitacora
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frmBitacora));

        public IServicio<Usuario> ServicioUsuario { get; set; }
        public IUsuarioDao ServicioUsuarioImplementor { get; set; }
        public IServicioBitacora ServicioBitacoraImplementor { get; set; }
        private IList<Usuario> UsuariosEnBitacora { get; set; }
        public IServicioIdioma ServicioIdioma;

        public frmBitacora(IServicio<Usuario> servicioUsuario, IUsuarioDao servicioUsuarioImplementor,
            IServicioBitacora servicioBitacoraImplementor, IServicioIdioma servicioIdioma)
        {
            InitializeComponent();
            this.ServicioUsuario = servicioUsuario;
            this.ServicioUsuarioImplementor = servicioUsuarioImplementor;
            this.ServicioBitacoraImplementor = servicioBitacoraImplementor;
            this.ServicioIdioma = servicioIdioma;
        }

        private void Bitacora_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            CargarCriticidades();
            rpvBitacora.RefreshReport();
            //this.rwBitacora.RefreshReport();
            //this.rwBitacora.RefreshReport();
            //this.rpvBitacora.RefreshReport();
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
            var criticidadesSeleccionadas = new List<string>();
            //var prueba = new List<string>();

            //Obtenemos los usuarios seleccionados
            for (int i = 0; i < chklUsuario.CheckedItems.Count; i++)
            {
                var usuarioToAdd = UsuariosEnBitacora.FirstOrDefault(u => u.Email == (string)chklUsuario.CheckedItems[i]);
                usuariosSeleccionados.Add(usuarioToAdd);
            }
            //Obtenemos las criticidades seleccionadas
            for (int i = 0; i < chklCriticidad.CheckedItems.Count; i++)
            {
                //prueba.Add("INFO");
                criticidadesSeleccionadas.Add((string)chklCriticidad.CheckedItems[i]);
            }

            var idUsuarios = usuariosSeleccionados.Select(u => u.IdUsuario).ToList();
            //Buscamos los usuarios con parametros de fecha y criticidad en la bitacora
            var listaBitacora = ListarBitacora(idUsuarios, criticidadesSeleccionadas, fechaDesde, fechaHasta);
            if (listaBitacora != null)
            {
                BitacoraViewModel.ListadoBitacora = CreateDataTable(listaBitacora);
                //Cargamos info en el reporte
                rpvBitacora.LocalReport.DataSources.Clear();
                rpvBitacora.LocalReport.DataSources.Add(new ReportDataSource("DS_Bitacora", BitacoraViewModel.ListadoBitacora.Tables[0]));
                rpvBitacora.LocalReport.Refresh();
                rpvBitacora.RefreshReport();
            }
            else
            {
                //VER PORQUE NO LO LIMPIA CUANDO NO HAY DATOS
                //lo de abajo es temporal hasta encontrar una mejor solucion
                BitacoraViewModel.ListadoBitacora.Clear();
                rpvBitacora.LocalReport.DataSources.Clear();
                rpvBitacora.LocalReport.DataSources.Add(new ReportDataSource("DS_Bitacora", BitacoraViewModel.ListadoBitacora.Tables[0]));
                rpvBitacora.LocalReport.Refresh();
                rpvBitacora.RefreshReport();
                Alert.ShowAlterWithButtonAndIcon("MSJ004", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataSet CreateDataTable(List<Bitacora> listaBitacora)
        {
            var table = new DataTable();
            var dsBitacora = new DataSet();
            table.Columns.Add("Fecha");
            table.Columns.Add("Usuario");
            table.Columns.Add("Funcionalidad");
            table.Columns.Add("Descripcion");
            table.Columns.Add("Criticidad");

            if (listaBitacora != null)
            {
                foreach (var item in listaBitacora)
                {
                    var email = UsuariosEnBitacora.FirstOrDefault(_ => _.IdUsuario == item.IdUsuario)?.Email;
                    DataRow row = table.NewRow();
                    row["Fecha"] = item.Fecha.Value.ToShortDateString();
                    row["Usuario"] = email;
                    row["Funcionalidad"] = item.Actividad;
                    row["Descripcion"] = item.InformacionAsociada;
                    row["Criticidad"] = item.Criticidad;
                    table.Rows.Add(row);
                }
                dsBitacora.Tables.Add(table);
            }

            return dsBitacora;
        }

        public List<Bitacora> ListarBitacora(List<Guid> idUsuarios, List<string> prueba, DateTime fechaDesde, DateTime fechaHasta)
        {
            var listaBitacora =
                ServicioBitacoraImplementor.LeerBitacoraPorUsuarioCriticidadYFecha(idUsuarios, prueba, fechaDesde, fechaHasta);
            return listaBitacora;
        }

        private void AplicarTraducciones()
        {
            LoginInfo.Traducciones.Clear();
            LoginInfo.Traducciones = GetTraducciones();
            IdiomaProvider.FillResources(LoginInfo.Traducciones, LoginInfo.LenguajeSeleccionado.IdIdioma,
                Application.OpenForms[0].Name);
            IdiomaProvider.ReadResources(this.Controls);
        }

        private IDictionary<string, string> GetTraducciones()
        {
            LoginInfo.Traducciones =
                ServicioIdioma.GetTranslationsByLanguageAndForm(Utils.LoginInfo.LenguajeSeleccionado.IdIdioma,
                    Application.OpenForms[0].Name).ToDictionary(k => k.ControlName ?? k.MensajeCodigo, v => v.Traduccion);
            return LoginInfo.Traducciones;
        }

        //private void CargarGrilla(List<BE.Bitacora> listaBitacora)
        //{
        //    if (listaBitacora.Any())
        //    {
        //        for (int i = 0; i < listaBitacora.Count; i++)
        //        {
        //            var email = UsuariosEnBitacora.FirstOrDefault(_ => _.IdUsuario == listaBitacora[i].IdUsuario)?.Email;
        //            dgvBitacora.Rows.Add(new string[]
        //            {
        //                listaBitacora[i].Fecha.ToString(), email, listaBitacora[i].Actividad,
        //                listaBitacora[i].InformacionAsociada, listaBitacora[i].Criticidad
        //            });
        //        }
        //    }            
        //}

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            //this.rwBitacora.Reset();
            //var currentPath =
            //    Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            //var reportPath = currentPath + "\\Reportes\\Bitacora\\Report1.rdlc";
            //rwBitacora.ProcessingMode = ProcessingMode.Local;
            //this.rwBitacora.LocalReport.ReportPath = reportPath;
        }

        private void frmBitacora_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
