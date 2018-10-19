namespace BLL
{
    using System;
    using System.Collections.Generic;
    using BE;

    public class ProvinciaBLL : BE.ICRUD<BE.Provincia>
    {

        private ProvinciaBLL()
        {
        }

        private static ProvinciaBLL instancia;

        public static ProvinciaBLL Getinstancia()
        {
            if (instancia == null)
            {
                instancia = new ProvinciaBLL();
            }
            return instancia;
        }
        
        
        public bool Create(BE.Provincia ObjAlta)
        {
            throw new System.NotImplementedException();
        }

        public List<BE.Provincia> Retrive()
        {
            return DAL.Impl.ProvinciaDAL.Getinstancia().Retrive();
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
