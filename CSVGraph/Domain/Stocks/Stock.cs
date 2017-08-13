using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Stocks
{
    public class Stock : IEntity
    {
        [Key]
        public Guid Id { get; private set; }

        public decimal MarketPrice { get; private set; }

        public DateTime Date { get; private set; }

        public Stock(decimal marketPrice, DateTime dateTime)
        {
            this.Id = Guid.NewGuid();
            this.MarketPrice = marketPrice;
            this.Date = dateTime;
        }
    }
}
