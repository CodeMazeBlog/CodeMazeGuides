using System.Text;

namespace SerializationDemo.Client.Serialization.Xml
{
    public class XmlSerializer : IStringSerializer
    {
        public T? Deserialize<T>(string text)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using var reader = new StringReader(text);

            return (T?)serializer.Deserialize(reader);
        }

        public string Serialize(object data)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(data.GetType());

            using var writer = new Utf8StringWriter();
            serializer.Serialize(writer, data);

            return writer.ToString();
        }
    }

    internal class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
