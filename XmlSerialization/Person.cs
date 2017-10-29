using System;
using System.Xml.Serialization;

namespace XmlSerialization
{
    public class Person
    {
        [XmlIgnore]
        public int Id { get; set; }
        [XmlElement("Imie")]
        public string FirstName { get; set; }
        [XmlElement("Nazwisko")]
        public string LastName { get; set; }
        [XmlElement("DataUrodzin")]
        public DateTime DateOfBirth { get; set; }
        [XmlElement("Adres")]
        public Address Address { get; set; }
    }
}