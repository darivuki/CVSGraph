﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Stocks;
using Microsoft.EntityFrameworkCore;
using Domain.Common;

namespace Persistance.Shared
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Stock> Stocks { get; set; }

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
