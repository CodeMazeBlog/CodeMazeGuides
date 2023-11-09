using ProtoBuf;

namespace SerializationDemo.Client.Serialization.Protobuf
{
    public class ProtobufSerializer : IByteSerializer
    {
        public T Deserialize<T>(byte[] buffer)
        {
            using (var stream = new MemoryStream(buffer))
            {
                return Serializer.Deserialize<T>(stream);
            }
        }

        public byte[] Serialize(object data)
        {
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, data);
                stream.Flush();

                return stream.ToArray();
            }
        }
    }
}
