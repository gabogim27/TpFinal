using BE;
using DAL.Interfaces;

namespace DAL.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepositorioFamilia : IRepository<Familia>, IRepositorioFamilia
    {
        public IDao<Familia> FamiliaDao;
        public IFamiliaDao FamiliaDaoImplementor;

        public RepositorioFamilia(IDao<Familia> familiaDao, IFamiliaDao familiaDaoImplementor)
        {
            this.FamiliaDao = familiaDao;
            this.FamiliaDaoImplementor = familiaDaoImplementor;
        }
        public bool Create(Familia ObjAlta)
        {
            return FamiliaDao.Create(ObjAlta);
        }

        public Familia GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Familia> Retrive()
        {
            return FamiliaDao.Retrive();
        }

        public bool Delete(Familia ObjDel)
        {
            return FamiliaDao.Delete(ObjDel);
        }

        public bool Update(Familia ObjUpd)
        {
            return FamiliaDao.Update(ObjUpd);
        }

        public bool GuardarFamiliaUsuario(List<Guid> familiaIds, Guid usuarioId)
        {
            return FamiliaDaoImplementor.GuardarFamiliaUsuario(familiaIds, usuarioId);
        }

        public bool GuardarFamiliasUsuario(Guid familiaId, Guid usuarioId)
        {
            return FamiliaDaoImplementor.GuardarFamiliasUsuario(familiaId, usuarioId);
        }

        public bool BorrarFamiliaUsuario(Guid familiaId, Guid usuarioId)
        {
            return FamiliaDaoImplementor.BorrarFamiliaUsuario(familiaId, usuarioId);
        }

        public List<Patente> ObtenerPatentesFamilia(List<Guid> familiaIds)
        {
            return FamiliaDaoImplementor.ObtenerPatentesFamilia(familiaIds);
        }

        public Guid ObtenerIdFamiliaPorDescripcion(string descripcion)
        {
            return FamiliaDaoImplementor.ObtenerIdFamiliaPorDescripcion(descripcion);
        }

        public Guid ObtenerIdFamiliaPorUsuario(Guid usuarioId)
        {
            return FamiliaDaoImplementor.ObtenerIdFamiliaPorUsuario(usuarioId);
        }

        public string ObtenerDescripcionFamiliaPorId(Guid familiaId)
        {
            return FamiliaDaoImplementor.ObtenerDescripcionFamiliaPorId(familiaId);
        }

        public bool ComprobarUsoFamilia(Guid usuarioId)
        {
            return FamiliaDaoImplementor.ComprobarUsoFamilia(usuarioId);
        }

        public List<string> TraerFamiliaUsuarioDescripcion(Guid IdUsuario)
        {
            return FamiliaDaoImplementor.TraerFamiliaUsuarioDescripcion(IdUsuario);
        }

        public List<Guid> ObtenerIdsFamiliasPorUsuario(Guid usuarioId)
        {
            return FamiliaDaoImplementor.ObtenerIdsFamiliasPorUsuario(usuarioId);
        }

        public void BorrarFamiliaDeFamiliaPatente(Guid familiaId)
        {
            FamiliaDaoImplementor.BorrarFamiliaDeFamiliaPatente(familiaId);
        }

        public List<Familia> ObtenerFamiliasPorUsuario(Guid usuarioId)
        {
            return FamiliaDaoImplementor.ObtenerFamiliasPorUsuario(usuarioId);
        }

        public List<Guid> ObtenerPatentesPorFamiliaId(Guid familiaId)
        {
            return FamiliaDaoImplementor.ObtenerPatentesPorFamiliaId(familiaId);
        }
    }
}
