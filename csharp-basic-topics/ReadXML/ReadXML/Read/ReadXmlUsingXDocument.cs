using System.Xml.Linq;
using System.Xml.XPath;

namespace ReadXML.Read
{
    public static class ReadXmlUsingXDocument
    {
        public static XDocument ReadXmlAndCatchErrors(string xml)
        {
            try
            {
                return XDocument.Parse(xml);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong:");
                Console.WriteLine(ex);
            }

            return new XDocument();
        }

        public static string TestValidXml()
        {
            var xmlDoc = ReadXmlAndCatchErrors(CreateXMLUsingXmlWriter.CreateSimpleXML(People.GetOne()));
            return xmlDoc.ToString();
        }

        public static string TestInvalidXml()
        {
            var xmlDoc = ReadXmlAndCatchErrors(CreateXMLUsingXmlWriter.CreateWrongXML(People.GetOne()));
            return xmlDoc.ToString();
        }

        public static string TestReadWithElementCollection()
        {
            var xmlDoc = ReadXmlAndCatchErrors(CreateXMLUsingXmlWriter.CreateSimpleXML(People.GetOne()));
            var name = xmlDoc.Root!.Element("name")!.Element("firstName")!.Value;
            var age = xmlDoc.Root!.Element("age")!.Value;
            return $"Name: {name}, Age: {age}";
        }

        public static string TestReadUsingXPath()
        {
            var xmlDoc = ReadXmlAndCatchErrors(CreateXMLUsingXmlWriter.CreateSimpleXML(People.GetOne()));

            var name = xmlDoc.XPathSelectElement("/person/name/firstName")!.Value;
            var age = xmlDoc.XPathSelectElement("/person/age")!.Value;
            return $"Name: {name}, Age: {age}";
        }
    }
}
