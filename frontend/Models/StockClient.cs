using backend.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace frontend.Models
{
    public class StockClient
    {
        private readonly HttpClient _client;

        public string requestpath { get; set; }

        public StockClient(HttpClient client)
        {
            _client = client;
        }

        private readonly JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public async Task<Stock[]> GetStocksAsync()
        {
            requestpath = _client.BaseAddress.ToString();
            try
            {
                var responseMessage = await _client.GetAsync("/api/Stocks");

                if (responseMessage != null)
                {
                    var stream = await responseMessage.Content.ReadAsStreamAsync();
                    return await JsonSerializer.DeserializeAsync<Stock[]>(stream, options);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
            return new Stock[] { };

        }
    }
}
