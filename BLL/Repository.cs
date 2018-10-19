using BE;

namespace BLL
{
    using DAL.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Repository<T> : IRepository<T>
    {
        public IDao<T> Dao { get; }

        public Repository(IDao<T> dao)
        {
            this.Dao = dao ?? throw new ArgumentNullException(nameof(dao));
        }
        public bool Create(T entity)
        {
            return this.Dao.Create(entity);
        }

        public T GetById(Guid id)
        {
            return this.Dao.GetById(id);
        }

        public List<T> Retrive()
        {
            throw new NotImplementedException();
        }

        public bool Delete(T ObjDel)
        {
            throw new NotImplementedException();
        }

        public bool Update(T ObjUpd)
        {
            throw new NotImplementedException();
        }
    }
}
