namespace DAL.Impl
{
    using BE;
    using DAL.Utils;
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Familia : ICRUD<BE.Familia>
    {
        private Familia() { }

        private static Familia instancia;

        public static Familia Getinstancia()
        {
            if (instancia == null)
            {
                instancia = new Familia();
            }
            return instancia;
        }

        public bool Create(BE.Familia ObjAlta)
        {
            var sqlQuery = string.Format("@INSERT INTO dbo.Familia (idFamilia, Descripcion) values ('{0}', {1})", ObjAlta.IdFamilia.ToString(), ObjAlta.Descripcion);
            var returnValue = false;

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Execute(sqlQuery);

                    return !returnValue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return returnValue;
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
