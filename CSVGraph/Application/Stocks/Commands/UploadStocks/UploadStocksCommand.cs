using CsvHelper;
using Domain.Stocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Application.Stocks.Commands.UploadStocks
{
    public class UploadStocksCommand : IUploadStocksCommand
    {
        public void Execute(UploadStocksModel model)
        {
            TextReader tr = new StreamReader(model.FileStream);

            var csv = new CsvReader(tr);
            // *Avoiding error handling for simplicity
            var stocks = csv.GetRecords<Stock>();


        }
    }
}
