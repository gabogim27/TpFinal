using BLL.Interfaces;

namespace BLL
{
    using System;
    using System.Collections.Generic;
    using BE;

    public class ServicioLocalidad : IServicio<Localidad>
    {
        public IRepository<Localidad> RepositorioLocalidad { get; }

        public ServicioLocalidad(IRepository<Localidad> repositorioLocalidad)
        {
            this.RepositorioLocalidad = repositorioLocalidad ?? throw new ArgumentNullException(nameof(repositorioLocalidad));
        }

        public bool Create(BE.Localidad ObjAlta)
        {
            return RepositorioLocalidad.Create(ObjAlta);
        }

        public List<Localidad> Retrive()
        {
            return RepositorioLocalidad.Retrive();
        }

        public bool Delete(Localidad ObjDel)
        {
            return RepositorioLocalidad.Delete(ObjDel);
        }

        public bool Update(BE.Localidad ObjUpd)
        {
            return RepositorioLocalidad.Update(ObjUpd);
        }

        public BE.Localidad GetById(Guid id)
        {
            return RepositorioLocalidad.GetById(id);
        }
    }
}
