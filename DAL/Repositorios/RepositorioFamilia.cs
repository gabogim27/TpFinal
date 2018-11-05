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
    }
}
