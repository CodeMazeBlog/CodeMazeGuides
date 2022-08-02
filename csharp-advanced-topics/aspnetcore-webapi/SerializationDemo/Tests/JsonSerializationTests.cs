using NUnit.Framework;
using SerializationDemo.Client.Serialization.Json;
using System;

namespace Tests
{
    [TestFixture]
    public class JsonSerializationTests
    {
        [Test]
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

            Assert.AreEqual(expected.Text, obj.Text);
            Assert.AreEqual(expected.Flag, obj.Flag);
            Assert.AreEqual(expected.Timestamp, obj.Timestamp);
        }

        [Test]
        public void JsonByteSerializationFollowedByDeserialization_ReturnsSameObject()
        {
            var expected = new TestClass
            {
                Flag = true,
                Text = "Test String",
                Timestamp = DateTime.UtcNow
            };
            var serializer = new JsonStringSerializer();

            var obj = serializer.Deserialize<TestClass>(serializer.Serialize(expected));

            Assert.AreEqual(expected.Text, obj.Text);
            Assert.AreEqual(expected.Flag, obj.Flag);
            Assert.AreEqual(expected.Timestamp, obj.Timestamp);
        }

        private class TestClass
        {
            public DateTime Timestamp { get; set; }

            public string Text { get; set; }

            public bool Flag { get; set; }
        }
    }   
}