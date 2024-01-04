using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace WriteXML.Create
{
    public class CreateXmlUsingXmlWriter : ICreateXml
    {
        public string CreateSimpleXml(Person person)
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

        public string CreateSimpleXmlWithAttributes(Person person)
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

        public string CreateXmlWithNamespace(Person person)
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

        public string CreateXmlWithThreeNamespaces(Person person)
        {
            var sb = new StringBuilder();

            var namespaceP = XNamespace.Get("https://www.code-maze.com/sample-person");
            var namespaceN = XNamespace.Get("https://www.code-maze.com/sample-name");
            var namespaceO = XNamespace.Get("https://www.code-maze.com/sample-other");

            using var xmlWriter = XmlWriter.Create(sb,
                new XmlWriterSettings { Indent = true });

            xmlWriter.WriteStartElement("p", "person", namespaceP.ToString());
            xmlWriter.WriteAttributeString("xmlns", "p", null, namespaceP.ToString());
            xmlWriter.WriteAttributeString("xmlns", "n", null, namespaceN.ToString());
            xmlWriter.WriteAttributeString("xmlns", "o", null, namespaceO.ToString());

            xmlWriter.WriteStartElement("n", "name", namespaceN.ToString());
            xmlWriter.WriteElementString("n", "firstName", namespaceN.ToString(), person.FirstName);
            xmlWriter.WriteElementString("n", "lastName", namespaceN.ToString(), person.LastName);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteElementString("email", namespaceO.ToString(), person.Email);
            xmlWriter.WriteElementString("age", namespaceO.ToString(), person.Age.ToString());
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

        public static string CreateWrongXml(Person person)
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
