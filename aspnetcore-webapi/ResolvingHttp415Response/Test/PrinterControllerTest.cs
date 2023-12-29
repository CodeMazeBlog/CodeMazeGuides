using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResolvingUnsuportedMediaTypesTest;

[TestClass]
public class PrinterControllerTest
{
    private static HttpClient _httpClient;
    private static WebApplicationFactory<Program> _factory;

    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        _factory = new WebApplicationFactory<Program>();
        _httpClient = _factory.CreateClient();
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        _httpClient.Dispose();
        _factory.Dispose();
    }
    
    [TestMethod]
    public async Task GivenValidMediaTypeFromBody_WhenActionCalled_ShouldReturnOkResult()
    {
        var testMsg = "Valid Media Type";

        var result = await SendPrintFromBodyRequest(testMsg);
        Assert.IsNotNull(result);
        Assert.IsTrue(result.IsSuccessStatusCode);
        Assert.AreEqual($"Received (FromBody): {testMsg}", await result.Content.ReadAsStringAsync());

    }
    
    [TestMethod]
    public async Task GivenValidMediaTypeFromForm_WhenActionCalled_ShouldReturnOkResult()
    {
        var testMsg = "Valid Media Type";

        var result = await SendPrintFromFormRequest(testMsg);
        Assert.IsNotNull(result);
        Assert.IsTrue(result.IsSuccessStatusCode);
        Assert.AreEqual($"Received (FromForm): {testMsg}", await result.Content.ReadAsStringAsync());
    }

    [TestMethod]
    public async Task GivenInValidMediaType_WhenActionCalled_ShouldReturnHttp415()
    {
        string testMsg = "<xml><data>Invalid Media Type</data></xml>"; 

        var result = await SendPrintRequest(testMsg);
        Assert.AreEqual(415, (int)result.StatusCode);   
    }
    private async Task<HttpResponseMessage> SendPrintFromBodyRequest(string msg)
    {
        return await _httpClient.PostAsync("/api/Printer/PrintFromBody", 
        new StringContent($"\"{msg}\"", Encoding.UTF8, "application/json"));
    }
    private async Task<HttpResponseMessage> SendPrintFromFormRequest(string msg)
    {
        return await _httpClient.PostAsync("/api/Printer/PrintFromForm", 
        new StringContent($"data={msg}", Encoding.UTF8, "application/x-www-form-urlencoded"));
    }
    private async Task<HttpResponseMessage> SendPrintRequest(string msg)
    {
        return await _httpClient.PostAsync("/api/Printer/Print", 
        new StringContent($"data={msg}", Encoding.UTF8, "application/x-www-form-urlencoded"));
    }
}
