using BE;
using DAL.Interfaces;

namespace DAL.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepositorioLocalidad : IRepository<Localidad>
    {
        public IDao<Localidad> LocalidadDao { get; }

        public RepositorioLocalidad(IDao<Localidad> localidadDao)
        {
            this.LocalidadDao = localidadDao ?? throw new ArgumentNullException(nameof(localidadDao));
        }

        public bool Create(Localidad ObjAlta)
        {
            return LocalidadDao.Create(ObjAlta);
        }

        public bool Delete(Localidad ObjDel)
        {
            return LocalidadDao.Delete(ObjDel);
        }

        public Localidad GetById(Guid id)
        {
            return LocalidadDao.GetById(id);
        }

        public List<Localidad> Retrive()
        {
            return LocalidadDao.Retrive();
        }

        public bool Update(Localidad ObjUpd)
        {
            throw new NotImplementedException();
        }
    }
}
