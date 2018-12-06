using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.Interfaces
{
    public interface IVehiculoDao
    {
        List<Marca> TraerMarcas();

        List<Modelo> TraerModelosPorMarca(Guid idMarca);

        List<TipoUso> TraerTipoDeUsosDeVehiculo();
    }
}
