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
using Microsoft.Win32;
using SSTIS.Interfaces;
using SSTIS.Utils;
using SysAnalizer;

namespace SSTIS
{
    public partial class frmAdmFamiliaPatente : Form, IAdmPatenteFamilia
    {
        private IServicioPatente ServicioPatente;
        private IServicio<Familia> ServicioFamilia;
        private IServicioFamilia ServicioFamiliaImplementor;
        private List<Patente> listaPatente = new List<Patente>();


        public frmAdmFamiliaPatente(IServicioPatente ServicioPatente, IServicioFamilia ServicioFamiliaImplementor,
            IServicio<Familia> ServicioFamilia)
        {
            this.ServicioFamiliaImplementor = ServicioFamiliaImplementor;
            this.ServicioPatente = ServicioPatente;
            this.ServicioFamilia = ServicioFamilia;
            InitializeComponent();
        }

        private bool familiaNueva;

        public bool FamiliaNueva
        {
            get { return familiaNueva; }
            set { familiaNueva = value; }
        }

        public void AsignarPatente(Guid familiaId, Guid patenteId)
        {
            var asignadas = ServicioPatente.AsignarPatente(familiaId, patenteId);
            if (asignadas)
            {
                DialogResult = DialogResult.OK;
            }
        }

        public void BorrarPatente(Guid familiaId, Guid patenteId)
        {
            if (CheckeoPatentes(ServicioFamilia.Retrive().FirstOrDefault(x => x.IdFamilia == familiaId), patenteId))
            {
                var borrada = ServicioPatente.BorrarPatente(familiaId, patenteId);
                if (borrada)
                {
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("La familia actualmente esta en uso");
            }

        }

        public bool CheckeoPatentes(Familia familia, Guid patenteId)
        {
            var returnValue = true;

            returnValue = ServicioPatente.CheckeoFamiliaParaBorrar(null, familia, patenteId);

            return returnValue;

        }

        private void frmAdmFamiliaPatente_Load(object sender, EventArgs e)
        {
            //var ABMFamilia = Program.simpleInyectorContainer.GetInstance<IABMFamilia>();VER PORQUE TRAER 
            //LA FAMILIA EN NULL           
            CargarGrilla();
            //lstPatentes.DataSource = patenteBLL.Cargar();
        }

        private void CargarGrilla()
        {
            var familia = FamiliaInfo.NuevaFamilia;
            lblFamiliaText.Text = familia.Descripcion;

            listaPatente = ServicioPatente.RetrievePatentes();
            var patentesPorFamiliaId =
                ServicioFamiliaImplementor.ObtenerPatentesPorFamiliaId(FamiliaInfo.NuevaFamilia.IdFamilia);

            dgvAdminFamiliaPatente.Rows.Clear();

            for (int i = 0; i < listaPatente.Count; i++)
            {
                dgvAdminFamiliaPatente.Rows.Add(listaPatente[i].Descripcion,
                    patentesPorFamiliaId.Any(p => p == listaPatente[i].IdPatente));
            }
            //dgvAdminFamiliaPatente.Rows.Clear();
            //dgvAdminFamiliaPatente.DataSource = null;
            //dgvAdminFamiliaPatente.DataSource = patentes;
            //dgvAdminFamiliaPatente.Columns[0].ReadOnly = false;
            //dgvAdminFamiliaPatente.Columns[1].ReadOnly = false;
            ////dgvAdminFamiliaPatente.Columns[3].ReadOnly = true;
            //dgvAdminFamiliaPatente.Columns[1].Visible = false;

            //foreach (DataGridViewRow row in dgvAdminFamiliaPatente.Rows)
            //{
            //    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[0];

            //    if (patentesPorFamiliaId.Any() && patentesPorFamiliaId.Exists(x => x == (Guid) row.Cells[1].Value))
            //    {
            //        cell.Value = true;
            //    }
            //}
            //for (int i = 0; i < patentes.Count; i++)
            //{
            //    dgvAdminFamiliaPatente.Rows[i].Cells[0].Value =
            //        patentesPorFamiliaId.Any(p => p == patentes[i].IdPatente);
            //}

            //dgvAdminFamiliaPatente.EndEdit();
        }

        private void dgvAdminFamiliaPatente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvAdminFamiliaPatente.CurrentCell is DataGridViewCheckBoxCell)
            {
                if (FamiliaNueva)
                {

                    DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dgvAdminFamiliaPatente.CurrentCell;

                    bool isChecked = (bool)checkbox.EditedFormattedValue;
                    var patenteDescripcion = dgvAdminFamiliaPatente.CurrentRow.Cells[0].Value.ToString();
                    var idPatente = listaPatente.FirstOrDefault(f => f.Descripcion == patenteDescripcion).IdPatente;
                    //var patenteSeleccionada = (Patente)dgvAdminFamiliaPatente.CurrentRow.DataBoundItem;
                    //Otorgada
                    if (checkbox.ColumnIndex == 1 && isChecked)
                    {
                        AsignarPatente(FamiliaInfo.NuevaFamilia.IdFamilia, idPatente);
                    }
                    //Otorgada pero desasignada
                    else if (checkbox.ColumnIndex == 1 && !isChecked)
                    {
                        var patentes = ServicioPatente.ConsultarPatenteFamilia(FamiliaInfo.NuevaFamilia.IdFamilia);

                        if (patentes != null && patentes.Exists(x => x.IdPatente == idPatente))
                        {
                            BorrarPatente(FamiliaInfo.NuevaFamilia.IdFamilia, idPatente);
                        }
                        else
                        {
                            AsignarPatente(FamiliaInfo.NuevaFamilia.IdFamilia, idPatente);
                        }
                    }
                    //
                }

                CargarGrilla();
                DialogResult = DialogResult.None;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void frmAdmFamiliaPatente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void frmAdmFamiliaPatente_Enter(object sender, EventArgs e)
        {
            CargarGrilla();
        }
    }
}
