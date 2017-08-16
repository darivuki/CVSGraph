using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Common.Extensions;

namespace Application.Stocks.Shared.Handlers
{
    public class StocksAnalytics : IAnalyticsAggregator<IEnumerable<StockDTO>>
    {
        /// <summary>
        /// Return a list of Stocks indicating the most expensive hour 
        /// by calculating the average Market Price for each group
        /// </summary>
        /// <returns>list of stocks</returns>
        public IEnumerable<StockDTO> MovingAverage(IEnumerable<StockDTO> stocks)
        {
            if (stocks.Count() == 0)
            {
                return new StockDTO[] { };
            }
            return stocks 
                         .ZipThree(stocks.Skip(1), stocks.Skip(2), (a, b, c) => new
                         {
                             Stocks = new[] { a, c },
                             Sum = a.MarketPrice + b.MarketPrice,
                             MovingAverage = a.Date.Minute == 0 ? // This is to avoid 00:30, 01:00, 01:30 types o records into the average equation
                                             new[] { a.MarketPrice, b.MarketPrice, c.MarketPrice }.Average()
                                             : 0
                         })
                         .Aggregate((agg, next) => next.MovingAverage >= agg.MovingAverage ? next : agg)
                         .Stocks;
        }
    }
}
