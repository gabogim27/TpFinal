namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BE;

    public class Contacto : BE.ICRUD<BE.Contacto>
    {
        private static Contacto instancia;
        
        private Contacto() { }

        public static Contacto GetInstancia()
        {
            if (instancia == null)
            {
                return new Contacto();
            }
            return instancia;
        }

        public bool Create(BE.Contacto ObjAlta)
        {
            return DAL.Impl.Contacto.GetInstancia().Create(ObjAlta);
        }

        public bool Delete(BE.Contacto ObjDel)
        {
            throw new NotImplementedException();
        }

        public BE.Contacto GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(BE.Contacto ObjUpd)
        {
            throw new NotImplementedException();
        }

        List<BE.Contacto> ICRUD<BE.Contacto>.Retrive()
        {
            throw new NotImplementedException();
        }
    }
}
