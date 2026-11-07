using System.Xml;
using System.Xml.Linq;

namespace ReadXml.Read
{
    public static class ReadXmlFromFile
    {
        public static readonly string FilePath =
            Path.Combine(AppContext.BaseDirectory, "people.xml");

        public static IEnumerable<string> ReadEmailsUsingXDocument(string path)
        {
            var xmlDoc = XDocument.Load(path);

            return xmlDoc.Root!
                .Elements("person")
                .Select(person => person.Element("email")!.Value)
                .ToList();
        }

        public static IEnumerable<string> ReadEmailsUsingXmlReader(string path)
        {
            using var reader = XmlReader.Create(path);

            List<string> result = [];
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "email")
                    result.Add(reader.ReadElementContentAsString());
            }

            return result;
        }
    }
}
