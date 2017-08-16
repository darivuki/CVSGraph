using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Stocks.Shared.Handlers
{
    public interface IAnalyticsAggregator<T>
    {
        T MovingAverage(T stocks);
    }
}
