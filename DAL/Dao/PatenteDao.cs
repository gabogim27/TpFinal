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

        public void BorrarListaPatentesUsuario(List<Guid> patentesId, Guid usuarioId)
        {
            try
            {

                foreach (var id in patentesId)
                {
                    //var digitoVH = DigitoVerificador.CalcularDVHorizontal(new List<string> { }, new List<int> { id, usuarioId });
                    var queryString = $"DELETE FROM UsuarioPatente WHERE IdPatente = '{id}' AND IdUsuario = '{usuarioId}'";
                    SqlUtils.Exec(queryString);
                }
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al borrar las patente del Usuario: '{0}'. Error: " +
                                  "{1}", usuarioId, ex.Message));
            }
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

        public bool CheckeoDePatentesParaBorrar(Usuario usuarioABorrar)
        {
            Dictionary<Guid, int> diccionarioPatentes = null;
            List<Usuario> usuariosGlobales;
            var usuarios = new List<Usuario>();
            var patentesEscenciales = new List<Patente>();

            usuariosGlobales = UsuarioDao.Retrive().Where(x => x.Estado).ToList();
            //Son las patentes que vamos a usar para chequear todo el tiempo
            patentesEscenciales = RetrievePatentes();

            //Primer chequeo
            //usuarios.AddRange(usuariosGlobales);
            usuariosGlobales.RemoveAll(usu => usu.IdUsuario == usuarioABorrar.IdUsuario);

            ///Si ningun usuario tiene patentes no se puede borrar ningun usuario
            //Chequear que el que se esta borrando no sea el unico usuario con las patentes escenciales
            if (usuariosGlobales.All(x => x.Patentes.Count < 1))
            {
                return false;
            }

            //En caso de que sea borrado de usuario, removemos el mismo de la lista global
            if (usuarioABorrar != null)
            {
                //usuariosGlobales.Remove(usuarioABorrar);
                diccionarioPatentes = new Dictionary<Guid, int>();
                foreach (var usu in usuariosGlobales)
                {
                    usu.Patentes = usu.Patentes.GroupBy(x => x.IdPatente).Select(g => g.First()).ToList();
                }

                foreach (var patEscencial in patentesEscenciales)
                {
                    diccionarioPatentes.Add(patEscencial.IdPatente, 0);
                    foreach (var usuPat in usuariosGlobales)
                    {
                        foreach (var pat in usuPat.Patentes)
                        {
                            if (pat.IdPatente == patEscencial.IdPatente)
                            {
                                diccionarioPatentes[patEscencial.IdPatente] += 1;
                            }
                        }
                        //if (usuPat.Patentes.Any(x => x.IdPatente == patEscencial.IdPatente))
                        //{
                        //    diccionarioPatentes[patEscencial.IdPatente] += 1;
                        //}
                    }
                }
                //Si hay mas de un usuario con todas las patentes retornamos true
                if (diccionarioPatentes.Count > 0 && diccionarioPatentes.All(x => x.Value > 0))
                    return true;
            }

            return false;
        }

        private bool ComprobarTablaUsuarioPatente()
        {
            List<UsuarioPatente> patentesUsuarios = ObtenerTodasLasPatentesYUsuarios();

            return patentesUsuarios.Count > 0;
        }

        private List<UsuarioPatente> ObtenerTodasLasPatentesYUsuarios()
        {
            var patentesUsuarios = new List<UsuarioPatente>();
            try
            {
                var optQuery = "SELECT * FROM UsuarioPatente";

                patentesUsuarios = SqlUtils.Exec<UsuarioPatente>(optQuery);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al obtener los datos de usuarioPatente. Error: " +
                                  "{0}", ex.Message));
            }

            return patentesUsuarios;
        }        

        public bool CheckeoFamiliaParaBorrar(Usuario usuario = null, Familia familiaABorrar = null, Guid? idPatente = null, bool esNegado = false)
        {
            var diccionarioPatentes = new Dictionary<Guid, int>();
            var patenteToCheck = idPatente ?? Guid.Empty;
            var usuariosGlobales = UsuarioDao.Retrive().Where(x => x.Estado).ToList();

            if (familiaABorrar?.PatentesDeFamilia.Count <= 0 || usuario?.Patentes.Count <= 0)
            {
                return true;
            }

            //Si estamos eliminando una patente de una familia, y esa patente ya la tiene asignada un usuario,
            //retornamos true de una
            if (usuariosGlobales.Count(u => Enumerable.Any<Patente>(u.Patentes, p => p.IdPatente == patenteToCheck && !p.Negada)) > 1)
                return true;


            //Cuando estamos verificando solo por una patente de la familia, si necesito acumular, caso contrario no!!!
            if (idPatente != null)
            {
                foreach (var user in usuariosGlobales)
                {
                    foreach (var fam in user.Familia)
                    {
                        foreach (var patfam in fam.PatentesDeFamilia)
                        {
                            if ((familiaABorrar == null && idPatente != null) || (fam.IdFamilia != familiaABorrar.IdFamilia && patfam.IdPatente != idPatente))
                                user.Patentes.Add(patfam);
                            //if (familiaABorrar != null && (fam.IdFamilia != familiaABorrar.IdFamilia && fam.PatentesDeFamilia.Any(x => x.IdPatente != idPatente)))
                            //    user.Patentes.AddRange(fam.PatentesDeFamilia);
                        }
                    }
                }
            }

            if (esNegado)
            {   //Agrupamos ya que no nos interesa la herencia por familia            
                foreach (var usu in usuariosGlobales)
                {
                    usu.Patentes = usu.Patentes.GroupBy(x => x.IdPatente).Select(g => g.First()).ToList();
                }
            }

            //Descartamos los usuarios que no tienen patentes asignadas, no tiene sentido tenerlos en la lista
            usuariosGlobales = usuariosGlobales.Where(x => x.Patentes.Count > 0 || x.Familia.Select(u => u.PatentesDeFamilia).Count() > 0).ToList();

            //usuariosGlobales = usuariosGlobales.(user => user.Patentes.GroupBy(p => p.IdPatente));

            diccionarioPatentes = CargarDiccionario(usuariosGlobales, familiaABorrar, idPatente);

            if ((familiaABorrar == null && !esNegado && patenteToCheck != Guid.Empty && diccionarioPatentes.All(x => x.Value > 1)) || (familiaABorrar != null && !esNegado && diccionarioPatentes.Count > 0 && diccionarioPatentes.All(x => x.Value > 0)) || (esNegado &&
                                                                                                 patenteToCheck != Guid.Empty && diccionarioPatentes.All(x => x.Value > 1)))
            {
                return true;
            }

            return false;
        }      

        private Dictionary<Guid, int> CargarDiccionario(List<Usuario> usuariosGlobal, Familia familiaAConsultar, Guid? patenteId)
        {
            var diccionarioPatentes = new Dictionary<Guid, int>();
            var patenteToCheck = patenteId ?? Guid.Empty;

            if (familiaAConsultar != null)
            {
                foreach (var patenteAChequear in familiaAConsultar.PatentesDeFamilia)
                {
                    diccionarioPatentes.Add(patenteAChequear.IdPatente, 0);
                    var contador = 0;
                    foreach (var usuario in usuariosGlobal)
                    {
                        if (usuario.Patentes.Any(x => x.IdPatente == patenteAChequear.IdPatente) ||
                            (usuario.Familia.Any(x => x.IdFamilia != familiaAConsultar.IdFamilia) && usuario.Familia.Any(x => x.PatentesDeFamilia.Any(y => y.IdPatente == patenteAChequear.IdPatente))))
                        {
                            contador++;
                            diccionarioPatentes[patenteAChequear.IdPatente] = contador;
                        }
                    }
                }
            }
            else if (patenteToCheck != Guid.Empty)
            {
                foreach (var usuario in usuariosGlobal)
                {
                    if (!diccionarioPatentes.ContainsKey(patenteToCheck))
                        diccionarioPatentes.Add(patenteToCheck, 0);
                    if (usuario.Patentes.Any(x => x.IdPatente == patenteId))
                    {
                        diccionarioPatentes[patenteToCheck] += usuario.Patentes.Count(x => x.IdPatente == patenteId);
                    }
                }
            }

            return diccionarioPatentes;
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
