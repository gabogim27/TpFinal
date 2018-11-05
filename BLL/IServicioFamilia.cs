namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IServicioFamilia
    {
        bool GuardarFamiliaUsuario(List<Guid> familiaIds, Guid usuarioId);
    }
}
