namespace BLL
{
    using System;
    using System.Collections.Generic;
    using BE;

    public class LocalidadBLL : BE.ICRUD<BE.Localidad>
    {

        private LocalidadBLL()
        {
        }

        private static LocalidadBLL instancia;

        public static LocalidadBLL Getinstancia()
        {
            if (instancia == null)
            {
                instancia = new LocalidadBLL();
            }
            return instancia;
        }
        
        public bool Create(BE.Localidad ObjAlta)
        {
            throw new System.NotImplementedException();
        }

        public List<BE.Localidad> Retrive()
        {
            return DAL.Impl.LocalidadDAL.Getinstancia().Retrive();
        }

        public bool Delete(BE.Localidad ObjDel)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(BE.Localidad ObjUpd)
        {
            throw new System.NotImplementedException();
        }

        public BE.Localidad GetById(Guid id)
        {
            throw new System.NotImplementedException();
        }
    }
}
