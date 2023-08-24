using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TwoFactorAuthentication.Areas.Identity.Services
{
    public class MessageSender : ISmsSender
    {
        public SMSOptions Options { get; }
        public MessageSender(IOptions<SMSOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public Task SendSmsAsync(string number, string message)
        {
            var accountSid = Options.SMSAccountIdentification;
            var authToken = Options.SMSAccountPassword;

            TwilioClient.Init(accountSid, authToken);

            return MessageResource.CreateAsync(
                to: new PhoneNumber(number),
                from: new PhoneNumber(Options.SMSAccountFrom),
                body: message);
        }
    }
}
