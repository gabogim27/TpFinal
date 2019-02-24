using BE;
using DAL.Interfaces;

namespace DAL.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepositorioFactura : IRepository<Factura>
    {
        private IDao<Factura> FacturaDao;

        public RepositorioFactura(IDao<Factura> FacturaDao)
        {
            this.FacturaDao = FacturaDao;
        }

        public bool Create(Factura ObjAlta)
        {
            return FacturaDao.Create(ObjAlta);
        }

        public Factura GetById(Guid id)
        {
            return FacturaDao.GetById(id);
        }

        public List<Factura> Retrive()
        {
            return FacturaDao.Retrive();
        }

        public bool Delete(Factura ObjDel)
        {
            return FacturaDao.Delete(ObjDel);
        }

        public bool Update(Factura ObjUpd)
        {
            return FacturaDao.Update(ObjUpd);
        }
    }
}
