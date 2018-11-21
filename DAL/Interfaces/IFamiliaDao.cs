using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.Interfaces
{
    public interface IFamiliaDao
    {
        bool GuardarFamiliaUsuario(List<Guid> familiaId, Guid usuarioId);

        bool GuardarFamiliasUsuario(Guid familiaId, Guid usuarioId);

        bool BorrarFamiliaUsuario(Guid familiaId, Guid usuarioId);

        List<Patente> ObtenerPatentesFamilia(List<Guid> familiaId);

        Guid ObtenerIdFamiliaPorDescripcion(string descripcion);

        Guid ObtenerIdFamiliaPorUsuario(Guid usuarioId);

        string ObtenerDescripcionFamiliaPorId(Guid familiaId);

        bool ComprobarUsoFamilia(Guid usuarioId);

        List<string> TraerFamiliaUsuarioDescripcion(Guid IdUsuario);

        List<Guid> ObtenerIdsFamiliasPorUsuario(Guid usuarioId);

        void BorrarFamiliaDeFamiliaPatente(Guid familiaId);
        List<Familia> ObtenerFamiliasPorUsuario(Guid usuarioId);
    }
}
