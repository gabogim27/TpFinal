using BE;

namespace DAL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRepositorioPatente
    {
        List<Patente> RetrievePatentes();

        bool GuardarPatentesUsuario(List<Guid> patentesUsuario, Guid idUsuario);

        void NegarPatenteUsuario(List<Guid> patentesId, Guid usuarioId);

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

        List<UsuarioPatente> ConsultarUsuarioPatente(Guid usuarioId, Guid patenteId);

        bool VerificarDatos(List<Guid> idsToDelete);
        bool CheckeoDePatentes(Usuario usuarioToDelete);

        bool CheckeoDePatentesParaBorrar(Usuario usuario, bool requestFamilia = false, bool requestFamiliaUsuario = false, Guid? idAQuitar = null, bool esBorrado = false);

        void BorrarListaPatentesUsuario(List<Guid> patentesId, Guid usuarioId);

        List<UsuarioPatente> ConsultarUsuarioPatente(Guid usuarioId);

        bool CheckeoFamiliaParaBorrar(Usuario usuario = null, Familia familiaABorrar = null, Guid? idPatente = null);
    }
}
