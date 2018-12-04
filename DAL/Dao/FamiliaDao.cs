using DAL.Interfaces;

namespace DAL.Impl
{
    using BE;
    using DAL.Utils;
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FamiliaDao : IDao<Familia>, IFamiliaDao
    {
        public IRepositorioBitacora RepositorioBitacora;
        public IDigitoVerificador DigitoVerificador;
        public IDao<Usuario> UsuarioDao;

        public FamiliaDao(IRepositorioBitacora repositorioBitacora, IDigitoVerificador DigitoVerificador, IDao<Usuario> UsuarioDao)
        {
            this.UsuarioDao = UsuarioDao;
            this.DigitoVerificador = DigitoVerificador;
            this.RepositorioBitacora = repositorioBitacora;
        }
        public bool Create(BE.Familia ObjAlta)
        {
            try
            {
                var sqlQuery = string.Format("INSERT INTO dbo.Familia (idFamilia, Descripcion) values ('{0}', '{1}')", ObjAlta.IdFamilia.ToString(), ObjAlta.Descripcion);
                return SqlUtils.Exec(sqlQuery);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    String.Format("Ocurrio un error al tratar de crear la familia: {0}. Error: {1}", ObjAlta.Descripcion, ex.Message));
            }

            return false;
        }

        public Familia GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Familia> Retrive()
        {
            try
            {
                var query = "Select * from Familia";
                return SqlUtils.Exec<Familia>(query);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al traer todas las familias de la base de datos. Error: {0}", ex.Message));
            }

            return null;
        }

