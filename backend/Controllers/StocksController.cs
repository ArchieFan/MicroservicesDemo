using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private static readonly Stock[] StockList = new[]
        {
            new Stock { Ticker = "NASDAQ: TSLA", CompanyName= "Tesla Inc", Industry="automotive", MarketCap=868.47M , OpenPrice=272.58M , ClosePrice =277.16M },
            new Stock { Ticker = "NASDAQ: AAPL", CompanyName= "Apple Inc", Industry="technology", MarketCap=2540M , OpenPrice=156.64M , ClosePrice =157.96M },
            new Stock { Ticker = "NASDAQ: GOOGL", CompanyName= "Alphabet Inc Class A", Industry="technology", MarketCap=1440M , OpenPrice=108.28M , ClosePrice =109.74M },
            new Stock { Ticker = "NASDAQ: MSFT", CompanyName= "Microsoft Corporation", Industry="technology", MarketCap=1940M , OpenPrice=258.87M , ClosePrice =260.40M }
        };

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Task.FromResult(StockList);
            return Ok(result);
        }
    }
}
