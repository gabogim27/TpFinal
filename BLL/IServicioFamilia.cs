using BE;

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

        List<Patente> ObtenerPatentesFamilia(List<Guid> familiaIds);

        Guid ObtenerIdFamiliaPorDescripcion(string descripcion);

        Guid ObtenerIdFamiliaPorUsuario(Guid usuarioId);

        string ObtenerDescripcionFamiliaPorId(Guid familiaId);

        bool ComprobarUsoFamilia(Guid familiaId);
    }
}
