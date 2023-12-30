using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("SoldProducts")]
    public class ProductSoldRootDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("products")]
        public ProductsRoot Test { get; set; }
    }
}