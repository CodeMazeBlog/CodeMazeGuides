//
// ****************** ATTENTION ******************
// This console application requires Docker configured to run Linux containers
//

using SendGrid;
using SendGrid.Helpers.Mail;
using UsingSendGridApi;
using UsingSendGridConsoleApp;

await using var helper = new Helper();
await helper.Initialize();

Console.WriteLine("-----Sending simple email with HttpClient-----");
var (isSuccess, statusCode) = await helper.Client.SendSimpleEmail(Helper.ToEmail, Helper.FromEmail,
                                              Helper.EmailSubject,
                                              Helper.PlainTextEmailContent)
                                          .ConfigureAwait(false);
Console.WriteLine($"Success: {isSuccess}\tStatusCode: {statusCode}");
await helper.PrintAndCleanUpSentMails().ConfigureAwait(false);

Console.WriteLine("-----Sending email with attachment with HttpClient-----");
(isSuccess, statusCode) = await helper.Client
                                      .SendEmailWithAttachment(Helper.ToEmail, Helper.FromEmail,
                                          Helper.EmailWithAttachmentSubject,
                                          helper.PdfFile, "application/pdf", Helper.PlainTextEmailContent,
                                          Helper.HtmlEmailContent).ConfigureAwait(false);
Console.WriteLine($"Success: {isSuccess}\tStatusCode: {statusCode}");
await helper.PrintAndCleanUpSentMails().ConfigureAwait(false);

var toAddress = new EmailAddress(Helper.ToEmail);
var fromAddress = new EmailAddress(Helper.FromEmail);
var sendGridClient = new SendGridClient(Helper.ApiKey, helper.ContainerUri!.AbsoluteUri);

Console.WriteLine("-----Sending simple email with SendGrid MailHelper class-----");
(isSuccess, statusCode) = await sendGridClient
                                .SendMailUsingMailHelper(toAddress, fromAddress, Helper.EmailSubject,
                                    Helper.PlainTextEmailContent,
                                    null)
                                .ConfigureAwait(false);

Console.WriteLine($"Success: {isSuccess}\tStatusCode: {statusCode}");
await helper.PrintAndCleanUpSentMails().ConfigureAwait(false);

Console.WriteLine("-----Sending email and attachment with SendGrid MailHelper class-----");
(isSuccess, statusCode) = await sendGridClient
                                .SendMailWithAttachment(toAddress, fromAddress, Helper.EmailSubject, helper.PdfFile,
                                    "application/pdf", "PdfFile_1", false, Helper.PlainTextEmailContent,
                                    Helper.HtmlEmailContent).ConfigureAwait(false);

Console.WriteLine($"Success: {isSuccess}\tStatusCode: {statusCode}");
await helper.PrintAndCleanUpSentMails().ConfigureAwait(false);

Console.WriteLine("-----Sending scheduled email with SendGrid -----");
(isSuccess, statusCode) = await sendGridClient.SendScheduledEmail(toAddress, fromAddress, null, null,
    Helper.EmailSubject,
    DateTime.Now.AddDays(1), Helper.PlainTextEmailContent,
    Helper.HtmlEmailContent).ConfigureAwait(false);

Console.WriteLine($"Success: {isSuccess}\tStatusCode: {statusCode}");
await helper.PrintAndCleanUpSentMails().ConfigureAwait(false);

Console.WriteLine();