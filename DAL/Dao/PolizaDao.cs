using System.Data;
using Dapper;
using DAL.Interfaces;
using DAL.Utils;
using EasyEncryption;

namespace DAL.Dao
{
    using BE;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PolizaDao : IDao<Poliza>, IPolizaDao
    {
        private IBitacoraDao BitacoraDao;
        public IDigitoVerificador DigitoVerificador;
        private IDao<Cliente> ClienteDao;
        private IDao<Vehiculo> VehiculoDao;

        public PolizaDao(IBitacoraDao BitacoraDao, IDigitoVerificador DigitoVerificador, 
            IDao<Cliente> ClienteDao, IDao<Vehiculo> VehiculoDao)
        {
            this.BitacoraDao = BitacoraDao;
            this.DigitoVerificador = DigitoVerificador;
            this.ClienteDao = ClienteDao;
            this.VehiculoDao = VehiculoDao;
        }

        public bool Create(Poliza entity)
        {
            var dvh = 0;
            var queryString = "INSERT INTO dbo.Detalle_Poliza(IdDetalle, IdVehiculo, prima, " +
                              "SumaAsegurada, DVH) values " +
                              "(@idDetalle,@idVehiculo,@prima,@sumaAsegurada,@dvh)";

            var returnValue = false;

            try
            {
                var polizaGuardada = false;
                //Guardamos el detalle
                var detalleGuardado = SqlUtils.Exec(queryString, new
                {
                    @idDetalle = entity.Detalle.IdDetalle,
                    //@idCobertura = entity.Detalle.Cobertura.IdCobertura,
                    @idVehiculo = entity.Detalle.Vehiculo.IdVehiculo,
                    @prima = entity.Detalle.Prima,
                    @sumaAsegurada = entity.Detalle.SumaAsegurada,
                    @dvh = dvh
                });

                //Guardamos la poliza
                if (detalleGuardado)
                {
                    var query = "INSERT INTO dbo.Poliza(IdPoliza, IdDetalle, IdCliente, Estado, " +
                                      "NroPoliza, FechaEmision) values " +
                                      "(@idPoliza,@idDetalle,@idCliente,@estado,@nroPoliza,@fechaEmision)";

                    polizaGuardada = SqlUtils.Exec(query, new
                    {
                        @idPoliza = entity.IdPoliza,
                        @idDetalle = entity.Detalle.IdDetalle,
                        @idCliente = entity.Cliente.IdCliente,
                        @estado = entity.Estado,
                        @nroPoliza = entity.NroPoliza,
                        @fechaEmision = entity.FechaEmision
                    });
                }

                if (polizaGuardada)
                {
                    InsertCoberturas(entity);

                    BitacoraDao.RegistrarEnBitacora(Log.Level.Alta.ToString(), string.Format("Detalle Poliza con ID: {0} persistido correctamenete", entity.Detalle.IdDetalle));

                    return !returnValue;
                }

            }
            catch (Exception ex)
            {
                BitacoraDao.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    string.Format("Ocurrio un error al guardar la poliza con id: {0} en la BD. Error: " +
                                  "{1}", entity.IdPoliza, ex.Message));
            }

            return returnValue;
        }

