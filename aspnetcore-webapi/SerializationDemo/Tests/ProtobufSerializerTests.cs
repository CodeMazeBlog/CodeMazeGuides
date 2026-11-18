using ProtoBuf;
using SerializationDemo.Client.Serialization.Protobuf;

namespace Tests;

[TestClass]
public class ProtobufSerializerTests
{
    [TestMethod]
    public void ProtobufSerializationFollowedByDeserialization_ReturnsSameObject()
    {
        var expected = new TestClass
        {
            Flag = true,
            Text = "Test String",
            Timestamp = DateTime.UtcNow
        };
        var serializer = new ProtobufSerializer();

        var obj = serializer.Deserialize<TestClass>(serializer.Serialize(expected));

        Assert.IsNotNull(obj);
        Assert.AreEqual(expected.Text, obj.Text);
        Assert.AreEqual(expected.Flag, obj.Flag);
        Assert.AreEqual(expected.Timestamp, obj.Timestamp);
    }

    [ProtoContract]
    private class TestClass
    {
        [ProtoMember(1)]
        public DateTime Timestamp { get; set; }

        [ProtoMember(2)]
        public string Text { get; set; } = string.Empty;

        [ProtoMember(3)]
        public bool Flag { get; set; }
    }
}
