using AutomapperVsMapster.AttributeMapping.AutoMapper;
using AutomapperVsMapster.CollectionMapping;
using AutomapperVsMapster.CustomPropertyMapping;
using AutomapperVsMapster.Flattened;
using AutomapperVsMapster.NestedTypeMapping;
using AutomapperVsMapster.ReverseMappingAndUnflattening;
using AutomapperVsMapster.SimpleTypeMapping;
using System.Globalization;

namespace Tests;

public class AutoMapperUnitTest
{
    [Fact]
    public void GivenASimpleObjectSource_WhenMappedUsingAutoMapper_ThenMapToDestinationObjectCorrectly()
    {
        var source = SimpleTypeMappingDataGenerator.GetSources(1).First();
        var destination = AutoMapperSimpleTypeMapping.Map(source);

        Assert.Equal(source.Id, destination.Id);
        Assert.Equal(source.Name, destination.Name);
        Assert.Equal(source.Email, destination.Email);
        Assert.Equal(source.IsActive, destination.IsActive);
    }

    [Fact]
    public void GivenAListObjectSource_WhenMappedUsingAutoMapper_ThenMapToDestinationObjectCorrectly()
    {
        var sourceList = CollectionMappingDataGenerator.GetSources(1);
        var destinationList = AutoMapperCollectionMapping.Map(sourceList);

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
    public void GivenANestedObjectSource_WhenMappedUsingAutoMapper_ThenMapToDestinationObjectCorrectly()
    {
        var source = NestedTypeMappingDataGenerator.GetSources(1).First();
        var destination = AutoMapperNestedTypeMapping.Map(source);

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
    public void GivenACustomPropertyObjectSource_WhenMappedUsingAutoMapper_ThenMapToDestinationObjectCorrectly()
    {
        var source = CustomPropertyMappingDataGenerator.GetSources(1).First();
        var destination = AutoMapperCustomPropertyMapping.Map(source);

        Assert.Equal(source.Id, destination.Id);
        Assert.Equal($"{source.FirstName} {source.LastName}", destination.FullName);
        Assert.Equal(source.Email, destination.Email);
    }

    [Fact]
    public void GivenANestedObjectSource_WhenMappedUsingAutoMapper_ThenMapToFlattenedDestinationObjectCorrectly()
    {
        var source = FlattenedMappingDataGenerator.GetSources(1).First();
        var destination = AutoMapperFlattenedMapping.Map(source);

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
    public void GivenFlattenedObjectSource_WhenMappedUsingAutoMapper_ThenMapToNestedDestinationObjectCorrectly()
    {
        var source = ReverseMappingDataGenerator.GetSources(1).First();
        var destination = AutoMapperReverseMapping.Map(source);

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
    public void GivenASourceObjectWithAutoMapperAttributes_WhenMappedUsingAutoMapper_ThenMapToDestinationObjectCorrectly()
    {
        var source = AutoMapperAttributeMappingDataGenerator.GetSources(1).First();
        var destination = AutoMapperAttributeMapping.Map(source);

        Assert.Equal(source.Id, destination.Id);
        Assert.Equal(source.FirstName, destination.FirstName);
        Assert.Equal(source.LastName, destination.LastName);
        Assert.Equal(source.Email, destination.Email);
        Assert.Equal(source.CreatedAt.ToString(CultureInfo.CurrentCulture), destination.CreatedDate);
    }
}