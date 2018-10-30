using System.Windows.Forms;

namespace SSTIS.MessageBoxHelper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Alert
    {
        public static void ShowSimpleAlert(string msj)
        {
            MessageBox.Show(msj);
        }

        public static void ShowAlterWithButtonAndIcon(string msj, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(msj, title, buttons, icon);
        }
    }
}
