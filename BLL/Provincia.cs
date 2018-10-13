namespace BLL
{
    using System.Collections.Generic;
    using BE;

    public class Provincia : BE.ICRUD<BE.Provincia>
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
        
        
        public bool Create(BE.Provincia ObjAlta)
        {
            throw new System.NotImplementedException();
        }

        List<BE.Provincia> ICRUD<BE.Provincia>.Retrive()
        {
            return DAL.Impl.Provincia.Getinstancia().Retrive();
        }

        public bool Delete(BE.Provincia ObjDel)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(BE.Provincia ObjUpd)
        {
            throw new System.NotImplementedException();
        }
    }
}
