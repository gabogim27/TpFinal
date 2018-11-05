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

    public class ServicioFamilia : IServicio<Familia>, IServicioFamilia
    {
        public IRepository<Familia> RepositorioFamilia;
        public IRepositorioFamilia RepositorioFamiliaImplementor;

        public ServicioFamilia(IRepository<Familia> repositorioFamilia, IRepositorioFamilia repositorioFamiliaImplementor)
        {
            this.RepositorioFamilia = repositorioFamilia;
            RepositorioFamiliaImplementor = repositorioFamiliaImplementor;
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

        public bool GuardarFamiliaUsuario(List<Guid> familiaId, Guid usuarioId)
        {
            return RepositorioFamiliaImplementor.GuardarFamiliaUsuario(familiaId, usuarioId);
        }
    }
}
