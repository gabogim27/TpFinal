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
using Microsoft.Win32;
using SSTIS.Interfaces;
using SSTIS.Utils;
using SysAnalizer;

namespace SSTIS
{
    public partial class frmAdmFamiliaPatente : Form, IAdmPatenteFamilia
    {
        public IServicioPatente ServicioPatente;

        public frmAdmFamiliaPatente(IServicioPatente ServicioPatente)
        {
            this.ServicioPatente = ServicioPatente;
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
            var borrada = ServicioPatente.BorrarPatente(familiaId, patenteId);
            if (borrada)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void frmAdmFamiliaPatente_Load(object sender, EventArgs e)
        {
            //var ABMFamilia = Program.simpleInyectorContainer.GetInstance<IABMFamilia>();VER PORQUE TRAER 
                        //LA FAMILIA EN NULL
            var familia = FamiliaInfo.NuevaFamilia;
            lblFamiliaText.Text = familia.Descripcion;
            CargarGrilla();
            //lstPatentes.DataSource = patenteBLL.Cargar();
        }

        private void CargarGrilla()
        {
            var patentes = ServicioPatente.RetrievePatentes();
            dgvAdminFamiliaPatente.DataSource = patentes;
            dgvAdminFamiliaPatente.Columns[0].ReadOnly = false;
            dgvAdminFamiliaPatente.Columns[1].ReadOnly = false;
            dgvAdminFamiliaPatente.Columns[3].ReadOnly = true;
            dgvAdminFamiliaPatente.Columns[2].Visible = false;
        }

        private void dgvAdminFamiliaPatente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgvAdminFamiliaPatente.CurrentCell is DataGridViewCheckBoxCell)
            {
                if (FamiliaNueva)
                {                   

                    DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dgvAdminFamiliaPatente.CurrentCell;

                    bool isChecked = (bool)checkbox.EditedFormattedValue;
                    var patenteSeleccionada = (Patente)dgvAdminFamiliaPatente.CurrentRow.DataBoundItem;
                    //Otorgada
                    if (checkbox.ColumnIndex == 0 && isChecked)
                    {
                        AsignarPatente(FamiliaInfo.NuevaFamilia.IdFamilia, patenteSeleccionada.IdPatente);
                    }
                    //Otorgada pero desasignada
                    else if (checkbox.ColumnIndex == 0 && !isChecked)
                    {
                        var patentes = ServicioPatente.ConsultarPatenteFamilia(FamiliaInfo.NuevaFamilia.IdFamilia);

                        if (patentes != null && patentes.Exists(x => x.IdPatente == patenteSeleccionada.IdPatente))
                        {
                            BorrarPatente(FamiliaInfo.NuevaFamilia.IdFamilia, patenteSeleccionada.IdPatente);
                        }
                        else
                        {
                            AsignarPatente(FamiliaInfo.NuevaFamilia.IdFamilia, patenteSeleccionada.IdPatente);
                        }
                    }
                    //
                }
                DialogResult = DialogResult.None;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
           DialogResult = DialogResult.OK;           
        }
    }
}
