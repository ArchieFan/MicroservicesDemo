using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace WebServiceAutomation.Models
{
    [XmlRoot(ElementName = "Stock")]
    public class XMLStock
    {
        [XmlElement(ElementName = "Ticker")]
        public string? Ticker { get; set; }
        [XmlElement(ElementName = "CompanyName")]
        public string? CompanyName { get; set; }
        [XmlElement(ElementName = "Industry")]
        public string? Industry { get; set; }
        [XmlElement(ElementName = "MarketCap")]
        public string? MarketCap { get; set; }
        [XmlElement(ElementName = "OpenPrice")]
        public string? OpenPrice { get; set; }
        [XmlElement(ElementName = "ClosePrice")]
        public string? ClosePrice { get; set; }
    }

}