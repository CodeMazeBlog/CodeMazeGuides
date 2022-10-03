using AutomapperVsMapster.AttributeMapping.AutoMapper;
using AutomapperVsMapster.AttributeMapping.Mapster;
using AutomapperVsMapster.CollectionMapping;
using AutomapperVsMapster.CustomPropertyMapping;
using AutomapperVsMapster.Flattened;
using AutomapperVsMapster.NestedTypeMapping;
using AutomapperVsMapster.ReverseMappingAndUnflattening;
using AutomapperVsMapster.SimpleTypeMapping;
using BenchmarkDotNet.Attributes;

namespace AutomapperVsMapster.Benchmark;

[MemoryDiagnoser(false)]
public class AutomapperVsMapsterBenchmark
{
    public readonly int _size = 1_000;

    private SimpleTypeMapping.User[] _simpleObjectSource = null!;
    private CollectionMapping.User[] _collectionObjectSource = null!;
    private NestedTypeMapping.User[] _nestedObjectSource = null!;
    private Flattened.User[] _flattenedObjectSource = null!;
    private CustomPropertyMapping.User[] _customPropertyObjectSource = null!;
    private ReverseMappingAndUnflattening.UserDto[] _reverseMappingObjectSource = null!;
    private AttributeMapping.AutoMapper.User[] _automapperAttributeObjectSource = null!;
    private AttributeMapping.Mapster.User[] _mapsterAttributeObjectSource = null!;

    #region SimpleMapping

    [GlobalSetup(Targets = new[] { nameof(AutoMapperSimpleObjectMapping), nameof(MapsterSimpleObjectMapping) })]
    public void SetupDataSourceForSimpleTypeMapping()
    {
        _simpleObjectSource = SimpleTypeMappingDataGenerator.GetSources(_size).ToArray();
    }

    [Benchmark(Description = "AutoMapper_SimpleMapping")]
    public void AutoMapperSimpleObjectMapping()
    {
        for (var i = 0; i < _size; i++)
        {
            AutoMapperSimpleTypeMapping.Map(_simpleObjectSource[i]);
        }
    }

    [Benchmark(Description = "Mapster_SimpleMapping")]
    public void MapsterSimpleObjectMapping()
    {
        for (var i = 0; i < _size; i++)
        {
            MapsterSimpleTypeMapping.Map(_simpleObjectSource[i]);
        }
    }

    #endregion

    #region ListOrArrayMapping

    [GlobalSetup(Targets = new[] { nameof(AutoMapperListOrArrayMapping), nameof(MapsterListOrArrayMapping) })]
    public void SetupDataSourceForCollectionMapping()
    {
        _collectionObjectSource = CollectionMappingDataGenerator.GetSources(_size).ToArray();
    }

    [Benchmark(Description = "AutoMapper_ListOrArrayMapping")]
    public void AutoMapperListOrArrayMapping()
    {
        AutoMapperCollectionMapping.Map(_collectionObjectSource.ToList());
    }

    [Benchmark(Description = "Mapster_ListOrArrayMapping")]
    public void MapsterListOrArrayMapping()
    {
        MapsterCollectionMapping.Map(_collectionObjectSource.ToList());
    }

    #endregion

    #region NestedMapping

    [GlobalSetup(Targets = new[] { nameof(AutoMapperNestedObjectMapping), nameof(MapsterNestedObjectMapping) })]
    public void SetupDataSourceForNestedTypeMapping()
    {
        _nestedObjectSource = NestedTypeMappingDataGenerator.GetSources(_size).ToArray();
    }

    [Benchmark(Description = "AutoMapper_NestedMapping")]
    public void AutoMapperNestedObjectMapping()
    {
        for (var i = 0; i < _size; i++)
        {
            AutoMapperNestedTypeMapping.Map(_nestedObjectSource[i]);
        }
    }

    [Benchmark(Description = "Mapster_NestedMapping")]
    public void MapsterNestedObjectMapping()
    {
        for (var i = 0; i < _size; i++)
        {
            MapsterNestedTypeMapping.Map(_nestedObjectSource[i]);
        }
    }

    #endregion

    #region FlattenedMapping

