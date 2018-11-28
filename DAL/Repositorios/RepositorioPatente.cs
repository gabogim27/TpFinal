using BE;
using DAL.Impl;
using DAL.Interfaces;

namespace DAL.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepositorioPatente : IRepositorioPatente
    {
        public IPatenteDao PatenteDao;

        public RepositorioPatente(IPatenteDao patenteDao)
        {
            this.PatenteDao = patenteDao;
        }
        public List<Patente> RetrievePatentes()
        {
            return PatenteDao.RetrievePatentes();
        }

        public bool GuardarPatentesUsuario(List<Guid> patentesUsuario, Guid idUsuario)
        {
            return PatenteDao.GuardarPatentesUsuario(patentesUsuario, idUsuario);
        }

        public void NegarPatenteUsuario(List<Guid> patentesId, Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        public List<Patente> Cargar()
        {
            return PatenteDao.Cargar();
        }

        public Guid ObtenerIdPatentePorDescripcion(string descripcion)
        {
            return PatenteDao.ObtenerIdPatentePorDescripcion(descripcion);
        }

        public bool BorrarPatente(Guid familiaId, Guid patenteId)
        {
            return PatenteDao.BorrarPatente(familiaId, patenteId);
        }

        public bool AsignarPatente(Guid familiaId, Guid patenteId)
        {
            return PatenteDao.AsignarPatente(familiaId, patenteId);
        }

        public bool ComprobarPatentesUsuario(Guid usuarioId)
        {
            return PatenteDao.ComprobarPatentesUsuario(usuarioId);
        }

        public List<FamiliaPatente> ConsultarPatenteFamilia(Guid familiaId)
        {
            return PatenteDao.ConsultarPatenteFamilia(familiaId);
        }

        public List<UsuarioPatente> TraerPatenteDescrUsuario(Guid idUsuario)
        {
            return PatenteDao.TraerPatenteDescrUsuario(idUsuario);
        }

        public bool GuardarPatenteUsuario(Guid patenteId, Guid usuarioId)
        {
            return PatenteDao.GuardarPatenteUsuario(patenteId, usuarioId);
        }

        public bool BorrarPatenteUsuario(Guid patenteId, Guid usuarioId)
        {
            return PatenteDao.BorrarPatenteUsuario(patenteId, usuarioId);
        }

        public bool NegarPatenteUsuario(Guid patenteId, Guid usuarioId)
        {
            return PatenteDao.NegarPatenteUsuario(patenteId, usuarioId);
        }

        public bool HabilitarPatenteUsuario(Guid patenteId, Guid usuarioId)
        {
            return PatenteDao.HabilitarPatenteUsuario(patenteId, usuarioId);
        }

        public List<Patente> ObtenerPermisosFormulario(Guid formId)
        {
            return PatenteDao.ObtenerPermisosFormulario(formId);
        }

        public List<Patente> ObtenerPermisosFormularios()
        {
            return PatenteDao.ObtenerPermisosFormularios();
        }

        public List<UsuarioPatente> ConsultarUsuarioPatente(Guid usuarioId, Guid patenteId)
        {
            return PatenteDao.ConsultarUsuarioPatente(usuarioId, patenteId);
        }

        public bool VerificarDatos(List<Guid> idsToDelete)
        {
            return PatenteDao.VerificarDatos(idsToDelete);
        }

        public bool CheckeoDePatentes(Usuario usuarioToDelete)
        {
            return PatenteDao.CheckeoDePatentes(usuarioToDelete);
        }

        public bool CheckeoDePatentesParaBorrar(Usuario usuario, bool requestFamilia = false, bool requestFamiliaUsuario = false,
            Guid? idAQuitar = null)
        {
            return PatenteDao.CheckeoDePatentesParaBorrar(usuario, requestFamilia, requestFamiliaUsuario);
        }
    }
}
