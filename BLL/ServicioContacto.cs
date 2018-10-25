using BLL.Interfaces;

namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BE;

    public class ServicioContacto : IServicio<Contacto>
    {
        public IRepository<Contacto> RepositorioContacto { get; }

        public ServicioContacto(IRepository<Contacto> repositorioContacto)
        {
            this.RepositorioContacto = repositorioContacto ?? throw new ArgumentNullException(nameof(repositorioContacto));
        }

        public bool Create(Contacto ObjAlta)
        {
            return RepositorioContacto.Create(ObjAlta);
        }

        public List<Contacto> Retrive()
        {
            throw new NotImplementedException();
        }

        public bool Delete(Contacto ObjDel)
        {
            throw new NotImplementedException();
        }

        public Contacto GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Contacto ObjUpd)
        {
            throw new NotImplementedException();
        }       
    }
}
