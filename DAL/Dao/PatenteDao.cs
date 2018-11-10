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

    public class PatenteDao : IPatenteDao
    {
        public IRepositorioBitacora RepositorioBitacora;

        public PatenteDao(IRepositorioBitacora repositorioBitacora)
        {
            this.RepositorioBitacora = repositorioBitacora;
        }

        public List<Patente> RetrievePatentes()
        {
            try
            {
                var query = "select * from Patente";
                return SqlUtils.Exec<Patente>(query);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(), 
                    string.Format("Ocurrio un error al traer las patentes de la BD. Error: " +
                                  "{0}", ex.Message));
            }

            return null;
        }

        public bool GuardarPatentesUsuario(List<Guid> patentesUsuario, Guid idUsuario)
        {
            try
            {
                //TODO: Implementar mas adelante
                foreach (var idPatente in patentesUsuario)
                {
                    string processQuery = string.Format("INSERT INTO UsuarioPatente (IdPatente, IdUsuario, negada) VALUES ('{0}', '{1}', 0)", idPatente, idUsuario);
                    SqlUtils.Connection().Execute(processQuery);
                }

                return true;
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al guardar en la tabla usuarioPatente idUsuario: {0}. Error: {1}",
                        idUsuario, ex.Message));
            }

            return false;
        }

        public void NegarPatenteUsuario(List<Guid> patentesId, Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        public List<Patente> Cargar()
        {
            throw new NotImplementedException();
        }

        public Guid ObtenerIdPatentePorDescripcion(string descripcion)
        {
            try
            {
                var queryString = $"SELECT IdPatente FROM Patente WHERE Descripcion = '{descripcion}'";
                return SqlUtils.Exec<Guid>(queryString)[0];
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al obtener el Id de la patente: '{0}'. Error: " +
                                  "{2}", descripcion, ex.Message));
            }
            return Guid.Empty;
        }

        public bool BorrarPatente(Guid familiaId, Guid patenteId)
        {
            var borrada = false;
            try
            {
                borrada = SqlUtils.Exec($"DELETE FROM FamiliaPatente WHERE IdFamilia = '{familiaId}' AND IdPatente = '{patenteId}'");
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al borrar la patente: '{0}' y familia: '{1}'. Error: " +
                                  "{2}", familiaId, patenteId,ex.Message));
            }

            return borrada;
        }

        public bool AsignarPatente(Guid familiaId, Guid patenteId)
        {
            var asignado = false;
            try
            {             
                //TODO: hacer el DVH mañana
                var digitoVerificadorHorizontal = 0;
                //digitoVerificador.CalcularDVHorizontal(new List<string>(), new List<int>() { familiaId, patenteId });
                asignado = SqlUtils.Exec($"INSERT INTO FamiliaPatente (IdFamilia, IdPatente, DVH) VALUES ('{familiaId}', '{patenteId}', {digitoVerificadorHorizontal})");

            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al asignar la patente: '{0}' a la familia '{1}'. Error: " +
                                  "{2}", patenteId, familiaId, ex.Message));
            }
            return asignado;
        }

        public bool ComprobarPatentesUsuario(Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        public List<FamiliaPatente> ConsultarPatenteFamilia(Guid familiaId)
        {
            try
            {
                var queryString = string.Format("SELECT IdFamilia, IdPatente FROM FamiliaPatente WHERE IdFamilia = '{0}'", familiaId);
                return SqlUtils.Exec<FamiliaPatente>(queryString);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al consultar la tabla PatenteFamilia con IdFamilia: '{0}' .Error: " +
                                  "{1}", familiaId, ex.Message));
            }

            return null;
        }
    }
}
