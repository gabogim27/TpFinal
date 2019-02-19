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
    using System.Text;
    using System.Threading.Tasks;

    public class FacturaDao : IDao<Factura>
    {
        private IBitacoraDao BitacoraDao;
        public IDigitoVerificador DigitoVerificador;

        public FacturaDao(IBitacoraDao BitacoraDao, IDigitoVerificador DigitoVerificador)
        {
            this.BitacoraDao = BitacoraDao;
            this.DigitoVerificador = DigitoVerificador;
        }
        public bool Create(Factura entity)
        {
            var digitoVH = DigitoVerificador.CalcularDVHorizontal(new List<string> { entity.DetalleFactura.IdDetalle.ToString(), entity.IdFactura.ToString() }, new List<int> { entity.NumeroFactura });
            var queryString = "INSERT INTO dbo.Detalle_Factura(IdDetalle, IdVehiculo, IdCliente, " +
                              "importe, DVH) values " +
                              "(@idDetalle,@idVehiculo,@idCliente,@importe,@dvh)";

            var returnValue = false;

            try
            {
                var facturaGuardada = false;
                //Guardamos el detalle
                var detalleGuardado = SqlUtils.Exec(queryString, new
                {
                    @idDetalle = entity.DetalleFactura.IdDetalle,
                    @idVehiculo = entity.DetalleFactura.Vehiculo.IdVehiculo,
                    @idCliente = entity.DetalleFactura.Cliente.IdCliente,
                    @importe = entity.DetalleFactura.Importe,
                    @sumaAsegurada = entity.DetalleFactura,
                    @dvh = digitoVH
                });

                //Guardamos la poliza
                if (detalleGuardado)
                {
                    var query = "INSERT INTO dbo.Factura(IdFactura, IdDetalle, IdPoliza, NumeroFactura, " +
                                      "Vencimiento, Estado, Paga) values " +
                                      "(@idFactura,@idDetalle,@idPoliza,@numeroFactura,@vencimiento,@estado,@paga)";

                    facturaGuardada = SqlUtils.Exec(query, new
                    {
                        @idFactura = entity.IdFactura,
                        @idDetalle = entity.DetalleFactura.IdDetalle,
                        @idPoliza = entity.Poliza.IdPoliza,
                        @numeroFactura = entity.Estado,
                        @vencimiento = entity.Vencimiento,
                        @estado = entity.Estado,
                        @paga = entity.Paga
                    });
                }

                if (facturaGuardada)
                {
                    BitacoraDao.RegistrarEnBitacora(Log.Level.Alta.ToString(), string.Format("Detalle Factura con ID: {0} persistido correctamenete", entity.DetalleFactura.IdDetalle));
                    return !returnValue;
                }

            }
            catch (Exception ex)
            {
                BitacoraDao.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    string.Format("Ocurrio un error al guardar la factura con id: {0} en la BD. Error: " +
                                  "{1}", entity.IdFactura, ex.Message));
            }

            return returnValue;
        }

        Factura IDao<Factura>.GetById(Guid id)
        {
            try
            {
                var queryString = @"SELECT fac.*, det.*, veh.*, cli.* , pol.*
                                    FROM dbo.Factura fac
                                    inner join dbo.Detalle_Factura det on fac.IdDetalle = det.IdDetalle
                                    inner join dbo.vehiculo veh on veh.IdVehiculo = det.IdVehiculo
                                    inner join dbo.Cliente cli on cli.IdCliente = det.IdCliente
                                    inner join dbo.Poliza pol on pol.IdPoliza = fac.IdPoliza
                                    where IdFactura = " + "'" + id + "'";
                BitacoraDao.RegistrarEnBitacora(Log.Level.Baja.ToString(),
                    string.Format("Buscando Factura con ID: {0} ", 
                        id));

                using (IDbConnection connection = SqlUtils.Connection())
                {
                    connection.Open();
                    var facturaById = connection.Query<Factura, DetalleFactura, Vehiculo, Cliente, Poliza, Factura>(
                            queryString,
                            (factura, detalleFactura, vehiculo, cliente, poliza) =>
                            {
                                factura.DetalleFactura = detalleFactura;
                                factura.DetalleFactura.Vehiculo = vehiculo;
                                factura.DetalleFactura.Cliente = cliente;
                                factura.Poliza = poliza;
                                return factura;
                            },
                            splitOn: "IdFactura, IdDetalle, IdVehiculo, IdCliente, IdPoliza")
                        .Distinct()
                        .FirstOrDefault();
                    return facturaById;
                }
            }
            catch (Exception ex)
            {
                BitacoraDao.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    string.Format("Ocurrio un error al buscar la factura con id: {0} en la BD. Error: " +
                                  "{1}", id, ex.Message));
            }

            return null;
        }

        List<Factura> IDao<Factura>.Retrive()
        {
            try
            {
                var queryString = @"SELECT fac.*, det.*, veh.*, cli.* , pol.*
                                    FROM dbo.Factura fac
                                    inner join dbo.Detalle_Factura det on fac.IdDetalle = det.IdDetalle
                                    inner join dbo.vehiculo veh on veh.IdVehiculo = det.IdVehiculo
                                    inner join dbo.Cliente cli on cli.IdCliente = det.IdCliente
                                    inner join dbo.Poliza pol on pol.IdPoliza = fac.IdPoliza";

                BitacoraDao.RegistrarEnBitacora(Log.Level.Baja.ToString(),
                    string.Format("Buscando todas las facturas en la Tabla Factura."));

                using (IDbConnection connection = SqlUtils.Connection())
                {
                    connection.Open();
                    var facturas = connection.Query<Factura, DetalleFactura, Vehiculo, Cliente, Poliza, Factura>(
                            queryString,
                            (factura, detalleFactura, vehiculo, cliente, poliza) =>
                            {
                                factura.DetalleFactura = detalleFactura;
                                factura.DetalleFactura.Vehiculo = vehiculo;
                                factura.DetalleFactura.Cliente = cliente;
                                factura.Poliza = poliza;
                                return factura;
                            },
                            splitOn: "IdFactura, IdDetalle, IdVehiculo, IdCliente, IdPoliza")
                        .Distinct()
                        .ToList();

                    return facturas;
                }
            }
            catch (Exception ex)
            {
                BitacoraDao.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    string.Format("Ocurrio un error al buscar las facturas en la BD. Error: " +
                                  "{0}", ex.Message));
            }

            return null;
        }

        //ESTE METODO FUNCIONARIA COMO EL QUE TRATA EL ESTADO DE LA FACTURA
        //1 = NORMAL
        //0 = ANULADA
        public bool Delete(Factura entity)
        {
            try
            {
                var query = string.Format("Update Factura set Estado = 1 where IdFactura = '{0}'", entity.IdFactura);

                return SqlUtils.Exec(query);
            }
            catch (Exception ex)
            {
                BitacoraDao.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    string.Format("Ocurrio un error al intentar actualizar la factura {0} en la BD. Error: " +
                                  "{1}", entity.NumeroFactura, ex.Message));
            }

            return false;
        }

        //ESTE METODO ACTUALIZA EN LA BD SI LA FACTURA FUE PAGA
        //1 = NORMAL
        //0 = ANULADA
        public bool Update(Factura entity)
        {
            try
            {
                var query = string.Format("Update Factura set paga = 1 where IdFactura = '{0}'", entity.IdFactura);

                return SqlUtils.Exec(query);
            }
            catch (Exception ex)
            {
                BitacoraDao.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    string.Format("Ocurrio un error al intentar actualizar la factura {0} en la BD. Error: " +
                                  "{1}", entity.NumeroFactura, ex.Message));
            }

            return false;
        }
    }
}
