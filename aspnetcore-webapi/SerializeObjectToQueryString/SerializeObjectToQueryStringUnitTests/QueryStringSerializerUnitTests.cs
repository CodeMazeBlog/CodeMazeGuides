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
            var result = QueryStringSerializer.SerializeObjectToQueryStringUsingReflection();

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }

        [TestMethod]
        public void WhenSerializingObjectToQueryStringUsingNewtosnsoftJson_ThenCorrectApiUrlIsBuilt()
        {
            //Arrange
            var expectedApiUrl = $"{BaseApiUrl}?Author=George+Orwell&Language=English";

            //Act
            var result = QueryStringSerializer.SerializeObjectToQueryStringUsingNewtonsoftJson();

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }

        [TestMethod]
        public void WhenSerializingNestedObjectToQueryString_ThenCorrectApiUrlIsBuilt()
        {
            //Arrange
            var expectedApiUrl = $"{BaseApiUrl}?Name=Laptop&Category=Electronics&Manufacturer.Location=Silicon+Valley";

            //Act
            var result = QueryStringSerializer.SerializeNestedObjectToQueryString();

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }

        [TestMethod]
        public void WhenSerializingObjectContainsArrayToQueryString_ThenCorrectApiUrlIsBuilt()
        {
            //Arrange
            var expectedApiUrl = $"{BaseApiUrl}?FirstName=Smith&Age=25&Hobbies[0]=Reading&Hobbies[1]=Traveling&Hobbies[2]=Gaming";

            //Act
            var result = QueryStringSerializer.SerializeObjectContainingArraysToQueryString();

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }
    }
}