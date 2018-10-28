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

    public class ContactoDao : IDao<Contacto>
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ContactoDao));

        public bool Create(BE.Contacto ObjAlta)
        {
            var queryString = string.Format("INSERT INTO dbo.Contacto(IdContacto, Telefono, Celular) values " +
                "('{0}','{1}','{2}')",
                ObjAlta.IdContacto = Guid.NewGuid(),
                ObjAlta.Telefono,
                ObjAlta.Celular);

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Execute(queryString);
                    log.InfoFormat("Contacto con IdUsuario: {0} persistido correctamente", ObjAlta.IdContacto);
                    return true;
                }
                catch (Exception ex)
                {
                    log.ErrorFormat("Hubo un error al persistir el contacto: {0}", ex.Message);
                    return false;
                }
            }
        }
       
        public List<Contacto> Retrive()
        {
            throw new NotImplementedException();
        }

        public bool Delete(BE.Contacto ObjDel)
        {
            throw new NotImplementedException();
        }

        public bool Update(BE.Contacto ObjUpd)
        {
            try
            {
                var queryString = string.Format("Update dbo.Contacto set " +
                                                "Telefono = '{0}', Celular = '{1}'" +
                                                " where IdContacto = '{2}'",
                    ObjUpd.Telefono,
                    ObjUpd.Celular,
                    ObjUpd.IdContacto
                );

                return SqlUtils.Exec(queryString);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Ocurrio un error al intentar actualizar el contacto con Id: {0}", ObjUpd.IdContacto);
                return false;
            }
        }

        public BE.Contacto GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
