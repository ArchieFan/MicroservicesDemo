using backend.Models;
using frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace frontend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public Stock[] stocks { get; set; }
        public string ErrorMessage { get; set; }

        public string getpath { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet([FromServices] StockClient client)
        {
			stocks = await client.GetStocksAsync();
            getpath = client.requestpath;
            if (stocks.Count() == 0)
                ErrorMessage = "The Watch list is empty. Try again tomorrow.";
            else
                ErrorMessage = string.Empty;
        }

    }
}