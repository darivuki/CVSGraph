using Application.Interfaces.Persitence;
using Domain.Stocks;
using Persistance.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Stocks
{
    public class StockRepository
        : Repository<Stock>,
        IStockRepository
    {
        public StockRepository(IDatabaseContext database)
            : base(database) { }
    }
}
