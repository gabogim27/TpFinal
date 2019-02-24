using BE;
using BLL.Interfaces;

namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ServicioFactura : IServicio<Factura>
    {
        private IRepository<Factura> RepositorioFactura;

        public ServicioFactura(IRepository<Factura> RepositorioFactura)
        {
            this.RepositorioFactura = RepositorioFactura;
        }
        public bool Create(Factura entity)
        {
            return RepositorioFactura.Create(entity);
        }

        public Factura GetById(Guid id)
        {
            return RepositorioFactura.GetById(id);
        }

        public List<Factura> Retrive()
        {
            return RepositorioFactura.Retrive();
        }

        public bool Delete(Factura entity)
        {
            return RepositorioFactura.Delete(entity);
        }

        public bool Update(Factura entity)
        {
            return RepositorioFactura.Update(entity);
        }
    }
}
