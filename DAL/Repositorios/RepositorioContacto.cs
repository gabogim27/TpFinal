using BE;
using DAL.Interfaces;

namespace DAL.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepositorioContacto : IRepository<Contacto>
    {
        public IDao<Contacto> ContactoDao { get; }

        public RepositorioContacto(IDao<Contacto> contactoDao)
        {
            this.ContactoDao = contactoDao ?? throw new ArgumentNullException(nameof(contactoDao));
        }
        public bool Create(Contacto ObjAlta)
        {
            return ContactoDao.Create(ObjAlta);
        }

        public Contacto GetById(Guid id)
        {
            return ContactoDao.GetById(id);
        }

        public List<Contacto> Retrive()
        {
            return ContactoDao.Retrive();
        }

        public bool Delete(Contacto ObjDel)
        {
            return ContactoDao.Delete(ObjDel);
        }

        public bool Update(Contacto ObjUpd)
        {
            return ContactoDao.Update(ObjUpd);
        }
    }
}
