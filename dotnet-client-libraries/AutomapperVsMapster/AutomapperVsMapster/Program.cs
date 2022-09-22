using AutomapperVsMapster.AttributeMapping.AutoMapper;
using AutomapperVsMapster.AttributeMapping.Mapster;
using AutomapperVsMapster.CollectionMapping;
using AutomapperVsMapster.CustomPropertyMapping;
using AutomapperVsMapster.Flattened;
using AutomapperVsMapster.NestedTypeMapping;
using AutomapperVsMapster.SimpleTypeMapping;
using System.Text.Json;

namespace AutomapperVsMapster;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(nameof(AutoMapperAttributeMapping));
        var destination1 = AutoMapperAttributeMapping.Map(AutoMapperAttributeMappingDataGenerator.GetSources(1).First());
        Console.WriteLine(JsonSerializer.Serialize(destination1) + Environment.NewLine);

        Console.WriteLine(nameof(MapsterAttributeMapping));
        var destination2 = MapsterAttributeMapping.Map(MapsterAttributeMappingDataGenerator.GetSources(1).First());
        Console.WriteLine(JsonSerializer.Serialize(destination2) + Environment.NewLine);

        Console.WriteLine(nameof(AutoMapperCustomPropertyMapping));
        var destination3 = AutoMapperCustomPropertyMapping.Map(CustomPropertyMappingDataGenerator.GetSources(1).First());
        Console.WriteLine(JsonSerializer.Serialize(destination3) + Environment.NewLine);

        MapsterCustomPropertyMapping.Initialize();
        Console.WriteLine(nameof(MapsterCustomPropertyMapping));
        var destination4 = MapsterCustomPropertyMapping.Map(CustomPropertyMappingDataGenerator.GetSources(1).First());
        Console.WriteLine(JsonSerializer.Serialize(destination4) + Environment.NewLine);

        Console.WriteLine(nameof(AutoMapperFlattenedMapping));
        var destination5 = AutoMapperFlattenedMapping.Map(FlattenedMappingDataGenerator.GetSources(1).First());
        Console.WriteLine(JsonSerializer.Serialize(destination5) + Environment.NewLine);

        Console.WriteLine(nameof(MapsterFlattenedMapping));
        var destination6 = MapsterFlattenedMapping.Map(FlattenedMappingDataGenerator.GetSources(1).First());
        Console.WriteLine(JsonSerializer.Serialize(destination6) + Environment.NewLine);

        Console.WriteLine(nameof(AutoMapperNestedTypeMapping));
        var destination7 = AutoMapperNestedTypeMapping.Map(NestedTypeMappingDataGenerator.GetSources(1).First());
        Console.WriteLine(JsonSerializer.Serialize(destination7) + Environment.NewLine);

        Console.WriteLine(nameof(MapsterNestedTypeMapping));
        var destination8 = MapsterNestedTypeMapping.Map(NestedTypeMappingDataGenerator.GetSources(1).First());
        Console.WriteLine(JsonSerializer.Serialize(destination8) + Environment.NewLine);

        Console.WriteLine(nameof(AutoMapperSimpleTypeMapping));
        var destination9 = AutoMapperSimpleTypeMapping.Map(SimpleTypeMappingDataGenerator.GetSources(1).First());
        Console.WriteLine(JsonSerializer.Serialize(destination9) + Environment.NewLine);

        Console.WriteLine(nameof(MapsterSimpleTypeMapping));
        var destination10 = MapsterSimpleTypeMapping.Map(SimpleTypeMappingDataGenerator.GetSources(1).First());
        Console.WriteLine(JsonSerializer.Serialize(destination10) + Environment.NewLine);

        Console.WriteLine(nameof(AutoMapperCollectionMapping));
        var destination11 = AutoMapperCollectionMapping.Map(CollectionMappingDataGenerator.GetSources(1));
        Console.WriteLine(JsonSerializer.Serialize(destination11) + Environment.NewLine);

        Console.WriteLine(nameof(MapsterCollectionMapping));
        var destination12 = MapsterCollectionMapping.Map(CollectionMappingDataGenerator.GetSources(1));
        Console.WriteLine(JsonSerializer.Serialize(destination12) + Environment.NewLine);
    }
}
