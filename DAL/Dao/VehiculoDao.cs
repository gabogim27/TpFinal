using System.Data;
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

    public class VehiculoDao : IDao<Vehiculo>, IVehiculoDao
    {
        private IRepositorioBitacora RepositorioBitacora;

        public VehiculoDao(IRepositorioBitacora RepositorioBitacora)
        {
            this.RepositorioBitacora = RepositorioBitacora;
        }
        public bool Create(Vehiculo entity)
        {
            var queryString = "INSERT INTO dbo.Vehiculo(IdVehiculo, IdTipoUso, IdMarca, IdModelo, " +
                              "CantPuertas, Color, Combustible, NumChasis, NumSerie, Patente, Año, Foto1, Foto2, Foto3, Foto4) values " +
                              "(@idVehiculo,@idTipoUso,@idMarca,@idModelo,@canPuertas,@color,@combustible," +
                              "@numchasis,@numserie,@patente,@año, @foto1, @foto2, @foto3, @foto4)";

            var returnValue = false;

            try
            {
                SqlUtils.Exec(queryString, new
                {
                    @idVehiculo = entity.IdVehiculo,
                    @idTipoUso = entity._TipoUso.IdTipoUso,
                    @idMarca = entity.Marca.IdMarca,
                    @idModelo = entity.Modelo.IdModelo,
                    @canPuertas = entity.CantPuertas,
                    @color = entity.Color,
                    @combustible = entity.Combustible,
                    @numchasis = entity.NumChasis,
                    @numserie = entity.NumSerie,
                    @patente = entity.Patente,
                    @año = entity.Año,
                    @foto1 = entity.Foto1,
                    @foto2 = entity.Foto2,
                    @foto3 = entity.Foto3,
                    @foto4 = entity.Foto4
                });

                 RepositorioBitacora.RegistrarEnBitacora(Log.Level.Alta.ToString(), string.Format("Usuario con ID: {0} persistido correctamenete", entity.IdVehiculo));
                return !returnValue;
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    string.Format("Ocurrio un error al guardar el vehiculo con patente: {0} en la BD. Error: " +
                                  "{1}", entity.Patente, ex.Message));
            }

            return returnValue;
        }

        public Vehiculo GetById(Guid id)
        {
            try
            {
                var queryString = @"SELECT veh.*, tip.*, ma.*, mo.*
                                    FROM dbo.Vehiculo veh
                                    inner join dbo.TipoUso tip on tip.IdTipoUso = veh.IdTipoUso
                                    inner join dbo.Marca ma on ma.IdMarca = veh.IdMarca
                                    inner join dbo.Modelo mo on mo.IdModelo = veh.IdModelo
                                    where IdVehiculo = " + "'" + id + "'";

                RepositorioBitacora.RegistrarEnBitacora(Log.Level.Alta.ToString(), string.Format("Buscando vehiculo con Id: {0} en la BD", id));

                using (IDbConnection connection = SqlUtils.Connection())
                {
                    connection.Open();
                    var client = connection.Query<Vehiculo, TipoUso, Marca, Modelo, Vehiculo>(
                            queryString,
                            (vehiculo, tipoUso, marca, modelo) =>
                            {
                                vehiculo._TipoUso = tipoUso;
                                vehiculo.Marca = marca;
                                vehiculo.Modelo = modelo;
                                return vehiculo;
                            },
                            splitOn: "IdVehiculo, IdTipoUso, IdMarca, IdModelo")
                        .Distinct()
                        .FirstOrDefault();
                    //client.Email = DES.Decrypt(client.Email, Key, Iv);
                    return client;
                }
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(Log.Level.Alta.ToString(), string.Format("No es posible encontrar el vehiculo con Id: {0}. Error: {1}", id, ex.Message));
            }

            return null;
        }

        public List<Vehiculo> Retrive()
        {
            try
            {
                var queryString = @"SELECT veh.*, tip.*, ma.*, mo.*
                                    FROM dbo.Vehiculo veh
                                    inner join dbo.TipoUso tip on tip.IdTipoUso = veh.IdTipoUso
                                    inner join dbo.Marca ma on ma.IdMarca = veh.IdMarca
                                    inner join dbo.Modelo mo on mo.IdModelo = veh.IdModelo";

                RepositorioBitacora.RegistrarEnBitacora(Log.Level.Alta.ToString(), "Buscando todos los vehiculos.");

                using (IDbConnection connection = SqlUtils.Connection())
                {
                    connection.Open();
                    var vehiculos = connection.Query<Vehiculo, TipoUso, Marca, Modelo, Vehiculo>(
                            queryString,
                            (vehiculo, tipoUso, marca, modelo) =>
                            {
                                vehiculo._TipoUso = tipoUso;
                                vehiculo.Marca = marca;
                                vehiculo.Modelo = modelo;
                                return vehiculo;
                            },
                            splitOn: "IdVehiculo, IdTipoUso, IdMarca, IdModelo")
                        .Distinct()
                        .ToList();
                    //client.Email = DES.Decrypt(client.Email, Key, Iv);
                    return vehiculos;
                }
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(Log.Level.Alta.ToString(), string.Format("Ocurrió un error al buscar los vehiculos. Error: {0}", ex.Message));
            }

            return null;
        }

        public bool Delete(Vehiculo entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Vehiculo entity)
        {
            try
            {
                //var emailEcnript = DES.Encrypt(entity.Email, Key, Iv);
                var queryString = "Update dbo.Vehiculo set " +
                                  "IdTipoUso = @idTipoUso, IdMarca = @idMarca, IdModelo = @idModelo, " +
                                  " CantPuertas = @cantPuertas, Color = @color, Combustible = @combustible, " +
                                  "NumChasis = @numChasis, NumSerie = @numSerie, Patente = @patente, Año = @año, "  +
                                  "Foto1 = @foto1, Foto2 = @foto2, Foto3 = @foto3, Foto4 = @foto4 " +
                                  "where IdVehiculo = @idVehiculo";

                return SqlUtils.Exec(queryString, new
                {
                    @idVehiculo = entity.IdVehiculo,
                    @idTipoUso = entity._TipoUso.IdTipoUso,
                    @idMarca = entity.Marca.IdMarca,
                    @idModelo = entity.Modelo.IdModelo,
                    @cantPuertas = entity.CantPuertas,
                    @color = entity.Color,
                    @combustible = entity.Combustible,
                    @numChasis = entity.NumChasis,
                    @numSerie = entity.NumSerie,
                    @patente = entity.Patente,
                    @año = entity.Año,
                    @foto1 = entity.Foto1,
                    @foto2 = entity.Foto2,
                    @foto3 = entity.Foto3,
                    @foto4 = entity.Foto4,
                });
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    string.Format("Ocurrio un error al actualizar el vehiculo con patente: {0} en la BD. Error: " +
                                  "{1}", entity.Patente, ex.Message));
                return false;
            }
        }

        public List<Marca> TraerMarcas()
        {
            try
            {
                var query = "select * from MARCA";
                return SqlUtils.Exec<Marca>(query);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    string.Format("Ocurrio un error al traer las marcas de vehiculos de la BD. Error: " +
                                  "{0}", ex.Message));
            }

            return null;
        }

        public List<Modelo> TraerModelosPorMarca(Guid idMarca)
        {
            try
            {
                var query = string.Format("select mode.IdModelo, mode.Descripcion from MARCA mar " +
                                          "inner join MODELO mode on mode.IdMarca = mar.IdMarca " +
                                          "where mar.IdMarca = '{0}'", idMarca);
                return SqlUtils.Exec<Modelo>(query);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    string.Format("Ocurrio un error al traer los modelos de vehiculos por la marca {0}. Error: " +
                                  "{1}", idMarca, ex.Message));
            }

            return null;
        }

        public List<TipoUso> TraerTipoDeUsosDeVehiculo()
        {
            try
            {
                var query = "select * from TIPOUSO";
                return SqlUtils.Exec<TipoUso>(query);
            }
            catch (Exception ex)
            {
                RepositorioBitacora.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    string.Format("Ocurrio un error al traer los tipo de usos de vehiculos de la BD. Error: " +
                                  "{0}", ex.Message));
            }

            return null;
        }
    }
}
