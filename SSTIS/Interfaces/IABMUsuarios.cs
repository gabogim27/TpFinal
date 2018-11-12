using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;

namespace SSTIS.Interfaces
{
    public interface IABMUsuarios
    {
        void Show();
        DialogResult ShowDialog();
        Usuario usuarioSeleccionado();
    }
}
