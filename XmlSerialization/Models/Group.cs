using System.Xml.Serialization;

namespace XmlSerialization.Models
{
    public class Group
    {
        [XmlIgnore]
        public int Id { get; set; }
        [XmlElement]
        public Person[] People { get; set; }
    }
}