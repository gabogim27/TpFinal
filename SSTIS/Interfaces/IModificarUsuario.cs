using System.Windows.Forms;
using BE;

namespace SSTIS.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IModificarUsuario
    {
        void Show();
        Form MdiParent { get; set; }
        DialogResult ShowDialog();
    }
}
