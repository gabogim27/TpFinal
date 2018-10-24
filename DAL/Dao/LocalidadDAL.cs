using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.Utils;
using Dapper;

namespace DAL.Impl
{
    public class LocalidadDAL : BE.ICRUD<BE.Localidad>
    {
        private static LocalidadDAL instancia;

        private LocalidadDAL()
        {
        }

        public static LocalidadDAL Getinstancia()
        {
            if (instancia == null)
            {
                instancia = new LocalidadDAL();
            }
            return instancia;
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

            using (IDbConnection connection = SqlUtils.Connection())
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

        public BE.Localidad GetById(Guid localidadId)
        {
            var query = string.Format("Select * from dbo.Localidad loc inner join dbo.provincia prov on loc.IdLocalidad = '{0}'", localidadId);

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    return (BE.Localidad)connection.Query<BE.Localidad>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw new KeyNotFoundException();
                }
            }
        }
    }
}
