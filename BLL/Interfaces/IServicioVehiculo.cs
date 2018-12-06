using BE;

namespace BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IServicioVehiculo
    {
        List<Marca> TraerMarcas();

        List<Modelo> TraerModelosPorMarca(Guid idMarca);

        List<TipoUso> TraerTipoDeUsosDeVehiculo();
    }
}
