using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSTIS.Interfaces
{
    public interface IAdmPatenteFamilia
    {
        void Show();

        DialogResult ShowDialog();

        bool FamiliaNueva { get; set; }

        void AsignarPatente(Guid familiaId, Guid patenteId);

        void BorrarPatente(Guid familiaId, Guid patenteId);
    }
}
