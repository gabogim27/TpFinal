namespace DAL.Impl
{
    using BE;
    using DAL.Utils;
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Contacto : BE.ICRUD<BE.Contacto>
    {
        private static Contacto instancia;

        private Contacto() { }

        public static Contacto GetInstancia()
        {
            if (instancia == null)
            {
                return new Contacto();
            }
            return instancia;
        }

        public bool Create(BE.Contacto ObjAlta)
        {
            var queryString = string.Format("INSERT INTO dbo.Contacto(IdContacto, Telefono, Calular) values " +
                "('{0}','{1}','{2}')",
                ObjAlta.Id = Guid.NewGuid(),
                ObjAlta.Telefono,
                ObjAlta.Celular);

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

        List<BE.Contacto> ICRUD<BE.Contacto>.Retrive()
        {
            throw new NotImplementedException();
        }

        public bool Delete(BE.Contacto ObjDel)
        {
            throw new NotImplementedException();
        }

        public bool Update(BE.Contacto ObjUpd)
        {
            throw new NotImplementedException();
        }

        public BE.Contacto GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
