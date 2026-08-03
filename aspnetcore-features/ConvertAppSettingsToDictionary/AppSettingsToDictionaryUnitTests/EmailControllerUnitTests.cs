using ConvertAppSettingsToDictionary;
using ConvertAppSettingsToDictionary.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppSettingsToDictionaryUnitTests
{
    [TestClass]
    public class EmailControllerUnitTests
    {
        private IConfigurationRoot? _configurationRoot;
        private IOptions<EmailSettings>? _options;
        private const string EMAIL_SETTINGS = "EmailSettings";

        [TestInitialize]
        public void Initialize()
        {
            _configurationRoot = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string?>
                {
                {"EmailSettings:SmtpServer", "smtp.example.com"},
                {"EmailSettings:Port", "587"},
                {"EmailSettings:Username", "test@example.com"},
                {"EmailSettings:Password", "testpassword"}
                }).Build();

            _options = Options.Create(new EmailSettings
            {
                SmtpServer = "smtp.example.com",
                Port = 587,
                UserName = "test@example.com",
                Password = "testpassword"
            });

        }

        [TestMethod]
        public void GivenValidSectionName_WhenUsingGetSectionMethod_ThenReturnDictionary()
        {
            var emailController = new EmailController(_configurationRoot!, _options!);

            var result = emailController.GetAppSettingsAsDictionaryUsingGetSection(EMAIL_SETTINGS);

            var okObjectResult = (OkObjectResult)result.Result!;
            var appSettingsDictionary = (Dictionary<string, string>?)okObjectResult.Value;


            Assert.IsInstanceOfType(okObjectResult.Value, typeof(Dictionary<string, string>));
            Assert.AreEqual("smtp.example.com", appSettingsDictionary?["SmtpServer"]);
            Assert.AreEqual("587", appSettingsDictionary?["Port"]);
            Assert.AreEqual("test@example.com", appSettingsDictionary?["Username"]);
            Assert.AreEqual("testpassword", appSettingsDictionary?["Password"]);
        }

        [TestMethod]
        public void GivenValidSectionName_WhenUsingGetChildrenMethod_ThenReturnDictionary()
        {
            var emailController = new EmailController(_configurationRoot!, _options!);

            var result = emailController.GetAppSettingsAsDictionaryUsingGetChildren(EMAIL_SETTINGS);

            var okObjectResult = (OkObjectResult)result.Result!;
            var appSettingsDictionary = (Dictionary<string, string>?)okObjectResult.Value;


            Assert.IsInstanceOfType(okObjectResult.Value, typeof(Dictionary<string, string>));
            Assert.AreEqual("smtp.example.com", appSettingsDictionary?["SmtpServer"]);
            Assert.AreEqual("587", appSettingsDictionary?["Port"]);
            Assert.AreEqual("test@example.com", appSettingsDictionary?["Username"]);
            Assert.AreEqual("testpassword", appSettingsDictionary?["Password"]);
        }

        [TestMethod]
        public void GivenValidSectionName_WhenUsingBindMethod_ThenReturnDictionary()
        {
            var emailController = new EmailController(_configurationRoot!, _options!);

            var result = emailController.GetAppSettingsAsDictionaryUsingBind(EMAIL_SETTINGS);

            var okObjectResult = result.Value!;
            var appSettingsDictionary = (Dictionary<string, object>?)okObjectResult!;


            Assert.IsInstanceOfType(okObjectResult, typeof(Dictionary<string, object>));
            Assert.AreEqual("smtp.example.com", appSettingsDictionary?["SmtpServer"]);
            Assert.AreEqual(587, appSettingsDictionary?["Port"]);
            Assert.AreEqual("test@example.com", appSettingsDictionary?["UserName"]);
            Assert.AreEqual("testpassword", appSettingsDictionary?["Password"]);
        }

        [TestMethod]
        public void GivenValidSectionName_WhenUsingOpions_ThenReturnDictionary()
        {
            var emailController = new EmailController(_configurationRoot!, _options!);

            var result = emailController.GetAppSettingsAsDictionaryUsingOptions();

            var okObjectResult = result.Value!;
            var appSettingsDictionary = (Dictionary<string, object>?)okObjectResult!;


            Assert.IsInstanceOfType(okObjectResult, typeof(Dictionary<string, object>));
            Assert.AreEqual("smtp.example.com", appSettingsDictionary?["SmtpServer"]);
            Assert.AreEqual(587, appSettingsDictionary?["Port"]);
            Assert.AreEqual("test@example.com", appSettingsDictionary?["UserName"]);
            Assert.AreEqual("testpassword", appSettingsDictionary?["Password"]);
        }
    }
}