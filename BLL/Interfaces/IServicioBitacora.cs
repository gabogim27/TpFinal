using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL.Interfaces
{
    public interface IServicioBitacora
    {
        void RegistrarEnBitacora(string criticidad, string mensaje, Usuario usuario = null);

        void FiltrarBitacora(BitacoraFiltros filtros);        

        int GenerarDVH(Usuario usu);       

        List<Bitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<Guid> idUsuarios, List<string> criticidades, DateTime desde, DateTime hasta);
    }
}
