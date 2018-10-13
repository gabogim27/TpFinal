namespace BLL
{
    using System.Collections.Generic;
    using BE;

    public class Localidad : BE.ICRUD<BE.Localidad>
    {

        private Provincia()
        {
        }

        private static Provincia instancia;

        public static Provincia Getinstancia()
        {
            if (instancia == null)
            {
                instancia = new Provincia();
            }
            return instancia;
        }
        
        public bool Create(BE.Localidad ObjAlta)
        {
            throw new System.NotImplementedException();
        }

        public List<BE.Localidad> Retrive()
        {
            return DAL.Impl.Provincia.Getinstancia().Retrive();
        }

        public bool Delete(BE.Localidad ObjDel)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(BE.Localidad ObjUpd)
        {
            throw new System.NotImplementedException();
        }
    }
}
