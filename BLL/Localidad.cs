namespace BLL
{
    using System;
    using System.Collections.Generic;
    using BE;

    public class Localidad : BE.ICRUD<BE.Localidad>
    {

        private Localidad()
        {
        }

        private static Localidad instancia;

        public static Localidad Getinstancia()
        {
            if (instancia == null)
            {
                instancia = new Localidad();
            }
            return instancia;
        }
        
        public bool Create(BE.Localidad ObjAlta)
        {
            throw new System.NotImplementedException();
        }

        public List<BE.Localidad> Retrive()
        {
            return DAL.Impl.Localidad.Getinstancia().Retrive();
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
