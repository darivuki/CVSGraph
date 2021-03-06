﻿using Application.Stocks.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Stocks.Queries.GetStocksList
{
    public interface IGetStocksListQuery
    {
        StocksDTO Execute(bool? includeMostExpensiveHour);
    }
}
