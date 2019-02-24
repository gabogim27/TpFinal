using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.Interfaces
{
    public interface IRepositorioPoliza
    {
        int TraerUlitmoNumeroDePoliza();
        bool Create(Poliza entity);
        List<Cobertura> TraerCoberturas();
        List<Cobertura> TraercoberturasPorPolizaId(Guid idPoliza);
        bool ActualizarCoberturasSeleccionadas(Poliza entity);
        Poliza TraerPolizaPorNumero(int numero);
    }
}
