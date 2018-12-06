using BE;
using DAL.Interfaces;

namespace DAL.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepositorioVehiculo : IRepository<Vehiculo>, IRepositorioVehiculo
    {
        private IDao<Vehiculo> VehiculoDao;
        private IVehiculoDao VehiculoDaoImplementor;

        public RepositorioVehiculo(IDao<Vehiculo> VehiculoDao, IVehiculoDao VehiculoDaoImplementor)
        {
            this.VehiculoDao = VehiculoDao;
            this.VehiculoDaoImplementor = VehiculoDaoImplementor;
        }

        public List<Marca> TraerMarcas()
        {
            return VehiculoDaoImplementor.TraerMarcas();
        }

        public List<Modelo> TraerModelosPorMarca(Guid idMarca)
        {
            return VehiculoDaoImplementor.TraerModelosPorMarca(idMarca);
        }

        public List<TipoUso> TraerTipoDeUsosDeVehiculo()
        {
            return VehiculoDaoImplementor.TraerTipoDeUsosDeVehiculo();
        }

        public bool Create(Vehiculo ObjAlta)
        {
            return VehiculoDao.Create(ObjAlta);
        }

        public Vehiculo GetById(Guid id)
        {
            return VehiculoDao.GetById(id);
        }

        public List<Vehiculo> Retrive()
        {
            return VehiculoDao.Retrive();
        }

        public bool Delete(Vehiculo ObjDel)
        {
            return VehiculoDao.Delete(ObjDel);
        }

        public bool Update(Vehiculo ObjUpd)
        {
            return VehiculoDao.Update(ObjUpd);
        }
    }
}
