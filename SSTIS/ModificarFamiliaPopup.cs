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
using SSTIS.Interfaces;
using SSTIS.MessageBoxHelper;
using SSTIS.Utils;

namespace SSTIS
{
    public partial class frmModificarFamiliaPopup : Form, IModificarFamilia
    {
        public frmModificarFamiliaPopup()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtFamilia.Text.Trim()))
                {
                    var nuevaFamilia = txtFamilia.Text.Trim();
                    if (FamiliaInfo.ListaFamilias.All(x => x.Descripcion.ToUpper()
                                                           != nuevaFamilia.ToUpper()))
                    {
                        //FamiliaInfo.NuevaFamilia.IdFamilia = Guid.NewGuid();
                        
                        FamiliaInfo.NuevaFamilia.Descripcion = txtFamilia.Text.Trim();
                        //Limpiamos el textbox
                        txtFamilia.Text = String.Empty;
                        this.Hide();
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void frmModificarFamiliaPopup_Load(object sender, EventArgs e)
        {
            if (FamiliaInfo.NuevaFamilia != null)
            {
                txtFamilia.Text = FamiliaInfo.NuevaFamilia.Descripcion;
            }
        }

        private void frmModificarFamiliaPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
