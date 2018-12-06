using BE;
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
            var queryString = "INSERT INTO dbo.Usuario(IdVehiculo, IdTipoUso, IdTipoVehiculo, IdMarca, IdModelo, " +
                              "CantPuertas, Color, Combustible, NumChasis, NumSerie, Patente, Año) values " +
                              "(@idVehiculo,@idTipoUso,@idTipoVehiculo,@idMarca,@idModelo,@canPuertas,@color,@combustible," +
                              "@numchasis,@numserie,@patente,@año)";

            var returnValue = false;

            try
            {
                SqlUtils.Exec(queryString, new
                {
                    @idVehiculo = entity.IdVehiculo,
                    @idTipoUso = entity._TipoUso.IdTipoUso,
                    @idTipoVehiculo = entity._TipoVehiculo.IdTipoVehiculo,
                    @idMarca = entity.Marca.IdMarca,
                    @idModelo = entity.Modelo.IdModelo,
                    @canPuertas = entity.CantPuertas,
                    @color = entity.Color,
                    @combustible = entity.Combustible,
                    @numchasis = entity.NumChasis,
                    @numserie = entity.NumSerie,
                    @patente = entity.Patente,
                    @año = entity.Año
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
            throw new NotImplementedException();
        }

        public List<Vehiculo> Retrive()
        {
            throw new NotImplementedException();
        }

        public bool Delete(Vehiculo entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Vehiculo entity)
        {
            throw new NotImplementedException();
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
