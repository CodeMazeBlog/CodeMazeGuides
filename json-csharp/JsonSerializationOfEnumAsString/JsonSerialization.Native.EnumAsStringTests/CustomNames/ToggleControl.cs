namespace JsonSerialization.Native.EnumAsStringTests.CustomNames;

public record struct ToggleControl(string Name, ToggleType Type);

public enum ToggleType
{
    [JsonStringEnumMemberName("Enable/Disable")]
    EnableDisable,

    [JsonStringEnumMemberName("Visible/Hidden")]
    VisibleHidden,

    [JsonStringEnumMemberName("Editable/Readonly")]
    EditableReadonly,
}
