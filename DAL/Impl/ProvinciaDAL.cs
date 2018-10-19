using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.Utils;
using Dapper;

namespace DAL.Impl
{
    public class ProvinciaDAL : ICRUD<BE.Provincia>
    {
        private static ProvinciaDAL instancia;

        private ProvinciaDAL()
        {
        }

        public static ProvinciaDAL Getinstancia()
        {
            if (instancia == null)
            {
                instancia = new ProvinciaDAL();
            }
            return instancia;
        }

        public List<BE.Provincia> Retrive()
        {
            var queryString = "SELECT * FROM dbo.Provincia;";
            var comm = new SqlCommand();

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {

                    return (List<BE.Provincia>)connection.Query<BE.Provincia>(queryString);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Create(BE.Provincia ObjAlta)
        {
            throw new NotImplementedException();
        }


        public bool Delete(BE.Provincia ObjDel)
        {
            throw new NotImplementedException();
        }

        public bool Update(BE.Provincia ObjUpd)
        {
            throw new NotImplementedException();
        }

        public BE.Provincia GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public BE.Provincia GetById(BE.Provincia ObjToSearch)
        {
            throw new NotImplementedException();
        }
    }
}
