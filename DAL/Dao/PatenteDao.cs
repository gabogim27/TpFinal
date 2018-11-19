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

        public bool ComprobarPatentesUsuario(Guid idUsuario)
        {
            try
            {
                string query = string.Format("Select IdUsuario from UsuarioPatente where " +
                                             " IdUsuario = '{0}'", idUsuario);
                var retorno = SqlUtils.Exec<Guid>(query);
                if (retorno.Count > 0)
                    return true;
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al comprobar las patentes del usuario: {0} de la BD. Error: " +
                                  "{1}", idUsuario, ex.Message));
            }

            return false;
        }

        public List<UsuarioPatente> TraerPatenteDescrUsuario(Guid idUsuario)
        {
            try
            {
                var query = string.Format("select pat.IdPatente, usupat.Negada, usupat.IdUsuario from " +
                                          " UsuarioPatente usupat join USUARIO usu on usupat.IdUsuario " +
                                          " = usu.IdUsuario join Patente pat on usupat.IdPatente = " +
                                          " pat.IdPatente where usu.IdUsuario = '{0}'", idUsuario);
                return SqlUtils.Exec<UsuarioPatente>(query);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al traer las descripciones de patentes de la BD. Error: " +
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

        public bool GuardarPatenteUsuario(Guid patenteId, Guid usuarioId)
        {
            try
            {
                //var digitoVH =
                //digitoVerificador.CalcularDVHorizontal(new List<string> { }, new List<int> {patenteId, usuarioId});
                var queryString =
                    $"INSERT INTO UsuarioPatente(IdPatente, IdUsuario, Negada, DVH) VALUES ('{patenteId}', '{usuarioId}', 0, 0)";
                return SqlUtils.Exec(queryString);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al guardar patenteUsuario: '{0}'. Error: " +
                                  "{1}", patenteId, ex.Message));
            }

            return false;
        }

        public bool BorrarPatenteUsuario(Guid patenteId, Guid usuarioId)
        {
            try
            {
                //var digitoVH =
                //digitoVerificador.CalcularDVHorizontal(new List<string> { }, new List<int> {patenteId, usuarioId});
                var queryString =
                    $"Delete UsuarioPatente where IdPatente = '{patenteId}' and IdUsuario = '{usuarioId}'";
                return SqlUtils.Exec(queryString);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al borrar patenteUsuario: '{0}'. Error: " +
                                  "{1}", patenteId, ex.Message));
            }

            return false;
        }

        public bool NegarPatenteUsuario(Guid patenteId, Guid usuarioId)
        {
            try
            {
                var queryString = $"UPDATE UsuarioPatente SET Negada = 1 WHERE IdUsuario = '{usuarioId}' AND IdPatente = '{patenteId}'";
                return SqlUtils.Exec(queryString);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al negar la patente: '{0}' al usuario: {1}. Error: " +
                                  "{2}", patenteId, usuarioId, ex.Message));
            }

            return false;
        }

        public bool HabilitarPatenteUsuario(Guid patenteId, Guid usuarioId)
        {
            try
            {
                var queryString = $"UPDATE UsuarioPatente SET Negada = 0 WHERE IdUsuario = '{usuarioId}' AND IdPatente = '{patenteId}'";
                return SqlUtils.Exec(queryString);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al habilitar la patente: '{0}' al usuario: {1}. Error: " +
                                  "{2}", patenteId, usuarioId, ex.Message));
            }

            return false;
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
                                  "{1}", descripcion, ex.Message));
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
                                  "{2}", familiaId, patenteId, ex.Message));
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

        public List<UsuarioPatente> ConsultarUsuarioPatente(Guid usuarioId, Guid patenteId)
        {
            try
            {
                var queryString = string.Format("SELECT IdUsuario, IdPatente FROM UsuarioPatente WHERE IdUsuario = '{0}' and IdPatente " +
                                                " = '{1}'", usuarioId, patenteId);
                return SqlUtils.Exec<UsuarioPatente>(queryString);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    string.Format("Ocurrio un error al consultar la tabla UsuarioPatente con IdUsuario: '{0}' y " +
                                  " IdPatente: {1}. Error: " +
                                  "{2}", usuarioId, patenteId, ex.Message));
            }

            return null;
        }

        public List<Patente> ObtenerPermisosFormulario(Guid formId)
        {
            try
            {
                var query = "SELECT IdPatente FROM FormularioPatente WHERE IdFormularioPatente = @formId";

                return SqlUtils.Exec<Patente>(query, new { @formId = formId });

            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al obtener los permisos del formulario. Error: " +
                                  "{0}", ex.Message));
            }

            return null;
        }

        public List<Patente> ObtenerPermisosFormularios()
        {
            try
            {
                var query = "SELECT IdPatente FROM FormularioPatente";

                return SqlUtils.Exec<Patente>(query);

            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al obtener los permisos del formulario. Error: " +
                                  "{0}", ex.Message));
            }

            return null;
        }
    }
}
