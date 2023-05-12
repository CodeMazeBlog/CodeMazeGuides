using System.Net;
using SendGrid;
using SendGrid.Helpers.Mail;
using UsingSendGridApi.Utils;

namespace UsingSendGridApi;

public static class SendGridWithOfficialLibraryHelper
{
    public static async Task<(bool isSuccess, HttpStatusCode statusCode)> SendMailUsingMailHelper(
        this ISendGridClient sendGridClient, string to, string from, string subject, string? plainTextContent,
        string? htmlContent)
    {
        var message =
            MailHelper.CreateSingleEmail(from.ToEmail(), to.ToEmail(), subject, plainTextContent, htmlContent);
        var response = await sendGridClient.SendEmailAsync(message);

        return (response.IsSuccessStatusCode, response.StatusCode);
    }

    public static async Task<(bool isSuccess, HttpStatusCode statusCode)> SendMailWithAttachment(
        this ISendGridClient sendGridClient, string to, string from, string subject, string fileToAttach,
        string mimeType, string? contentId, bool inlineAttachment,
        string? plainTextContent, string? htmlContent)
    {
        var fileName = Path.GetFileName(fileToAttach);
        var attachment = new Attachment
                         {
                             Content = await Utilities.GetAttachmentFileContentsAsBase64(fileToAttach),
                             Filename = fileName,
                             Disposition = inlineAttachment ? "inline" : "attachment",
                             Type = mimeType,
                         };
        if (contentId is not null) attachment.ContentId = contentId;

        var message =
            MailHelper.CreateSingleEmail(from.ToEmail(), to.ToEmail(), subject, plainTextContent, htmlContent);
        message.Attachments = new List<Attachment>(new[] {attachment});
        var response = await sendGridClient.SendEmailAsync(message);

        return (response.IsSuccessStatusCode, response.StatusCode);
    }

    public static async Task<(bool isSucces, HttpStatusCode statusCode)> SendScheduledEmail(
        this ISendGridClient sendGridClient, string to, string from, string? cc, string? bcc, string subject,
        DateTime sendAt, string plainTextContent, string? htmlContent)

    {
        var personalizations = new List<Personalization>(new[]
                                                         {
                                                             new Personalization
                                                             {
                                                                 Tos = to.ToEmail().ToList(),
                                                                 Ccs = cc?.ToEmail().ToList(),
                                                                 Bccs = bcc?.ToEmail().ToList(),
                                                             },
                                                         });
        var message = new SendGridMessage
                      {
                          Personalizations = personalizations,
                          Subject = subject,
                          From = from.ToEmail(),
                          SendAt = sendAt.ToUnixTime(),
                          PlainTextContent = plainTextContent,
                          HtmlContent = htmlContent,
                      };
        var response = await sendGridClient.SendEmailAsync(message);

        return (response.IsSuccessStatusCode, response.StatusCode);
    }

    private static EmailAddress ToEmail(this string emailAddress) => MailHelper.StringToEmailAddress(emailAddress);

    private static List<EmailAddress> ToList(this EmailAddress address) => new(new[] {address});

    private static long ToUnixTime(this DateTime dateTime) => new DateTimeOffset(dateTime).ToUnixTimeSeconds();
}