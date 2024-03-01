using CommunityToolkit.HighPerformance.Buffers;

namespace HowToUseStringPoolTests;

[TestClass]
public class HowToUseStringPoolTests
{
    private IFixture? _fixture;
    private StringPoolHelper _poolHelper = null!;

    [TestInitialize]
    public void Setup()
    {
        _fixture = new Fixture();
        _poolHelper = new StringPoolHelper();
        Environment.SetEnvironmentVariable("EncryptionPassword", "123abcd");
    }

    [TestMethod]
    public void WhenInitCalled_ThenReturnsTrue()
    {
        var poolSize = _fixture.Create<int>();

        var result = _poolHelper.Init(poolSize);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void WhenUseSharedInstanceCalled_ThenReturnsTrue()
    {
        var result = StringPoolHelper.UseSharedInstance();

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void WhenGetPoolSizeCalled_ThenSizeMustBeReturn()
    {
        var poolSize = _fixture.Create<int>();

        _poolHelper.Init(poolSize);
        var result = _poolHelper.GetPoolSize();
        var expected = new StringPool(poolSize).Size;

        Assert.AreEqual(result, expected);
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

        Assert.IsTrue(string.IsNullOrEmpty(result));
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

        var result = StringPoolHelper.GetHeaderValue(httpRequest, headerKey);

        Assert.AreEqual(headerValue, result);
    }

    [TestMethod]
    public void WhenCheckHeaderCalled_WithNoHeader_ThenResultMustBeFalse()
    {
        var httpRequest = GetHttpRequest([]);

        var result = StringPoolHelper.CheckHeader(httpRequest);

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

        var result = StringPoolHelper.CheckHeader(httpRequest);

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
    public void WhenTranslateCalled_ThenResultMustNotBeNull()
    {
        var key = _fixture.Create<string>();
        var lang = _fixture.Create<string>();

        var result = _poolHelper.Translate(key, lang);
        var expected = $"LOCALIZATION_{key}{lang}";

        Assert.IsNotNull(result);
        Assert.AreNotEqual(expected, result);
    }

    private static HttpRequestMessage GetHttpRequest(Dictionary<string, string> headerItems)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://code-maze.com/");

        foreach (var item in headerItems)
        {
            request.Headers.Add(item.Key, item.Value);
        }

        return request;
    }
}