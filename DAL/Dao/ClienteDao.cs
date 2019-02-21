using System.Data;
using BE;
using Dapper;
using DAL.Interfaces;
using DAL.Utils;
using EasyEncryption;

namespace DAL.Dao
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class ClienteDao : IDao<Cliente>
    {
        private IBitacoraDao BitacoraDao;
        public const string Key = "bZr2URKx";
        public const string Iv = "HNtgQw0w";

        public ClienteDao(IBitacoraDao BitacoraDao)
        {
            this.BitacoraDao = BitacoraDao;
        }

        public bool Create(Cliente entity)
        {
            //var emailEncript = DES.Encrypt(entity.Email, Key, Iv);
            //var nombreEcript = DES.Encrypt(entity.Nombre, Key, Iv);
            //var apellidoEncript = DES.Encrypt(entity.Apellido, Key, Iv);
            //var dniEncript = DES.Encrypt(entity.Dni.ToString(), Key, Iv);
            var queryString = "INSERT INTO dbo.Cliente(IdCliente, IdDomicilio, IdContacto, Nombre, Apellido, Email, " +
                              "FechaNacimiento, Dni, Sexo, Estado) values " +
                              "(@idCliente,@idDomicilio,@idContacto,@nombre,@apellido,@email,@fechaNacimiento,@dni," +
                              "@sexo,@estado)";

            var returnValue = false;

            try
            {
                returnValue = SqlUtils.Exec(queryString, new
                {
                    @idCliente = entity.IdCliente,
                    @idDomicilio = entity.Domicilio.IdDomicilio,
                    @idContacto = entity.Contacto.IdContacto,
                    @nombre = entity.Nombre,
                    @apellido = entity.Apellido,
                    @email = entity.Email,
                    @fechaNacimiento = entity.FechaNacimiento,
                    @dni = entity.Dni,
                    @estado = Convert.ToByte(entity.Estado = true),
                    @sexo = entity.Sexo,
                });

                BitacoraDao.RegistrarEnBitacora(Log.Level.Media.ToString(), string.Format("Cliente con ID: {0} persistido correctamente.", entity.IdCliente));
                return returnValue;
            }
            catch (Exception ex)
            {
                BitacoraDao.RegistrarEnBitacora(Log.Level.Media.ToString(), string.Format("Ocurrió un error al persistir el cliente: {0}. Error {1}", entity.Email, ex.Message));
            }

            return returnValue;
        }

        public Cliente GetById(Guid id)
        {
            try
            {
                var queryString = @"SELECT cl.*, con.*, dom.*, loc.* , prov.*
                                    FROM dbo.cliente cl
                                    inner join dbo.contacto con on cl.IdContacto = con.IdContacto
                                    inner join dbo.DOMICILIO dom on dom.IdDomicilio = cl.IdDomicilio
                                    inner join dbo.LOCALIDAD loc on loc.IdLocalidad = dom.IdLocalidad
                                    inner join dbo.Provincia prov on prov.IdProvincia = dom.IdProvincia
                                    where IdCliente = " + "'" + id + "'";

                BitacoraDao.RegistrarEnBitacora(Log.Level.Alta.ToString(), string.Format("Buscando cliente con Id: {0} en la BD", id));

                using (IDbConnection connection = SqlUtils.Connection())
                {
                    connection.Open();
                    var client = connection.Query<Cliente, Contacto, Domicilio, Localidad, Provincia, Cliente>(
                            queryString,
                            (cliente, contacto, domicilio, localidad, provincia) =>
                            {
                                cliente.Contacto = contacto;
                                cliente.Domicilio = domicilio;
                                cliente.Domicilio.Localidad = localidad;
                                cliente.Domicilio.Provincia = provincia;
                                return cliente;
                            },
                            splitOn: "IdCliente, IdContacto, IdDomicilio, IdLocalidad, IdProvincia")
                        .Distinct()
                        .FirstOrDefault();
                    //client.Email = DES.Decrypt(client.Email, Key, Iv);
                    return client;
                }
            }
            catch (Exception ex)
            {
                 BitacoraDao.RegistrarEnBitacora(Log.Level.Alta.ToString(), string.Format("No es posible encontrar el cliente con Id: {0}. Error: {1}", id, ex.Message));
            }

            return null;
        }

        public List<Cliente> Retrive()
        {
            try
            {
                var queryString = @"SELECT cl.*, con.*, dom.*, loc.* , prov.*
                                    FROM dbo.cliente cl
                                    inner join dbo.contacto con on cl.IdContacto = con.IdContacto
                                    inner join dbo.DOMICILIO dom on dom.IdDomicilio = cl.IdDomicilio
                                    inner join dbo.LOCALIDAD loc on loc.IdLocalidad = dom.IdLocalidad
                                    inner join dbo.Provincia prov on prov.IdProvincia = dom.IdProvincia";

                BitacoraDao.RegistrarEnBitacora(Log.Level.Alta.ToString(), "Buscando Todos los Clientes.");

                using (IDbConnection connection = SqlUtils.Connection())
                {
                    connection.Open();
                    var clientes = connection.Query<Cliente, Contacto, Domicilio, Localidad, Provincia, Cliente>(
                            queryString,
                            (cliente, contacto, domicilio, localidad, provincia) =>
                            {
                                cliente.Contacto = contacto;
                                cliente.Domicilio = domicilio;
                                cliente.Domicilio.Localidad = localidad;
                                cliente.Domicilio.Provincia = provincia;
                                return cliente;
                            },
                            splitOn: "IdCliente, IdContacto, IdDomicilio, IdLocalidad, IdProvincia")
                        .Distinct()
                        .ToList();

                    //foreach (var client in clientes)
                    //{
                    //    client.Email = DES.Decrypt(client.Email, Key, Iv);
                    //}
                    return clientes;                  
                }
            }
            catch (Exception ex)
            {
                BitacoraDao.RegistrarEnBitacora(Log.Level.Alta.ToString(), string.Format("No es posible obtener todos los clientes de la BD. Error: {0}", ex.Message));
            }

            return null;
        }

        public bool Delete(Cliente entity)
        {
            try
            {
                var query = string.Format("Update Usuario set Estado = 0 where IdCliente = '{0}'", entity.IdCliente);

                return SqlUtils.Exec(query);
            }
            catch (Exception ex)
            {
                 BitacoraDao.RegistrarEnBitacora(Log.Level.Alta.ToString(), string.Format("Ocurrio un error al intentar eliminar el cliente: {0}. Error: {1}", entity.IdCliente, ex.Message));
            }

            return false;
        }

        public bool Update(Cliente entity)
        {
            try
            {
                //var emailEcnript = DES.Encrypt(entity.Email, Key, Iv);
                var queryString = "Update dbo.Cliente set " +
                                  "Nombre = @nombre, Apellido = @apellido, FechaNacimiento = @fechaNac, " +
                                  " Dni = @dni, Email = @email, " +
                                  "Sexo = @sexo where IdCliente = @idCliente";

                return SqlUtils.Exec(queryString, new
                {
                    @idCliente = entity.IdCliente,
                    @nombre = entity.Nombre,
                    @apellido = entity.Nombre,
                    @fechaNac = entity.FechaNacimiento,
                    @dni = entity.Dni,
                    @email = entity.Email,
                    @sexo = entity.Sexo,
                    @idUsuario = entity.IdCliente
                });
            }
            catch (Exception e)
            {
                BitacoraDao.RegistrarEnBitacora(Log.Level.Alta.ToString(), string.Format("Ocurrio un error al intentar actualizar el cliente con Id: {0}. Error: {1}", entity.IdCliente, e.Message));
                return false;
            }

        }
    }
}
