using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using XmlSerialization.Models;

namespace XmlSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Stream stream = File.Create("group.xml"))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Group));
                xmlSerializer.Serialize(stream, CreateGroup());
            }

            XDocument document = XDocument.Load("group.xml");

            IEnumerable<XElement> firstGroup = document.Root.Elements("People")
                .Where(x => x.Element("FirstName").Value.Equals("Michael"));

            Console.WriteLine("People with firstname: Michael");
            foreach (var item in firstGroup)
            {
                Console.WriteLine(item);
            }

            Console.Write(document.Root.Elements("People"));

            IEnumerable<XElement> secondGroup = document.Root.Elements("People")
                .Where(x => x.Descendants("Title").Any(t =>t.Value.Equals("A criminal Deffence 2")));

            Console.WriteLine("People who read A criminal Deffence 2");
            foreach (var item in secondGroup)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        static Group CreateGroup()
        {
            return new Group()
            {
                People = new[] {CreatePersonTwo(), CreatePersonOne()}
            };
        }

        static Person CreatePersonTwo()
        {
            return new Person
            {
                Id = 1,
                FirstName = "Michael",
                LastName = "Peres",
                ReadBooks = new List<Book>()
                {
                    new Book()
                    {
                        Publisher = "NYT",
                        Title = "Paper Magician"
                    },
                    new Book()
                    {
                        Publisher = "NYT",
                        Title = "A criminal Deffence"
                    }
                }
            };
        }
        static Person CreatePersonOne()
        {
            return new Person
            {
                Id = 1,
                FirstName = "Christopher",
                LastName = "Peres",
                ReadBooks = new List<Book>()
                {
                    new Book()
                    {
                        Publisher = "NYT",
                        Title = "Paper Magician"
                    },
                    new Book()
                    {
                        Publisher = "NYT",
                        Title = "A criminal Deffence 2"
                    }
                }
            };
        }
    }
}
