﻿using BE;
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
            if(!ComprobarUsoFamilia(entity.IdFamilia))
                return RepositorioFamilia.Delete(entity);
            return false;
        }

        public bool Update(Familia entity)
        {
            return RepositorioFamilia.Update(entity);
        }

        public bool GuardarFamiliaUsuario(List<Guid> familiaId, Guid usuarioId)
        {
            return RepositorioFamiliaImplementor.GuardarFamiliaUsuario(familiaId, usuarioId);
        }

        public bool GuardarFamiliasUsuario(Guid familiaId, Guid usuarioId)
        {
            return RepositorioFamiliaImplementor.GuardarFamiliasUsuario(familiaId, usuarioId);
        }

        public bool BorrarFamiliaUsuario(Guid familiaId, Guid usuarioId)
        {
            return RepositorioFamiliaImplementor.BorrarFamiliaUsuario(familiaId, usuarioId);
        }

        public List<Patente> ObtenerPatentesFamilia(List<Guid> familiaIds)
        {
            return RepositorioFamiliaImplementor.ObtenerPatentesFamilia(familiaIds);
        }

        public Guid ObtenerIdFamiliaPorDescripcion(string descripcion)
        {
            return RepositorioFamiliaImplementor.ObtenerIdFamiliaPorDescripcion(descripcion);
        }

        public Guid ObtenerIdFamiliaPorUsuario(Guid usuarioId)
        {
            return RepositorioFamiliaImplementor.ObtenerIdFamiliaPorUsuario(usuarioId);
        }

        public string ObtenerDescripcionFamiliaPorId(Guid familiaId)
        {
            return RepositorioFamiliaImplementor.ObtenerDescripcionFamiliaPorId(familiaId);
        }

        public bool ComprobarUsoFamilia(Guid familiaId)
        {
            return RepositorioFamiliaImplementor.ComprobarUsoFamilia(familiaId);
        }

        public List<string> TraerFamiliaUsuarioDescripcion(Guid IdUsuario)
        {
            return RepositorioFamiliaImplementor.TraerFamiliaUsuarioDescripcion(IdUsuario);
        }
    }
}
