using JsonSerialization.EnumAsString.Models;

namespace JsonSerialization.Native.EnumAsStringTests.SourceGeneration;

[JsonSourceGenerationOptions(UseStringEnumConverter = true)]
[JsonSerializable(typeof(Canvas))]
internal partial class CanvasContext : JsonSerializerContext;
