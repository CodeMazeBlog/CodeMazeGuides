using Microsoft.AspNetCore.Mvc.Testing;
using SerializationDemo.Common.Models;
using SerializationDemo.EmployeeApi.Controllers;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace Tests;

[TestClass]
public class ApiIntegrationTests
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    [TestMethod]
    public async Task WhenGetEndPointIsInvoked_Status200IsReturnedWithListOfEmployees()
    {
        using var factory = new WebApplicationFactory<EmployeesController>();
        var httpClient = factory.CreateClient();

        var response = await httpClient.GetAsync("/api/employees");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        var employees = JsonSerializer.Deserialize<List<Employee>>(result, JsonOptions);

        Assert.AreEqual(5, employees?.Count);
    }

    [TestMethod]
    public async Task WhenPostEndPointIsInvoked_StatusCode201IsReturnedWithNewEmployee()
    {
        var newEmployee = GetNewEmployee();
        using var factory = new WebApplicationFactory<EmployeesController>();
        var httpClient = factory.CreateClient();
        var request = CreateRequest(HttpMethod.Post, "/api/employees", "application/json");
        request.Content = new StringContent(JsonSerializer.Serialize(newEmployee, JsonOptions), Encoding.UTF8, "application/json");

        var response = await httpClient.SendAsync(request);
        var receivedEmployee = JsonSerializer.Deserialize<Employee>(await response.Content.ReadAsStringAsync(), JsonOptions);

        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        Assert.AreEqual(newEmployee.Id, receivedEmployee?.Id);
    }

    [TestMethod]
    public async Task WhenGetEndPointIsInvokedWithAcceptHeaderSetAsJson_ResponseIsReturnedInJsonFormat()
    {
        using var factory = new WebApplicationFactory<EmployeesController>();
        var httpClient = factory.CreateClient();
        var contentFormat = "application/json";
        var request = CreateRequest(HttpMethod.Get, "/api/employees", contentFormat);

        var response = await httpClient.SendAsync(request);

        Assert.AreEqual(contentFormat, response.Content.Headers.ContentType?.MediaType);
    }

    [TestMethod]
    public async Task WhenGetEndPointIsInvokedWithAcceptHeaderSetAsXml_ResponseIsReturnedInXmlFormat()
    {
        using var factory = new WebApplicationFactory<EmployeesController>();
        var httpClient = factory.CreateClient();
        var contentFormat = "application/xml";
        var request = CreateRequest(HttpMethod.Get, "/api/employees", contentFormat);

        var response = await httpClient.SendAsync(request);

        Assert.AreEqual(contentFormat, response.Content.Headers.ContentType?.MediaType);
    }

    [TestMethod]
    public async Task WhenGetEndPointIsInvokedWithAcceptHeaderSetAsProtobuf_ResponseIsReturnedInProtoFormat()
    {
        using var factory = new WebApplicationFactory<EmployeesController>();
        var httpClient = factory.CreateClient();
        var contentFormat = "application/x-protobuf";
        var request = CreateRequest(HttpMethod.Get, "/api/employees", contentFormat);

        var response = await httpClient.SendAsync(request);

        Assert.AreEqual(contentFormat, response.Content.Headers.ContentType?.MediaType);
    }

    [TestMethod]
    public async Task WhenGetEndPointIsInvokedWithAcceptHeaderSetAsProtobuf_ResponseDeserializesToEmployees()
    {
        using var factory = new WebApplicationFactory<EmployeesController>();
        var httpClient = factory.CreateClient();
        var request = CreateRequest(HttpMethod.Get, "/api/employees", "application/x-protobuf");

        var response = await httpClient.SendAsync(request);
        using var stream = await response.Content.ReadAsStreamAsync();
        var employees = ProtoBuf.Serializer.Deserialize<List<Employee>>(stream);

        Assert.AreEqual(5, employees.Count);
        Assert.AreEqual("TestEmployee1", employees[0].Name);
    }

    [TestMethod]
    public async Task WhenPostEndPointIsInvokedWithContentTypeHeaderSetAsXml_StatusCode201IsReturnedWithNewEmployee()
    {
        using var factory = new WebApplicationFactory<EmployeesController>();
        var httpClient = factory.CreateClient();
        var newEmployee = GetNewEmployee();
        var request = CreateRequest(HttpMethod.Post, "api/employees", "application/json");
        request.Content = new StringContent(XmlSerialize(newEmployee), Encoding.UTF8, "application/xml");

        var response = await httpClient.SendAsync(request);
        var receivedEmployee = JsonSerializer.Deserialize<Employee>(await response.Content.ReadAsStringAsync(), JsonOptions);

        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        Assert.AreEqual(newEmployee.Id, receivedEmployee?.Id);
    }

    [TestMethod]
    public async Task WhenPostEndPointIsInvokedWithContentTypeHeaderSetAsProtobuf_StatusCode201IsReturnedWithNewEmployee()
    {
        using var factory = new WebApplicationFactory<EmployeesController>();
        var httpClient = factory.CreateClient();
        var newEmployee = GetNewEmployee();
        var request = CreateRequest(HttpMethod.Post, "api/employees", "application/json");
        using var stream = new MemoryStream();
        ProtoBuf.Serializer.Serialize(stream, newEmployee);
        request.Content = new ByteArrayContent(stream.ToArray());
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-protobuf");

        var response = await httpClient.SendAsync(request);
        var receivedEmployee = JsonSerializer.Deserialize<Employee>(await response.Content.ReadAsStringAsync(), JsonOptions);

        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        Assert.AreEqual(newEmployee.Id, receivedEmployee?.Id);
    }

    private static Employee GetNewEmployee() => new()
    {
        Id = Guid.NewGuid(),
        Name = "TestEmployee",
        Address = new Address
        {
            AddressLine1 = "Street",
            AddressLine2 = "District",
            City = "Sample City30",
            Country = "Sample Country22",
        }
    };

    private static HttpRequestMessage CreateRequest(HttpMethod verb, string url, string format)
    {
        var request = new HttpRequestMessage(verb, url);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(format));

        return request;
    }

    private static string XmlSerialize(object data)
    {
        var serializer = new XmlSerializer(data.GetType());

        using var writer = new Utf8StringWriter();
        serializer.Serialize(writer, data);

        return writer.ToString();
    }

    private class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
