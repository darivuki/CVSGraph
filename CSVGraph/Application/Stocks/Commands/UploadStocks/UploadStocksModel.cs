using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Application.Stocks.Commands.UploadStocks
{
    public class UploadStocksModel
    {
        public Stream FileStream { get; }
        public UploadStocksModel(Stream fileStream)
        {
            this.FileStream = fileStream;
        }
    }
}
