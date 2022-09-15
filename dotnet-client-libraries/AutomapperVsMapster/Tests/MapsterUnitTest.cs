using AutomapperVsMapster.AttributeMapping.Mapster;
using AutomapperVsMapster.CollectionMapping;
using AutomapperVsMapster.CustomPropertyMapping;
using AutomapperVsMapster.Flattened;
using AutomapperVsMapster.NestedTypeMapping;
using AutomapperVsMapster.ReverseMappingAndUnflattening;
using AutomapperVsMapster.SimpleTypeMapping;
using System.Globalization;

namespace Tests;

public class MapsterUnitTest
{
    [Fact]
    public void GivenASimpleObjectSource_WhenMappedUsingMapster_ThenMapToDestinationObjectCorrectly()
    {
        var source = SimpleTypeMappingDataGenerator.GetSources(1).First();
        var destination = MapsterSimpleTypeMapping.Map(source);

        Assert.Equal(source.Id, destination.Id);
        Assert.Equal(source.Name, destination.Name);
        Assert.Equal(source.Email, destination.Email);
        Assert.Equal(source.IsActive, destination.IsActive);
        Assert.Equal(source.CreatedAt.ToString(CultureInfo.CurrentCulture), destination.CreatedAt);
    }

    [Fact]
    public void GivenAListObjectSource_WhenMappedUsingMapster_ThenMapToDestinationObjectCorrectly()
    {
        var sourceList = CollectionMappingDataGenerator.GetSources(1);
        var destinationList = MapsterCollectionMapping.Map(sourceList);

        foreach (var (destination, index) in destinationList.Select(((userDto, i) => (userDto, i))))
        {
            var source = sourceList.ElementAt(index);
            Assert.Equal(source.Id, destination.Id);
            Assert.Equal(source.Name, destination.Name);
            Assert.Equal(source.Email, destination.Email);
            Assert.Equal(source.IsActive, destination.IsActive);
        }
    }

    [Fact]
    public void GivenANestedObjectSource_WhenMappedUsingMapster_ThenMapToDestinationObjectCorrectly()
    {
        var source = NestedTypeMappingDataGenerator.GetSources(1).First();
        var destination = MapsterNestedTypeMapping.Map(source);

        Assert.Equal(source.Id, destination.Id);
        Assert.Equal(source.FirstName, destination.FirstName);
        Assert.Equal(source.LastName, destination.LastName);
        Assert.Equal(source.Email, destination.Email);
        Assert.Equal(source.Address.AddressLine1, destination.Address.AddressLine1);
        Assert.Equal(source.Address.AddressLine2, destination.Address.AddressLine2);
        Assert.Equal(source.Address.City, destination.Address.City);
        Assert.Equal(source.Address.State, destination.Address.State);
        Assert.Equal(source.Address.Country, destination.Address.Country);
        Assert.Equal(source.Address.ZipCode, destination.Address.ZipCode);
    }

    [Fact]
    public void GivenACustomPropertyObjectSource_WhenMappedUsingMapster_ThenMapToDestinationObjectCorrectly()
    {
        var source = CustomPropertyMappingDataGenerator.GetSources(1).First();

        MapsterCustomPropertyMapping.Initialize();
        var destination = MapsterCustomPropertyMapping.Map(source);

        Assert.Equal(source.Id, destination.Id);
        Assert.Equal($"{source.FirstName} {source.LastName}", destination.FullName);
        Assert.Equal(source.Email, destination.Email);
    }

    [Fact]
    public void GivenANestedObjectSource_WhenMappedUsingMapster_ThenMapToFlattenedDestinationObjectCorrectly()
    {
        var source = FlattenedMappingDataGenerator.GetSources(1).First();
        var destination = MapsterFlattenedMapping.Map(source);

        Assert.Equal(source.Id, destination.Id);
        Assert.Equal(source.GetFullName(), destination.FullName);
        Assert.Equal(source.Email, destination.Email);
        Assert.Equal(source.Address.AddressLine1, destination.AddressAddressLine1);
        Assert.Equal(source.Address.AddressLine2, destination.AddressAddressLine2);
        Assert.Equal(source.Address.City, destination.AddressCity);
        Assert.Equal(source.Address.State, destination.AddressState);
        Assert.Equal(source.Address.Country, destination.AddressCountry);
        Assert.Equal(source.Address.ZipCode, destination.AddressZipCode);
    }

    [Fact]
    public void GivenFlattenedObjectSource_WhenMappedUsingMapster_ThenMapToNestedDestinationObjectCorrectly()
    {
        var source = ReverseMappingDataGenerator.GetSources(1).First();
        MapsterReverseMapping.Initialize();
        var destination = MapsterReverseMapping.Map(source);

        Assert.Equal(source.Id, destination.Id);
        Assert.Equal(source.EmailAddress, destination.Email);
        Assert.Equal(source.AddressAddressLine1, destination.Address.AddressLine1);
        Assert.Equal(source.AddressAddressLine2, destination.Address.AddressLine2);
        Assert.Equal(source.AddressCity, destination.Address.City);
        Assert.Equal(source.AddressState, destination.Address.State);
        Assert.Equal(source.AddressCountry, destination.Address.Country);
        Assert.Equal(source.AddressZipCode, destination.Address.ZipCode);
    }

    [Fact]
    public void GivenASourceObjectWithMapsterAttributes_WhenMappedUsingMapster_ThenMapToDestinationObjectCorrectly()
    {
        var source = MapsterAttributeMappingDataGenerator.GetSources(1).First();
        var destination = MapsterAttributeMapping.Map(source);

        Assert.Equal(source.Id, destination.Id);
        Assert.Equal(source.FirstName, destination.FirstName);
        Assert.Equal(source.LastName, destination.LastName);
        Assert.Equal(source.Email, destination.Email);
        Assert.Equal(source.CreatedAt.ToString(CultureInfo.CurrentCulture), destination.CreatedDate);
    }
}