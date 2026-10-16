using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EnumMemberAsString;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Region
{
    [Description("North America")]
    [EnumMember(Value = "north-america")]
    NorthAmerica,

    [JsonStringEnumMemberName("asia-pacific")]
    AsiaPacific,
}
