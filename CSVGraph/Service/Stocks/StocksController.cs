using Application.Stocks.Commands.UploadStocks;
using Application.Stocks.Queries.GetStocksList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Stocks
{
    [Route("api/[controller]")]
    public class StocksController : Controller
    {
        private readonly IGetStocksListQuery _query;
        private readonly IUploadStocksCommand _command;

        public StocksController(IGetStocksListQuery query, IUploadStocksCommand command)
        {
            this._command = command;
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

        [HttpPost]
        [Route("upload/{file}")]
        public IActionResult Post(IFormFile file)
        {
            _command.Execute(new UploadStocksModel(file.OpenReadStream()));

            return Ok();
        }
    }
}
