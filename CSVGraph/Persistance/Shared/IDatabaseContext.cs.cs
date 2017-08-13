using Domain.Common;
using Domain.Stocks;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Shared
{
    public interface IDatabaseContext
    {
        DbSet<Stock> Stocks { get; set; }

        DbSet<T> Set<T>() where T : class, IEntity;
        bool EnsureDatabaseCreated();
        void Save();
    }
}
