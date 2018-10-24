using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Impl
{
    public class DigitoVerificadorDAL : IDigitoVerificador
    {
        public static SqlConnection Connection()
        {
            var conn = new SqlConnection(@"Data Source=EZE1-LHP-B01637;Initial Catalog=SistemaTIS;Integrated Security=True");
            return conn;
        }

        public int CalcularDVHorizontal(string entidad, List<string> columnasString, List<int> columnasInt)
        {
            var colLenght = new List<int>();
            var digito = 0;

            foreach (var col in columnasString)
            {
                colLenght.Add(col.Length);

                if (columnasString[columnasString.Count - 1] == col)
                {
                    foreach (var colL in colLenght)
                    {
                        digito += colL * colLenght.FindIndex(x => x == colL);
                    }
                }
            }

            return digito;
        }

        public BE.DigitoVerificador ObtenerDigito(int id_Entidad)
        {
            var sqlQuery = string.Format(@"SELECT valor FROM DigitoVerificadorVertical WHERE IdEntidad = {0}", id_Entidad);

            var comm = new SqlCommand();

            using (SqlConnection connection = Connection())
            {
                var digitoVerificador = new BE.DigitoVerificador();
                try
                {
                    comm.CommandText = sqlQuery;
                    comm.Connection = connection;
                    comm.CommandType = CommandType.Text;

                    var da = new SqlDataAdapter(comm);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        digitoVerificador.ValorDigito = Convert.ToInt32(dr["ValorDigitoVerificador"]);
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                return digitoVerificador;
            }
        }
    }
}
