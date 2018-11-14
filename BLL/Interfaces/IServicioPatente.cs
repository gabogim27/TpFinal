using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL.Interfaces
{
    public interface IServicioPatente
    {
        List<Patente> RetrievePatentes();

        bool GuardarPatentesUsuario(List<Guid> patentesUsuario, Guid idUsuario);

        List<Patente> Cargar();//ver si esta no es la misma que retrievePatentes

        Guid ObtenerIdPatentePorDescripcion(string descripcion);

        bool BorrarPatente(Guid familiaId, Guid patenteId);

        bool AsignarPatente(Guid familiaId, Guid patenteId);

        bool ComprobarPatentesUsuario(Guid usuarioId);

        List<FamiliaPatente> ConsultarPatenteFamilia(Guid familiaId);

        List<UsuarioPatente> TraerPatenteDescrUsuario(Guid idUsuario);

        bool GuardarPatenteUsuario(Guid patenteId, Guid usuarioId);

        bool BorrarPatenteUsuario(Guid patenteId, Guid usuarioId);

        bool NegarPatenteUsuario(Guid patenteId, Guid usuarioId);

        bool HabilitarPatenteUsuario(Guid patenteId, Guid usuarioId);

        List<Patente> ObtenerPermisosFormulario(Guid formId);

        List<Patente> ObtenerPermisosFormularios();
    }
}
