namespace backend.Models
{
    public class Stock
    {
        public string Ticker { get; set; }
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public decimal MarketCap { get; set; }
        public decimal OpenPrice { get; set; }
        public decimal ClosePrice { get; set; }
    }
}
