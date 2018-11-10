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
    public partial class frmNuevaFamilia : Form, INuevaFamilia
    {
        public IServicio<Familia> ServicioFamilia;
        public IAdmPatenteFamilia AdminPatFamilia;

        public frmNuevaFamilia(IServicio<Familia> servicioFamilia, IAdmPatenteFamilia AdminPatFamilia)
        {
            ServicioFamilia = servicioFamilia;
            this.AdminPatFamilia = AdminPatFamilia;
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                FamiliaInfo.NuevaFamilia = new BE.Familia();
                
                if (!string.IsNullOrEmpty(txtFamilia.Text.Trim()))
                {
                    var nuevaFamilia = txtFamilia.Text.Trim();
                    if (FamiliaInfo.ListaFamilias.All(x => x.Descripcion.ToUpper() 
                                                           != nuevaFamilia.ToUpper()))
                    {
                        FamiliaInfo.NuevaFamilia.IdFamilia = Guid.NewGuid();
                        FamiliaInfo.NuevaFamilia.Descripcion = txtFamilia.Text.Trim();
                        //Limpiamos el textbox
                        txtFamilia.Text = String.Empty;

                    }
                    else
                    {
                        Alert.ShowSimpleAlert("La Familia ingresada ya existe.");
                    }
                }
                else
                {
                    Alert.ShowSimpleAlert("Por favor ingrese una familia.");
                }

                //var res = AdminPatFamilia.ShowDialog();
                //if (res == DialogResult.OK)
                //{
                //    MessageBox.Show("Familia y Patentes registradas");
                //}
                Hide(); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
