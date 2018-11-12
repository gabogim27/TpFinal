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
using SSTIS.Interfaces;
using SSTIS.Utils;

namespace SSTIS
{
    public partial class frmAdminFamiliaUsuario : Form, IAdminFamiliaUsuario
    {
        public IServicio<Familia> ServicioFamilia;
        public IServicioFamilia ServicioFamiliaImplementor;
        private Usuario UsuarioSeleccionado = new Usuario();
        private List<Familia> Familias = new List<Familia>();

        public frmAdminFamiliaUsuario(IServicio<Familia> ServicioFamilia, IServicioFamilia ServicioFamiliaImplementor)
        {
            this.ServicioFamilia = ServicioFamilia;
            this.ServicioFamiliaImplementor = ServicioFamiliaImplementor;
            InitializeComponent();
        }

        private void frmAdminFamiliaUsuario_Load(object sender, EventArgs e)
        {
            UsuarioSeleccionado = Program.simpleInyectorContainer.GetInstance<IABMUsuarios>().usuarioSeleccionado();
            lblUsuario.Text = UsuarioSeleccionado.Email;
            dgvFamiliaUsuario.Rows.Clear();
            dgvFamiliaUsuario.Refresh();
            CargarGrilla();
            dgvFamiliaUsuario.Columns[1].ReadOnly = false;
        }

        private void CargarGrilla()
        {
            var familiasUsuario =
                ServicioFamiliaImplementor.TraerFamiliaUsuarioDescripcion(UsuarioSeleccionado.IdUsuario);
            Familias = ServicioFamilia.Retrive();

            for (int i = 0; i < Familias.Count; i++)
            {
                dgvFamiliaUsuario.Rows.Add(Familias[i].Descripcion.ToString(),
                     familiasUsuario?.Any(x => x.Contains(Familias[i].Descripcion)) ?? false);
            }
        }

        private void dgvFamiliaUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFamiliaUsuario.CurrentCell is DataGridViewCheckBoxCell)
            {
                if (UsuarioSeleccionado != null)
                {
                    DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dgvFamiliaUsuario.CurrentCell;

                    bool isChecked = (bool)checkbox.EditedFormattedValue;
                    var familiaDescripcion = dgvFamiliaUsuario.CurrentRow.Cells[0].Value.ToString();
                    var idFamilia = Familias.FirstOrDefault(f => f.Descripcion == familiaDescripcion).IdFamilia;
                    //Otorgada
                    if (checkbox.ColumnIndex == 1 && isChecked)
                    {
                        ServicioFamiliaImplementor.GuardarFamiliasUsuario(idFamilia, UsuarioSeleccionado.IdUsuario);
                    }
                    else
                    {
                        ServicioFamiliaImplementor.BorrarFamiliaUsuario(idFamilia, UsuarioSeleccionado.IdUsuario);
                    }

                    dgvFamiliaUsuario.EndEdit();
                }
                DialogResult = DialogResult.None;
            }
        }

        private void frmAdminFamiliaUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
