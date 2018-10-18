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
    }
}
