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
        public IRepository<Localidad> RepositorioLocalidad;
        public IRepository<Provincia> RepositorioProvincia;
        public IRepository<Domicilio> RepositorioDomicilio;
        public IRepository<Contacto> RepositorioContacto;

        public ServicioCliente(IRepository<Cliente> RepositorioCliente, IRepository<Localidad> RepositorioLocalidad,
            IRepository<Provincia> RepositorioProvincia, IRepository<Domicilio> RepositorioDomicilio,
            IRepository<Contacto> RepositorioContacto)
        {
            this.RepositorioLocalidad = RepositorioLocalidad;
            this.RepositorioProvincia = RepositorioProvincia;
            this.RepositorioDomicilio = RepositorioDomicilio;
            this.RepositorioContacto = RepositorioContacto;
            this.RepositorioCliente = RepositorioCliente;
        }
        public bool Create(Cliente ObjAlta)
        {
            var localidad = RepositorioLocalidad.GetById(ObjAlta.Domicilio.Localidad.IdLocalidad);
            ObjAlta.Domicilio.Localidad = localidad;
            //Retrieve Provincia
            var provincia = RepositorioProvincia.GetById(ObjAlta.Domicilio.Provincia.IdProvincia);
            ObjAlta.Domicilio.Provincia = provincia;
            //Create domicilio
            RepositorioDomicilio.Create(ObjAlta.Domicilio);
            RepositorioContacto.Create(ObjAlta.Contacto);
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
