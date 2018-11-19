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
        public IRepositorioBitacora RepositorioBitacora;

        public UsuarioDao(IRepositorioBitacora RepositorioBitacora)
        {
            this.RepositorioBitacora = RepositorioBitacora;
        }

        public bool Create(Usuario ObjAlta)
        {
            var queryString = string.Format("INSERT INTO dbo.Usuario(IdUsuario, Nombre, Apellido, Password, Email, " +
                "CantLoginsFallidos, Estado, IdDomicilio, IdContacto, IdIdioma, PrimerLogin, Sexo, Dvh) values " +
                "('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}','{9}',{10}, '{11}', {12})",
                ObjAlta.IdUsuario = Guid.NewGuid(),
                ObjAlta.Nombre,
                ObjAlta.Apellido,
                ObjAlta.ContraseñaEncriptada,
                ObjAlta.Email,
                ObjAlta.CantIngresosFallidos = 0,
                Convert.ToByte(ObjAlta.Estado = true),
                ObjAlta.Domicilio.IdDomicilio,
                ObjAlta.Contacto.IdContacto,
                ObjAlta.IdIdioma,
                Convert.ToByte(ObjAlta.PrimerLogin = true),
                ObjAlta.Sexo,
                ObjAlta.Dvh
                );
            var returnValue = false;

            try
            {
                SqlUtils.Exec(queryString);
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
                    return usuarios;
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("Hubo un error al traer la lista de usuarios: {0}", ex.Message);
            }
            return new List<Usuario>();
        }

        public bool Delete(BE.Usuario ObjDel)
        {
            try
            {
                var queryString = string.Format("delete from dbo.Usuario where " +
                                                "IdUsuario = '{0}'",
                    ObjDel.IdUsuario
                );

                return SqlUtils.Exec(queryString);
            }
            catch (Exception e)
            {
                log.ErrorFormat("Ocurrio un error al intentar eliminar el usuario: {0}", ObjDel.IdUsuario);
            }

            return false;
        }

        public bool Update(BE.Usuario ObjUpd)
        {
            try
            {
                var queryString = string.Format("Update dbo.Usuario set " +
                                                "Nombre = '{0}', Apellido = '{1}', Email = '{2}', " +
                                                "Sexo = '{3}' where IdUsuario = '{4}'",
                    ObjUpd.Nombre,
                    ObjUpd.Apellido,
                    ObjUpd.Email,
                    ObjUpd.Sexo,
                    ObjUpd.IdUsuario
                );

                return SqlUtils.Exec(queryString);
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
                var queryString = string.Format("SELECT * FROM dbo.Usuario WHERE Email = '{0}'", email);
                return SqlUtils.Exec<Usuario>(queryString).FirstOrDefault();
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
                var query = string.Format("Update Usuario set Estado = 0 where IdUsuario = '{0}'", idUsuario);
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
                var query = string.Format("Update Usuario set Estado = 1 and PrimerLogin = 1 where IdUsuario = '{0}'", idUsuario);
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
