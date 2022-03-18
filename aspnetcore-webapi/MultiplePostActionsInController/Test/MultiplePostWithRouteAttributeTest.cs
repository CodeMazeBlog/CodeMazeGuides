using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MultiplePostActionsInController.Models;

using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace Test
{
    [TestClass]
    public class MultiplePostWithRouteAttributeTest
    {
        private readonly HttpClient _client;

        public MultiplePostWithRouteAttributeTest()
        {
            var appFactory = new WebApplicationFactory<Program>();
            _client = appFactory.CreateClient();
        }

        [TestMethod]
        public void WhenPostStudentInfo_ThenHttpStatusOK()
        {
            StudentInfo student = new StudentInfo
            {
                Id = "s1",
                Name = "Olive Yew"
            };
            var responce = _client.PostAsJsonAsync("/StudentMultiplePostWithRouteAttribute/PostStudentInfo"
                 , student).Result;

            Assert.AreEqual(HttpStatusCode.OK, responce.StatusCode);
        }

        [TestMethod]
        public void WhenPostStudentGrade_ThenHttpStatusOK()
        {
            StudentGrade grade = new()
            {
                StudentId = "s1",
                GPA = 3.2
            };
            var responce = _client.PostAsJsonAsync("/StudentMultiplePostWithRouteAttribute/PostStudentGrade"
                 , grade).Result;

            Assert.AreEqual(HttpStatusCode.OK, responce.StatusCode);
        }
    }
}
