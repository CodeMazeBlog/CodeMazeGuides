using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MultiplePostActionsInController.Models;

using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

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
        public void WhenPostToStudentController_ThenInternalServerError()
        {
            var responce = _client.PostAsJsonAsync($"/Students"
                 , _student).Result;

            Assert.AreEqual(HttpStatusCode.InternalServerError, responce.StatusCode);
        }

        [TestMethod]
        public void WhenPostToStudentController_WithAddStudentAction_ThenNotFound()
        {
            var responce = _client.PostAsJsonAsync("/Students/PostStudent"
                 , _student).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, responce.StatusCode);
        }

        [TestMethod]
        public void WhenPostToStudentController_WithAddGradeAction_ThenNotFound()
        {
            var responce = _client.PostAsJsonAsync("/Students/PostGrade"
                 , _grade).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, responce.StatusCode);
        }

        [TestMethod]
        public void WhenPostToStudentController_WithAddStudentAction_ThenCreated()
        {
            var responce = _client.PostAsJsonAsync("/Students/AddStudent"
                 , _student).Result;

            Assert.AreEqual(HttpStatusCode.Created, responce.StatusCode);
        }

        [TestMethod]
        public void WhenPostToStudentController_WithAddGradeAction_ThenCreated()
        {
            var responce = _client.PostAsJsonAsync("/Students/AddGrade"
                 , _grade).Result;

            Assert.AreEqual(HttpStatusCode.Created, responce.StatusCode);
        }
    }
}