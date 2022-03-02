using System.Runtime.Serialization;

namespace JsonSerialization.Native.EnumAsStringTests.CustomSerialization;

public record struct ToggleControl(string Name, ToggleType Type);

public enum ToggleType
{
    [EnumMember(Value = "Enable/Disable")]
    EnableDisable,

    [EnumMember(Value = "Visible/Hidden")]
    VisibleHidden,

    [EnumMember(Value = "Editable/Readonly")]
    EditableReadonly,
}