using Application.Interfaces.Persitence;
using Application.Stocks.Shared;
using Application.Stocks.Shared.Handlers;
using Common.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Application.Stocks.Queries.GetStocksList
{
    public class GetStocksListQuery : IGetStocksListQuery
    {
        private IStockRepository _stockRepository;
        private IAnalyticsAggregator<IEnumerable<StockDTO>> AnalyticsAggregator { get; set; } = new StocksAnalytics();
        public GetStocksListQuery(IStockRepository stockRepository)
        {
            this._stockRepository = stockRepository;
        }

        public StocksDTO Execute(bool? includeMostExpensiveHour)
        {
            var stocksDTO = new StocksDTO();

            // Get All data
            var stocks = _stockRepository
                         .GetAll()
                         .Select(stock => new StockDTO()
                         {
                             Date = stock.Date,
                             MarketPrice = stock.MarketPrice
                         })
                         .OrderBy(x => x.Date) // Life is easier when data is sorted
                         .ToList(); // Load into memory

            // Append to DTO
            stocksDTO.Stocks = stocks;

            // Not the most efficient way...
            stocksDTO.MostExpensiveHour = (includeMostExpensiveHour.HasValue == false || includeMostExpensiveHour.Value == false) ? null
                                           : AnalyticsAggregator.MovingAverage(stocks)
                                           .ToList();

            stocksDTO.LowestStock = stocks.FirstOrDefault(x => x.MarketPrice == stocks.Min(y => y.MarketPrice));
            stocksDTO.HighestStock = stocks.FirstOrDefault(x => x.MarketPrice == stocks.Max(y => y.MarketPrice));

            return stocksDTO;
        }
    }
}
