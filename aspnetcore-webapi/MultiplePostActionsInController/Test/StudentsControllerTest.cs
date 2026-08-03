using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MultiplePostActionsInController.Models;

using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class StudentsControllerTest
    {
        private readonly HttpClient _client;
        private readonly Student _student = new(4, "Test Name");
        private readonly StudentGrade _grade = new(4, 3);

        public StudentsControllerTest()
        {
            var appFactory = new WebApplicationFactory<Program>();
            _client = appFactory.CreateClient();
        }

        [TestMethod]
        public async Task WhenPostToStudentController_ThenInternalServerError()
        {
            var responce = await _client.PostAsJsonAsync($"/Students"
                 , _student);

            Assert.AreEqual(HttpStatusCode.InternalServerError, responce.StatusCode);
        }

        [TestMethod]
        public async Task WhenPostToStudentController_WithAddStudentAction_ThenNotFound()
        {
            var responce = await _client.PostAsJsonAsync("/Students/PostStudent"
                 , _student);

            Assert.AreEqual(HttpStatusCode.NotFound, responce.StatusCode);
        }

        [TestMethod]
        public async Task WhenPostToStudentController_WithAddGradeAction_ThenNotFound()
        {
            var responce = await _client.PostAsJsonAsync("/Students/PostGrade"
                 , _grade);

            Assert.AreEqual(HttpStatusCode.NotFound, responce.StatusCode);
        }

        [TestMethod]
        public async Task WhenPostToStudentController_WithAddStudentAction_ThenCreated()
        {
            var responce = await _client.PostAsJsonAsync("/Students/AddStudent"
                 , _student);

            Assert.AreEqual(HttpStatusCode.Created, responce.StatusCode);
        }

        [TestMethod]
        public async Task WhenPostToStudentController_WithAddGradeAction_ThenCreated()
        {
            var responce = await _client.PostAsJsonAsync("/Students/AddGrade"
                 , _grade);

            Assert.AreEqual(HttpStatusCode.Created, responce.StatusCode);
        }
    }
}