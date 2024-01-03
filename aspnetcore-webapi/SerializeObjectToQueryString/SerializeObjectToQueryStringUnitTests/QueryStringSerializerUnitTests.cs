using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializeObjectToQueryString;

namespace SerializeObjectToQueryStringUnitTests;

[TestClass]
public class QueryStringSerializerUnitTests
{
    private const string BaseApiUrl = "https://test.com";

    [TestMethod]
    public void WhenSerializingObjectToQueryStringUsingReflection_ThenCorrectApiUrlIsBuilt()
    {
        //Arrange
        var expectedApiUrl = $"{BaseApiUrl}?Author=George+Orwell&Language=English";

        //Act
        var result = QueryStringSerializer.CreateURLWithBookAsQueryParamsUsingReflection(BaseApiUrl, new Book());

        //Assert
        Assert.AreEqual(expectedApiUrl, result);
    }

    [TestMethod]
    public void WhenSerializingObjectToQueryStringUsingNewtosnsoftJson_ThenCorrectApiUrlIsBuilt()
    {
        //Arrange
        var expectedApiUrl = $"{BaseApiUrl}?Author=George+Orwell&Language=English";

        //Act
        var result = QueryStringSerializer.CreateURLWithBookAsQueryParamsUsingNewtonsoftJson(BaseApiUrl, new Book());

        //Assert
        Assert.AreEqual(expectedApiUrl, result);
    }

    [TestMethod]
    public void WhenSerializingNestedObjectToQueryString_ThenCorrectApiUrlIsBuilt()
    {
        //Arrange
        var expectedApiUrl =
            $"{BaseApiUrl}?Name=Laptop&Category=Electronics&Manufacturer.Location=Silicon+Valley&Manufacturer.Distributor.Name=TechDistributors";

        //Act
        var result = QueryStringSerializer.CreateURLWithProductAsQueryParams(BaseApiUrl, new Product());

        //Assert
        Assert.AreEqual(expectedApiUrl, result);
    }

    [TestMethod]
    public void WhenSerializingObjectContainsArrayToQueryString_ThenCorrectApiUrlIsBuilt()
    {
        //Arrange
        var expectedApiUrl =
            $"{BaseApiUrl}?FirstName=Smith&Age=25&Hobbies%5b0%5d=Reading&Hobbies%5b1%5d=Traveling&Hobbies%5b2%5d=Gaming&Address.Country=Australia";

        //Act
        var result = QueryStringSerializer.CreateURLWithPersonAsQueryParams(BaseApiUrl, new Person());

        //Assert
        Assert.AreEqual(expectedApiUrl, result);
    }
}