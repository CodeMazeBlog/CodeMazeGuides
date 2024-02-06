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
        _poolHelper = new StringPoolHelper();
        Environment.SetEnvironmentVariable("EncryptionPassword", "123abcd");
    }

    [TestMethod]
    public void WhenAddUserCalled_ThenStringPoolMustUpdateItsCache()
    {
        var user = _fixture.Create<string>();
        var email = _fixture.Create<string>();

        var result = _poolHelper.AddUser(user, email);

        Assert.IsTrue(result);
        Assert.IsTrue(_poolHelper.CacheContains("USER_" + user));
        Assert.AreEqual(_poolHelper.GetUser(user), email);
    }

    [TestMethod]
    public void WhenGetUserCalled_ThenNoResultMustReturn()
    {
        var user = _fixture.Create<string>();

        var result = _poolHelper.GetUser(user);

        Assert.IsNull(result);
    }

    [TestMethod]
    public void WhenLogErrorCalled_ThenLogCountMustBeIncrease()
    {
        var errorMessage = _fixture.Create<string>();
        var beforeLogCount = _poolHelper.GetLogCount();

        _poolHelper.LogError(errorMessage);
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
        var headerKey = _fixture.Create<string>();
        var headerValue = _fixture.Create<string>();
        var httpRequest = GetHttpRequest(new Dictionary<string, string>()
        {
            { headerKey,headerValue }
        });

        var result = _poolHelper.GetHeaderValue(httpRequest, headerKey);

        Assert.AreEqual(headerValue, result);
    }

    [TestMethod]
    public void WhenCheckHeaderCalled_WithNoHeader_ThenResultMustBeFalse()
    {
        var httpRequest = GetHttpRequest([]);

        var result = _poolHelper.CheckHeader(httpRequest);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void WhenCheckHeaderCalled_WithRightHeaderValues_ThenResultMustBeTrue()
    {
        var authorizationToken = _fixture.Create<string>();
        var httpRequest = GetHttpRequest(new Dictionary<string, string>()
        {
            { "Authorization", authorizationToken },
            { "User-Agent", "chrome"}
        });

        var result = _poolHelper.CheckHeader(httpRequest);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void WhenCheckTokenCalled_ThenResultMustBeFalse()
    {
        var authorizationToken = _fixture.Create<string>();
        var httpRequest = GetHttpRequest(new Dictionary<string, string>()
        {
            { "AuthorizationToken",authorizationToken },
        });

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

    private static HttpRequestMessage GetHttpRequest(Dictionary<string, string> headerItems)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://code-maze.com/");

        if (headerItems != null && headerItems.Count != 0)
        {
            foreach (var item in headerItems)
            {
                request.Headers.Add(item.Key, item.Value);
            }
        }

        return request;
    }
}