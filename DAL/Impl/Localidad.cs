using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Dapper;

namespace DAL.Impl
{
    public class Localidad : BE.ICRUD<BE.Localidad>
    {
        private static Localidad instancia;

        private Localidad()
        {
        }

        public static Localidad Getinstancia()
        {
            if (instancia == null)
            {
                instancia = new Localidad();
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
            var queryString = "SELECT * FROM dbo.Localidad;";
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
    }
}
