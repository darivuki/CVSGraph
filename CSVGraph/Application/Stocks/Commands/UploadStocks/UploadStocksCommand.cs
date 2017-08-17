using Application.Interfaces.Persitence;
using Common.CsvHelpers;
using Domain.Stocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Application.Stocks.Commands.UploadStocks
{
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
            var stocks = CsvReader.ReadCsv(model.FileStream)
                         .Skip(1)
                         .Select(x => new Stock(DateTime.Parse(x[0]), decimal.Parse(x[1].Replace('.', ','))))
                         .Distinct(new StockEqualityComparer()) // Filter out duplicates
                         .ToList();

            _stockRepository.AddRange(stocks);

            _unitOfWork.Save();
        }
    }
}
