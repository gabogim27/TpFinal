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
using log4net;

namespace DAL.Impl
{
    public class LocalidadDao : IDao<Localidad>, ILocalidadDao
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LocalidadDao));

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
            var query = string.Format("Select * from dbo.Localidad where IdLocalidad = '{0}'", localidadId);

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

        public List<Localidad> GetLocalidadesByProvinciaId(Guid provinciaId)
        {
            try
            {
                var query = string.Format("select loc.* from LOCALIDAD loc inner join " +
                                          "PROVINCIA prov on loc.IdProvincia = prov.IdProvincia " +
                                          "where loc.IdProvincia = '{0}'", provinciaId);
                log.InfoFormat("Buscando Localidades para la provincia: {0}", provinciaId);
                return SqlUtils.Exec<Localidad>(query);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Ocurrio un error al buscar las localidades para la provincia: {0}. Error: {1}", provinciaId, ex.Message);
                return null;
            }
        }
    }
}
