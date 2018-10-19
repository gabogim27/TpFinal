using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDao<T>
    {
        bool Create(T entity);
        T GetById(Guid id);
        List<T> Retrive();
        bool Delete(T entity);
        bool Update(T entity);
    }
}
