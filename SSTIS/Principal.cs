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
    public partial class Principal : Form, IPrincipal
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
