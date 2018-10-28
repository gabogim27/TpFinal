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
using DAL.Interfaces;

namespace DAL.Impl
{
    public class ProvinciaDao : IDao<Provincia>, IProvinciaDao
    {
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

        public Provincia GetById(Guid id)
        {
            var query = string.Format("Select * from dbo.Provincia where IdProvincia = '{0}'", id);

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    return (BE.Provincia)connection.Query<BE.Provincia>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw new KeyNotFoundException();
                }
            }
        }

        public Provincia GetProvinciaByLocalidadId(Guid idLocalidad)
        {
            throw new NotImplementedException();
        }
    }
}
