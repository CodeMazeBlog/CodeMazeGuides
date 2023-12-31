using System.Net;
using System.Net.Http.Json;
using XUnitPriorityOrderer;

namespace Tests
{
    [TestCaseOrderer(CasePriorityOrderer.TypeName, CasePriorityOrderer.AssembyName)]
    public class CoursesControllerIntegrationTest(TestingWebAppFactory<Program> factory) : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client = factory.CreateClient();

        [Fact, Order(1)]
        public async Task GetAll_WhenExecuted_ReturnsAllCourses()
        {
            var response = await _client.GetAsync("/api/courses");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("Biology", responseString);
            Assert.Contains("Mathematics", responseString);
            Assert.Contains("Physics", responseString);

        }

        [Fact, Order(2)]
        public async Task Get_WhenExecuted_ReturnsACourse()
        {
            var response = await _client.GetAsync("/api/courses/1");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("Biology", responseString);
        }

        [Fact, Order(3)]
        public async Task Post_WhenPostExecuted_ReturnsCreatedAtRoute()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/courses");

            var jsonDict = new Dictionary<string, string>
            {
                { "Title", "Fine Arts" },
                { "CreditUnit", "3" }
            };

            postRequest.Content = JsonContent.Create(jsonDict);
            var response = await _client.SendAsync(postRequest);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact, Order(4)]
        public async Task Update_WhenUpdateExecuted_ReturnsNoContent()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Put, "/api/courses/1");

            var jsonDict = new Dictionary<string, string>
            {
                { "Title", "Social Sciences" },
                { "CreditUnit", "4" }
            };

            postRequest.Content = JsonContent.Create(jsonDict);
            var response = await _client.SendAsync(postRequest);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact, Order(5)]
        public async Task Delete_WhenExecuted_DeletesACourse()
        {
            var response = await _client.DeleteAsync("/api/courses/1");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.DoesNotContain("Biology", responseString);
        }
    }
}