using System.Data;
using BE;
using Dapper;
using DAL.Interfaces;
using DAL.Utils;
using EasyEncryption;
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
        
        private readonly IDigitoVerificador DigitoVerificador;
        public const string Key = "bZr2URKx";
        public const string Iv = "HNtgQw0w";

        public BitacoraDao(IDigitoVerificador DigitoVerificador)
        {
            this.DigitoVerificador = DigitoVerificador;
        }

        public void RegistrarEnBitacora(string criticidad, string mensaje, Usuario usuario = null)
        {
            var bitacora = new Bitacora()
            {
                IdBitacora = Guid.NewGuid(),
                Fecha = DateTime.Now,
                IdUsuario = usuario != null ? usuario.IdUsuario : (Guid?) null,
                Actividad = "BitacoraDao",
                Criticidad = criticidad,
                InformacionAsociada = mensaje
            };

            GlobalContext.Properties["IdBitacora"] = bitacora.IdBitacora;
            GlobalContext.Properties["Fecha"] = bitacora.Fecha;
            GlobalContext.Properties["IdUsuario"] = bitacora.IdUsuario != Guid.Empty ? bitacora.IdUsuario : (object)null;
            GlobalContext.Properties["logLevel"] = bitacora.Criticidad;
            var actividad = GlobalContext.Properties["Actividad"]; //= bitacora.Actividad;
            var digitoVH = GenerarDVH(bitacora);
            GlobalContext.Properties["dvh"] = digitoVH;
            mensaje = DES.Encrypt(mensaje, Key, Iv);

            log.Info(mensaje);

            //var query = string.Format(
            //    "INSERT INTO Bitacora ([IdBitacora],[Fecha],[Criticidad],[Actividad],[InformacionAsociada],[IdUsuario],[DVH]) VALUES " +
            //    "('{0}','{1}', '{2}', '{3}', '{4}', '{5}', {6})", bitacora.IdBitacora, bitacora.Fecha,
            //    bitacora.Criticidad, bitacora.Actividad, mensaje, bitacora.IdUsuario, digitoVH);
            //SqlUtils.Exec(query);
        }

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

        public Bitacora LeerBitacoraConId(DateTime? fecha)
        {
            try
            {
                var query = string.Format("select * from bitacora where Fecha = '{0}'", fecha);
                var ultimoCreado =  SqlUtils.Exec<Bitacora>(query)[0];
                ultimoCreado.InformacionAsociada = DES.Decrypt(ultimoCreado.InformacionAsociada, Key, Iv);
                return ultimoCreado;
            }
            catch (Exception ex)
            {
                RegistrarEnBitacora(Log.Level.Alta.ToString(), string.Format("Hubo un error al leer la bitacora para la fecha: {0} " +
                                                                                                 " Error: {1}", fecha, ex.Message));
            }

            return null;
        }

        public DateTime? ObtenerMaxFechaBitacora()
        {

            try
            {
                var queryString = "Select MAX(Fecha) from Bitacora";
                return SqlUtils.Exec<DateTime?>(queryString)[0];               
            }
            catch (Exception ex)
            {
                log.ErrorFormat(string.Format("Hubo un error al traer la ultima fecha de la bitacora. " +
                                                                                                 " Error: {0}",ex.Message));
            }

            return null;
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
                coma = String.Empty;
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
                var listaBitacora = SqlUtils.Exec<Bitacora>(query).Select(x =>
               {
                   x.InformacionAsociada = DES.Decrypt(x.InformacionAsociada, Key, Iv);
                   return x;
               }).ToList();

                return listaBitacora;
            }
            catch (Exception ex)
            {
                RegistrarEnBitacora(Log.Level.Alta.ToString(), String.Format("Ocurrio un error al buscar informacion en la bitacora. Error: {0}", ex.Message));
            }

            return null;
        }

        public int GenerarDVH(Bitacora log)
        {
            var digitoVH = DigitoVerificador.CalcularDVHorizontal(new List<string> { log.IdBitacora.ToString(), log.InformacionAsociada, log.Actividad, log.Criticidad, log.IdUsuario.ToString(), log.Fecha.ToString() }, new List<int> { });
            return digitoVH;
        }
    }
}
