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
        public IDigitoVerificador DigitoVerificador;
        public IDao<Usuario> UsuarioDao;
        public IUsuarioDao UsuarioDaoImplementor;
        public IFamiliaDao FamiliaDaoImplementor;

        public PatenteDao(IRepositorioBitacora repositorioBitacora, IDigitoVerificador DigitoVerificador, IUsuarioDao UsuarioDaoImplementor,
            IDao<Usuario> UsuarioDao, IFamiliaDao FamiliaDaoImplementor)
        {
            this.UsuarioDao = UsuarioDao;
            this.UsuarioDaoImplementor = UsuarioDaoImplementor;
            this.DigitoVerificador = DigitoVerificador;
            this.FamiliaDaoImplementor = FamiliaDaoImplementor;
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
                var digitoVH = DigitoVerificador.CalcularDVHorizontal(new List<string> { patenteId.ToString(), usuarioId.ToString() }, new List<int> { });
                var queryString =
                    $"INSERT INTO UsuarioPatente(IdPatente, IdUsuario, Negada, DVH) VALUES ('{patenteId}', '{usuarioId}', 0, {digitoVH})";
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
                var digitoVerificadorHorizontal = DigitoVerificador.CalcularDVHorizontal(new List<string>() { familiaId.ToString(), patenteId.ToString() }, new List<int>() { });
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

        public List<UsuarioPatente> ConsultarUsuarioPatente(Guid usuarioId)
        {
            try
            {
                var queryString = string.Format("SELECT IdUsuario, IdPatente, Negada FROM UsuarioPatente WHERE IdUsuario = '{0}'", usuarioId);
                return SqlUtils.Exec<UsuarioPatente>(queryString);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    string.Format("Ocurrio un error al consultar la tabla UsuarioPatente con IdUsuario: '{0}' y  Error: " +
                                  "{1}", usuarioId, ex.Message));
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

        //TODO: Cambiar el nombre de ka funcion
        public bool VerificarDatos(List<Guid> idsToDelete)
        {
            try
            {
                //Todas las patentes en patentesUsuarios
                //var todasLaspatentes = patentesUsuarios.Select(x => x.IdPatente);
                //Primer
                //var listapatente = Cargar().Select(x => x.IdPatente).ToList();
                ////patForm.Exists(item => patUsu.Patentes.Select(item2 => item2.IdPatente).Contains(item.IdPatente)

                //var pete = todasLaspatentes.Intersect(listapatente);
                //var check = pete.Count() == listapatente.Count();

                var queryselect = "SELECT * FROM UsuarioPatente";

                var listaUsuariosPatentes = new List<UsuarioPatente>();


                listaUsuariosPatentes = SqlUtils.Exec<UsuarioPatente>(queryselect);

                var patentesUsuarios = listaUsuariosPatentes.ToList();

                //Las patentes que tiene asignada el usuario
                var patUsu = patentesUsuarios.Where(u => idsToDelete.Select(x => x).Contains(u.IdUsuario)).Select(x => x.IdPatente).OrderBy(x => x).ToList();

                //Deberiamos verificar que las patentes asignadas al usuario sigan existiendo en la tabla cruzada
                // 1 - Borramos de la lista original el usuario seleccionado
                patentesUsuarios.RemoveAll(u => idsToDelete.Select(x => x).Contains(u.IdUsuario));
                // 2 - Chequear que sigan existiendo sus patentes, es decir, que sigan estando asignadas
                return patentesUsuarios.FindAll(x => patUsu.Any(y => y == x.IdPatente)).Distinct().Count() == patUsu.Count;


            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al verificar los datos en la tabla PatenteUsuario. Error: " +
                                  "{0}", ex.Message));
            }

            return false;
        }

        public bool CheckeoDePatentesParaBorrar(Usuario usuario, bool requestFamilia = false, bool requestFamiliaUsuario = false, Guid? idAQuitar = null)
        {
            var patUsuDictionary = new Dictionary<Guid, int>();
            var returnValue = false;
            var usuariosGlobal = UsuarioDao.Retrive().Where(x => x.Estado).ToList();
            usuariosGlobal.RemoveAll(x => x.IdUsuario == usuario.IdUsuario);

            usuario.Patentes = new List<Patente>();
            usuario.Familia = new List<Familia>();
            var familiaId = FamiliaDaoImplementor.ObtenerIdsFamiliasPorUsuario(usuario.IdUsuario);

            if (requestFamiliaUsuario)
            {
                familiaId.RemoveAll(x => x != idAQuitar);
            }

            foreach (var idfam in familiaId)
            {
                usuario.Familia.Add(new Familia() {IdFamilia = idfam});
            }

            usuario.Patentes.AddRange(UsuarioDaoImplementor.ObtenerPatentesDeUsuario(usuario.IdUsuario));

            usuario.Patentes.AddRange(FamiliaDaoImplementor.ObtenerPatentesFamilia(familiaId));

            usuario.Patentes = usuario.Patentes.GroupBy(p => p.IdPatente).Select(grp => grp.First()).ToList();

            foreach (var usu in usuariosGlobal)
            {
                var familiasId = FamiliaDaoImplementor.ObtenerIdsFamiliasPorUsuario(usu.IdUsuario);
                usu.Familia = new List<Familia>();
                usu.Patentes = new List<Patente>();

                foreach (var idfam in familiasId)
                {
                    usu.Familia.Add(new Familia() {IdFamilia = idfam});

                    if (requestFamilia)
                    {
                        if (usu.Familia.Exists(a => usuario.Familia.All(x => a.IdFamilia == x.IdFamilia)))
                        {
                            usu.Familia.RemoveAll(x => x.IdFamilia == idfam);
                        }
                        else
                        {
                            usu.Patentes.AddRange(FamiliaDaoImplementor.ObtenerPatentesPorFamiliaGUID(idfam));
                        }
                    }
                    else
                    {
                        usu.Patentes.AddRange(FamiliaDaoImplementor.ObtenerPatentesPorFamiliaGUID(idfam));
                    }

                }

                usu.Patentes.AddRange(UsuarioDaoImplementor.ObtenerPatentesDeUsuario(usu.IdUsuario));

                usu.Patentes = usu.Patentes.GroupBy(p => p.IdPatente).Select(grp => grp.First()).ToList();
            }

            foreach (var patpepe in usuario.Patentes)
            {
                patUsuDictionary.Add(patpepe.IdPatente, 0);
                var contador = 0;

                foreach (var usu2 in usuariosGlobal)
                {
                    //returnValue = usuario.Patentes.Exists(u => usu2.Patentes.All(x => x.IdPatente == u.IdPatente));
                    foreach (var patusu in usu2.Patentes)
                    {
                        if (patpepe.IdPatente == patusu.IdPatente)
                        {
                            contador++;
                            patUsuDictionary[patpepe.IdPatente] = contador;
                        }
                    }
                }
            }

            if (patUsuDictionary.Count > 0 && patUsuDictionary.All(x => x.Value > 0))
            {
                returnValue = true;
            }

            return returnValue;
        }

        public bool CheckeoDePatentes(Usuario usuarioToDelete)
        {
            var returnValue = false;

            var usuarioPatentes = ConsultarUsuarioPatente(usuarioToDelete.IdUsuario).Select(x => x.IdPatente).ToList();
            var familiasUsuario = new List<Guid>();


            if (usuarioToDelete.Familia != null)
            {
                familiasUsuario = usuarioToDelete.Familia.Select(x => x.IdFamilia).ToList();

            }

            if (familiasUsuario.Any())
            {
                foreach (var idFam in familiasUsuario)
                {
                    returnValue = esPatenteFamiliaEnUso(usuarioToDelete.IdUsuario, idFam);
                }
            }
            else
            {
                foreach (var usuPat in usuarioPatentes)
                {
                    returnValue = esPatenteFamiliaEnUso(usuarioToDelete.IdUsuario, null, usuPat);
                }
            }

            foreach (var patente in usuarioPatentes)
            {
                returnValue = EsPatenteEnUso(patente, usuarioToDelete.IdUsuario);

                if (!returnValue)
                    break;
            }


            return returnValue;
        }

        public bool CheckeoDePatentesParaBorrar(Usuario usuario, bool requestFamilia = false, bool requestFamiliaUsuario = false,
            int idAQuitar = 0)
        {
            throw new NotImplementedException();
        }

        private bool EsPatenteEnUso(Guid patente, Guid idUsuario)
        {
            var query = string.Format("Select IdUsuario from UsuarioPatente where IdPatente = '{0}'", patente);
            var usuarios = new List<Guid>();
            var returnValue = false;

            usuarios = SqlUtils.Exec<Guid>(query);

            if (usuarios.Count > 1)
            {
                returnValue = true;
            }
            else if (usuarios.All(x => x != idUsuario))
            {
                returnValue = true;
            }

            return returnValue;
        }

        private bool esPatenteFamiliaEnUso(Guid idUsuario, Guid? idFam = null, Guid? idPatente = null)
        {
            var returnValue = false;
            if (idFam != null)
            {
                var queryPatFamilia = string.Format("SELECT IdPatente FROM FamiliaPatente WHERE IdFamilia = '{0}'", idFam);

                var patentesFamilia = new List<Guid>();


                patentesFamilia = SqlUtils.Exec<Guid>(queryPatFamilia);

                var idsPat = string.Join(",", patentesFamilia);
                idsPat = "'" + idsPat.Replace("", "'") + "'";

                ///Buscar como checkear que esa familia pertenezca a ese usuario SI otro usuario tiene la misma familia pero 
                ///no tiene asignada la patente si la recibe por la familia puedo eliminar al usuario
                var queryFamilias = string.Format("SELECT DISTINCT IdFamilia FROM FamiliaPatente WHERE IdPatente IN ({0})", idsPat);
                var idDeFamilias = new List<Guid>();
                var usuariosConFamilia = new List<Guid>();



                idDeFamilias = SqlUtils.Exec<Guid>(queryFamilias);

                var idsFam = string.Join(",", idDeFamilias);
                idsFam = "'" + idsFam.Replace("", "'") + "'";

                var queryFamiliaUsuario = string.Format("SELECT DISTINCT IdUsuario FROM FamiliaUsuario WHERE IdFamilia IN ({0})", idsFam);

                usuariosConFamilia = SqlUtils.Exec<Guid>(queryFamiliaUsuario);

                ///si hay mas de un usuario con la familia que tiene la patente entonces si me la puedo sacar sin importar si yo soy el que tiene esa familia
                if (usuariosConFamilia.Count > 1)
                {
                    returnValue = true;
                }
                ////si otro tiene esa familia entonces yo me la puedo sacar
                else if (usuariosConFamilia[0] != idUsuario)
                {
                    returnValue = true;
                }
            }
            else
            {

                var queryFamByPatente = string.Format("SELECT IdFamilia FROM FamiliaPatente WHERE IdPatente = '{0}'", idPatente);

                var idsFamilia = new List<Guid>();


                idsFamilia = SqlUtils.Exec<Guid>(queryFamByPatente);

                var idsPat = string.Join(",", idsFamilia);
                idsPat = "'" + idsPat.Replace("", "'") + "'";

                ///Buscar como checkear que esa familia pertenezca a ese usuario SI otro usuario tiene la misma familia pero 
                ///no tiene asignada la patente si la recibe por la familia puedo eliminar al usuario
                var queryFamilias = string.Format("SELECT DISTINCT IdFamilia FROM FamiliaPatente WHERE IdPatente IN ({0})", idsPat);
                var idDeFamilias = new List<Guid>();
                var usuariosConFamilia = new List<Guid>();



                idDeFamilias = SqlUtils.Exec<Guid>(queryFamilias);

                var idsFam = string.Join(",", idDeFamilias);
                idsFam = "'" + idsFam.Replace("", "'") + "'";

                var queryFamiliaUsuario = string.Format("SELECT DISTINCT IdUsuario FROM FamiliaUsuario WHERE IdFamilia IN ({0})", idsFam);

                usuariosConFamilia = SqlUtils.Exec<Guid>(queryFamiliaUsuario);

                ///si hay mas de un usuario con la familia que tiene la patente entonces si me la puedo sacar sin importar si yo soy el que tiene esa familia
                if (usuariosConFamilia.Count > 1)
                {
                    returnValue = true;
                }
                ////si otro tiene esa familia entonces yo me la puedo sacar
                else if (usuariosConFamilia[0] != idUsuario)
                {
                    returnValue = true;
                }
            }



            return returnValue;
        }
    }
}
