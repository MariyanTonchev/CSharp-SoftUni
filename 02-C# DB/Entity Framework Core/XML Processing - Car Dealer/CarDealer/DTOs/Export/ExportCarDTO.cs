using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("car")]
    public class ExportCarDTO
    {
        [XmlElement("make")]
        public string make { get; set; }

        [XmlElement("model")]
        public string model { get; set; }

        [XmlElement("traveled-distance")]
        public long travelledDistance { get; set; }
    }
}
