using BE;
using BLL.Interfaces;

namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ServicioFamilia : IServicio<Familia>
    {
        public IRepository<Familia> RepositorioFamilia;

        public ServicioFamilia(IRepository<Familia> repositorioFamilia)
        {
            this.RepositorioFamilia = repositorioFamilia;
        }
        public bool Create(Familia entity)
        {
            return RepositorioFamilia.Create(entity);
        }

        public Familia GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Familia> Retrive()
        {
            return RepositorioFamilia.Retrive();
        }

        public bool Delete(Familia entity)
        {
            return RepositorioFamilia.Delete(entity);
        }

        public bool Update(Familia entity)
        {
            return RepositorioFamilia.Update(entity);
        }
    }
}
