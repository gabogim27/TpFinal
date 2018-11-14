using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;

namespace SSTIS.Interfaces
{
    public interface ICambiarIdioma
    {
        void Show();
        DialogResult ShowDialog();
        Form MdiParent { get; set; }
    }
}
