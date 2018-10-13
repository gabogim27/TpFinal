using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using BE;
using Dapper;

namespace DAL.Impl
{
    public class Provincia : ICRUD<BE.Provincia>
    {
        private static Provincia instancia;

        private Provincia()
        {
        }

        public static Provincia Getinstancia()
        {
            if (instancia == null)
            {
                instancia = new Provincia();
            }
            return instancia;
        }

        public static SqlConnection Connection()
        {
            var conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=EZE1-LHP-B01637;Initial Catalog=SistemaTIS;Integrated Security=True";
            return conn;
        }

        public bool Create(BE.Localidad ObjAlta)
        {
            throw new NotImplementedException();
        }

        public bool Delete(BE.Localidad ObjDel)
        {
            throw new NotImplementedException();
        }

        public List<BE.Localidad> Retrive()
        {
            var queryString = "SELECT * FROM dbo.Provincia;";
            var comm = new SqlCommand();

            using (IDbConnection connection = Connection())
            {
                try
                {

                    return (List<BE.Localidad>)connection.Query<BE.Localidad>(queryString);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Update(BE.Localidad ObjUpd)
        {
            throw new NotImplementedException();
        }

        public bool Create(BE.Provincia ObjAlta)
        {
            throw new NotImplementedException();
        }

        List<BE.Provincia> ICRUD<BE.Provincia>.Retrive()
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
    }
}
