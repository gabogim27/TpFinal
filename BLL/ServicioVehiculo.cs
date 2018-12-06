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

    public class ServicioVehiculo : IServicio<Vehiculo>, IServicioVehiculo
    {
        private IRepository<Vehiculo> RepositorioVehiculo;
        private IRepositorioVehiculo RepositorioVehiculoImplementor;

        public ServicioVehiculo(IRepository<Vehiculo> RepositorioVehiculo, IRepositorioVehiculo RepositorioVehiculoImplementor)
        {
            this.RepositorioVehiculo = RepositorioVehiculo;
            this.RepositorioVehiculoImplementor = RepositorioVehiculoImplementor;
        }
        public bool Create(Vehiculo entity)
        {
            return RepositorioVehiculo.Create(entity);
        }

        public Vehiculo GetById(Guid id)
        {
            return RepositorioVehiculo.GetById(id);
        }

        public List<Vehiculo> Retrive()
        {
            return RepositorioVehiculo.Retrive();
        }

        public bool Delete(Vehiculo entity)
        {
            return RepositorioVehiculo.Delete(entity);
        }

        public bool Update(Vehiculo entity)
        {
            return RepositorioVehiculo.Update(entity);
        }

        public List<Marca> TraerMarcas()
        {
            return RepositorioVehiculoImplementor.TraerMarcas();
        }

        public List<Modelo> TraerModelosPorMarca(Guid idMarca)
        {
            return RepositorioVehiculoImplementor.TraerModelosPorMarca(idMarca);
        }

        public List<TipoUso> TraerTipoDeUsosDeVehiculo()
        {
            return RepositorioVehiculoImplementor.TraerTipoDeUsosDeVehiculo();
        }
    }
}
