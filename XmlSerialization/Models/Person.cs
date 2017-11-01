using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlSerialization.Models
{
    public class Person
    {
        [XmlIgnore]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [XmlArray]
        public List<Book> ReadBooks { get; set; }
    }
}