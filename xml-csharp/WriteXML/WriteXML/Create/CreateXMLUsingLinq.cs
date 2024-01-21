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


        public string CreateXmlWithThreeNamespaces(Person person)
        {
            var namespaceP = XNamespace.Get("https://www.code-maze.com/sample-person");
            var namespaceN = XNamespace.Get("https://www.code-maze.com/sample-name");
            var namespaceO = XNamespace.Get("https://www.code-maze.com/sample-other");

            var xmlPerson = new XDocument(
                new XElement(namespaceP + "person",
                new XAttribute(XNamespace.Xmlns + "p", namespaceP.ToString()),
                new XAttribute(XNamespace.Xmlns + "o", namespaceO.ToString()),
                new XAttribute(XNamespace.Xmlns + "n", namespaceN.ToString()),
                    new XElement(namespaceN + "name",
                        new XElement(namespaceN + "firstName", person.FirstName),
                        new XElement(namespaceN + "lastName", person.LastName)),
                    new XElement(namespaceO + "email", person.Email),
                    new XElement(namespaceO + "age", person.Age))
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
