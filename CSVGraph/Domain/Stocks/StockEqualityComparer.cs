using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Stocks
{
    public class StockEqualityComparer : IEqualityComparer<Stock>
    {
        public bool Equals(Stock b1, Stock b2)
        {
            if (b2 == null && b1 == null)
                return true;
            else if (b1 == null | b2 == null)
                return false;
            else if (b1.Date == b2.Date && b1.MarketPrice == b2.MarketPrice)
                return true;
            else
                return false;
        }

        public int GetHashCode(Stock obj)
        {
            int date = obj.Date.GetHashCode();
            int price = obj.MarketPrice.GetHashCode();

            return date ^ price;
        }
    }
}
