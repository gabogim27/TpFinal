using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSTIS.Interfaces
{
    public interface ICambiarContraseña
    {
        void Show();
        Form MdiParent { get; set; }
        DialogResult ShowDialog();
    }
}
