using BLL.Interfaces;

namespace BLL
{
    using System;
    using System.Collections.Generic;
    using BE;

    public class ServicioProvincia : IServicio<Provincia>
    {

        public IRepository<Provincia> RepositorioProvincia;

        public ServicioProvincia(IRepository<Provincia> repositorioProvincia)
        {
            this.RepositorioProvincia = repositorioProvincia ?? throw new ArgumentNullException(nameof(repositorioProvincia));
        }            
        
        public bool Create(BE.Provincia ObjAlta)
        {
            throw new System.NotImplementedException();
        }

        public List<BE.Provincia> Retrive()
        {
            return RepositorioProvincia.Retrive();
        }

        public bool Delete(BE.Provincia ObjDel)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(BE.Provincia ObjUpd)
        {
            throw new System.NotImplementedException();
        }

        public BE.Provincia GetById(Guid id)
        {
            throw new System.NotImplementedException();
        }
    }
}
