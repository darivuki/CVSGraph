using System.Collections.Generic;

namespace Application.Stocks.Queries.GetStocksList
{
    public class StocksDTO
    {
        public List<StockDTO> Stocks { get; set; }
        public List<StockDTO> MostExpensiveHour { get; set; }
    }
}
