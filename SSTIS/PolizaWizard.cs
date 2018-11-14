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
    public partial class PolizaWizard : Form
    {
        public PolizaWizard()
        {
            InitializeComponent();
        }

        private void advancedWizardPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void stwControl_SelectedPageChanged(object sender, EventArgs e)
        {

        }

        private void PolizaWizard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
