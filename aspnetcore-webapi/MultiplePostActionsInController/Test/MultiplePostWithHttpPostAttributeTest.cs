using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MultiplePostActionsInController.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class MultiplePostWithHttpPostAttributeTest
    {

        private readonly HttpClient _client;

        public MultiplePostWithHttpPostAttributeTest()
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
            var responce = _client.PostAsJsonAsync("/StudentMultiplePostWithHttpPostAttribute/PostStudentInfo"
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
            var responce = _client.PostAsJsonAsync("/StudentMultiplePostWithHttpPostAttribute/PostStudentGrade"
                 , grade).Result;

            Assert.AreEqual(HttpStatusCode.OK, responce.StatusCode);
        }
    }
}
