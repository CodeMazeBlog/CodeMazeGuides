using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Data;

namespace ConvertAppSettingsToDictionary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly EmailSettings _settings;

        public EmailController(IConfiguration configuration, IOptions<EmailSettings> emailSettings)
        {
            _configuration = configuration;
            _settings = emailSettings.Value;
        }

        [HttpGet("get-dictionary/{sectionName}")]
        public ActionResult<Dictionary<string, string>> GetAppSettingsAsDictionaryUsingGetSection(string sectionName)
        {
            var appSettingsSection = _configuration.GetSection(sectionName);

            var appSettingsDictionary = appSettingsSection
                .AsEnumerable()
                .Where(x => !string.IsNullOrWhiteSpace(x.Value))
                .ToDictionary(x => x.Key.Replace("EmailSettings:", ""), x => x.Value);

            return Ok(appSettingsDictionary);
        }

        [HttpGet("get-children-dictionary/{sectionName}")]
        public ActionResult<Dictionary<string, string>> GetAppSettingsAsDictionaryUsingGetChildren(string sectionName)
        {
            var appSettingsSection = _configuration.GetSection(sectionName);

            var appSettingsDictionary = new Dictionary<string, string?>();

            foreach (var child in appSettingsSection.GetChildren())
            {
                appSettingsDictionary[child.Key] = child.Value;
            }

            return Ok(appSettingsDictionary);
        }

        [HttpGet("bind-dictionary/{sectionName}")]
        public ActionResult<Dictionary<string, object?>> GetAppSettingsAsDictionaryUsingBind(string sectionName)
        {
           var settings = new EmailSettings();

            _configuration.GetSection(sectionName).Bind(settings);

            return ToDictionary(settings);
        }

        [HttpGet("options-pattern-dictionary")]
        public ActionResult<Dictionary<string, object?>> GetAppSettingsAsDictionaryUsingOptions()
        {
            return ToDictionary(_settings);
        }

        private Dictionary<string, object?> ToDictionary(EmailSettings settings)
        {
            return settings
                .GetType()
                .GetProperties()
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(_settings, null));
        }
    }
}
