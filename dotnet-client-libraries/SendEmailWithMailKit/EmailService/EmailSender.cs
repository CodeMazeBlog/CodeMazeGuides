using MailKit.Net.Smtp;
using MimeKit;

namespace EmailService;

public class EmailSender : IEmailSender
{
    private readonly EmailConfiguration _emailConfig;

    public EmailSender(EmailConfiguration emailConfig)
    {
        _emailConfig = emailConfig;
    }

    public void SendEmail(Message message)
    {
        var emailMessage = CreateEmailMessage(message);

        Send(emailMessage);
    }

    public async Task SendEmailAsync(Message message)
    {
        var mailMessage = CreateEmailMessage(message);

        await SendAsync(mailMessage);
    }

    private MimeMessage CreateEmailMessage(Message message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(MailboxAddress.Parse(_emailConfig.From));
        emailMessage.To.AddRange(message.To);
        emailMessage.Subject = message.Subject;

        var bodyBuilder = new BodyBuilder { HtmlBody = $"<h2 style='color:red;'>{message.Content}</h2>" };

        if (message.Attachments != null && message.Attachments.Any())
        {
            byte[] fileBytes;
            foreach (var attachment in message.Attachments)
            {
                using (var ms = new MemoryStream())
                {
                    attachment.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }

                bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
            }
        }

        emailMessage.Body = bodyBuilder.ToMessageBody();
        return emailMessage;
    }

    private void Send(MimeMessage mailMessage)
    {
        using var client = new SmtpClient();

        client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
        client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

        client.Send(mailMessage);
        client.Disconnect(true);
    }

    private async Task SendAsync(MimeMessage mailMessage)
    {
        using var client = new SmtpClient();

        await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
        await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

        await client.SendAsync(mailMessage);
        await client.DisconnectAsync(true);
    }
}
