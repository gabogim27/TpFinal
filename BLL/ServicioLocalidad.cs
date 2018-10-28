using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL
{
    using System;
    using System.Collections.Generic;
    using BE;

    public class ServicioLocalidad : IServicio<Localidad>, IServicioLocalidad
    {
        public IRepository<Localidad> RepositorioLocalidad { get; }
        public IRepositorioLocalidad RepositorioLocalidadImplementor;

        public ServicioLocalidad(IRepository<Localidad> repositorioLocalidad, IRepositorioLocalidad repositorioLocalidadImplementor)
        {
            this.RepositorioLocalidad = repositorioLocalidad ?? throw new ArgumentNullException(nameof(repositorioLocalidad));
            this.RepositorioLocalidadImplementor = repositorioLocalidadImplementor;
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

        public List<Localidad> GetLocalidadesByProvinciaId(Guid provinciaId)
        {
            return RepositorioLocalidadImplementor.GetLocalidadesByProvinciaId(provinciaId);
        }
    }
}
