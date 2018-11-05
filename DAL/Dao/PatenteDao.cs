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

    public class PatenteDao : IPatenteDao
    {
        public IRepositorioBitacora RepositorioBitacora;

        public PatenteDao(IRepositorioBitacora repositorioBitacora)
        {
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
    }
}
