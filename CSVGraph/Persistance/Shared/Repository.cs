using Application.Interfaces.Persitence;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistance.Shared
{
    public class Repository<T>
        : IRepository<T>
        where T : class, IEntity

    {
        private readonly IDatabaseContext _database;

        public Repository(IDatabaseContext database)
        {
            _database = database;
        }

        public IQueryable<T> GetAll()
        {
            return _database.Set<T>();
        }

        public T Get(Guid id)
        {
            return _database.Set<T>()
                .SingleOrDefault(p => p.Id == id);
        }

        public void Add(T entity)
        {
            _database.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _database.Set<T>().Remove(entity);
        }
    }
}
