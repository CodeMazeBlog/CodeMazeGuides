using FixUnableToResolveServiceIssue.Settings;
using Microsoft.Extensions.Options;

namespace FixUnableToResolveServiceIssue.Services
{
    public class EmailService
    {
        private readonly SmtpSettings _settings;

        // Asking for "string host" here instead would throw
        // "Unable to resolve service for type 'System.String'", because the container
        // cannot tell which string we mean. IOptions<SmtpSettings> is a type it can resolve.
        public EmailService(IOptions<SmtpSettings> options)
        {
            _settings = options.Value;
        }

        public string GetServerAddress() => $"{_settings.Host}:{_settings.Port}";
    }
}
