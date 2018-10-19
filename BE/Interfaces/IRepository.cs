using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public interface IRepository<T>
    {
        bool Create(T ObjAlta);
        T GetById(Guid id);
        List<T> Retrive();
        bool Delete(T ObjDel);
        bool Update(T ObjUpd);
    }
}
