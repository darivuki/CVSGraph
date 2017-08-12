using Domain.Stocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Persitence
{
    public interface IStockRepository : IRepository<Stock>
    {
    }
}
