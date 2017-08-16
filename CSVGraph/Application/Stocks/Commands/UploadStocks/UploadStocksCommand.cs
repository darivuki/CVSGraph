using Application.Interfaces.Persitence;
using Domain.Stocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Application.Stocks.Commands.UploadStocks
{
    class StockEqualityComparer : IEqualityComparer<Stock>
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


    public class UploadStocksCommand : IUploadStocksCommand
    {
        private readonly IStockRepository _stockRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UploadStocksCommand(IStockRepository stockRepository, IUnitOfWork unitOfWork)
        {
            this._stockRepository = stockRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Execute(UploadStocksModel model)
        {
            var stocks = ReadCsv(model.FileStream)
                         .Skip(1)
                         .Select(x => new Stock(DateTime.Parse(x[0]), decimal.Parse(x[1].Replace('.', ','))))
                         .Distinct(new StockEqualityComparer())
                         .ToList();

            _stockRepository.AddRange(stocks);

            _unitOfWork.Save();
        }

        private IEnumerable<string[]> ReadCsv(Stream stream)
        {
            char[] separator = new[] { ',' };
            string currentLine;

            using (var reader = new StreamReader(stream, Encoding.UTF8, true, 1024))
            {
                while ((currentLine = reader.ReadLine()) != null)
                {
                    yield return currentLine.Split(separator, StringSplitOptions.None);
                }
            }
        }
    }
}
