using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Stocks.Queries.GetStocksList
{
    public class StockDTO
    {
        public DateTime Date { get; set; }
        public decimal MarketPrice { get; set; }
    }
}
