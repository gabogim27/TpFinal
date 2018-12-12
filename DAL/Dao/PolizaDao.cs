using DAL.Interfaces;
using DAL.Utils;

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

        public PolizaDao(IBitacoraDao BitacoraDao)
        {
            this.BitacoraDao = BitacoraDao;
        }

        public bool Create(Poliza entity)
        {
            var dvh = 0;
            var queryString = "INSERT INTO dbo.Detalle_Poliza(IdDetalle, IdCobertura, IdVehiculo, prima, " +
                              "SumaAsegurada, DVH) values " +
                              "(@idDetalle,@idCobertura,@idVehiculo,@prima,@sumaAsegurada,@dvh)";

            var returnValue = false;

            try
            {
                var polizaGuardada = false;
                //Guardamos el detalle
                var detalleGuardado = SqlUtils.Exec(queryString, new
                {
                    @idDetalle = entity.Detalle.IdDetalle,
                    @idCobertura = entity.Detalle.Cobertura.IdCobertura,
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
            throw new NotImplementedException();
        }

        public bool Delete(Poliza entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Poliza entity)
        {
            throw new NotImplementedException();
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
