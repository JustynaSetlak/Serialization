using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace XmlSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = CreatePerson();

            using (Stream stream = File.Create("person.xml"))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
                xmlSerializer.Serialize(stream,person);
            }

            Person personFromFile;
            using (Stream stream = File.OpenRead("person.xml"))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
                personFromFile = (Person)xmlSerializer.Deserialize(stream);
            }
            Console.WriteLine(personFromFile.FirstName + " " + personFromFile.LastName);
            Console.ReadKey();
        }

        static Person CreatePerson()
        {
            return new Person
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                DateOfBirth = new DateTime(1993, 02, 01),
                Address = new Address
                {
                    Id = 1,
                    City = "Wrocław",
                    HouseNumber = 10,
                    StreetName = "Polaka"
                }
            };
        }
    }
}
