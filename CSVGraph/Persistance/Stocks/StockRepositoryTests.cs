using Moq;
using Persistance.Shared;
using Xunit;

namespace Persistance.Stocks
{
    public class StockRepositoryTests
    {
        public StockRepositoryTests()
        {
            // Setup

        }
        [Fact]
        public void TestConstructorShouldCreateRepository()
        {
            var context = new Mock<IDatabaseContext>();
            var repository = new StockRepository(context.Object);
            Assert.NotNull(repository);
        }
    }
}
