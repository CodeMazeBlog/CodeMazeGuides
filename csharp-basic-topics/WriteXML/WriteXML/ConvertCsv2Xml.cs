using System.Xml.Linq;

namespace WriteXML
{
    public class ConvertCsv2Xml(
        IEnumerable<string> csvLines,
        bool hasCaptionLine,
        string mainTag = "rows",
        string rowTag = "row",
        string separator = ",")
    {
        public XDocument Convert()
        {
            if (!csvLines.Any())
                return new XDocument();

            var captions = hasCaptionLine
                ? GetCaptions(csvLines.First())
                : GetCaptionReplacements(csvLines.First());

            return new XDocument(
                new XElement(mainTag,
                csvLines
                    .Skip(hasCaptionLine ? 1 : 0)
                    .Select(line =>
                        new XElement(rowTag,
                            line.Split(separator)
                                .Select((value, index) =>
                                    new XElement(captions[index], value)))))
            );
        }

        public string[] GetCaptionReplacements(string firstLine)
        {
            return firstLine
                .Split(separator)
                .Select((_, index) => $"Field{index}")
                .ToArray();
        }

        public string[] GetCaptions(string firstLine)
        {
            return firstLine
                .Split(separator)
                .Select(value => value.Trim().Replace(" ", "_"))
                .ToArray();
        }
    }
}
