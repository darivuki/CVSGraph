using System;
using System.Collections.Generic;
using System.Text;
using Domain.Stocks;
using Microsoft.EntityFrameworkCore;
using Domain.Common;

namespace Persistance.Shared
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Stock> Stocks { get; set; }

        public void EnsureDatabaseCreated()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

            var stocks = new List<Stock>
            {
                new Stock(DateTime.Parse("10/01/2017 0:30"), 50.29000092m),
                new Stock(DateTime.Parse("10/01/2017 1:00"), 50m),
                new Stock(DateTime.Parse("10/01/2017 1:30"), 50m),
                new Stock(DateTime.Parse("10/01/2017 2:00"), 40.88000107m),
                new Stock(DateTime.Parse("10/01/2017 2:30"), 40.88000107m),
                new Stock(DateTime.Parse("10/01/2017 3:00"), 37.45999908m),
                new Stock(DateTime.Parse("10/01/2017 3:30"), 37.45999908m),
                new Stock(DateTime.Parse("10/01/2017 4:00"), 36.63999939m),
                new Stock(DateTime.Parse("10/01/2017 4:30"), 36.63999939m),
                new Stock(DateTime.Parse("10/01/2017 5:00"), 36.63999939m),
                new Stock(DateTime.Parse("10/01/2017 5:30"), 37.45999908m),
                new Stock(DateTime.Parse("10/01/2017 6:00"), 37.45999908m),
                new Stock(DateTime.Parse("10/01/2017 6:30"), 41.54999924m),
                new Stock(DateTime.Parse("10/01/2017 7:00"), 49.11000061m),
                new Stock(DateTime.Parse("10/01/2017 7:30"), 50.93999863m),
                new Stock(DateTime.Parse("10/01/2017 8:00"), 51.68000031m),
                new Stock(DateTime.Parse("10/01/2017 8:30"), 53.43000031m),
                new Stock(DateTime.Parse("10/01/2017 9:00"), 53.43000031m),
                new Stock(DateTime.Parse("10/01/2017 9:30"), 51.68000031m),
                new Stock(DateTime.Parse("10/01/2017 10:00"), 54.29000092m),
                new Stock(DateTime.Parse("10/01/2017 10:30"), 54.29000092m),
                new Stock(DateTime.Parse("10/01/2017 11:00"), 54.29000092m),
                new Stock(DateTime.Parse("10/01/2017 11:30"), 54.33000183m),
                new Stock(DateTime.Parse("10/01/2017 12:00"), 54.33000183m),
                new Stock(DateTime.Parse("10/01/2017 12:30"), 54.33000183m),
                new Stock(DateTime.Parse("10/01/2017 13:00"), 54.29000092m),
                new Stock(DateTime.Parse("10/01/2017 13:30"), 53.15000153m),
                new Stock(DateTime.Parse("10/01/2017 14:00"), 51.88000107m),
                new Stock(DateTime.Parse("10/01/2017 14:30"), 51.88000107m),
                new Stock(DateTime.Parse("10/01/2017 15:00"), 51.88000107m),
                new Stock(DateTime.Parse("10/01/2017 15:30"), 53.15000153m),
                new Stock(DateTime.Parse("10/01/2017 16:00"), 54.29000092m),
                new Stock(DateTime.Parse("10/01/2017 16:30"), 54.33000183m),
                new Stock(DateTime.Parse("10/01/2017 17:00"), 184.2200012m),
                new Stock(DateTime.Parse("10/01/2017 17:30"), 184.2200012m),
                new Stock(DateTime.Parse("10/01/2017 18:00"), 184.2200012m),
                new Stock(DateTime.Parse("10/01/2017 18:30"), 184.2200012m),
                new Stock(DateTime.Parse("10/01/2017 19:00"), 59.34999847m),
                new Stock(DateTime.Parse("10/01/2017 19:30"), 59.34999847m),
                new Stock(DateTime.Parse("10/01/2017 20:00"), 59.34999847m),
                new Stock(DateTime.Parse("10/01/2017 20:30"), 54.33000183m),
                new Stock(DateTime.Parse("10/01/2017 21:00"), 54.33000183m),
                new Stock(DateTime.Parse("10/01/2017 21:30"), 54.29000092m),
                new Stock(DateTime.Parse("10/01/2017 22:00"), 54.29000092m),
                new Stock(DateTime.Parse("10/01/2017 22:30"), 51.11999893m),
                new Stock(DateTime.Parse("10/01/2017 23:00"), 50.29000092m),
                new Stock(DateTime.Parse("10/01/2017 23:30"), 50.29000092m)
            };

            foreach (var stock in stocks)
            {
                this.Add(stock);
            }

            this.SaveChanges();
        }

        public void Save()
        {
            this.SaveChanges();
        }

        public new DbSet<T> Set<T>() where T : class, IEntity
        {
            return base.Set<T>();
        }
    }
}
