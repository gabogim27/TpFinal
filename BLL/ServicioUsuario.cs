using System.Data;
using System.Linq;
using EasyEncryption;
using BLL.Interfaces;
using DAL;
using TimeSpan = System.TimeSpan;

namespace BLL
{
    using System;
    using System.Collections.Generic;
    using BE;   
    using DAL.Impl;

    public class ServicioUsuario : IServicio<Usuario>
    {
        public IRepository<Usuario> RepositorioUsuario;
        public IRepository<Localidad> RepositorioLocalidad;
        public IRepository<Domicilio> RepositorioDomicilio;
        public IRepository<Contacto> RepositorioContacto;

        public ServicioUsuario(IRepository<Usuario> repositorioUsuario, 
            IRepository<Localidad> repositorioLocalidad, IRepository<Domicilio> repositorioDomicilio,
            IRepository<Contacto> repositorioContacto)
        {
            this.RepositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
            this.RepositorioLocalidad = repositorioLocalidad;
            this.RepositorioDomicilio = repositorioDomicilio;
            this.RepositorioContacto = repositorioContacto;
        }
        public bool Create(Usuario entity)
        {
            //Llamar repositorio localidad
            Random random = new Random();
            string nuevoPass = random.Next().ToString();
            entity.ContraseñaEncriptada = MD5.ComputeMD5Hash(entity.Password = nuevoPass);

            //Damos de alta el domicilio del usuario
            var objDomicilio = new BE.Domicilio();
            objDomicilio.IdDomicilio = Guid.NewGuid();
            objDomicilio.Direccion = entity.Domicilio.Direccion;
            objDomicilio.CodPostal = "1665";//agregar esto en la UI
            var localidad = RepositorioLocalidad.GetById(entity.Domicilio.Localidad.IdLocalidad);
            objDomicilio.Localidad = localidad;

            RepositorioDomicilio.Create(objDomicilio);
            //Damos de alta el contacto del usuario
            var objContacto = new BE.Contacto();
            objContacto.Id = Guid.NewGuid();
            objContacto.Telefono = entity.Contacto.Telefono;
            objContacto.Celular = entity.Contacto.Celular;
            RepositorioContacto.Create(objContacto);
            return RepositorioUsuario.Create(entity);
        }

        public Usuario GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Retrive()
        {
            throw new NotImplementedException();
        }

        public bool Delete(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
