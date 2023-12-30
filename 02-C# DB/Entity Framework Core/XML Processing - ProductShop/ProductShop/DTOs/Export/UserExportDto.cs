using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{

    [XmlType("User")]
    public class UserExportDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public string Age { get; set; }

        [XmlElement("SoldProducts")]
        public ProductSoldRootDto SoldProducts { get; set; }
    }
}