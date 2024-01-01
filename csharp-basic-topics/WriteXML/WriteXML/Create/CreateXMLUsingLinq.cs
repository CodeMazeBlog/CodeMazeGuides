using System.Xml.Linq;

namespace WriteXML.Create
{
    public class CreateXmlUsingLinq : ICreateXml
    {
        public string CreateSimpleXml(Person person)
        {
            var xmlPerson = new XDocument(
                new XElement("person",
                    new XElement("name",
                        new XElement("firstName", person.FirstName),
                        new XElement("lastName", person.LastName)),
                    new XElement("email", person.Email),
                    new XElement("age", person.Age))
            );

            return xmlPerson.ToString();
        }

        public string CreateSimpleXmlWithAttributes(Person person)
        {
            var xmlPerson = new XDocument(
                new XElement("person",
                    new XElement("name",
                        new XAttribute("firstName", person.FirstName),
                        new XAttribute("lastName", person.LastName)),
                    new XElement("email", person.Email),
                    new XElement("age", person.Age))
            );

            return xmlPerson.ToString();
        }

        public string CreateXmlWithNamespace(Person person)
        {
            var xmlPerson = new XDocument(
                new XElement("person",
                    new XAttribute(XNamespace.Xmlns + "xsi", "https://www.code-maze.com/sample-schema"),
                    new XElement("name",
                        new XElement("firstName", person.FirstName),
                        new XElement("lastName", person.LastName)),
                    new XElement("email", person.Email),
                    new XElement("age", person.Age))
            );

            return xmlPerson.ToString();
        }


        public string CreateXmlWithNamespace2(Person person)
        {
            var namespace_p = XNamespace.Get("https://www.code-maze.com/sample-person");
            var namespace_n = XNamespace.Get("https://www.code-maze.com/sample-name");
            var namespace_o = XNamespace.Get("https://www.code-maze.com/sample-other");

            var xmlPerson = new XDocument(
                new XElement(namespace_p + "person",
                new XAttribute(XNamespace.Xmlns + "p", namespace_p.ToString()),
                new XAttribute(XNamespace.Xmlns + "o", namespace_o.ToString()),
                new XAttribute(XNamespace.Xmlns + "n", namespace_n.ToString()),
                    new XElement(namespace_n + "name",
                        new XElement(namespace_n + "firstName", person.FirstName),
                        new XElement(namespace_n + "lastName", person.LastName)),
                    new XElement(namespace_o + "email", person.Email),
                    new XElement(namespace_o + "age", person.Age))
            );

            return xmlPerson.ToString();
        }

        public string CreateAnArrayOfPeople(Person[] people)
        {
            var xmlPeople = new XDocument(
                new XElement("people",
                    from person in people
                    select new XElement("person",
                        new XElement("name",
                            new XElement("firstName", person.FirstName),
                            new XElement("lastName", person.LastName)),
                        new XElement("email", person.Email),
                        new XElement("age", person.Age)))
            );

            return xmlPeople.ToString();
        }

        public static string CreateSimpleXml_Comments(Person person)
        {
            var xmlPerson = new XDocument(  // Create the XML document
                new XElement("person", // Start of the root element
                    new XElement("name", // Start of the name element (inside the root element)
                        new XElement("firstName", person.FirstName),
                        new XElement("lastName", person.LastName)
                    ), // End of the name element
                    new XElement("email", person.Email),
                    new XElement("age", person.Age)
                ) // End of the root element
            ); // End of the XML document

            return xmlPerson.ToString();
        }

        public static string CreateSimpleXmlWithXmlDeclaration(Person person)
        {
            var xmlPerson = new XDocument(
                new XElement("person",
                    new XElement("name",
                        new XElement("firstName", person.FirstName),
                        new XElement("lastName", person.LastName)),
                    new XElement("email", person.Email),
                    new XElement("age", person.Age))
            );

            var stringWriter = new StringWriter();
            xmlPerson.Save(stringWriter);
            return stringWriter.ToString();
        }

    }
}
