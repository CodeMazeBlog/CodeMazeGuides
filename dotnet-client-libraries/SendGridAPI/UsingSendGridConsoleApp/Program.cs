//
// ****************** ATTENTION ******************
// This console application requires Docker configured to run Linux containers
//

using SendGrid;
using SendGrid.Helpers.Mail;
using UsingSendGridApi;
using UsingSendGridConsoleApp;

await using var helper = await SampleSetupAndConfigurationHelper.Create();

var client = new HttpClient
{
    BaseAddress = helper.ContainerUri
};
client.DefaultRequestHeaders.Add("authorization", $"Bearer {SampleConstants.ApiKey}");

Console.WriteLine("-----Sending simple email with HttpClient-----");
var (isSuccess, statusCode) = await client.SendSimpleEmail(SampleConstants.ToEmail, SampleConstants.FromEmail,
                                              SampleConstants.EmailSubject, SampleConstants.PlainTextEmailContent)
                                          .ConfigureAwait(false);

Console.WriteLine($"Success: {isSuccess}\tStatusCode: {statusCode}");
await PrintAndCleanUpSentMails(client).ConfigureAwait(false);

Console.WriteLine("-----Sending email with attachment with HttpClient-----");
(isSuccess, statusCode) = await client.SendEmailWithAttachment(SampleConstants.ToEmail, 
        SampleConstants.FromEmail, SampleConstants.EmailWithAttachmentSubject, helper.PdfFile, 
        "application/pdf", SampleConstants.PlainTextEmailContent, SampleConstants.HtmlEmailContent)
    .ConfigureAwait(false);

Console.WriteLine($"Success: {isSuccess}\tStatusCode: {statusCode}");
await PrintAndCleanUpSentMails(client).ConfigureAwait(false);

var toAddress = new EmailAddress(SampleConstants.ToEmail);
var fromAddress = new EmailAddress(SampleConstants.FromEmail);
var sendGridClient = new SendGridClient(SampleConstants.ApiKey, helper.ContainerUri!.AbsoluteUri);

Console.WriteLine("-----Sending simple email with SendGrid MailHelper class-----");
(isSuccess, statusCode) = await sendGridClient
    .SendMailUsingMailHelper(toAddress, fromAddress, SampleConstants.EmailSubject,
        SampleConstants.PlainTextEmailContent, null)
    .ConfigureAwait(false);

Console.WriteLine($"Success: {isSuccess}\tStatusCode: {statusCode}");
await PrintAndCleanUpSentMails(client).ConfigureAwait(false);

Console.WriteLine("-----Sending email and attachment with SendGrid MailHelper class-----");
(isSuccess, statusCode) = await sendGridClient
    .SendMailWithAttachment(toAddress, fromAddress, SampleConstants.EmailSubject,
        helper.PdfFile, "application/pdf", "PdfFile_1", false, SampleConstants.PlainTextEmailContent,
        SampleConstants.HtmlEmailContent)
    .ConfigureAwait(false);

Console.WriteLine($"Success: {isSuccess}\tStatusCode: {statusCode}");
await PrintAndCleanUpSentMails(client).ConfigureAwait(false);

Console.WriteLine("-----Sending scheduled email with SendGrid -----");
(isSuccess, statusCode) = await sendGridClient.SendScheduledEmail(toAddress, fromAddress, null, null,
        SampleConstants.EmailSubject, DateTime.Now.AddDays(1), SampleConstants.PlainTextEmailContent,
        SampleConstants.HtmlEmailContent)
    .ConfigureAwait(false);

Console.WriteLine($"Success: {isSuccess}\tStatusCode: {statusCode}");
await PrintAndCleanUpSentMails(client).ConfigureAwait(false);

Console.WriteLine();

static async Task PrintAndCleanUpSentMails(HttpClient client)
{
    Console.WriteLine("Sent mail:");
    var mails = await client.GetStringAsync("/api/mails").ConfigureAwait(false);
    Console.WriteLine(mails);
    await client.DeleteAsync("/api/mails").ConfigureAwait(false);
    Console.WriteLine();
}