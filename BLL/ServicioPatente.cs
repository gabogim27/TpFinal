using BE;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ServicioPatente : IServicioPatente
    {
        public IRepositorioPatente RepositorioPatente;

        public ServicioPatente(IRepositorioPatente repositorioPatente)
        {
            this.RepositorioPatente = repositorioPatente;
        }
        public List<Patente> RetrievePatentes()
        {
            return RepositorioPatente.RetrievePatentes();
        }

        public bool GuardarPatentesUsuario(List<Guid> patentesUsuario, Guid idUsuario)
        {
            return RepositorioPatente.GuardarPatentesUsuario(patentesUsuario, idUsuario);
        }

        public List<Patente> Cargar()
        {
            return RepositorioPatente.Cargar();
        }

        public Guid ObtenerIdPatentePorDescripcion(string descripcion)
        {
            return RepositorioPatente.ObtenerIdPatentePorDescripcion(descripcion);
        }

        public bool BorrarPatente(Guid familiaId, Guid patenteId)
        {
            return RepositorioPatente.BorrarPatente(familiaId, patenteId);
        }

        public bool AsignarPatente(Guid familiaId, Guid patenteId)
        {
            return RepositorioPatente.AsignarPatente(familiaId, patenteId);
        }

        public bool ComprobarPatentesUsuario(Guid usuarioId)
        {
            return RepositorioPatente.ComprobarPatentesUsuario(usuarioId);
        }

        public List<FamiliaPatente> ConsultarPatenteFamilia(Guid familiaId)
        {
            return RepositorioPatente.ConsultarPatenteFamilia(familiaId);
        }

        public List<UsuarioPatente> TraerPatenteDescrUsuario(Guid idUsuario)
        {
            return RepositorioPatente.TraerPatenteDescrUsuario(idUsuario);
        }

        public bool GuardarPatenteUsuario(Guid patenteId, Guid usuarioId)
        {
            return RepositorioPatente.GuardarPatenteUsuario(patenteId, usuarioId);
        }

        public bool BorrarPatenteUsuario(Guid patenteId, Guid usuarioId)
        {
            return RepositorioPatente.BorrarPatenteUsuario(patenteId, usuarioId);
        }

        public bool NegarPatenteUsuario(Guid patenteId, Guid usuarioId)
        {
            return RepositorioPatente.NegarPatenteUsuario(patenteId, usuarioId);
        }

        public bool HabilitarPatenteUsuario(Guid patenteId, Guid usuarioId)
        {
            return RepositorioPatente.HabilitarPatenteUsuario(patenteId, usuarioId);
        }

        public List<Patente> ObtenerPermisosFormulario(Guid formId)
        {
            return RepositorioPatente.ObtenerPermisosFormulario(formId);
        }

        public List<Patente> ObtenerPermisosFormularios()
        {
            return RepositorioPatente.ObtenerPermisosFormularios();
        }

        public List<UsuarioPatente> ConsultarUsuarioPatente(Guid usuarioId, Guid patenteId)
        {
            return RepositorioPatente.ConsultarUsuarioPatente(usuarioId, patenteId);
        }

        public bool VerificarDatos(List<Guid> idsToDelete)
        {
            return RepositorioPatente.VerificarDatos(idsToDelete);
        }

        public bool CheckeoDePatentes(Usuario usuarioToDelete)
        {
            return RepositorioPatente.CheckeoDePatentes(usuarioToDelete);
        }

        public bool CheckeoDePatentesParaBorrar(Usuario usuario, bool requestFamilia = false, bool requestFamiliaUsuario = false,
            Guid? idAQuitar = null, bool esBorrado = false)
        {
            return RepositorioPatente.CheckeoDePatentesParaBorrar(usuario, requestFamilia, requestFamiliaUsuario, idAQuitar, esBorrado);
        }

        public bool CheckeoFamiliaParaBorrar(Usuario usuario = null, Familia familiaABorrar = null, Guid? idPatente = null)
        {
            return RepositorioPatente.CheckeoFamiliaParaBorrar(usuario, familiaABorrar, idPatente);
        }
    }
}
