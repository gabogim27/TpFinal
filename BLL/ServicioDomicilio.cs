using BLL.Interfaces;

namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using BE;

    public class ServicioDomicilio : IServicio<Domicilio>
    {
        public IRepository<Domicilio> RepositorioDomicilio { get; }

        public ServicioDomicilio(IRepository<Domicilio> repositorioDomicilio)
        {
            this.RepositorioDomicilio = repositorioDomicilio ?? throw new ArgumentNullException(nameof(repositorioDomicilio));
        }

        public bool Create(BE.Domicilio ObjAlta)
        {
            return RepositorioDomicilio.Create(ObjAlta);
        }

        public bool Delete(BE.Domicilio ObjDel)
        {
            return RepositorioDomicilio.Delete(ObjDel);
        }

        public List<BE.Domicilio> Retrive()
        {
            return RepositorioDomicilio.Retrive();
        }

        public bool Update(BE.Domicilio ObjUpd)
        {
            return RepositorioDomicilio.Update(ObjUpd);
        }

        public BE.Domicilio GetById(Guid id)
        {
            return RepositorioDomicilio.GetById(id);
        }
    }
}
