using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL.Interfaces
{
    public interface IServicioPoliza
    {
        int TraerUlitmoNumeroDePoliza();
        bool Create(Poliza entity);
        List<Cobertura> TraerCoberturas();
        List<Cobertura> TraercoberturasPorPolizaId(Guid idPoliza);
        bool ActualizarCoberturasSeleccionadas(Poliza entity);
        Poliza TraerPolizaPorNumero(int numero);
        bool Delete(Poliza entity);
        List<Poliza> Retrive();
        bool ActualizarAprobacion(Poliza entity);
    }
}
