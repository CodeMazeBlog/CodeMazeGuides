using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using XMLSerializationInCsharp_v1;

namespace XMLSerializationInCsharpTests
{
    public class XMLSerializationUnitTest_v6
    {
        string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<Patient>
  <ID>232323</ID>
  <FirstName>John</FirstName>
  <LastName>Doe</LastName>
  <Birthday>1990-12-30T00:00:00</Birthday>
  <RoomNo>310</RoomNo>
</Patient>";

        [Test]
        public void WhenSerializingWithXmlWriterSettingsAndEmptyNamespaces_ThenNoNamespacesAndUtf8Declaration()
        {
            var patient = new Patient()
            {
                ID = 232323,
                FirstName = "John",
                LastName = "Doe",
                Birthday = new DateTime(1990, 12, 30),
                RoomNo = 310
            };

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = new UTF8Encoding(false)
            };

            var serializer = new XmlSerializer(typeof(Patient));
            using var stream = new MemoryStream();
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, patient, namespaces);
            }

            var bytes = stream.ToArray();
            var result = Encoding.UTF8.GetString(bytes);

            Assert.That(bytes[0], Is.EqualTo((byte)'<'), "UTF8Encoding(false) writes no byte order mark");
            Assert.That(result, Does.Not.Contain("xmlns:xsi"));
            Assert.That(result, Does.Not.Contain("xmlns:xsd"));
            Assert.That(result.Replace("\r\n", "\n"), Is.EqualTo(xml.Replace("\r\n", "\n")));
        }
    }
}
