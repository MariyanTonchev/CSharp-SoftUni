namespace ProductShop.App.Dto.Export
{
    using ProductShop.DTOs.Export;
    using System.Xml.Serialization;

    [XmlType("User")]
    public class SellerUserDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public SoldProductDto[] Products { get; set; }
    }
}