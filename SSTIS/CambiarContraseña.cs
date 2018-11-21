using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SSTIS.Interfaces;

namespace SSTIS
{
    public partial class frmCambiarContraseña : Form, ICambiarContraseña
    {
        public frmCambiarContraseña()
        {
            InitializeComponent();
        }

        private void frmCambiarContraseña_Load(object sender, EventArgs e)
        {

        }
    }
}
