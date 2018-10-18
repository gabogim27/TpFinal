namespace BE
{
    using System;
    using System.Collections.Generic;
    public interface ICRUD<T>
    {
        bool Create(T ObjAlta);
        T GetById(Guid id);
        List<T> Retrive();
        bool Delete(T ObjDel);
        bool Update(T ObjUpd);
    }
}
