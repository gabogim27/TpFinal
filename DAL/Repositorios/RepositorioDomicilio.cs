using BE;
using DAL.Interfaces;

namespace DAL.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepositorioDomicilio : IRepository<Domicilio>
    {
        public IDao<Domicilio> DomicilioDao { get; }

        public RepositorioDomicilio(IDao<Domicilio> domicilioDao)
        {
            this.DomicilioDao = domicilioDao ?? throw new ArgumentNullException(nameof(domicilioDao));
        }

        public bool Create(Domicilio ObjAlta)
        {
            return DomicilioDao.Create(ObjAlta);
        }

        public bool Delete(Domicilio ObjDel)
        {
            return DomicilioDao.Delete(ObjDel);
        }

        public Domicilio GetById(Guid id)
        {
            return DomicilioDao.GetById(id);
        }

        public List<Domicilio> Retrive()
        {
            return DomicilioDao.Retrive();
        }

        public bool Update(Domicilio ObjUpd)
        {
            throw new NotImplementedException();
        }
    }
}
