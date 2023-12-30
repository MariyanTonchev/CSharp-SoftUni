using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{

    [XmlType("Products")]
    public class ProductSoldDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}