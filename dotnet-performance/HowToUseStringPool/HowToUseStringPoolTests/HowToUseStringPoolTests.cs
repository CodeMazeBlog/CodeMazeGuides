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
        var result = _poolHelper.GetMyPoolSize();
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
        var remainingUrl = _fixture.Create<string>();
        var url = $"https://{hostName}/{remainingUrl}";

        var result = StringPoolHelper.GetHostName(url);

        Assert.AreEqual(hostName, result);
    }

    [TestMethod]
    public void GivenInvalidUrlString_WhenGetHostNameCalled_ThenReturnsEmptyString()
    {
        const string url = "ThisIsNot a URL";

        var result = StringPoolHelper.GetHostName(url);

        Assert.AreEqual(string.Empty, result);
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
}