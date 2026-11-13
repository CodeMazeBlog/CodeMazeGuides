using SerializationDemo.Client.Serialization.Xml;

namespace Tests;

[TestClass]
public class XmlSerializerTests
{
    [TestMethod]
    public void XmlSerializationFollowedByDeserialization_ReturnsSameObject()
    {
        var expected = new TestClass
        {
            Flag = true,
            Text = "Test String",
            Timestamp = DateTime.UtcNow
        };
        var serializer = new XmlSerializer();

        var obj = serializer.Deserialize<TestClass>(serializer.Serialize(expected));

        Assert.IsNotNull(obj);
        Assert.AreEqual(expected.Text, obj.Text);
        Assert.AreEqual(expected.Flag, obj.Flag);
        Assert.AreEqual(expected.Timestamp, obj.Timestamp);
    }

    public class TestClass
    {
        public DateTime Timestamp { get; set; }

        public string Text { get; set; } = string.Empty;

        public bool Flag { get; set; }
    }
}
