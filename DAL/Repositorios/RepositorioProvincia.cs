using BE;
using DAL.Interfaces;

namespace DAL.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepositorioProvincia : IRepository<Provincia>
    {
        public IDao<Provincia> ProvinciaDao { get; }

        public RepositorioProvincia(IDao<Provincia> provinciaDao)
        {
            this.ProvinciaDao = provinciaDao ?? throw new ArgumentNullException(nameof(provinciaDao));
        }

        public bool Create(Provincia ObjAlta)
        {
            return ProvinciaDao.Create(ObjAlta);
        }

        public Provincia GetById(Guid id)
        {
            return ProvinciaDao.GetById(id);
        }

        public List<Provincia> Retrive()
        {
            return ProvinciaDao.Retrive();
        }

        public bool Delete(Provincia ObjDel)
        {
            return ProvinciaDao.Delete(ObjDel);
        }

        public bool Update(Provincia ObjUpd)
        {
            return ProvinciaDao.Update(ObjUpd);
        }
    }
}
