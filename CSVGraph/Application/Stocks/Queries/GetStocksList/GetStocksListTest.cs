using Application.Interfaces.Persitence;
using Domain.Stocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Application.Stocks.Queries.GetStocksList
{
    public class GetStocksListTest
    {
        private GetStocksListQuery _query;
        private IQueryable<Stock> _stocks;
        private Mock<IStockRepository> _salesRepositoryMock;

        public GetStocksListTest()
        {
            // Setup
            _stocks = new List<Stock> { new Stock(50.123m, DateTime.Now) }.AsQueryable();

            _salesRepositoryMock = new Mock<IStockRepository>();
            _salesRepositoryMock.Setup(x => x.GetAll())
                .Returns(_stocks);

            _query = new GetStocksListQuery(_salesRepositoryMock.Object);
        }

        [Fact]
        public void TestExecuteShouldReturnListOfStocks()
        {
            // Act
            var results = _query.Execute();

            // Assert
            Assert.NotNull(results);
            Assert.Contains(results, x => x.MarketPrice == 50.123m);
        }
    }
}