        public bool Delete(Familia entity)
        {
            try
            {
                var query = string.Format("Delete Familia where IdFamilia = '{0}'", entity.IdFamilia);
                return SqlUtils.Exec(query);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al eliminar la familia: {0}. Error: {1}",
                        entity.Descripcion, ex.Message));
            }

            return false;
        }

        public bool Update(Familia entity)
        {
            try
            {
                var query = string.Format("Update Familia set Descripcion = '{0}' where IdFamilia = '{1}'",
                    entity.Descripcion, entity.IdFamilia);
                return SqlUtils.Exec(query);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al actualizar la familia: {0}. Error: {1}", entity.Descripcion, ex.Message));
            }

            return false;
        }       

        public bool GuardarFamiliaUsuario(List<Guid> familiaIds, Guid usuarioId)
        {
            try
            {
                //TODO: Implementar mas adelante
                foreach (var idFamilia in familiaIds)
                {
                    string processQuery = string.Format("INSERT INTO FamiliaUsuario (IdFamilia, IdUsuario) VALUES ('{0}', '{1}')", idFamilia, usuarioId);
                    SqlUtils.Connection().Execute(processQuery);
                }

                return true;
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al guardar en FamiliaUsuario idUsuario: {0}. Error: {1}",
                        usuarioId, ex.Message));
            }

            return false;
        }

        public bool GuardarFamiliasUsuario(Guid familiaId, Guid usuarioId)
        {
            try
            {
                var digitoVH = DigitoVerificador.CalcularDVHorizontal(new List<string> { familiaId.ToString(), usuarioId.ToString() }, new List<int> { });
                string processQuery = string.Format("INSERT INTO FamiliaUsuario (IdFamilia, IdUsuario, DVH) VALUES ('{0}', '{1}', {2})", familiaId, usuarioId, digitoVH);
                SqlUtils.Connection().Execute(processQuery);

                return true;
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al guardar en FamiliaUsuario idUsuario: {0}. Error: {1}",
                        usuarioId, ex.Message));
            }

            return false;
        }

        public bool BorrarFamiliaUsuario(Guid familiaId, Guid usuarioId)
        {
            try
            {
                var result = 0;
                string processQuery = string.Format("Delete FamiliaUsuario where IdFamilia = '{0}' and IdUsuario = '{1}'", familiaId, usuarioId);
                result = SqlUtils.Connection().Execute(processQuery);

                if (result > 0)
                    return true;
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al borrar en FamiliaUsuario idUsuario: {0}. Error: {1}",
                        usuarioId, ex.Message));
            }

            return false;
        }

        public List<Patente> ObtenerPatentesFamilia(List<Guid> familiaIds)
        {
            var patentes = new List<Patente>();

            try
            {
                foreach (var id in familiaIds)
                {
                    var queryString = $"SELECT IdPatente FROM FamiliaPatente WHERE IdFamilia = '{id}'";
                    patentes.AddRange(SqlUtils.Exec<Patente>(queryString));
                }
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(), string.Format("Ocurrio une error al obtener las patentes por el familias. " +
                                                                                                             "Error: {0}", ex.Message));
            }
            return patentes;
        }

        public List<Guid> ObtenerPatentesPorFamiliaId(Guid familiaId)
        {
            var patentes = new List<Guid>();

            try
            {
                var queryString = $"SELECT distinct IdPatente FROM FamiliaPatente WHERE IdFamilia = '{familiaId}'";
                patentes.AddRange(SqlUtils.Exec<Guid>(queryString));
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(), string.Format("Ocurrio une error al obtener las patentes por el familias. " +
                                                                                                             "Error: {0}", ex.Message));
            }
            return patentes;
        }

        public List<Patente> ObtenerPatentesPorFamiliaGUID(Guid familiaId)
        {
            var patentes = new List<Patente>();

            try
            {
                var queryString = $"SELECT distinct IdPatente FROM FamiliaPatente WHERE IdFamilia = '{familiaId}'";
                patentes.AddRange(SqlUtils.Exec<Patente>(queryString));
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(), string.Format("Ocurrio une error al obtener las patentes por el familias. " +
                                                                                                             "Error: {0}", ex.Message));
            }
            return patentes;
        }

        public Guid ObtenerIdFamiliaPorDescripcion(string descripcion)
        {
            try
            {
                var queryString = $"SELECT IdFamilia FROM Familia WHERE Descripcion = '{descripcion}'";
                return SqlUtils.Exec<Guid>(queryString)[0];
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(), string.Format("Ocurrio une error al obtener el I de la familia por la descripcion: " +
                                                                                                             "'{0}'. Error: {1}", descripcion, ex.Message));
            }

            return Guid.Empty;
        }

        public Guid ObtenerIdFamiliaPorUsuario(Guid usuarioId)
        {
            try
            {
                var query = string.Format("select IdFamilia from FamiliaUsuario where IdUsuario = '{0}'", usuarioId);
                return SqlUtils.Exec<Guid>(query)[0];
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(), string.Format("Ocurrio une error al obtener el Id de la familia por el id del usuario: " +
                                                                                                            "'{0}'. Error: {1}", usuarioId, ex.Message));
            }

            return Guid.Empty;
        }

        public string ObtenerDescripcionFamiliaPorId(Guid familiaId)
        {
            try
            {
                var query = string.Format("select Descripcion from Familia where IdFamilia = '{0}'");
                return SqlUtils.Exec<string>(query)[0];
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(), string.Format("Ocurrio une error al buscar la descripcion de la familia: " +
                                                                                                             "'{0}'. Error: {1}", familiaId, ex.Message));
            }

            return null;
        }

        public List<string> TraerFamiliaUsuarioDescripcion(Guid IdUsuario)
        {
            try
            {
                var query = String.Format("select fam.Descripcion from FamiliaUsuario famusu" +
                                          " join USUARIO usu on famusu.IdUsuario = usu.IdUsuario join Familia fam on " +
                                          " fam.IdFamilia = famusu.IdFamilia  where " +
                                          "usu.IdUsuario = '{0}'", IdUsuario);
                return SqlUtils.Exec<string>(query);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(), string.Format("Ocurrio une error al buscar la descripcion de las familia para el usuario: " +
                                                                                                             "'{0}'. Error: {1}", IdUsuario, ex.Message));
            }

            return null;
        }

        public bool ComprobarUsoFamilia(Guid usuarioId)
        {
            var result = new List<Guid>();
            try
            {
                var query = string.Format("Select IdUsuario from FamiliaUsuario where IdUsuario = '{0}'", usuarioId);
                result = SqlUtils.Exec<Guid>(query);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(), String.Format("Ocurrio un error al comprobar el uso de familia." +
                                                                                                             "UsuarioId: '{0}'. Error: {1}", usuarioId, ex.Message));
            }

            if (result.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Guid> ObtenerIdsFamiliasPorUsuario(Guid usuarioId)
        {
            var famIds = new List<Guid>();
            try
            {
                var queryString = $"SELECT IdFamilia FROM FamiliaUsuario WHERE IdUsuario = '{usuarioId}'";

                famIds = SqlUtils.Exec<Guid>(queryString);
                return famIds;

            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(), String.Format("Ocurrio un error al buscar los id de familia en la tabla FamiliaUsuario para el usuario: {0}" +
                                                                                                             " Error: {1}", usuarioId, ex.Message));
            }

            return famIds;
        }

        public List<Familia> ObtenerFamiliasPorUsuario(Guid usuarioId)
        {
            var allFamilies = Retrive();
            var familiaUsuario = ObtenerIdsFamiliasPorUsuario(usuarioId);

            return allFamilies.FindAll(x => familiaUsuario.Any(y => y == x.IdFamilia));
        }

        public void BorrarFamiliaDeFamiliaPatente(Guid familiaId)
        {
            try
            {
                var queryString = string.Format("DELETE FROM FamiliaPatente WHERE IdFamilia = '{0}'", familiaId);

                SqlUtils.Exec(queryString);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(), String.Format("Ocurrio un error al borrar la familiaPatente " +
                                                                                                             " Error: {0}", ex.Message));
            }

        }

        public List<Familia> ObtenerFamiliasUsuario(Guid usuarioId)
        {
            var familiasDb = Retrive();
            var familiaUsuario = ObtenerIdsFamiliasPorUsuario(usuarioId);

            return familiasDb.FindAll(x => familiaUsuario.Any(y => y == x.IdFamilia));
        }

        public List<Usuario> ObtenerUsuariosPorFamilia(Guid familiaId)
        {
            var queryString = string.Format("SELECT DISTINCT IdUsuario FROM FamiliaUsuario WHERE IdFamilia = '{0}'", familiaId);
            var listaUsuarios = new List<Usuario>();

            var usuarios = SqlUtils.Exec<Guid>(queryString);

            foreach (var usuario in usuarios)
            {
                listaUsuarios.Add(UsuarioDao.GetById(usuario));
            }

            return listaUsuarios;
        }
    }
}
