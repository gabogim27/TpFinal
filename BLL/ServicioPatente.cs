using BE;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ServicioPatente : IServicioPatente
    {
        public IRepositorioPatente RepositorioPatente;

        public ServicioPatente(IRepositorioPatente repositorioPatente)
        {
            this.RepositorioPatente = repositorioPatente;
        }
        public List<Patente> RetrievePatentes()
        {
            return RepositorioPatente.RetrievePatentes();
        }
    }
}
