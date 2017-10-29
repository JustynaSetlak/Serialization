using System.Xml.Serialization;

namespace XmlSerialization
{
    public class Address
    {
        [XmlIgnore]
        public int Id { get; set; }
        [XmlAttribute("NazwaUlicy")]
        public string StreetName { get; set; }
        [XmlAttribute("NumerDomu")]
        public int HouseNumber { get; set; }
        [XmlAttribute("Miasto")]
        public string City { get; set; }
    }
}