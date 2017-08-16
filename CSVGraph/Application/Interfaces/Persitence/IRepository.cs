using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Interfaces.Persitence
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        T Get(Guid id);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);
    }
}
