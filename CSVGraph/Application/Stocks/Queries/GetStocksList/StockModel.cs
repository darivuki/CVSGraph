using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Stocks.Queries.GetStocksList
{
    public class StockModel
    {
        public Guid Id { get; set; }
        public decimal MarketPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
