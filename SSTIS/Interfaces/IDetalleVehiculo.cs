using System.Windows.Forms;

namespace SSTIS.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDetalleVehiculo
    {
        void Show();
        DialogResult ShowDialog();
        Form MdiParent { get; set; }
    }
}
