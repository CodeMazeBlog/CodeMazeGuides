using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace JsonSerialization.Native.EnumAsStringTests.DataContract;

public class DataContractJsonSerializationUnitTest
{
    private static string SerializeToJson(ToggleSet set)
    {
        var serializer = new DataContractJsonSerializer(typeof(ToggleSet));

        using var stream = new MemoryStream();
        serializer.WriteObject(stream, set);

        return Encoding.UTF8.GetString(stream.ToArray());
    }

    private static ToggleSet? DeserializeFromJson(string json)
    {
        var serializer = new DataContractJsonSerializer(typeof(ToggleSet));

        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

        return serializer.ReadObject(stream) as ToggleSet;
    }

    [Fact]
    public void GivenEnum_WhenSerializedWithDataContractJsonSerializer_ThenWritesNumbersAndIgnoresEnumMember()
    {
        var set = new ToggleSet
        {
            Decorated = ToggleState.EnableDisable,
            Undecorated = ToggleState.VisibleHidden
        };

        var json = SerializeToJson(set);

        Assert.Equal("{\"Decorated\":0,\"Undecorated\":1}", json);
    }

    [Fact]
    public void GivenEnumMemberString_WhenDeserializedWithDataContractJsonSerializer_ThenThrows()
    {
        var json = "{\"Decorated\":\"Enable/Disable\",\"Undecorated\":1}";

        var exception = Assert.Throws<SerializationException>(() => DeserializeFromJson(json));

        Assert.Contains("cannot be parsed as the type 'Int64'", exception.Message);
    }

    [Fact]
    public void GivenUndefinedNumber_WhenDeserializedWithDataContractJsonSerializer_ThenAcceptsIt()
    {
        var json = "{\"Decorated\":42,\"Undecorated\":1}";

        var set = DeserializeFromJson(json);

        Assert.NotNull(set);
        Assert.Equal(42, (int)set.Decorated);
    }

    [Fact]
    public void GivenSameEnum_WhenSerializedWithXmlDataContractSerializer_ThenHonoursEnumMember()
    {
        var set = new ToggleSet
        {
            Decorated = ToggleState.EnableDisable,
            Undecorated = ToggleState.VisibleHidden
        };
        var serializer = new DataContractSerializer(typeof(ToggleSet));

        using var stream = new MemoryStream();
        serializer.WriteObject(stream, set);
        var xml = Encoding.UTF8.GetString(stream.ToArray());

        Assert.Contains("<Decorated>Enable/Disable</Decorated>", xml);
        Assert.Contains("<Undecorated>Visible/Hidden</Undecorated>", xml);
    }
}
