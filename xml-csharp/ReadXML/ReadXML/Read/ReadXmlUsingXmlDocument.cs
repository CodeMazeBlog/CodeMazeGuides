using System.Xml;

namespace ReadXml.Read
{
    public static class ReadXmlUsingXmlDocument
    {
        public static IEnumerable<string> ReadEmails(string path)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            return xmlDoc.GetElementsByTagName("email")
                .Cast<XmlNode>()
                .Select(node => node.InnerText)
                .ToList();
        }
    }
}
