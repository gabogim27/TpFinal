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
using SSTIS.MessageBoxHelper;
using SSTIS.Utils;

namespace SSTIS
{
    public partial class frmABMFamilia : Form, IABMFamilia
    {
        public INuevaFamilia NuevaFamilia;
        public IModificarFamilia ModificarFamilia;
        public IServicioFamilia ServicioFamiliaImplementor;
        public IServicio<Familia> ServicioFamilia;

        public frmABMFamilia(INuevaFamilia NuevaFamilia, IServicioFamilia ServicioFamiliaImplementor,
            IServicio<Familia> ServicioFamilia, IModificarFamilia ModificarFamilia)
        {
            this.NuevaFamilia = NuevaFamilia;
            this.ModificarFamilia = ModificarFamilia;
            this.ServicioFamiliaImplementor = ServicioFamiliaImplementor;
            this.ServicioFamilia = ServicioFamilia;
            InitializeComponent();
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            NuevaFamilia.ShowDialog();
            if (FamiliaInfo.NuevaFamilia != null)
            {
                var created = ServicioFamilia.Create(FamiliaInfo.NuevaFamilia);
                CargarFamiliaCheckedList();
                chklFamilias.Refresh();
                //Reseteamos el objeto por cada familia nueva creada
                FamiliaInfo.NuevaFamilia = null;
                Alert.ShowSimpleAlert("Familia creada correctamente");
            }

        }

        private void frmABMFamilia_Load(object sender, EventArgs e)
        {
            CargarFamiliaCheckedList();
        }

        private void CargarFamiliaCheckedList()
        {
            FamiliaInfo.ListaFamilias = ServicioFamilia.Retrive();
            chklFamilias.DataSource = FamiliaInfo.ListaFamilias;
            chklFamilias.DisplayMember = "Descripcion";
            chklFamilias.ValueMember = "IdFamilia";
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            var familiasAEliminar = chklFamilias.CheckedItems.OfType<Familia>().ToList();

            if (familiasAEliminar.Count != 0)
            {
                var confirmResult = MessageBox.Show("Esta seguro que desea eliminar las familias " +
                                                    "seleccionadas?",
                    "Confirme Baja.",
                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    var familiaNoEliminadas = new List<string>();

                    foreach (var familiaToDelete in familiasAEliminar)
                    {
                        if (!ServicioFamilia.Delete(familiaToDelete))
                        {
                            familiaNoEliminadas.Add(familiaToDelete.Descripcion);
                        }
                    }

                    if (familiaNoEliminadas.Count > 0)
                    {
                        var familiasAInformar = string.Join(", ", familiaNoEliminadas.ToArray());
                        MessageBox.Show(string.Format("Las Familias: {0} no se pueden eliminar" +
                                                      "ya que se encuentran en uso.", familiasAInformar));
                    }
                    CargarFamiliaCheckedList();
                    chklFamilias.Refresh();
                    MessageBox.Show("Familia/s eliminada's correctamente.");
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una familia para poder eliminar.");
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (chklFamilias.CheckedItems.Count == 1)
            {
                FamiliaInfo.NuevaFamilia = (Familia)chklFamilias.CheckedItems[0];
                ModificarFamilia.ShowDialog();
                if (FamiliaInfo.NuevaFamilia != null)
                {
                    var modified = ServicioFamilia.Update(FamiliaInfo.NuevaFamilia);
                    CargarFamiliaCheckedList();
                    chklFamilias.Refresh();
                    //Reseteamos el objeto por cada familia nueva creada
                    FamiliaInfo.NuevaFamilia = null;
                    Alert.ShowSimpleAlert("Familia modificada correctamente");
                }
            }
            else if (chklFamilias.CheckedItems.Count > 1)
            {
                MessageBox.Show("Se debe modificar de a un item por vez.");
            }
            else
            {
                MessageBox.Show("Por favor seleccione una familia.");
            }
        }

        private void chklFamilias_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue is CheckState.Checked && chklFamilias.CheckedItems.Count > 0)
            {
                FamiliaInfo.NuevaFamilia = (Familia)chklFamilias.CheckedItems[0];
            }
        }
    }
}
