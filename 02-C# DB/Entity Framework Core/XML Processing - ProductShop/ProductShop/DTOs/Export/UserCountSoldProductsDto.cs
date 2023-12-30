using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("users")]
    public class UserCountSoldProductsDto
    {
        [XmlElement("count")]
        public int count {  get; set; }

        [XmlElement("users")]
        public UsersRoot users { get; set; }
    }
}
