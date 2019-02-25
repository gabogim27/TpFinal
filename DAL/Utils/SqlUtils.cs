using System.Data;
using System.IO;
using System.Xml;
using BE;
using Dapper;
using SSTIS.Encryption;

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
        public static readonly string AppConfigFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.FullName + "\\App.config";
        private static string _connectionString = ConfigurationManager.ConnectionStrings["SistemaTISConnectionString"].ToString();

        public static SqlConnection Connection()
        {
            var connString = EncryptionHelper.DesencriptarASCII(_connectionString);
            
            var conn = new SqlConnection(connString);

            return conn;
        }       

        //Este metodo se correria solo una vez, luego siempre se llama al desencriptador
        private static void EncriptarConnectionString()
        {
            var connString = _connectionString;
            var encriptedConnString = EncryptionHelper.EncriptarASCII(connString);

            XmlDocument doc = new XmlDocument();
            doc.Load(AppConfigFilePath);
            XmlNodeList xmlnode;
            xmlnode = doc.GetElementsByTagName("connectionStrings");
            foreach (XmlNode nodo in xmlnode)
            {
                nodo.FirstChild.Attributes[1].InnerText = encriptedConnString;
            }

            doc.Save(AppConfigFilePath);
        }

        public static List<string> Tables { get; set; } = GetTables();

        private static List<string> GetTables()
        {
            using (SqlConnection connection = Connection())
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                List<string> tableNames = new List<string>();
                foreach (DataRow row in schema.Rows)
                {
                    tableNames.Add(row[2].ToString());
                }

                return tableNames;
            }
        }

        public static bool Exec(string query, object param = null)
        {
            using (var connection = SqlUtils.Connection())
            {
                connection.Open();
                if (param == null)
                {
                    connection.Execute(query);
                }
                else
                {
                    connection.Execute(query, param);
                }

                return true;
            }
        }

        public static List<T> Exec<T>(string query, object param = null)
        {
            using (IDbConnection connection = SqlUtils.Connection())
            {
                connection.Open();
                var result = param == null ? (List<T>)connection.Query<T>(query) : (List<T>)connection.Query<T>(query, param);

                return result;
            }
        }       
    }
}
