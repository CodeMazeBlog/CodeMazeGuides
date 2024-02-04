using System.Text;
using AutoFixture;
using HowtoUseStringPoolApi;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace HowToUseStringPoolTests;

[TestClass]
public class HowToUseStringPoolTests
{
    private IFixture? _fixture;
    private StringPoolHelper _poolHelper;

    [TestInitialize]
    public void Setup()
    {
        _fixture = new Fixture();

        var inMemorySettings = new List<KeyValuePair<string, string>> {
            new("EncryptionPassword", "Codemaze")
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        _poolHelper = new StringPoolHelper(configuration);
    }

    [TestMethod]
    public void WhenAddUserCalled_ThenStringPoolMustUpdateItsCache()
    {
        var user = _fixture.Create<string>();
        var email = _fixture.Create<string>();

        var result = _poolHelper.AddUser(user.AsSpan(), email.AsSpan());

        Assert.IsTrue(result);
        Assert.IsTrue(_poolHelper.CacheContains("USER_" + user));
        Assert.AreEqual(_poolHelper.GetUser(user), email);
    }

    [TestMethod]
    public void WhenGetUserCalled_ThenNoResultMustReturn()
    {
        var user = _fixture.Create<string>();

        var result = _poolHelper.GetUser(user.AsSpan());

        Assert.IsNull(result);
    }

    [TestMethod]
    public void WhenLogErrorCalled_ThenLogCountMustBeIncrease()
    {
        var errorMessage = _fixture.Create<string>();

        var beforeLogCount = _poolHelper.GetLogCount();
        _poolHelper.LogError(errorMessage.AsSpan());
        var afterLogCount = _poolHelper.GetLogCount();

        Assert.IsTrue(afterLogCount > beforeLogCount);
    }

    [TestMethod]
    public void WhenGetHostNameCalled_ThenResultMustBeReturn()
    {
        var hostName = _fixture.Create<string>();
        var remaingUrl = _fixture.Create<string>();
        var url = string.Format("https://{0}/{1}", hostName, remaingUrl);

        var result = _poolHelper.GetHostName(url);

        Assert.AreEqual(hostName, result);
    }

    [TestMethod]
    public void WhenGetHeaderValueCalled_ThenResultMustBeReturn()
    {
        var httpRequest = GetHttpRequest();
        var contentType = _fixture.Create<string>();
        httpRequest.Headers.Append("Content-Type", contentType);

        var result = _poolHelper.GetHeaderValue(httpRequest, "Content-Type".AsSpan());

        Assert.AreEqual(contentType, result);
    }

    [TestMethod]
    public void WhenCheckHeaderCalled_WithNoHeader_ThenResultMustBeFalse()
    {
        var httpRequest = GetHttpRequest();

        var result = _poolHelper.CheckHeader(httpRequest);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void WhenCheckHeaderCalled_WithRightHeaderValues_ThenResultMustBeTrue()
    {
        var httpRequest = GetHttpRequest();
        var authorizationValue = _fixture.Create<string>();
        httpRequest.Headers.Append("Content-Type", "application/json");
        httpRequest.Headers.Append("Authorization", authorizationValue);

        var result = _poolHelper.CheckHeader(httpRequest);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void WhenCheckTokenCalled_ThenResultMustBeFalse()
    {
        var httpRequest = GetHttpRequest();
        var authorizationToken = _fixture.Create<string>();
        httpRequest.Headers.Append("AuthorizationToken", authorizationToken);

        var result = _poolHelper.CheckToken(httpRequest);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void WhenEncryptCalled_ThenResultMustNotBeNull()
    {
        var text = _fixture.Create<string>();

        var result = _poolHelper.Encrypt(text);

        Assert.IsNotNull(result);
        Assert.AreNotEqual(text, result);
    }

    [TestMethod]
    public void WhenTranslateCalled_ThenResultMustNotBeNull()
    {
        var key = _fixture.Create<string>();
        var lang = _fixture.Create<string>();

        var result = _poolHelper.Translate(key, lang);
        var expected = string.Format("LOCALIZATION_{0}{1}", key, lang);

        Assert.IsNotNull(result);
        Assert.AreNotEqual(expected, result);
    }

    [TestMethod]
    public void WhenIsValidEmailCalled_WithGeneratedValue_ThenResultMustBeFalse()
    {
        var email = _fixture.Create<string>();

        var result = _poolHelper.IsValidEmail(email);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void WhenIsValidEmailCalled_WithEmailValue_ThenResultMustBeTrue()
    {
        var email = "abc@example.com";

        var result = _poolHelper.IsValidEmail(email);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void WhenCheckContentCalled_WithGeneratedContent_ThenResultMustBeTrue()
    {
        var content1 = _fixture.Create<string>();
        var content2 = _fixture.Create<string>();
        var content3 = _fixture.Create<string>();
        var content = string.Format("{0} {1} {2}", content1, content2, content3);

        var result = _poolHelper.CheckContent(content);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void WhenCheckContentCalled_WithBlockedContent_ThenResultMustBeFalse()
    {
        var content1 = _fixture.Create<string>();
        var content2 = _fixture.Create<string>();
        var content = string.Format("{0} badword1 {1}", content1, content2);

        var result = _poolHelper.CheckContent(content);

        Assert.IsFalse(result);
    }

    private HttpRequest GetHttpRequest()
    {
        var bodyString = _fixture.Create<string>();
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(bodyString));
        var httpContext = new DefaultHttpContext()
        {
            Request = { Body = stream, ContentLength = stream.Length, RouteValues = [] }
        };

        var controllerContext = new ControllerContext
        {
            HttpContext = httpContext,
            RouteData = new RouteData(),
            ActionDescriptor = new ControllerActionDescriptor()
        };

        return controllerContext.HttpContext.Request;
    }
}