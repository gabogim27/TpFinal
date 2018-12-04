using BE;
using BLL.Interfaces;

namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ServicioCliente : IServicio<Cliente>
    {
        private IRepository<Cliente> RepositorioCliente;

        public ServicioCliente(IRepository<Cliente> RepositorioCliente)
        {
            this.RepositorioCliente = RepositorioCliente;
        }
        public bool Create(Cliente ObjAlta)
        {
            return RepositorioCliente.Create(ObjAlta);
        }

        public Cliente GetById(Guid id)
        {
            return RepositorioCliente.GetById(id);
        }

        public List<Cliente> Retrive()
        {
            return RepositorioCliente.Retrive();
        }

        public bool Delete(Cliente ObjDel)
        {
            return RepositorioCliente.Delete(ObjDel);
        }

        public bool Update(Cliente ObjUpd)
        {
            return RepositorioCliente.Update(ObjUpd);
        }
    }
}
