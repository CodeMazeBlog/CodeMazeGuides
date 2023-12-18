using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace WriteXML.Create
{
    public class CreateXMLUsingXmlWriter : ICreateXML
    {
        public string CreateSimpleXML(Person person)
        {
            var sb = new StringBuilder();

            using var xmlWriter = XmlWriter.Create(sb,
                new XmlWriterSettings { Indent = true });

            xmlWriter.WriteStartElement("person");
            xmlWriter.WriteStartElement("name");
            xmlWriter.WriteElementString("firstName", person.FirstName);
            xmlWriter.WriteElementString("lastName", person.LastName);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteElementString("email", person.Email);
            xmlWriter.WriteElementString("age", person.Age.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.Flush();

            return sb.ToString();
        }

        public string CreateSimpleXMLWithAttributes(Person person)
        {
            var sb = new StringBuilder();

            using var xmlWriter = XmlWriter.Create(sb,
                new XmlWriterSettings { Indent = true });

            xmlWriter.WriteStartElement("person");
            xmlWriter.WriteStartElement("name");
            xmlWriter.WriteAttributeString("firstName", person.FirstName);
            xmlWriter.WriteAttributeString("lastName", person.LastName);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteElementString("email", person.Email);
            xmlWriter.WriteElementString("age", person.Age.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.Flush();

            return sb.ToString();
        }

        public string CreateXMLWithNamespace(Person person)
        {
            var sb = new StringBuilder();

            using var xmlWriter = XmlWriter.Create(sb,
                new XmlWriterSettings { Indent = true });

            xmlWriter.WriteStartElement("person");
            xmlWriter.WriteAttributeString("xmlns", "xsi", null, "https://www.code-maze.com/sample-schema");

            xmlWriter.WriteStartElement("name");
            xmlWriter.WriteElementString("firstName", person.FirstName);
            xmlWriter.WriteElementString("lastName", person.LastName);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteElementString("email", person.Email);
            xmlWriter.WriteElementString("age", person.Age.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.Flush();

            return sb.ToString();
        }

        public string CreateXMLWithNamespace2(Person person)
        {
            var sb = new StringBuilder();

            var namespace_p = XNamespace.Get("https://www.code-maze.com/sample-person");
            var namespace_n = XNamespace.Get("https://www.code-maze.com/sample-name");
            var namespace_o = XNamespace.Get("https://www.code-maze.com/sample-other");

            using var xmlWriter = XmlWriter.Create(sb,
                new XmlWriterSettings { Indent = true });

            xmlWriter.WriteStartElement("p", "person", namespace_p.ToString());
            xmlWriter.WriteAttributeString("xmlns", "p", null, namespace_p.ToString());
            xmlWriter.WriteAttributeString("xmlns", "n", null, namespace_n.ToString());
            xmlWriter.WriteAttributeString("xmlns", "o", null, namespace_o.ToString());

            xmlWriter.WriteStartElement("n", "name", namespace_n.ToString());
            xmlWriter.WriteElementString("n", "firstName", namespace_n.ToString(), person.FirstName);
            xmlWriter.WriteElementString("n", "lastName", namespace_n.ToString(), person.LastName);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteElementString("email", namespace_o.ToString(), person.Email);
            xmlWriter.WriteElementString("age", namespace_o.ToString(), person.Age.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.Flush();

            return sb.ToString();
        }

        public string CreateAnArrayOfPeople(Person[] people)
        {
            var sb = new StringBuilder();

            using var xmlWriter = XmlWriter.Create(sb,
                new XmlWriterSettings { Indent = true });

            xmlWriter.WriteStartElement("people");

            foreach (var person in people)
            {
                xmlWriter.WriteStartElement("person");
                xmlWriter.WriteStartElement("name");
                xmlWriter.WriteElementString("firstName", person.FirstName);
                xmlWriter.WriteElementString("lastName", person.LastName);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteElementString("email", person.Email);
                xmlWriter.WriteElementString("age", person.Age.ToString());
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();

            xmlWriter.Flush();

            return sb.ToString();
        }

        public static string CreateWrongXML(Person person)
        {
            var sb = new StringBuilder();

            using var xmlWriter = XmlWriter.Create(sb,
                new XmlWriterSettings { Indent = true });

            xmlWriter.WriteStartElement("person");
            xmlWriter.WriteStartElement("name");
            xmlWriter.WriteElementString("firstName", person.FirstName);
            xmlWriter.WriteElementString("lastName", person.LastName);
            // here we forgot to close the name element

            xmlWriter.WriteElementString("email", person.Email);
            xmlWriter.WriteElementString("age", person.Age.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.Flush();

            return sb.ToString();
        }

    }
}
