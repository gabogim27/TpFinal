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

        public void NegarPatenteUsuario(List<Guid> patentesId, Guid usuarioId)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
    }
}
