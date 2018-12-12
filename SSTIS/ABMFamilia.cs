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
        public IAdmPatenteFamilia AdminPatFamilia;
        public IServicio<Familia> ServicioFamilia;
        public IServicioPatente ServicioPatenteImplementor;
        public Familia familiaSeleccionada = null;

        public frmABMFamilia(INuevaFamilia NuevaFamilia, IServicioFamilia ServicioFamiliaImplementor,
            IServicio<Familia> ServicioFamilia, IModificarFamilia ModificarFamilia, IAdmPatenteFamilia AdminPatFamilia, IServicioPatente ServicioPatenteImplementor)
        {
            this.NuevaFamilia = NuevaFamilia;
            this.ModificarFamilia = ModificarFamilia;
            this.ServicioFamiliaImplementor = ServicioFamiliaImplementor;
            this.ServicioFamilia = ServicioFamilia;
            this.AdminPatFamilia = AdminPatFamilia;
            this.ServicioPatenteImplementor = ServicioPatenteImplementor;
            InitializeComponent();
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            NuevaFamilia.ShowDialog();

            if (FamiliaInfo.NuevaFamilia != null)
            {
                //var created = ServicioFamilia.Create(FamiliaInfo.NuevaFamilia);
                familiaSeleccionada = new Familia
                {
                    IdFamilia = FamiliaInfo.NuevaFamilia.IdFamilia,
                    Descripcion = FamiliaInfo.NuevaFamilia.Descripcion
                };

                var res = AdminPatFamilia.ShowDialog();
                if (res == DialogResult.OK)
                {
                }

                CargarFamiliaCheckedList();
                chklFamilias.Refresh();
                //Reseteamos el objeto por cada familia nueva creada
                FamiliaInfo.NuevaFamilia = null;
                AdminPatFamilia.FamiliaNueva = false;
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

        public Familia ObtenerFamiliaSeleccionada()
        {
            return familiaSeleccionada;
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            var familiasAEliminar = chklFamilias.CheckedItems.OfType<Familia>().ToList();

            foreach (var familiaToDelete in familiasAEliminar)
            {
                var returnValue = false;


                if (ServicioPatenteImplementor.CheckeoFamiliaParaBorrar(null, familiaToDelete, null))
                {
                    returnValue = true;
                }
                else
                {
                    MessageBox.Show("La familia actualmente esta en uso");
                }


                if (returnValue)
                {
                    var exitoso = ServicioFamilia.Delete(new Familia() { Descripcion = familiaToDelete.Descripcion, IdFamilia = ServicioFamiliaImplementor.ObtenerIdFamiliaPorDescripcion(familiaToDelete.Descripcion) });
                }
            }

            CargarFamiliaCheckedList();
            //if (familiasAEliminar.Count != 0)
            //{
            //    var confirmResult = MessageBox.Show("Esta seguro que desea eliminar las familias " +
            //                                        "seleccionadas?",
            //        "Confirme Baja.",
            //        MessageBoxButtons.YesNo);
            //    if (confirmResult == DialogResult.Yes)
            //    {
            //        var familiaNoEliminadas = new List<string>();

            //        foreach (var familiaToDelete in familiasAEliminar)
            //        {
            //            if (!ServicioFamilia.Delete(familiaToDelete))
            //            {
            //                familiaNoEliminadas.Add(familiaToDelete.Descripcion);
            //            }
            //        }

            //        if (familiaNoEliminadas.Count > 0)
            //        {
            //            var familiasAInformar = string.Join(", ", familiaNoEliminadas.ToArray());
            //            MessageBox.Show(string.Format("Las Familias: {0} no se pueden eliminar" +
            //                                          "ya que se encuentran en uso.", familiasAInformar));
            //        }
            //        CargarFamiliaCheckedList();
            //        chklFamilias.Refresh();
            //        MessageBox.Show("Familia/s eliminada's correctamente.");
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Debe seleccionar una familia para poder eliminar.");
            //}

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
                    if (modified)
                    {
                        MessageBox.Show("Familia modificada correctamente");
                        AdminPatFamilia.FamiliaNueva = true;
                    }

                    var res = AdminPatFamilia.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        //MessageBox.Show("kndaklbajkbcawibcawjk");
                    }

                    familiaSeleccionada = FamiliaInfo.NuevaFamilia;
                    CargarFamiliaCheckedList();
                    chklFamilias.Refresh();
                    //Reseteamos el objeto por cada familia nueva creada
                    FamiliaInfo.NuevaFamilia = null;
                    AdminPatFamilia.FamiliaNueva = false;
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

        private void frmABMFamilia_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void frmABMFamilia_Enter(object sender, EventArgs e)
        {
            CargarFamiliaCheckedList();
        }

        private void btnModificarPatentes_Click(object sender, EventArgs e)
        {
            if (chklFamilias.CheckedItems.Count != 0)
            {
                FamiliaInfo.NuevaFamilia = (Familia)chklFamilias.CheckedItems[0];
                AdminPatFamilia.FamiliaNueva = true;
                var res = AdminPatFamilia.ShowDialog();
                if (res == DialogResult.OK)
                {
                    //MessageBox.Show("kndaklbajkbcawibcawjk");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Familia.");
            }
            FamiliaInfo.NuevaFamilia = null;
            AdminPatFamilia.FamiliaNueva = false;
        }
    }
}
