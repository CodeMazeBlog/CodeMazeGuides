namespace SerializationDemo.Client.Serialization
{
    internal interface IStringSerializer    
    {
        T Deserialize<T>(string text);

        string Serialize(object data);
    }
}
