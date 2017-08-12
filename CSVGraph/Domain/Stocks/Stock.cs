using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Stocks
{
    public class Stock : IEntity
    {
        public Guid Id { get; }

        public decimal MarketPrice { get; }

        public DateTime Date { get; }

        public Stock(decimal marketPrice, DateTime dateTime)
        {
            this.Id = Guid.NewGuid();
            this.MarketPrice = marketPrice;
            this.Date = dateTime;
        }
    }
}
