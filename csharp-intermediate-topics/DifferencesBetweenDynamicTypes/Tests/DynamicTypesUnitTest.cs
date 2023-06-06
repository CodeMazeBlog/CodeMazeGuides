using System.ComponentModel;
using DifferencesBetweenDynamicTypes;
using System.Dynamic;
using Microsoft.CSharp.RuntimeBinder;
using Xunit;
using Xunit.Abstractions;

namespace Tests;

public class DynamicTypesUnitTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public DynamicTypesUnitTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void WhenAccessingNonExistentDynamicMember_ThenThrowError()
    {
        dynamic person = new
        {
            Name = "Test"
        };

        Assert.Throws<RuntimeBinderException>(() => person.Age);
    }

    [Fact]
    public void WhenAssigningDifferentTypesToObjects_ThenReturnObjectTypes()
    {
        dynamic count = 1;

        Assert.IsType<int>(count);
    }

    [Fact]
    public void WhenAddingMembersToExpandoObject_ThenReturnExpandoObjectMembers()   
    {
        dynamic book = new ExpandoObject();

        book.Author = "John Doe";
        book.Year = 2023;
        book.copiesSold = 1000;
        book.Sell = (Action)(() => { book.copiesSold++; });
        book.Sell();

        Assert.Equal("John Doe", book.Author);
        Assert.Equal(2023, book.Year);
        Assert.Equal(1001, book.copiesSold);
    }

    [Fact]
    public void WhenEnumeratingExpandoObjectMembers_ThenReturnExpandoObjectValues()
    {
        dynamic country = new ExpandoObject();

        country.Continent = "Asia";
        country.Population = "3 Billion people";

        foreach (KeyValuePair<string, object> keyValuePair in country)
        {
            _testOutputHelper.WriteLine($"{keyValuePair.Key} : {keyValuePair.Value}");
        }

        Assert.Equal("Asia", country.Continent);
        Assert.Equal("3 Billion people", country.Population);
    }

    [Fact]
    public void WhenRemovingValuesFromExpandoObject_ThenReturnRemainingValues()
    {
        dynamic person = new ExpandoObject();

        person.Age = 30;
        person.Name = "Jane Doe";   

        ((IDictionary<string, object>)person).Remove("Age");

        Assert.Equal("Jane Doe", person.Name);
    }

    [Fact]
    public void WhenHandlePropertyChangesMethodIsCalled_ThenChangeDynamicObjectProperties()
    {
        dynamic person = new ExpandoObject();

        ((INotifyPropertyChanged)person).PropertyChanged += (_, e) =>
        {
            _testOutputHelper.WriteLine($"Property changed: {e.PropertyName}");
        };

        person.Name = "John Doe";

        Assert.Equal("John Doe", person.Name);
    }

    [Fact]
    public void WhenDynamicObjectIsInherited_ThenSetDynamicObjectValues()
    {
        dynamic dynamicPerson = new Person();

        dynamicPerson.Name = "Daniel";
        dynamicPerson.Age = 30;
        dynamicPerson.Address = "1234 Good Street";

        Assert.Equal("Daniel", dynamicPerson.Name);
        Assert.Equal(30, dynamicPerson.Age);
        Assert.Equal("1234 Good Street", dynamicPerson.Address);
    }
}