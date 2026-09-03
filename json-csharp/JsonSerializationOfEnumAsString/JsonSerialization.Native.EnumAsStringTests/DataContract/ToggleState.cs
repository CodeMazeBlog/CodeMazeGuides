using System.Runtime.Serialization;

namespace JsonSerialization.Native.EnumAsStringTests.DataContract;

[DataContract]
public class ToggleSet
{
    [DataMember]
    public ToggleState Decorated { get; set; }

    [DataMember]
    public ToggleState Undecorated { get; set; }
}

[DataContract]
public enum ToggleState
{
    [EnumMember(Value = "Enable/Disable")]
    EnableDisable = 0,

    [EnumMember(Value = "Visible/Hidden")]
    VisibleHidden = 1,
}
