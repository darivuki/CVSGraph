using Application.Interfaces.Persitence;
using System;
using System.Collections.Generic;
using System.Text;
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
                         .OrderBy(x => x.Date)
                         .ToList();

            // Append to DTO
            stocksDTO.Stocks = stocks;

            // Calculate additional statistics in memory
            stocksDTO.MostExpensiveHour = (includeMostExpensiveHour.HasValue == false || includeMostExpensiveHour.Value == false) ? null 
                                          : stocks                                                                                       
                                                  .GroupBy(x => x.Date.Hour)
                                                  .Select((x) => new
                                                  {
                                                      Sum = x.Sum(y => y.MarketPrice),
                                                      StocksByHour = x.Select(y => y).ToList(),
                                                  })
                                                  .Aggregate((agg, next) => next.Sum >= agg.Sum ? next : agg)
                                          .       StocksByHour;

            // Append potential stock duplicates in MarketPrice so that we return multiple results with the same value
            stocksDTO.MostExpensiveHour = stocksDTO.Stocks
                .Join(stocksDTO.MostExpensiveHour, f => f.MarketPrice, s => s.MarketPrice, (fir, sec) => fir)
                .GroupBy(x => x.Date)
                .Select(y => y.First())
                .ToList(); ;

            return stocksDTO;
        }
    }
}
