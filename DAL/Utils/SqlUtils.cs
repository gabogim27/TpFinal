using System.Data;
using BE;
using Dapper;

namespace DAL.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SqlUtils
    {
        public static SqlConnection Connection()
        {
            var conn = new SqlConnection(ConfigurationManager.AppSettings["connString"]);
            return conn;
        }

        public static bool Exec(string query)
        {
            using (IDbConnection connection = SqlUtils.Connection())
            {
                connection.Open();
                connection.Execute(query);
                return true;
            }
        }

        public static List<T> Exec<T>(string query)
        {
            using (IDbConnection connection = SqlUtils.Connection())
            {
                connection.Open();
                var result = (List<T>)connection.Query<T>(query);

                return result;
            }
        }       
    }
}
