using Application.Interfaces.Persitence;
using Application.Stocks.Shared;
using System.Collections.Generic;
using System.Linq;

namespace Application.Stocks.Queries.GetStocksList
{
    public class GetStocksListQuery : IGetStocksListQuery
    {
        private IStockRepository _stockRepository;
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
                         .OrderBy(x => x.Date) // Life is easier when the data is ordered
                         .ToList();

            // Append to DTO
            stocksDTO.Stocks = stocks;


            stocksDTO.MostExpensiveHour = (includeMostExpensiveHour.HasValue == false || includeMostExpensiveHour.Value == false) ? null
                                           : stocks.Zip(stocks.Skip(1), (a, b) => new
                                           {
                                               Sum = a.MarketPrice + b.MarketPrice,
                                               Stocks = new[] { a, b }
                                           })
                                           .Aggregate((agg, next) => next.Sum >= agg.Sum ? next : agg)
                                           .Stocks
                                           .ToList();

            return stocksDTO;
        }
    }
}
