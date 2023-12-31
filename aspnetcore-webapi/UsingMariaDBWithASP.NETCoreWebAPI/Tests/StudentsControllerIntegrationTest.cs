using System.Net;
using System.Net.Http.Json;
using XUnitPriorityOrderer;

namespace Tests
{
    [TestCaseOrderer(CasePriorityOrderer.TypeName, CasePriorityOrderer.AssembyName)]
    public class StudentsControllerIntegrationTest(TestingWebAppFactory<Program> factory) : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client = factory.CreateClient();

        [Fact, Order(1)]
        public async Task GetAll_WhenExecuted_ReturnsAllStudents()
        {
            var response = await _client.GetAsync("/api/students");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("John", responseString);
            Assert.Contains("Jane", responseString);
        }

        [Fact, Order(2)]
        public async Task Get_WhenExecuted_ReturnsAStudent()
        {
            var response = await _client.GetAsync("/api/students/1");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("John", responseString);
            Assert.Contains("Doe", responseString);
        }

        [Fact, Order(3)]
        public async Task Post_WhenPostExecuted_ReturnsCreatedAtRoute()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/students");

            var jsonDict = new Dictionary<string, string>
            {
                { "FirstName", "Anna" },
                { "SecondName", "Dean" },
                { "Address", "23 Bog Street" }
            };

            postRequest.Content = JsonContent.Create(jsonDict);
            var response = await _client.SendAsync(postRequest);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact, Order(4)]
        public async Task Update_WhenUpdateExecuted_ReturnsNoContent()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Put, "/api/students/1");

            var jsonDict = new Dictionary<string, string>
            {
                { "FirstName", "Smith" },
                { "SecondName", "kel" },
                { "Address", "25 Domenico Street" }
            };

            postRequest.Content = JsonContent.Create(jsonDict);
            var response = await _client.SendAsync(postRequest);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact, Order(5)]
        public async Task Delete_WhenExecuted_DeletesAStudent()
        {
            var response = await _client.DeleteAsync("/api/students/1");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.DoesNotContain("John", responseString);
            Assert.DoesNotContain("Doe", responseString);
        }
    }
}