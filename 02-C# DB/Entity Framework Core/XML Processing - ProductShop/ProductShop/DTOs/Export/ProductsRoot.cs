using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("products")]
    public class ProductsRoot
    {
        [XmlElement("Product")]
        public SoldProductDto[] SoldProducts { get; set; }
    }
}
