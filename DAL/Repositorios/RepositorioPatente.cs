using BE;
using DAL.Interfaces;

namespace DAL.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepositorioPatente : IRepositorioPatente
    {
        public IPatenteDao PatenteDao;

        public RepositorioPatente(IPatenteDao patenteDao)
        {
            this.PatenteDao = patenteDao;
        }
        public List<Patente> RetrievePatentes()
        {
            return PatenteDao.RetrievePatentes();
        }
    }
}
