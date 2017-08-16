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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Stock>()
            //            .HasIndex(p => new { p.Date, p.MarketPrice }).IsUnique();
            modelBuilder.Entity<Stock>()
                        .HasKey(x => x.Id);
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
