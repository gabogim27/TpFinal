﻿using BE;
using DAL.Impl;
using DAL.Interfaces;

namespace DAL.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepositorioPatente : IRepositorioPatente
    {
        public IPatenteDao PatenteDao;

        public RepositorioPatente(IPatenteDao patenteDao)
        {
            this.PatenteDao = patenteDao;
        }
        public List<Patente> RetrievePatentes()
        {
            return PatenteDao.RetrievePatentes();
        }

        public bool GuardarPatentesUsuario(List<Guid> patentesUsuario, Guid idUsuario)
        {
            return PatenteDao.GuardarPatentesUsuario(patentesUsuario, idUsuario);
        }

        public void NegarPatenteUsuario(List<Guid> patentesId, Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        public List<Patente> Cargar()
        {
            throw new NotImplementedException();
        }

        public Guid ObtenerIdPatentePorDescripcion(string descripcion)
        {
            return PatenteDao.ObtenerIdPatentePorDescripcion(descripcion);
        }

        public bool BorrarPatente(Guid familiaId, Guid patenteId)
        {
            return PatenteDao.BorrarPatente(familiaId, patenteId);
        }

        public bool AsignarPatente(Guid familiaId, Guid patenteId)
        {
            return PatenteDao.AsignarPatente(familiaId, patenteId);
        }

        public bool ComprobarPatentesUsuario(Guid usuarioId)
        {
            return PatenteDao.ComprobarPatentesUsuario(usuarioId);
        }

        public List<FamiliaPatente> ConsultarPatenteFamilia(Guid familiaId)
        {
            return PatenteDao.ConsultarPatenteFamilia(familiaId);
        }
    }
}