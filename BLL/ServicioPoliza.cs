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

        public List<Cobertura> TraercoberturasPorPolizaId(Guid idPoliza)
        {
            return RepositorioPolizaImplementor.TraercoberturasPorPolizaId(idPoliza);
        }

        public bool ActualizarCoberturasSeleccionadas(Poliza entity)
        {
            return RepositorioPolizaImplementor.ActualizarCoberturasSeleccionadas(entity);
        }

        public Poliza TraerPolizaPorNumero(int numero)
        {
            return RepositorioPolizaImplementor.TraerPolizaPorNumero(numero);
        }
    }
}
