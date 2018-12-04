using BE;
using DAL.Interfaces;

namespace DAL.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepositorioCliente : IRepository<Cliente>
    {
        private IDao<Cliente> ClienteDao;

        public RepositorioCliente(IDao<Cliente> ClienteDao)
        {
            this.ClienteDao = ClienteDao;
        }

        public bool Create(Cliente ObjAlta)
        {
            return ClienteDao.Create(ObjAlta);
        }

        public Cliente GetById(Guid id)
        {
            return ClienteDao.GetById(id);
        }

        public List<Cliente> Retrive()
        {
            return ClienteDao.Retrive();
        }

        public bool Delete(Cliente ObjDel)
        {
            return ClienteDao.Delete(ObjDel);
        }

        public bool Update(Cliente ObjUpd)
        {
            return ClienteDao.Update(ObjUpd);
        }
    }
}
