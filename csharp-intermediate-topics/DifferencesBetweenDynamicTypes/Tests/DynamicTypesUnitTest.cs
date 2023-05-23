using DifferencesBetweenDynamicTypes;
using System;
using Xunit;

namespace Tests;

public class DynamicTypesUnitTest
{
    private readonly DynamicTypeService _dynamicTypeService;

    public DynamicTypesUnitTest()
    {
        _dynamicTypeService = new DynamicTypeService();
    }

    [Fact]
    public void WhenCreateExpandoObjectMethodIsCalled_ThenReturnExpandoObject()
    {
        dynamic actual = _dynamicTypeService.CreateExpandoObject();

        Assert.Equal("John Doe", actual.Author);
        Assert.Equal(2023, actual.Year);    
    }

    [Fact]
    public void WhenReadingValuesFromExpandoObject_ThenReturnExpandoObjectValues()
    {
        dynamic actual = _dynamicTypeService.ReadValuesFromExpandoObject();

        Assert.Equal("Asia", actual.Continent);
        Assert.Equal("3 Billion people", actual.Population);    
    }
    
    [Fact]  
    public void WhenRemoveValuesFromExpandoObjectMethodIsCalled_ThenReturnRemoveValues()
    {
        dynamic actual = _dynamicTypeService.RemoveValuesFromExpandoObject();

        Assert.Equal("Jane Doe", actual.Name);
    }
    
    [Fact]      
    public void WhenHandlePropertyChangesMethodIsCalled_ThenChangeDynamicObjectProperties()
    {
        dynamic actual = _dynamicTypeService.HandlePropertyChanges();

        Assert.Equal("John Doe", actual.Name);
    }

    [Fact]      
    public void WhenDynamicObjectIsInherited_ThenSetDynamicObjectValues()
    {
        dynamic dynamicPerson = new Person();

        dynamicPerson.Name = "Daniel";
        dynamicPerson.Age = 30;
        dynamicPerson.Address = "1234 Good Street";

        Assert.NotNull(dynamicPerson);
    }
}   