    [GlobalSetup(Targets = new[] { nameof(AutoMapperFlattenedObjectMapping), nameof(MapsterFlattenedObjectMapping) })]
    public void SetupDataSourceForFlattenedMapping()
    {
        _flattenedObjectSource = FlattenedMappingDataGenerator.GetSources(_size).ToArray();
    }

    [Benchmark(Description = "AutoMapper_FlattenedMapping")]
    public void AutoMapperFlattenedObjectMapping()
    {
        for (var i = 0; i < _size; i++)
        {
            AutoMapperFlattenedMapping.Map(_flattenedObjectSource[i]);
        }
    }

    [Benchmark(Description = "Mapster_FlattenedMapping")]
    public void MapsterFlattenedObjectMapping()
    {
        for (var i = 0; i < _size; i++)
        {
            MapsterFlattenedMapping.Map(_flattenedObjectSource[i]);
        }
    }

    #endregion

    #region CustomPropertyMapping

    [GlobalSetup(Targets = new[] { nameof(AutoMapperCustomPropertyObjectMapping), nameof(MapsterCustomPropertyObjectMapping) })]
    public void SetupDataSourceForCustomPropertyMapping()
    {
        MapsterCustomPropertyMapping.Initialize();
        _customPropertyObjectSource = CustomPropertyMappingDataGenerator.GetSources(_size).ToArray();
    }

    [Benchmark(Description = "AutoMapper_CustomPropertyMapping")]
    public void AutoMapperCustomPropertyObjectMapping()
    {
        for (var i = 0; i < _size; i++)
        {
            AutoMapperCustomPropertyMapping.Map(_customPropertyObjectSource[i]);
        }
    }

    [Benchmark(Description = "Mapster_CustomPropertyMapping")]
    public void MapsterCustomPropertyObjectMapping()
    {
        for (var i = 0; i < _size; i++)
        {
            MapsterCustomPropertyMapping.Map(_customPropertyObjectSource[i]);
        }
    }

    #endregion

    #region CustomPropertyMapping

    [GlobalSetup(Targets = new[] { nameof(AutoMapperReverseObjectMapping), nameof(MapsterReverseObjectMapping) })]
    public void SetupDataSourceForReverseMapping()
    {
        MapsterReverseMapping.Initialize();
        _reverseMappingObjectSource = ReverseMappingDataGenerator.GetSources(_size).ToArray();
    }

    [Benchmark(Description = "AutoMapper_ReverseMapping")]
    public void AutoMapperReverseObjectMapping()
    {
        for (var i = 0; i < _size; i++)
        {
            AutoMapperReverseMapping.Map(_reverseMappingObjectSource[i]);
        }
    }

    [Benchmark(Description = "Mapster_ReverseMapping")]
    public void MapsterReverseObjectMapping()
    {
        for (var i = 0; i < _size; i++)
        {
            MapsterReverseMapping.Map(_reverseMappingObjectSource[i]);
        }
    }

    #endregion

    #region AttributeMapping

    [GlobalSetup(Targets = new[] { nameof(AutoMapperAttributeObjectMapping) })]
    public void SetupDataSourceForAutoMapperAttributeMapping()
    {
        _automapperAttributeObjectSource = AutoMapperAttributeMappingDataGenerator.GetSources(_size).ToArray();
    }

    [Benchmark(Description = "AutoMapper_AttributeMapping")]
    public void AutoMapperAttributeObjectMapping()
    {
        for (var i = 0; i < _size; i++)
        {
            AutoMapperAttributeMapping.Map(_automapperAttributeObjectSource[i]);
        }
    }

    [GlobalSetup(Targets = new[] { nameof(MapsterAttributeObjectMapping) })]
    public void SetupDataSourceForMapsterAttributeMapping()
    {
        _mapsterAttributeObjectSource = MapsterAttributeMappingDataGenerator.GetSources(_size).ToArray();
    }

    [Benchmark(Description = "Mapster_AttributeMapping")]
    public void MapsterAttributeObjectMapping()
    {
        for (var i = 0; i < _size; i++)
        {
            MapsterAttributeMapping.Map(_mapsterAttributeObjectSource[i]);
        }
    }

    #endregion
}