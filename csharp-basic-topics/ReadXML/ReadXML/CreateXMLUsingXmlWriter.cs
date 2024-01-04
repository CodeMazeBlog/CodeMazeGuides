using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ReadXml.Read
{
    public class CreateXmlUsingXmlWriter
    {
        public static string CreateSimpleXml(Person person)
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

        public static string CreateAnArrayOfPeople(Person[] people)
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
