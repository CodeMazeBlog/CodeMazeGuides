using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SerializationDemo.Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tests
{
    [TestClass]
    public class ApiIntegrationTests
    {        
        [TestMethod]
        public async Task WhenGetEndPointIsInvoked_Status200IsReturnedWithListOfEmployees()
        {
            using var factory = new WebApplicationFactory<Program>();
            var httpClient = factory.CreateClient();

            var response = await httpClient.GetAsync("/api/employees");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(result);

            Assert.AreEqual(5, employees?.ToList().Count);
        }

        [TestMethod]
        public async Task WhenPostEndPointIsInvoked_StatusCode201IsReturnedWithNewEmployee()
        {
            var newEmployee = GetNewEmployee();
            using var factory = new WebApplicationFactory<Program>();
            var httpClient = factory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/employees");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(JsonConvert.SerializeObject(newEmployee), Encoding.UTF8, "application/json");
            
            var response = await httpClient.SendAsync(request);
            var receivedEmployee = JsonConvert.DeserializeObject<Employee>(await response.Content.ReadAsStringAsync());

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(newEmployee.Id, receivedEmployee.Id);
        }

        [TestMethod]
        public async Task WhenGetEndPointIsInvokedWithAcceptHeaderSetAsJson_ResponseIsReturnedInJsonFormat()
        {
            using var factory = new WebApplicationFactory<Program>();
            var httpClient = factory.CreateClient();
            var contentFormat = "application/json";
            var request = CreateRequest(HttpMethod.Get, "/api/employees", contentFormat);
            
            var response = await httpClient.SendAsync(request);

            Assert.AreEqual(contentFormat, response?.Content?.Headers?.ContentType?.MediaType);
        }

        [TestMethod]
        public async Task WhenGetEndPointIsInvokedWithAcceptHeaderSetAsXml_ResponseIsReturnedInXmlFormat()
        {
            using var factory = new WebApplicationFactory<Program>();
            var httpClient = factory.CreateClient();
            var contentFormat = "application/xml";
            var request = CreateRequest(HttpMethod.Get, "/api/employees", contentFormat);

            var response = await httpClient.SendAsync(request);

            Assert.AreEqual(contentFormat, response?.Content?.Headers?.ContentType?.MediaType);
        }

        [TestMethod]
        public async Task WhenGetEndPointIsInvokedWithAcceptHeaderSetAsProtobuf_ResponseIsReturnedInProtoFormat()
        {
            using var factory = new WebApplicationFactory<Program>();
            var httpClient = factory.CreateClient();
            var contentFormat = "application/x-protobuf";
            var request = CreateRequest(HttpMethod.Get, "/api/employees", contentFormat);

            var response = await httpClient.SendAsync(request);

            Assert.AreEqual(contentFormat, response?.Content?.Headers?.ContentType?.MediaType);
        }

        [TestMethod]
        public async Task WhenPostEndPointIsInvokedWithContentTypeHeaderSetAsJson_StatusCode201IsReturnedWithNewEmployee()
        {
            using var factory = new WebApplicationFactory<Program>();
            var httpClient = factory.CreateClient();
            var newEmployee = GetNewEmployee();
            var request = CreateRequest(HttpMethod.Post, "api/employees", "application/json");           
            request.Content = new StringContent(JsonConvert.SerializeObject(newEmployee), Encoding.UTF8, "application/json");
            
            var response = await httpClient.SendAsync(request);
            var receivedEmployee = JsonConvert.DeserializeObject<Employee>(await response.Content.ReadAsStringAsync());

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(newEmployee.Id, receivedEmployee.Id);
        }

        [TestMethod]
        public async Task WhenPostEndPointIsInvokedWithContentTypeHeaderSetAsXml_StatusCode201IsReturnedWithNewEmployee()
        {
            using var factory = new WebApplicationFactory<Program>();
            var httpClient = factory.CreateClient();
            var newEmployee = GetNewEmployee();
            var request = CreateRequest(HttpMethod.Post, "api/employees", "application/json");            
            request.Content = new StringContent(XmlSerialize(newEmployee), Encoding.UTF8, "application/xml");

            var response = await httpClient.SendAsync(request);
            var receivedEmployee = JsonConvert.DeserializeObject<Employee>(await response.Content.ReadAsStringAsync());

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(newEmployee.Id, receivedEmployee.Id);
        }

        [TestMethod]
        public async Task WhenPostEndPointIsInvokedWithContentTypeHeaderSetAsProtobuf_StatusCode201IsReturnedWithNewEmployee()
        {
            using var factory = new WebApplicationFactory<Program>();
            var httpClient = factory.CreateClient();
            var newEmployee = GetNewEmployee();
            var request = CreateRequest(HttpMethod.Post, "api/employees", "application/json");
            using (MemoryStream stream = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(stream, newEmployee);
                request.Content = new ByteArrayContent(stream.ToArray());
                request.Content.Headers.Add("Content-Type", "application/x-protobuf");
                var response = await httpClient.SendAsync(request);
                var receivedEmployee = JsonConvert.DeserializeObject<Employee>(await response.Content.ReadAsStringAsync());

                Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
                Assert.AreEqual(newEmployee.Id, receivedEmployee.Id);
            }      
          
        }

        private Employee GetNewEmployee()
        {
            return new Employee
            {
                Id = Guid.NewGuid(),
                Name = $"TestEmployee",
                Address = new Address
                {
                    AddressLine1 = $"Street",
                    AddressLine2 = $"District",
                    City = $"Sample City30",
                    Country = $"Sample Country22",
                }
            };
        }

        private HttpRequestMessage CreateRequest(HttpMethod verb, string url, string format)
        {
            var request = new HttpRequestMessage(verb, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

            return request;
        }
        private string XmlSerialize(object data)
        {
            var serializer = new XmlSerializer(data.GetType());

            using (var stream = new Utf8StringWriter())
            {
                serializer.Serialize(stream, data);

                return stream.ToString();
            }
        }

        private class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}
