using DAL.Interfaces;
using log4net;

namespace DAL.Impl
{
    using BE;
    using DAL.Utils;
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class DomicilioDao : IDao<Domicilio>
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DomicilioDao));

        public bool Create(BE.Domicilio ObjAlta)
        {
            var queryString = string.Format("INSERT INTO dbo.Domicilio(IdDomicilio, Direccion, IdLocalidad, CodPostal, IdProvincia) values " +
                "('{0}','{1}','{2}',{3}, '{4}')",
                ObjAlta.IdDomicilio = Guid.NewGuid(),
                ObjAlta.Direccion,
                ObjAlta.Localidad.IdLocalidad,
                ObjAlta.CodPostal,
                ObjAlta.Provincia.IdProvincia);

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Execute(queryString);
                    log.InfoFormat("Domicilio con IdUsuario: {0} persistido correctamente", ObjAlta.IdDomicilio);
                    return true;
                }
                catch (Exception ex)
                {
                    log.ErrorFormat("Ocurrio un error al guardar el domicilio. {0}", ex.Message);
                    return false;
                }
            }
        }

        public bool Delete(BE.Domicilio ObjDel)
        {
            throw new NotImplementedException();
        }

        public List<BE.Domicilio> Retrive()
        {
            throw new NotImplementedException();
        }

        public bool Update(Domicilio ObjUpd)
        {
            try
            {
                var queryString = string.Format("Update dbo.Domicilio set " +
                                                "Direccion = '{0}', CodPostal = '{1}', IdLocalidad = '{2}', " +
                                                "IdProvincia = {4}" +
                                                 "where IdDomicilio = '{3}'",
                    ObjUpd.Direccion,
                    ObjUpd.CodPostal,
                    ObjUpd.Localidad.IdLocalidad,
                    ObjUpd.IdDomicilio,
                    ObjUpd.Provincia.IdProvincia
                );

                return SqlUtils.Exec(queryString);
            }
            catch (Exception e)
            {
                log.ErrorFormat("Ocurrio un error al intentar actualizar el domicilio con Id: {0}", ObjUpd.IdDomicilio);
                return false;
            }
        }

        public BE.Domicilio GetById(Guid id)
        {
            var query = string.Format("Select * from dbo.Domicilio where Iddomicilio = '{0}'", id);

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    return connection.Query<BE.Domicilio>(query) as Domicilio;
                }
                catch (Exception ex)
                {
                    throw new KeyNotFoundException(ex.Message);
                }
            }

        }
    }
}
