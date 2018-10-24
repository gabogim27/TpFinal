namespace BLL.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IServicio<T>
    {
        bool Create(T entity);
        T GetById(Guid id);
        List<T> Retrive();
        bool Delete(T entity);
        bool Update(T entity);
    }
}
