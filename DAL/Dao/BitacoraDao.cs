using System.Data;
using BE;
using Dapper;
using DAL.Interfaces;
using DAL.Utils;
using log4net;

namespace DAL.Dao
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BitacoraDao : IBitacoraDao
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Bitacora));

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

        public List<Bitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<Guid> idUsuarios, List<string> criticidades, DateTime desde, DateTime hasta)
        {
            try
            {
                var queryImpl = "Select * from Bitacora where ";
                var idsUsuParameters = string.Empty;
                var criticidadesParameters = string.Empty;
                var coma = string.Empty;
                //Prepare usuariosIds parameters
                if (idUsuarios.Count != 0)
                {
                    for (int i = 0; i < idUsuarios.Count; i++)
                    {
                        if (i != 0)
                            coma = ",";

                        idsUsuParameters += coma + "'" + idUsuarios[i] + "'";
                    }
                    queryImpl += String.Format("IdUsuario IN ({0}) and  ", idsUsuParameters);
                }
                ////Prepare criticidadesIDs parameters
                if (criticidades.Count != 0)
                {
                    for (int i = 0; i < criticidades.Count; i++)
                    {
                        if (i != 0)
                            coma = ",";

                        criticidadesParameters += coma + "'" + criticidades[i] + "'";
                    }
                    queryImpl += String.Format("Criticidad IN ({0}) and  ", criticidadesParameters);
                }
                
                var query = string.Format(queryImpl + " Fecha between '{0}' and '{1}'", desde.ToShortDateString(), hasta);                          
                return SqlUtils.Exec<Bitacora>(query);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Ocurrio un error al buscar informacion en la bitacora. Error: {0}", ex.Message);
            }

            return null;
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