        private void InsertCoberturas(Poliza entity)
        {
            try
            {
                foreach (var cobertura in entity.Detalle.Coberturas)
                {
                    string processQuery = string.Format("INSERT INTO PolizaCobertura (IdPoliza, IdCobertura) VALUES ('{0}', '{1}')",
                        entity.IdPoliza, cobertura.IdCobertura);
                    SqlUtils.Connection().Execute(processQuery);
                }
            }
            catch (Exception ex)
            {
                BitacoraDao.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    string.Format("Ocurrio un error al guardar las coberturas seleccionadas para la poliza: {0} en la BD. Error: " +
                                  "{1}", entity.NroPoliza, ex.Message));
            }
        }

        public Poliza TraerPolizaPorNumero(int numero)
        {
            try
            {
                var queryString = @"SELECT pol.*, det.*, veh.*, cli.*
                                    FROM dbo.poliza pol
                                    inner join dbo.Detalle_Poliza det on det.IdDetalle = pol.IdDetalle
                                    inner join dbo.vehiculo veh on veh.IdVehiculo = det.IdVehiculo
                                    inner join dbo.Cliente cli on cli.IdCliente = pol.IdCliente
                                    where NroPoliza = " + "'" + numero + "'";
                BitacoraDao.RegistrarEnBitacora(Log.Level.Baja.ToString(),
                    string.Format("Buscando póliza con número: {0} ",
                        numero));

                using (IDbConnection connection = SqlUtils.Connection())
                {
                    connection.Open();
                    var polizaByNumero = connection.Query<Poliza, DetallePoliza, Vehiculo, Cliente, Poliza>(
                            queryString,
                            (poliza, detallePoliza, vehiculo, cliente) =>
                            {
                                poliza.Detalle = detallePoliza;
                                poliza.Detalle.Vehiculo = vehiculo;
                                poliza.Cliente = cliente;
                                return poliza;
                            },
                            splitOn: "IdPoliza, IdDetalle, IdVehiculo, IdCliente")
                        .Distinct()
                        .FirstOrDefault();

                    var coberturas = polizaByNumero != null ? TraercoberturasPorPolizaId(polizaByNumero.IdPoliza) : null;

                    if (coberturas != null)
                        polizaByNumero.Detalle.Coberturas.AddRange(coberturas);

                    var client = polizaByNumero != null ? ClienteDao.GetById(polizaByNumero.Cliente.IdCliente) : null;

                    if (client != null)
                        polizaByNumero.Cliente = client;

                    var auto = polizaByNumero != null
                        ? VehiculoDao.GetById(polizaByNumero.Detalle.Vehiculo.IdVehiculo)
                        : null;

                    if (auto != null)
                        polizaByNumero.Detalle.Vehiculo = auto;

                    return polizaByNumero;
                }
            }
            catch (Exception ex)
            {
                BitacoraDao.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    string.Format("Ocurrio un error al buscar la poliza con numero: {0} en la BD. Error: " +
                                  "{1}", numero, ex.Message));
            }

            return null;
        }

        public List<Cobertura> TraercoberturasPorPolizaId(Guid idPoliza)
        {
            try
            {
                var query = string.Format("select IdCobertura from PolizaCobertura" +
                                          " where IdPoliza = '{0}'", idPoliza);

                var result = SqlUtils.Exec<Guid>(query);

                if (result != null && result.Count > 0)
                {
                    var coma = string.Empty;
                    var idCoberturaParameters = string.Empty;
                    var queryImpl = "Select * from Cobertura where ";

                    for (int i = 0; i < result.Count; i++)
                    {
                        if (i != 0)
                            coma = ",";

                        idCoberturaParameters += coma + "'" + result[i] + "'";
                    }

                    queryImpl += String.Format("IdCobertura IN ({0})", idCoberturaParameters);

                    var result2 = SqlUtils.Exec<Cobertura>(queryImpl);

                    return result2;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return null;
        }

        public Poliza GetById(Guid id)
        {
            try
            {
                var query = string.Format("select p.*, d.*, c.*, v.* from Poliza p " +
                                          "inner join DETALLE_POLIZA d on p.IdDetalle = d.IdDetalle " +
                                          "inner join cliente c on c.IdCliente = p.IdCliente " +
                                          "inner join Vehiculo v on v.IdVehiculo = d.IdVehiculo" +
                                          " where p.NroPoliza = {}", id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return new Poliza();
        }

        public List<Poliza> Retrive()
        {
            try
            {
                var queryString = @"SELECT pol.*, det.*, veh.*, cli.* , cob.*
                                    FROM dbo.poliza pol
                                    inner join dbo.Detalle_Poliza det on det.IdDetalle = pol.IdDetalle
                                    inner join dbo.vehiculo veh on veh.IdVehiculo = det.IdVehiculo
                                    inner join dbo.Cliente cli on cli.IdCliente = pol.IdCliente";
                BitacoraDao.RegistrarEnBitacora(Log.Level.Baja.ToString(),
                    string.Format("Buscando todas las pólizas"));

                using (IDbConnection connection = SqlUtils.Connection())
                {
                    connection.Open();
                    var polizas = connection.Query<Poliza, DetallePoliza, Vehiculo, Cliente, Poliza>(
                            queryString,
                            (poliza, detallePoliza, vehiculo, cliente) =>
                            {
                                poliza.Detalle = detallePoliza;
                                poliza.Detalle.Vehiculo = vehiculo;
                                poliza.Cliente = cliente;
                                return poliza;
                            },
                            splitOn: "IdPoliza, IdDetalle, IdVehiculo, IdCliente")
                        .Distinct()
                        .ToList();

                    foreach (var poliza in polizas)
                    {
                        var coberturas = TraercoberturasPorPolizaId(poliza.IdPoliza);

                        if (coberturas != null)
                            poliza.Detalle.Coberturas.AddRange(coberturas);
                    }

                    return polizas;
                }
            }
            catch (Exception ex)
            {
                BitacoraDao.RegistrarEnBitacora(DalLogLevel.LogLevel.Media.ToString(),
                    string.Format("Ocurrio un error al buscar las polizas en la BD. Error: " +
                                  "{0}", ex.Message));
            }

            return null;
        }

        public bool Delete(Poliza entity)
        {
            try
            {
                var query = string.Format("Update Poliza set Estado = 0 where NroPoliza = {0}", entity.NroPoliza);

                return SqlUtils.Exec(query);
            }
            catch (Exception e)
            {
                BitacoraDao.RegistrarEnBitacora(DalLogLevel.LogLevel.Alta.ToString(),
                    string.Format("Ocurrio un error al tratar de anular la poliza con numero: {0} en la BD. Error: " +
                                  "{1}", entity.NroPoliza, e.Message));
            }

            return false;
        }

        public bool Update(Poliza entity)
        {
            try
            {
                //var digitoVH = DigitoVerificador.CalcularDVHorizontal(new List<string> { entity.IdPoliza.ToString() }, new List<int> { entity.NroPoliza });
                //var queryString = "Update dbo.Poliza set " +
                //                  "Nombre = @nombre, Apellido = @apellido, Email = @email, " +
                //                  "Sexo = @sexo where IdUsuario = @idUsuario, Dvh = @dvh";

                //var result = SqlUtils.Exec(queryString, new
                //{
                //    @nombre = ObjUpd.Nombre,
                //    @apellido = ObjUpd.Nombre,
                //    @email = emailEcnript,
                //    @sexo = ObjUpd.Sexo,
                //    @idUsuario = ObjUpd.IdUsuario,
                //    @dvh = digitoVH
                //});

                return true;

            }
            catch (Exception e)
            {
                BitacoraDao.RegistrarEnBitacora(Log.Level.Media.ToString(), string.Format("Ocurrio un error al intentar actualizar la poliza con Id: {0}. Error: {1}", entity.IdPoliza, e.Message));
                return false;
            }
        }

        public bool ActualizarCoberturasSeleccionadas(Poliza entity)
        {
            try
            {
                var query = string.Format("Delete from PolizaCobertura where IdPoliza = '{0}'", entity.IdPoliza);

                var res = SqlUtils.Exec(query);

                if (res)
                {
                    InsertCoberturas(entity);
                }

                return true;

            }
            catch (Exception ex)
            {
                BitacoraDao.RegistrarEnBitacora(Log.Level.Media.ToString(), String.Format("No es posible actualizar las cobertutas de la poliza numero: " +
                                                                                          " {0}. Error: {1}", entity.NroPoliza, ex.Message));
            }

            return false;
        }

        public int TraerUlitmoNumeroDePoliza()
        {
            try
            {
                var query = "SELECT ISNULL(MAX(NroPoliza), 0) FROM Poliza";
                return SqlUtils.Exec<int>(query)[0];

            }
            catch (Exception ex)
            {
                BitacoraDao.RegistrarEnBitacora(Log.Level.Media.ToString(), String.Format("No es posible traer la el " +
                                                                                          " ultimo numero de poliza creado. Error: {0}", ex.Message));
            }

            return 0;
        }

        public List<Cobertura> TraerCoberturas()
        {
            var coberturas = new List<Cobertura>();
            try
            {
                var query = "Select * from Cobertura";
                coberturas = SqlUtils.Exec<Cobertura>(query);
            }
            catch (Exception ex)
            {
                BitacoraDao.RegistrarEnBitacora(Log.Level.Media.ToString(), String.Format("No es posible traer las coberturas. Error: {0}", ex.Message));
            }

            return coberturas;
        }
    }
}
