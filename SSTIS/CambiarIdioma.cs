using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Interfaces;
using SSTIS.Interfaces;

namespace SSTIS
{
    public partial class frmCambiarIdioma : Form, ICambiarIdioma
    {
        private IServicioIdioma ServicioIdioma;

        public frmCambiarIdioma(IServicioIdioma ServicioIdioma)
        {
            this.ServicioIdioma = ServicioIdioma;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void frmCambiarIdioma_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void frmCambiarIdioma_Load(object sender, EventArgs e)
        {
            CargarCombo();
        }

        private void CargarCombo()
        {
            var idiomas = ServicioIdioma.GetAllLanguages();
            cboIdioma.DataSource = idiomas;
            cboIdioma.ValueMember = "IdIdioma";
            cboIdioma.DisplayMember = "Descripcion";
        }
    }
}
