using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSTIS.Interfaces
{
    public interface IRestaurarCopiaDeSeguridad
    {
        Form MdiParent { get; set; }
        void Show();
    }
}
