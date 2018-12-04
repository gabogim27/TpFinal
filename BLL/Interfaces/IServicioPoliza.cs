using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL.Interfaces
{
    public interface IServicioPoliza
    {
        int TraerUlitmoNumeroDePoliza();

        List<Cobertura> TraerCoberturas();
    }
}
