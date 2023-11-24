using System.Text;

namespace SerializationDemo.Client.Serialization.Xml
{
    public class XmlSerializer : IStringSerializer
    {
        public T Deserialize<T>(string text)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (var stream = new StringReader(text))
            {
                return (T)serializer.Deserialize(stream);
            }
        }

        public string Serialize(object data)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(data.GetType());

            using (var stream = new Utf8StringWriter())
            {
                serializer.Serialize(stream, data);

                return stream.ToString();
            }
        }
    }

    internal class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
