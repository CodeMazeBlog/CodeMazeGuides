using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializeObjectToQueryString;

namespace SerializeObjectToQueryStringUnitTests
{
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
            var expectedApiUrl = $"{BaseApiUrl}?Name=Laptop&Category=Electronics&Manufacturer.Location%3dSilicon%2bValley&Manufacturer.Distributor.Name%253dTechDistributors";

            //Act
            var result = QueryStringSerializer.CreateURLWithProductAsQueryParams(BaseApiUrl, new Product());

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }

        [TestMethod]
        public void WhenSerializingObjectContainsArrayToQueryString_ThenCorrectApiUrlIsBuilt()
        {
            //Arrange
            var expectedApiUrl = $"{BaseApiUrl}?FirstName=Smith&Age=25&Hobbies[0]=Reading&Hobbies[1]=Traveling&Hobbies[2]=Gaming&Address.Country%3dAustralia";
       
            //Act
            var result = QueryStringSerializer.CreateURLWithPersonAsQueryParams(BaseApiUrl, new Person());

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }
    }
}