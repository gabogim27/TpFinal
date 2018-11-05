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

namespace SSTIS
{
    public partial class frmNuevaFamilia : Form, INuevaFamilia
    {
        public IServicio<Familia> ServicioFamilia;

        public frmNuevaFamilia(IServicio<Familia> servicioFamilia)
        {
            ServicioFamilia = servicioFamilia;
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
                    ServicioFamilia.Create(objFamilia);
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
    }
}
