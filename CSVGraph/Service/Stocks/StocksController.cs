using Application.Stocks.Queries.GetStocksList;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Stocks
{
    [Route("api/[controller]")]
    public class StocksController : Controller
    {
        private readonly IGetStocksListQuery _query;

        public StocksController(IGetStocksListQuery query)
        {
            this._query = query;
        }

        // GET api/values
        [HttpGet]
        [Route("")]
        public IActionResult Get(bool? includeMostExpensiveHour = null)
        {
            var result = _query.Execute(includeMostExpensiveHour);

            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}
