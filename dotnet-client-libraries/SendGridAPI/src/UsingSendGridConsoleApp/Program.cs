//
// ****************** ATTENTION ******************
// This console application requires Docker configured to run Linux containers
//

using DotNet.Testcontainers.Builders;
using SendGrid;
using UsingSendGridApi;
using UsingSendGridApi.Utils;

const ushort testingPort = 3000;
const string apiKey = "SG.75a67731-b1ce-4254-b015-0c3a82c952b8";
const string emailSubject = "Sending Email with Twilio SendGrid is Fun!";
const string emailWithAttachmentSubject = "Sending Email with Attachment is Also Fun!";
const string toEmail = "john.smith@example.com";
const string fromEmail = "Jane.Doe@example.com";
const string plainTextEmailContent = "...and easy to do with C#!";
const string htmlEmailContent = "...and <strong>easy</strong> to do with C#!";

await using var pdfFile = await Utilities.CreateTemporaryFileWithSpecifiedSize(1024, "pdf");

var testContainer = new ContainerBuilder()
                   .WithImage(@"ghashange/sendgrid-mock:1.8.4")
                   .WithEnvironment("API_KEY", apiKey)
                   .WithPortBinding(testingPort, true)
                   .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(testingPort))
                   .Build();

await testContainer.StartAsync().ConfigureAwait(false);
var url = new UriBuilder("http", testContainer.Hostname, testContainer.GetMappedPublicPort(testingPort)).Uri;

var httpClient = new HttpClient
                 {
                     BaseAddress = url,
                 };
httpClient.DefaultRequestHeaders.Add("authorization", $"Bearer {apiKey}");

// ----- Sending Simple Email with HttpClient -----
Console.WriteLine("-----Sending simple email with HttpClient-----");
var (isSuccess, statusCode) = await httpClient.SendSimpleEmail(toEmail, fromEmail, emailSubject, plainTextEmailContent);
Console.WriteLine($"Success: {isSuccess}\tStatusCode: {statusCode}");
Console.WriteLine("Sent mail:");
var mails = await httpClient.GetStringAsync("/api/mails").ConfigureAwait(false);
Console.WriteLine(mails);
await httpClient.DeleteAsync("/api/mails").ConfigureAwait(false);
Console.WriteLine();

// ----- Sending Attachment with HttpClient -----
Console.WriteLine("-----Sending email with attachment with HttpClient-----");
(isSuccess, statusCode) = await httpClient.SendEmailWithAttachment(toEmail, fromEmail, emailWithAttachmentSubject,
                                                                   pdfFile.FileName, "application/pdf",
                                                                   plainTextEmailContent, htmlEmailContent);
Console.WriteLine($"Success: {isSuccess}\tStatusCode: {statusCode}");
Console.WriteLine("Sent mail:");
mails = await httpClient.GetStringAsync("/api/mails").ConfigureAwait(false);
Console.WriteLine(mails);
await httpClient.DeleteAsync("/api/mails").ConfigureAwait(false);
Console.WriteLine();

// ---------------------------- Using SendGridClient ----------------------------
var sendGridClient = new SendGridClient(apiKey, url.AbsoluteUri);

// ----- Using SendGrid MailHelper -----
Console.WriteLine("-----Sending simple email with SendGrid MailHelper class-----");
(isSuccess, statusCode) = await sendGridClient
                               .SendMailUsingMailHelper(toEmail, fromEmail, emailSubject, plainTextEmailContent, null)
                               .ConfigureAwait(false);

Console.WriteLine($"Success: {isSuccess}\tStatusCode: {statusCode}");
Console.WriteLine("Sent mail:");
mails = await httpClient.GetStringAsync("/api/mails").ConfigureAwait(false);
Console.WriteLine(mails);
await httpClient.DeleteAsync("/api/mails").ConfigureAwait(false);
Console.WriteLine();


// ----- Sending Attachment with SendGrid -----
Console.WriteLine("-----Sending email and attachment with SendGrid MailHelper class-----");
(isSuccess, statusCode) = await sendGridClient
                               .SendMailWithAttachment(toEmail, fromEmail, emailSubject, pdfFile.FileName,
                                                       "application/pdf", "PdfFile_1", false, plainTextEmailContent,
                                                       htmlEmailContent).ConfigureAwait(false);

Console.WriteLine($"Success: {isSuccess}\tStatusCode: {statusCode}");
Console.WriteLine("Sent mail:");
mails = await httpClient.GetStringAsync("/api/mails").ConfigureAwait(false);
Console.WriteLine(mails);
await httpClient.DeleteAsync("/api/mails").ConfigureAwait(false);
Console.WriteLine();

// ----- Sending Scheduled Email with SendGrid -----
Console.WriteLine("-----Sending scheduled email with SendGrid -----");
(isSuccess, statusCode) = await sendGridClient.SendScheduledEmail(toEmail, fromEmail, null, null, emailSubject,
                                                                  DateTime.Now.AddDays(1), plainTextEmailContent,
                                                                  htmlEmailContent).ConfigureAwait(false);

Console.WriteLine($"Success: {isSuccess}\tStatusCode: {statusCode}");
Console.WriteLine("Sent mail:");
mails = await httpClient.GetStringAsync("/api/mails").ConfigureAwait(false);
Console.WriteLine(mails);
await httpClient.DeleteAsync("/api/mails").ConfigureAwait(false);
Console.WriteLine();

await testContainer.StopAsync().ConfigureAwait(false);

Console.WriteLine();
Console.WriteLine("Finished");