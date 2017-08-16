using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Stocks.Shared
{
    public class StocksDTO
    {
        public List<StockDTO> Stocks { get; set; } = new List<StockDTO>();
        public List<StockDTO> MostExpensiveHour { get; set; } = new List<StockDTO>();
    }
}
