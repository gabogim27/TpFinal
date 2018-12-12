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

    public class ServicioPoliza : IServicioPoliza
    {
        private IRepositorioPoliza RepositorioPolizaImplementor;

        public ServicioPoliza(IRepositorioPoliza RepositorioPolizaImplementor)
        {
            this.RepositorioPolizaImplementor = RepositorioPolizaImplementor;
        }

        public int TraerUlitmoNumeroDePoliza()
        {
            return RepositorioPolizaImplementor.TraerUlitmoNumeroDePoliza();
        }

        public bool Create(Poliza entity)
        {
            return RepositorioPolizaImplementor.Create(entity);
        }

        public List<Cobertura> TraerCoberturas()
        {
            return RepositorioPolizaImplementor.TraerCoberturas();
        }
    }
}
