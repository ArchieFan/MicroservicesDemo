using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebServiceAutomation.Models
{
    [XmlRoot(ElementName = "ArrayOfStock")]
    public class XMLArrayOfStock
    {
        [XmlElement(ElementName = "Stock")]
        public List<XMLStock>? XMLStock { get; set; }

    }
}
