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
            throw new NotImplementedException();
        }

        public Poliza GetById(Guid id)
        {
            throw new NotImplementedException();
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
                coberturas =  SqlUtils.Exec<Cobertura>(query);
            }
            catch (Exception ex)
            {
                BitacoraDao.RegistrarEnBitacora(Log.Level.Media.ToString(), String.Format("No es posible traer las coberturas. Error: {0}", ex.Message));
            }

            return coberturas;
        }
    }
}
