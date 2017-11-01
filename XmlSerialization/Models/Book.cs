using System.Xml.Serialization;

namespace XmlSerialization.Models
{
    public class Book
    {
        [XmlIgnore]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
    }
}