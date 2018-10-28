using System.Data;
using BE;
using Dapper;
using DAL.Interfaces;
using DAL.Utils;

namespace DAL.Dao
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BitacoraDao : IBitacoraDao
    {
        private readonly IDigitoVerificador digitoVerificador;

        public void FiltrarBitacora(BitacoraFiltros filtros)
        {
            var queryString = new StringBuilder();

            var baseQuery = string.Format("SELECT * FROM Bitacora WHERE Fecha >= {0} AND Fecha <= {1} ", filtros.FechaDesde, filtros.FechaHasta);

            queryString.Append(baseQuery);

            if (filtros.IdsUsuarios.Count > 0)
            {
                queryString.Append(string.Format("AND IdUsuario IN ({0})", filtros.IdsUsuarios));
            }

            if (filtros.Criticidades.Count > 0)
            {
                queryString.Append(string.Format("AND Criticidad IN ({0})", filtros.Criticidades));
            }

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    connection.Execute(queryString.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Bitacora LeerBitacoraConId(int bitacoraId)
        {
            throw new NotImplementedException();
        }

        public Bitacora LeerBitacoraConId(Guid bitacoraId)
        {
            var queryString = $"SELECT * FROM Bitacora WHERE IdLog = {bitacoraId}";

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    var bitacora = (List<Bitacora>)connection.Query<Bitacora>(queryString);
                    return bitacora[0];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return null;
            }
        }

        public Guid ObtenerUltimoIdBitacora()
        {
            var queryString = "SELECT IDENT_CURRENT ('[dbo].[Bitacora]') AS Current_Identity;";

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    var bitacoraId = Guid.Empty;
                    var result = connection.Query<Guid>(queryString);
                    if (result.Any())
                    {
                        bitacoraId = result.ToList().FirstOrDefault();
                    }
        
                    return bitacoraId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return Guid.Empty;
            }
        }

        public int GenerarDVH(Usuario usu)
        {
            var bitacoraId = ObtenerUltimoIdBitacora();
            Bitacora bitacora = null;
            if (bitacoraId != Guid.Empty)
            {
                bitacora = LeerBitacoraConId(bitacoraId);
                //var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { bitacora.InformacionAsociada, bitacora.Actividad, bitacora.Criticidad });
            }

            return 0;
        }

        int IBitacoraDao.ObtenerUltimoIdBitacora()
        {
            throw new NotImplementedException();
        }
    }
}
