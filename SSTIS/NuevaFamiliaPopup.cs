using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSTIS
{
    public partial class NuevaFamiliaPopup : Form
    {
        public NuevaFamiliaPopup()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var objFamilia = new BE.Familia();

                if (!string.IsNullOrEmpty(txtFamilia.Text.Trim()))
                {
                    objFamilia.IdFamilia = Guid.NewGuid();
                    objFamilia.Descripcion = txtFamilia.Text.Trim();
                    //BLL.FamiliaBLL.Getinstancia().Create(objFamilia);
                }
                else
                {
                    MessageBox.Show("Por favor ingrese una familia valida!!!");
                }                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
