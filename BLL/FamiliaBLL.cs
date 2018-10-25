﻿namespace BLL
{
    using BE;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FamiliaBLL : ICRUD<BE.Familia>
    {
        private FamiliaBLL() {}

        private static FamiliaBLL instancia;

        public static FamiliaBLL Getinstancia()
        {
            if (instancia == null)
            {
                instancia = new FamiliaBLL();
            }
            return instancia;
        }

        public bool Create(BE.Familia ObjAlta)
        {
            return DAL.Impl.FamiliaDAL.Getinstancia().Create(ObjAlta);
        }

        public bool Delete(BE.Familia ObjDel)
        {
            throw new NotImplementedException();
        }

        public BE.Familia GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<BE.Familia> Retrive()
        {
            throw new NotImplementedException();
        }

        public bool Update(BE.Familia ObjUpd)
        {
            throw new NotImplementedException();
        }
    }
}