using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MultiplePostActionsInController.Models;

using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace Test
{
    [TestClass]
    public class SinglePostControllerTest
    {
        private readonly HttpClient _client;

        public SinglePostControllerTest()
        {
            var appFactory = new WebApplicationFactory<Program>();
            _client = appFactory.CreateClient();
        }

        [TestMethod]
        public void WhenPostStudentInfo_ThenInternalServerError()
        {
            StudentInfo student = new StudentInfo
            {
                Id = "s1",
                Name = "Olive Yew"
            };
            var responce = _client.PostAsJsonAsync("/StudentSinglePost"
                 , student).Result;

            Assert.AreEqual(HttpStatusCode.InternalServerError, responce.StatusCode);
        }

        [TestMethod]
        public void WhenPostStudentInfo_WithActionName_ThenNotFound()
        {
            StudentInfo student = new StudentInfo
            {
                Id = "s1",
                Name = "Olive Yew"
            };
            var responce = _client.PostAsJsonAsync("/StudentSinglePost/PostStudentInfo"
                 , student).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, responce.StatusCode);
        }

        [TestMethod]
        public void WhenPostStudentGrade_ThenInternalServerError()
        {
            StudentGrade grade = new StudentGrade
            {
                StudentId = "s1",
                GPA = 3.2
            };
            var responce = _client.PostAsJsonAsync("/StudentSinglePost"
                 , grade).Result;

            Assert.AreEqual(HttpStatusCode.InternalServerError, responce.StatusCode);
        }

        [TestMethod]
        public void WhenPostStudentGrade_WithActionName_ThenNotFound()
        {
            StudentGrade grade = new()
            {
                StudentId = "s1",
                GPA = 3.2
            };
            var responce = _client.PostAsJsonAsync("/StudentSinglePost/PostStudentGrade"
                 , grade).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, responce.StatusCode);
        }
    }
}