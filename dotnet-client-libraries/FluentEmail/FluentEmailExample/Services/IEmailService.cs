using FluentEmailExample.Model;

namespace FluentEmailExample.Services
{
    public interface IEmailService
    {
        Task Send(EmailMetadata emailMetadata);
        Task SendUsingTemplate(EmailMetadata emailMetadata, string template, User user);
        Task SendUsingTemplateFromFile(EmailMetadata emailMetadata, string templateFile, User user);
        Task SendWithAttachment(EmailMetadata emailMetadata);
        Task SendMultiple(List<EmailMetadata> emailsMetadata);
    }
}
