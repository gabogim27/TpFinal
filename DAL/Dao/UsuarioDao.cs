using log4net;
using log4net.Repository.Hierarchy;

namespace DAL.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using EasyEncryption;
    using Dapper;
    using DAL.Impl;
    using BE;
    using DAL.Utils;
    using DAL.Interfaces;

    public class UsuarioDao : IDao<Usuario>, IUsuarioDao
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UsuarioDao));
        public const string Key = "bZr2URKx";
        public const string Iv = "HNtgQw0w";

        public IRepositorioBitacora RepositorioBitacora;
        
        public UsuarioDao(IRepositorioBitacora RepositorioBitacora)
        {
            this.RepositorioBitacora = RepositorioBitacora;
        }

        public bool Create(Usuario ObjAlta)
        {
            var emailEncript = DES.Encrypt(ObjAlta.Email, Key, Iv);
            var queryString = "INSERT INTO dbo.Usuario(IdUsuario, Nombre, Apellido, Password, Email, " +
                              "CantLoginsFallidos, Estado, IdDomicilio, IdContacto, IdIdioma, PrimerLogin, Sexo, Dvh) values " +
                              "(@idUsuario,@nombre,@apellido,@password,@email,@cantloginsFallios,@estado,@idDomicilio," +
                              "@idContacto,@idIdioma,@primerLogin,@sexo,@dvh)";

            var returnValue = false;

            try
            {
                SqlUtils.Exec(queryString, new
                {
                    @idUsuario = ObjAlta.IdUsuario,
                    @nombre = ObjAlta.Nombre,
                    @apellido = ObjAlta.Apellido,
                    @password = ObjAlta.ContraseñaEncriptada,
                    @email = emailEncript,
                    @cantloginsFallios = ObjAlta.CantIngresosFallidos = 0,
                    @estado = Convert.ToByte(ObjAlta.Estado = true),
                    @idDomicilio = ObjAlta.Domicilio.IdDomicilio,
                    @idContacto = ObjAlta.Contacto.IdContacto,
                    @idIdioma = ObjAlta.IdIdioma,
                    @primerLogin = Convert.ToByte(ObjAlta.PrimerLogin = true),
                    @sexo = ObjAlta.Sexo,
                    @dvh = ObjAlta.Dvh
                });

                log.InfoFormat("Usuario con ID: {0} persistido correctamenete", ObjAlta.IdUsuario);
                return !returnValue;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Ocurrio un error al persistir el usuario: {0}", ex.Message);
            }

            return returnValue;
        }

        public List<Usuario> Retrive()
        {
            var queryString = @"SELECT us.*, con.*, dom.*, loc.* , prov.*
            FROM dbo.Usuario us
            inner join dbo.contacto con on us.IdContacto = con.IdContacto
            inner join dbo.DOMICILIO dom on dom.IdDomicilio = us.IdDomicilio
            inner join dbo.LOCALIDAD loc on loc.IdLocalidad = dom.IdLocalidad
            inner join dbo.Provincia prov on prov.IdProvincia = dom.IdProvincia";
            try
            {
                log.Info("Buscando todos los usuario en la BD");

                using (IDbConnection connection = SqlUtils.Connection())
                {
                    connection.Open();
                    var usuarios = connection.Query<Usuario, Contacto, Domicilio, Localidad, Provincia, Usuario>(
                            queryString,
                            (usuario, contacto, domicilio, localidad, provincia) =>
                            {
                                usuario.Contacto = contacto;
                                usuario.Domicilio = domicilio;
                                usuario.Domicilio.Localidad = localidad;
                                usuario.Domicilio.Provincia = provincia;
                                return usuario;
                            },
                            splitOn: "IdUsuario, IdContacto, IdDomicilio, IdLocalidad, IdProvincia")
                        .Distinct()
                        .ToList();
                    foreach (var user in usuarios)
                    {
                        user.Familia = new List<Familia>();
                        user.Patentes = new List<Patente>();
                        user.Email = DES.Decrypt(user.Email, Key, Iv);
                        //nos traemos la familia del usuario 
                        var familias = GetFamiliasForUser(user.IdUsuario);
                        if (familias != null)
                        {
                            user.Familia.AddRange(familias);
                            //nos traemos las patentes asociadas a esa familia(si existe)
                            foreach (var famusu in user.Familia)
                            {
                                famusu.PatentesDeFamilia = new List<Patente>();
                                var patentesDeFamilia = TraerPatentesAsociadasAFamilia(famusu.IdFamilia);
                                famusu.PatentesDeFamilia.AddRange(patentesDeFamilia);
                            }
                        }
                        //Cargamos las patentes del usuario
                        user.Patentes.AddRange(TraerPatentesAsociadasAUsuario(user.IdUsuario));
                    }

                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Hubo un error al traer la lista de usuarios: {0}", ex.Message);
            }
            return new List<Usuario>();
        }

        public List<Familia> GetFamiliasForUser(Guid idUsuario)
        {
            try
            {
                var query = string.Format("select famusu.IdFamilia, fam.Descripcion from FamiliaUsuario famusu" +
                                          " inner join FAMILIA fam on fam.IdFamilia = famusu.IdFamilia" +
                                          " where famusu.IdUsuario = '{0}'", idUsuario);
                return SqlUtils.Exec<Familia>(query);

            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al buscar en FamiliaUsuario idUsuario: {0}. Error: {1}",
                        idUsuario, ex.Message));
            }

            return null;
        }

        public List<Patente> TraerPatentesAsociadasAFamilia(Guid familiaId)
        {
            var patentes = new List<Patente>();
            try
            {
                //var famIds = string.Join(",", familiaIds.Select(x => $"'{x}'"));
                var query = string.Format("select fampat.IdPatente, pat.Descripcion from FamiliaPatente fampat" +
                                          " inner join Patente pat on pat.IdPatente = fampat.IdPatente" +
                                          " where fampat.IdFamilia = '{0}'", familiaId);
                patentes = SqlUtils.Exec<Patente>(query);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al traer las patentes de la BD. Error: " +
                                  "{0}", ex.Message));
            }

            return patentes;
        }

        public List<Patente> TraerPatentesAsociadasAUsuario(Guid usuarioId)
        {
            var patentes = new List<Patente>();
            try
            {
                //var famIds = string.Join(",", familiaIds.Select(x => $"'{x}'"));
                var query = string.Format("select usupat.IdPatente, pat.Descripcion, usupat.Negada from UsuarioPatente usupat" +
                                          " inner join Patente pat on usupat.IdPatente = pat.IdPatente" +
                                          " where usupat.IdUsuario = '{0}'", usuarioId);
                patentes = SqlUtils.Exec<Patente>(query);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al traer las patentes de la BD. Error: " +
                                  "{0}", ex.Message));
            }

            return patentes;
        }

        public bool Delete(BE.Usuario ObjDel)
        {
            try
            {
                var query = string.Format("Update Usuario set Estado = 0 where IdUsuario = '{0}'", ObjDel.IdUsuario);

                return SqlUtils.Exec(query);
            }
            catch (Exception e)
            {
                log.ErrorFormat("Ocurrio un error al intentar eliminar el usuario: {0}", ObjDel.IdUsuario);
            }

            return false;
        }

        public bool ReactivarUsuario(BE.Usuario ObjDel)
        {
            try
            {
                var query = string.Format("Update Usuario set Estado = 1 where IdUsuario = '{0}'", ObjDel.IdUsuario);

                return SqlUtils.Exec(query);
            }
            catch (Exception e)
            {
                log.ErrorFormat("Ocurrio un error al intentar reactivar el usuario: {0}", ObjDel.IdUsuario);
            }

            return false;
        }

        public bool Update(BE.Usuario ObjUpd)
        {
            try
            {
                var emailEcnript = DES.Encrypt(ObjUpd.Email, Key, Iv);
                var queryString = "Update dbo.Usuario set " +
                                  "Nombre = @nombre, Apellido = @apellido, Email = @email, " +
                                  "Sexo = @sexo where IdUsuario = @idUsuario";

                return SqlUtils.Exec(queryString, new
                {
                    @nombre = ObjUpd.Nombre,
                    @apellido = ObjUpd.Nombre,
                    @email = emailEcnript,
                    @sexo = ObjUpd.Sexo,
                    @idUsuario = ObjUpd.IdUsuario
                });
            }
            catch (Exception e)
            {
                log.ErrorFormat("Ocurrio un error al intentar actualizar el usuario con Id: {0}. Error: {1}", ObjUpd.IdUsuario, e.Message);
                return false;
            }
        }

        public bool LogIn(string email, string contraseña)
        {
            var usuario = ObtenerUsuarioConEmail(email);

            if (usuario == null) return false;

            if (usuario != null && !usuario.Estado) return false;

            if (!usuario.PrimerLogin)
            {
                var cingresoInc = usuario.CantIngresosFallidos;

                if (cingresoInc < 3)
                {
                    var contEncriptada = MD5.ComputeMD5Hash(contraseña);
                    var ingresa = ValidarContraseña(usuario.Password, contEncriptada);
                    if (!ingresa)
                    {
                        cingresoInc++;

                        ActualizarContIngresosIncorrectos(usuario.IdUsuario, cingresoInc);

                        return false;
                    }

                    return true;
                }

                return false;
            }

            return true;
        }

        private void AumentarIngresos(Usuario usuario, int ingresos)
        {
            var queryString = string.Format("UPDATE Usuario SET CantLoginsFallidos = {1} WHERE IdUsuario = {0}", usuario.IdUsuario, ingresos);

            SqlUtils.Exec(queryString);
        }

        public bool CambiarPassword(Usuario usuario, string nuevaContraseña, bool primerLogin)
        {
            throw new NotImplementedException();
        }

        Usuario IUsuarioDao.ObtenerUsuarioConEmail(string email)
        {
            return ObtenerUsuarioConEmail(email);
        }

        private bool ValidarContraseña(string password, string contEncriptada)
        {
            if (password == contEncriptada)
            {
                return true;
            }

            return false;
        }

        private Usuario ObtenerUsuarioConEmail(string email)
        {
            try
            {
                var queryString = string.Format("SELECT * FROM dbo.Usuario WHERE Email = '{0}'", DES.Encrypt(email, Key, Iv));
                var usuario = SqlUtils.Exec<Usuario>(queryString).FirstOrDefault();
                usuario.Email = DES.Decrypt(usuario.Email, Key, Iv);
                return usuario;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("No es posible encontrar el usuario con E-mail: {0}", email);
            }

            return null;
        }

        public Usuario GetById(Guid id)
        {
            try
            {
                var queryString = @"SELECT us.*, con.*, dom.*, loc.* , prov.*
                                    FROM dbo.Usuario us
                                    inner join dbo.contacto con on us.IdContacto = con.IdContacto
                                    inner join dbo.DOMICILIO dom on dom.IdDomicilio = us.IdDomicilio
                                    inner join dbo.LOCALIDAD loc on loc.IdLocalidad = dom.IdLocalidad
                                    inner join dbo.Provincia prov on prov.IdProvincia = dom.IdProvincia
                                    where IdUsuario = " + "'" + id + "'";
                log.Info("Buscando todos los usuario en la BD");

                using (IDbConnection connection = SqlUtils.Connection())
                {
                    connection.Open();
                    var user = connection.Query<Usuario, Contacto, Domicilio, Localidad, Provincia, Usuario>(
                            queryString,
                            (usuario, contacto, domicilio, localidad, provincia) =>
                            {
                                usuario.Contacto = contacto;
                                usuario.Domicilio = domicilio;
                                usuario.Domicilio.Localidad = localidad;
                                usuario.Domicilio.Provincia = provincia;
                                return usuario;
                            },
                            splitOn: "IdUsuario, IdContacto, IdDomicilio, IdLocalidad, IdProvincia")
                        .Distinct()
                        .FirstOrDefault();
                    user.Email = DES.Decrypt(user.Email, Key, Iv);
                    return user;
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("No es posible encontrar el usuario con Id: {0}. Error: {1}", id, ex.Message);
            }

            return null;
        }

        public bool CambiarContraseña(Usuario usuario, string nuevaContraseña, bool primerLogin = false)
        {
            try
            {
                var contEncript = MD5.ComputeMD5Hash(nuevaContraseña);
                var queryString = string.Empty;
                if (primerLogin == true)
                {
                    queryString = "UPDATE Usuario SET Password = @contraseña, PrimerLogin = 0 WHERE IdUsuario = @usuarioId";
                }
                else
                {
                    queryString = "UPDATE Usuario SET Password = @contraseña WHERE IdUsuario = @usuarioId";
                }

                return SqlUtils.Exec(queryString, new { @usuarioId = usuario.IdUsuario, @contraseña = contEncript });

            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    String.Format("Ocurrio un error al cambiar la contraseña del usuario: '{0}'. Error: {1}",
                        usuario.IdUsuario, ex.Message));
            }

            return false;
        }

        public bool ActualizarContIngresosIncorrectos(Guid usuarioId, int cantIngresosIncorrectos)
        {
            try
            {
                var query = string.Format("Update Usuario set CantLoginsFallidos = {0} where IdUsuario = " +
                                          "'{1}'", cantIngresosIncorrectos, usuarioId);
                return SqlUtils.Exec(query);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    String.Format("Ocurrio un error al actualizar la cantidad de logins fallidos del usuario: '{0}'. Error: {1}",
                        usuarioId, ex.Message));
            }

            return false;
        }

        public bool BloquearUsuario(Guid idUsuario)
        {
            try
            {
                var query = string.Format("Update Usuario set Bloqueado = 0 where IdUsuario = '{0}'", idUsuario);
                var result = SqlUtils.Exec(query);
                if (result)
                {
                    RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                        String.Format("Se ha bloqueado con exito al usuario: '{0}'.",
                            idUsuario));
                    return result;
                }

            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    String.Format("Ocurrio un error al intentar bloquear el usuario: '{0}'. Error: {1}",
                        idUsuario, ex.Message));
            }

            return false;
        }

        public bool DesBloquearUsuario(Guid idUsuario)
        {
            try
            {
                var query = string.Format("Update Usuario set Bloqueado = 1 and PrimerLogin = 1 where IdUsuario = '{0}'", idUsuario);
                var result = SqlUtils.Exec(query);
                if (result)
                {
                    RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                        String.Format("Se ha desbloqueado con exito al usuario: '{0}'.",
                            idUsuario));
                    return result;
                }

            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    String.Format("Ocurrio un error al intentar desbloquear el usuario: '{0}'. Error: {1}",
                        idUsuario, ex.Message));
            }

            return false;
        }

        public List<Patente> ObtenerPatentesDeUsuario(Guid usuarioId)
        {
            try
            {
                var queryString = $"SELECT IdPatente FROM UsuarioPatente WHERE IdUsuario = '{usuarioId}'";

                return SqlUtils.Exec<Patente>(queryString);

            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    String.Format("Ocurrio un error al obtener las patentes del usuario: '{0}'. Error: {1}",
                        usuarioId, ex.Message));
            }

            return null;
        }
    }
}
