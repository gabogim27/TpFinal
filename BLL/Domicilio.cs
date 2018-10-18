namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using BE;

    public class Domicilio : BE.ICRUD<BE.Domicilio>
    {
        private Domicilio()
        {
        }

        private static Domicilio instancia;

        public static Domicilio Getinstancia()
        {
            if (instancia == null)
            {
                instancia = new Domicilio();
            }
            return instancia;
        }

        public bool Create(BE.Domicilio ObjAlta)
        {
            return DAL.Impl.Domicilio.GetInstancia().Create(ObjAlta);
        }

        public bool Delete(BE.Domicilio ObjDel)
        {
            throw new NotImplementedException();
        }

        public List<BE.Domicilio> Retrive()
        {
            throw new NotImplementedException();
        }

        public bool Update(BE.Domicilio ObjUpd)
        {
            throw new NotImplementedException();
        }

        public BE.Domicilio GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
