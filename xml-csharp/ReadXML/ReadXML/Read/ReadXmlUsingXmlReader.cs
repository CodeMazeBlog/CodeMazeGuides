using System.Xml;

namespace ReadXml.Read
{
    public static class ReadXmlUsingXmlReader
    {
        public static IEnumerable<string> ReadXml(string xml)
        {
            using var reader = XmlReader.Create(new StringReader(xml));

            List<string> result = [];
            while (reader.Read())
            {
                result.Add($"> {reader.NodeType} | {reader.Name} | {reader.Value}");
            }

            return result;
        }

        public static IEnumerable<string> ReadXmlWithoutWhiteSpace(string xml)
        {
            using var reader = XmlReader.Create(new StringReader(xml));

            List<string> result = [];
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Whitespace)
                    continue;

                result.Add($"> {reader.NodeType} | {reader.Name} | {reader.Value}");
            }

            return result;
        }

        public static IEnumerable<string> ReadNamesAndSurnames(string xml)
        {
            var settings = new XmlReaderSettings
            {
                IgnoreWhitespace = true
            };

            using var reader = XmlReader.Create(new StringReader(xml), settings);

            List<string> result = [];
            var personData = new PersonData();
            var numberOfPersons = 0;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "person")
                        personData.Init();

                    if (reader.Name == "firstName")
                        personData.FirstName = reader.ReadElementContentAsString();

                    if (reader.Name == "lastName")
                        personData.LastName = reader.ReadElementContentAsString();
                }

                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    if (reader.Name == "person")
                        result.Add($"#{++numberOfPersons,3} | " +
                            $"{personData.FirstName,-15} | {personData.LastName,-15}");
                }
            }

            return result;
        }

        private class PersonData
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public void Init() => FirstName = LastName = "";
        }
    }
}
