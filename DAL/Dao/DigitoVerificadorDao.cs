using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BE;
using DAL.Utils;
using log4net;

namespace DAL.Impl
{
    public class DigitoVerificadorDao : IDigitoVerificador
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DigitoVerificadorDao));
        public List<string> Entidades { get; set; } = SqlUtils.Tables;

        public int CalcularDVHorizontal(List<string> columnasString, List<int> columnasInt)
        {
            var colLenght = new List<int>();
            var digito = 0;
            colLenght = columnasInt;

            foreach (var col in columnasString)
            {
                colLenght.Add(col.Length);
            }

            foreach (var colL in colLenght)
            {
                digito += colL * colLenght.FindIndex(x => x == colL);
            }

            return digito;
        }

        public int CalcularDVVertical(string entidad)
        {
            int result = 0;
            try
            {
                var queryString = string.Format("SELECT SUM(DVH) FROM {0}", entidad);

                result = SqlUtils.Exec<int>(queryString)[0];

                return result;
            }
            catch (Exception ex)
            {
                log.ErrorFormat(string.Format("Error al sumar los DVH de la entidad: {0}. Error: {1}", entidad, ex.Message));
            }

            return result;
        }

        public void InsertarDVVertical(string entidad)
        {
            try
            {
                var digito = CalcularDVVertical(entidad);
                var idDVV = Guid.NewGuid();
                var queryString = "INSERT INTO DigitoVerificadorVertical(IdDVH, Entidad, ValorDigitoVerificador) VALUES(@idDVV, @entidad, @digito)";


                SqlUtils.Exec(queryString, new { @idDVV = idDVV, @entidad = entidad, @digito = digito });

            }
            catch (Exception ex)
            {
                log.ErrorFormat(string.Format("Error al agregar un registro en la tabla DVV. Error: {0}. ", ex.Message));
            }

        }

        public void ActualizarDVVertical(string entidad)
        {
            try
            {
                var digito = CalcularDVVertical(entidad);

                var queryString = "INSERT INTO DigitoVerificadorVertical(Entidad, ValorDigitoVerificador) VALUES(@entidad, @digito)";

                SqlUtils.Exec(queryString, new { @entidad = entidad, @digito = digito });

            }
            catch (Exception ex)
            {
                log.ErrorFormat(string.Format("Error al actualizar un registro en la tabla DVV. Error: {0}. ", ex.Message));
            }

        }

        public bool ComprobarPrimerDigito(string entidad)
        {
            var queryString = "SELECT ValorDigitoVerificador FROM DigitoVerificadorVertical WHERE Entidad = @entidad";
            var digito = new List<int>();

            digito = SqlUtils.Exec<int>(queryString, new { @entidad = entidad });

            if (digito.Count > 0)
            {
                return false;
            }

            return true;
        }

        public Dictionary<string, int> ConsultarDVVertical(string entidades)
        {
            var entidadesdic = new Dictionary<string, int>();

            try
            {
                var queryString = string.Format("SELECT ValorDigitoVerificador FROM DigitoVerificadorVertical WHERE Entidad = '{0}'", entidades);

                entidadesdic.Add(entidades, SqlUtils.Exec<int>(queryString)[0]);

            }
            catch (Exception ex)
            {
                log.ErrorFormat(string.Format("Error al consultar por la entidad: {0} en la tabla DVV. Error: {1}. ", entidades, ex.Message));
            }

            return entidadesdic;
        }

        public bool ComprobarIntegridad()
        {
            var returnValue = true;

            var ResultadoUsuario = CalcularDVVertical(Entidades.Find(x => x == "Usuario"));

            var dVVerticalUsuario = ConsultarDVVertical(Entidades.Find(x => x == "Usuario"));

            if (ResultadoUsuario != dVVerticalUsuario["Usuario"])
            {
                returnValue = false;
            }

            return returnValue;
        }
    }
}
