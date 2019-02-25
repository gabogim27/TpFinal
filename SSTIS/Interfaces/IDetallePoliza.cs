using System.Windows.Forms;
using BE;

namespace SSTIS.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDetallePoliza
    {
        void Show();
        DialogResult ShowDialog();
        Form MdiParent { get; set; }
        Poliza polizaSeleccionada();
    }
}
