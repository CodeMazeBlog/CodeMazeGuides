using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Tests.StartUps;

namespace Tests
{
    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        [ExpectedException(typeof(System.Text.Json.JsonException))]
        public async Task GivenACircularReference_WhenNoReferenceHandlerIsUsed_ThenJsonExceptionIsThrown()
        {
            //Arrange
            using var testServer = 
                new TestServer(
                    new WebHostBuilder()
                    .UseEnvironment("Development")
                    .UseStartup<TestStartupWithoutReferenceHandler>());

            using var client = testServer.CreateClient();

            // Act
            var response = await client.GetAsync("/api/employee");
        }

        [TestMethod]
        public async Task GivenACircularReference_WhenIgnoreCyclesIsUsed_ThenJsonIsReturnedWithNulls()
        {
            //Arrange
            using var testServer =
                new TestServer(
                    new WebHostBuilder()
                    .UseEnvironment("Development")
                    .UseStartup<TestStartupWithIgnoreCycles>());

            using var client = testServer.CreateClient();

            // Act
            var response = await client.GetAsync("/api/employee");

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);

            response.EnsureSuccessStatusCode();
            string expectedJson = @"[{""name"":""Kate"",""surname"":""Wilson"",""title"":""Development Manager"",""manager"":null,""directReports"":[{""name"":""Adam"",""surname"":""Smith"",""title"":""Software Engineer"",""manager"":null,""directReports"":[]}]},{""name"":""Adam"",""surname"":""Smith"",""title"":""Software Engineer"",""manager"":{""name"":""Kate"",""surname"":""Wilson"",""title"":""Development Manager"",""manager"":null,""directReports"":[null]},""directReports"":[]}]";
            string actualJson = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(expectedJson, actualJson);
        }

        [TestMethod]
        public async Task GivenACircularReference_WhenPreserveIsUsed_ThenReferencesAreIncludedInJson()
        {
            //Arrange
            using var testServer =
                new TestServer(
                    new WebHostBuilder()
                    .UseEnvironment("Development")
                    .UseStartup<TestStartupWithPreserve>());

            using var client = testServer.CreateClient();

            // Act
            var response = await client.GetAsync("/api/employee");

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);

            response.EnsureSuccessStatusCode();
            string expectedJson = @"{""$id"":""1"",""$values"":[{""$id"":""2"",""name"":""Kate"",""surname"":""Wilson"",""title"":""Development Manager"",""manager"":null,""directReports"":{""$id"":""3"",""$values"":[{""$id"":""4"",""name"":""Adam"",""surname"":""Smith"",""title"":""Software Engineer"",""manager"":{""$ref"":""2""},""directReports"":{""$id"":""5"",""$values"":[]}}]}},{""$ref"":""4""}]}";
            string actualJson = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(expectedJson, actualJson);
        }
    }
}