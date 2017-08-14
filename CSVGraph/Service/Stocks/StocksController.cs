using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Stocks
{
    [Route("api/[controller]")]
    public class StocksController : Controller
    {
        // GET api/values
        [HttpGet]
        [Route("")]
        public IEnumerable<object> Get()
        {
            var anonArray = new[]
            {
                new { Date = DateTime.Parse("10/01/2017 0:30"), MarketPrice = 50.29000092m },
                new { Date = DateTime.Parse("10/01/2017 1:00"), MarketPrice = 50m },
                new { Date = DateTime.Parse("10/01/2017 1:30"), MarketPrice = 50m },
                new { Date = DateTime.Parse("10/01/2017 2:00"), MarketPrice = 40.88000107m },
                new { Date = DateTime.Parse("10/01/2017 2:30"), MarketPrice = 40.88000107m },
                new { Date = DateTime.Parse("10/01/2017 3:00"), MarketPrice = 37.45999908m },
                new { Date = DateTime.Parse("10/01/2017 3:30"), MarketPrice = 37.45999908m },
                new { Date = DateTime.Parse("10/01/2017 4:00"), MarketPrice = 36.63999939m },
                new { Date = DateTime.Parse("10/01/2017 4:30"), MarketPrice = 36.63999939m },
                new { Date = DateTime.Parse("10/01/2017 5:00"), MarketPrice = 36.63999939m },
                new { Date = DateTime.Parse("10/01/2017 5:30"), MarketPrice = 37.45999908m },
                new { Date = DateTime.Parse("10/01/2017 6:00"), MarketPrice = 37.45999908m },
                new { Date = DateTime.Parse("10/01/2017 6:30"), MarketPrice = 41.54999924m },
                new { Date = DateTime.Parse("10/01/2017 7:00"), MarketPrice = 49.11000061m },
                new { Date = DateTime.Parse("10/01/2017 7:30"), MarketPrice = 50.93999863m },
                new { Date = DateTime.Parse("10/01/2017 8:00"), MarketPrice = 51.68000031m },
                new { Date = DateTime.Parse("10/01/2017 8:30"), MarketPrice = 53.43000031m },
                new { Date = DateTime.Parse("10/01/2017 9:00"), MarketPrice = 53.43000031m },
                new { Date = DateTime.Parse("10/01/2017 9:30"), MarketPrice = 51.68000031m },
                new { Date = DateTime.Parse("10/01/2017 10:00"), MarketPrice = 54.29000092m },
                new { Date = DateTime.Parse("10/01/2017 10:30"), MarketPrice = 54.29000092m },
                new { Date = DateTime.Parse("10/01/2017 11:00"), MarketPrice = 54.29000092m },
                new { Date = DateTime.Parse("10/01/2017 11:30"), MarketPrice = 54.33000183m },
                new { Date = DateTime.Parse("10/01/2017 12:00"), MarketPrice = 54.33000183m },
                new { Date = DateTime.Parse("10/01/2017 12:30"), MarketPrice = 54.33000183m },
                new { Date = DateTime.Parse("10/01/2017 13:00"), MarketPrice = 54.29000092m },
                new { Date = DateTime.Parse("10/01/2017 13:30"), MarketPrice = 53.15000153m },
                new { Date = DateTime.Parse("10/01/2017 14:00"), MarketPrice = 51.88000107m },
                new { Date = DateTime.Parse("10/01/2017 14:30"), MarketPrice = 51.88000107m },
                new { Date = DateTime.Parse("10/01/2017 15:00"), MarketPrice = 51.88000107m },
                new { Date = DateTime.Parse("10/01/2017 15:30"), MarketPrice = 53.15000153m },
                new { Date = DateTime.Parse("10/01/2017 16:00"), MarketPrice = 54.29000092m },
                new { Date = DateTime.Parse("10/01/2017 16:30"), MarketPrice = 54.33000183m },
                new { Date = DateTime.Parse("10/01/2017 17:00"), MarketPrice = 184.2200012m },
                new { Date = DateTime.Parse("10/01/2017 17:30"), MarketPrice = 184.2200012m },
                new { Date = DateTime.Parse("10/01/2017 18:00"), MarketPrice = 184.2200012m },
                new { Date = DateTime.Parse("10/01/2017 18:30"), MarketPrice = 184.2200012m },
                new { Date = DateTime.Parse("10/01/2017 19:00"), MarketPrice = 59.34999847m },
                new { Date = DateTime.Parse("10/01/2017 19:30"), MarketPrice = 59.34999847m },
                new { Date = DateTime.Parse("10/01/2017 20:00"), MarketPrice = 59.34999847m },
                new { Date = DateTime.Parse("10/01/2017 20:30"), MarketPrice = 54.33000183m },
                new { Date = DateTime.Parse("10/01/2017 21:00"), MarketPrice = 54.33000183m },
                new { Date = DateTime.Parse("10/01/2017 21:30"), MarketPrice = 54.29000092m },
                new { Date = DateTime.Parse("10/01/2017 22:00"), MarketPrice = 54.29000092m },
                new { Date = DateTime.Parse("10/01/2017 22:30"), MarketPrice = 51.11999893m },
                new { Date = DateTime.Parse("10/01/2017 23:00"), MarketPrice = 50.29000092m },
                new { Date = DateTime.Parse("10/01/2017 23:30"), MarketPrice = 50.29000092m }
            };


            return anonArray;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}
