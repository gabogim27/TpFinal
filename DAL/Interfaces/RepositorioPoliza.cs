using BE;

namespace DAL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepositorioPoliza : IRepositorioPoliza
    {
        public IPolizaDao PolizaDaoImplementor;

        public RepositorioPoliza(IPolizaDao PolizaDaoImplementor)
        {
            this.PolizaDaoImplementor = PolizaDaoImplementor;
        }

        public int TraerUlitmoNumeroDePoliza()
        {
            return PolizaDaoImplementor.TraerUlitmoNumeroDePoliza();
        }

        public bool Create(Poliza entity)
        {
            return PolizaDaoImplementor.Create(entity);
        }

        public List<Cobertura> TraerCoberturas()
        {
            return PolizaDaoImplementor.TraerCoberturas();
        }

        public List<Cobertura> TraercoberturasPorPolizaId(Guid idPoliza)
        {
            return PolizaDaoImplementor.TraercoberturasPorPolizaId(idPoliza);
        }

        public bool ActualizarCoberturasSeleccionadas(Poliza entity)
        {
            return PolizaDaoImplementor.ActualizarCoberturasSeleccionadas(entity);
        }

        public Poliza TraerPolizaPorNumero(int numero)
        {
            return PolizaDaoImplementor.TraerPolizaPorNumero(numero);
        }

        public bool Delete(Poliza entity)
        {
            return PolizaDaoImplementor.Delete(entity);
        }

        public List<Poliza> Retrive()
        {
            return PolizaDaoImplementor.Retrive();
        }

        public bool ActualizarAprobacion(Poliza entity)
        {
            return PolizaDaoImplementor.ActualizarAprobacion(entity);
        }
    }
}
