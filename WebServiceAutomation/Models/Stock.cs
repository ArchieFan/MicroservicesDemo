using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceAutomation.Models
{
    public class Stock
    {
        public string? ticker { get; set; }
        public string? companyName { get; set; }
        public string? industry { get; set; }
        public float marketCap { get; set; }
        public float openPrice { get; set; }
        public float closePrice { get; set; }
    }

}
