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

        public List<StockModel> Execute()
        {
            var stocks = _stockRepository
                         .GetAll()
                         .Select(stock => new StockModel()
                         {
                             Id = stock.Id,
                             Date = stock.Date,
                             MarketPrice = stock.MarketPrice
                         });

            return stocks.ToList();
        }
    }
}
