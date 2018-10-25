using DAL.Interfaces;

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
  
        public bool Create(BE.Domicilio ObjAlta)
        {
            var queryString = string.Format("INSERT INTO dbo.Domicilio(IdDomicilio, Direccion, IdLocalidad, CodPostal) values " +
                "('{0}','{1}','{2}',{3})",
                ObjAlta.IdDomicilio = Guid.NewGuid(),
                ObjAlta.Direccion,
                ObjAlta.Localidad.IdLocalidad,
                ObjAlta.CodPostal);

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Execute(queryString);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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

        public bool Update(BE.Domicilio ObjUpd)
        {
            throw new NotImplementedException();
        }

        public BE.Domicilio GetById(Guid id)
        {
            var query = string.Format("Select * from dbo.Domicilio where Iddomicilio = '{0}'", id);

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    return (BE.Domicilio)connection.Query<BE.Domicilio>(query);
                }
                catch (Exception ex)
                {
                    throw new KeyNotFoundException(ex.Message);
                }
            }

        }
    }
}
