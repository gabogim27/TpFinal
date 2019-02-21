using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.Interfaces
{
    public interface IPolizaDao
    {
        int TraerUlitmoNumeroDePoliza();
        List<Cobertura> TraerCoberturas();
        bool Create(Poliza entity);
        Poliza TraerPolizaPorNumero(int numero);
        List<Cobertura> TraercoberturasPorPolizaId(Guid idPoliza);
        bool ActualizarCoberturasSeleccionadas(Poliza entity);
    }
}
