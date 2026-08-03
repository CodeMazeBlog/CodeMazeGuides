namespace SerializationDemo.Client.Serialization
{
    internal interface IByteSerializer
    {
        T Deserialize<T>(byte[] buffer);

        byte[] Serialize(object data);
    }
}
