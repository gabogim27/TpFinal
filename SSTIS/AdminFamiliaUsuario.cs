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
        private IServicioBitacora ServicioBitacora;
        private IServicioPatente ServicioPatenteImplementor;

        public frmAdminFamiliaUsuario(IServicio<Familia> ServicioFamilia, IServicioFamilia ServicioFamiliaImplementor,
            IServicioBitacora ServicioBitacora, IServicioPatente ServicioPatenteImplementor)
        {
            this.ServicioPatenteImplementor = ServicioPatenteImplementor;
            this.ServicioBitacora = ServicioBitacora;
            this.ServicioFamilia = ServicioFamilia;
            this.ServicioFamiliaImplementor = ServicioFamiliaImplementor;
            InitializeComponent();
        }

        private void frmAdminFamiliaUsuario_Load(object sender, EventArgs e)
        {
            CargaInicial();
        }

        private void CargaInicial()
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

            dgvFamiliaUsuario.Rows.Clear();
            dgvFamiliaUsuario.Refresh();

            for (int i = 0; i < Familias.Count; i++)
            {
                dgvFamiliaUsuario.Rows.Add(Familias[i].Descripcion.ToString(),
                     familiasUsuario?.Any(x => x == Familias[i].Descripcion) ?? false);
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
                        if (CheckeoPatentes(UsuarioSeleccionado, new Familia() {IdFamilia = idFamilia, Descripcion = familiaDescripcion}))
                        {
                            var result = ServicioFamiliaImplementor.BorrarFamiliaUsuario(idFamilia, UsuarioSeleccionado.IdUsuario);
                            if (!result)
                            {
                                ServicioBitacora.RegistrarEnBitacora(Log.Level.Alta.ToString(),
                                    string.Format("Ocurrio un error al eliminar un registro de la relacion FamiliaUsuario. Familia: " +
                                                  "{0}, usuario: {1}", idFamilia, UsuarioSeleccionado.IdUsuario), UsuarioSeleccionado);
                                MessageBox.Show("No se ha podido eliminar la relacion FamiliaUsuario. " +
                                                "Por favor contacte al Administrador.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No puede quitar esta familia");
                        }
                    }

                    dgvFamiliaUsuario.EndEdit();
                }
                DialogResult = DialogResult.None;
            }

            CargarGrilla();
        }

        public bool CheckeoPatentes(Usuario usuario, Familia familia)
        {
            var returnValue = true;

            returnValue = ServicioPatenteImplementor.CheckeoFamiliaParaBorrar(usuario, familia);

            return returnValue;

        }

        private void frmAdminFamiliaUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void frmAdminFamiliaUsuario_Enter(object sender, EventArgs e)
        {
            CargaInicial();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
