using SerializationDemo.Client.Serialization.Json;

namespace Tests;

[TestClass]
public class JsonSerializationTests
{
    [TestMethod]
    public void JsonStringSerializationFollowedByDeserialization_ReturnsSameObject()
    {
        var expected = new TestClass
        {
            Flag = true,
            Text = "Test String",
            Timestamp = DateTime.UtcNow
        };
        var serializer = new JsonStringSerializer();

        var obj = serializer.Deserialize<TestClass>(serializer.Serialize(expected));

        Assert.IsNotNull(obj);
        Assert.AreEqual(expected.Text, obj.Text);
        Assert.AreEqual(expected.Flag, obj.Flag);
        Assert.AreEqual(expected.Timestamp, obj.Timestamp);
    }

    [TestMethod]
    public void JsonByteSerializationFollowedByDeserialization_ReturnsSameObject()
    {
        var expected = new TestClass
        {
            Flag = true,
            Text = "Test String",
            Timestamp = DateTime.UtcNow
        };
        var serializer = new JsonByteSerializer();

        var obj = serializer.Deserialize<TestClass>(serializer.Serialize(expected));

        Assert.IsNotNull(obj);
        Assert.AreEqual(expected.Text, obj.Text);
        Assert.AreEqual(expected.Flag, obj.Flag);
        Assert.AreEqual(expected.Timestamp, obj.Timestamp);
    }

    private class TestClass
    {
        public DateTime Timestamp { get; set; }

        public string Text { get; set; } = string.Empty;

        public bool Flag { get; set; }
    }
}
