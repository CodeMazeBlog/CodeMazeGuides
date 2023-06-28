using System.Net;
using System.Text;
using UsingSendGridApi.Utils;

namespace UsingSendGridApi;

public static class SendGridWithHttpClientHelper
{
    private const string ContentHelper = "{{\"type\":\"{0}\",\"value\":\"{1}\"}}";
    private const string PlainTextContent = "text/plain";
    private const string HtmlContent = "text/html";
    private const string JsonContent = "application/json";
    private const string SendUriEndpoint = "/v3/mail/send";

    public static async Task<(bool isSuccess, HttpStatusCode statusCode)> SendSimpleEmail(
        this HttpClient client, string to, string from, string subject,
        string plainTextContent)
    {
        var emailContent = "\"content\":[" + string.Format(ContentHelper, PlainTextContent, plainTextContent) + "]";
        var simpleSendRequestBody = $$"""
        {"personalizations":[{"to":[{"email":"{{to}}"}]}],"from":{"email":"{{from}}"},"subject":"{{subject}}",{{emailContent}}}
        """;

        using var content = new StringContent(simpleSendRequestBody, Encoding.UTF8, JsonContent);
        using var response = await client.PostAsync(SendUriEndpoint, content).ConfigureAwait(false);

        return (response.IsSuccessStatusCode, response.StatusCode);
    }

    public static async Task<(bool isSuccess, HttpStatusCode statusCode)> SendEmailWithAttachment(
        this HttpClient client, string to, string from, string subject, string fileToAttach, string fileMimeType,
        string plainTextContent,
        string? htmlContent = null)
    {
        var emailContent = "\"content\":[" + string.Format(ContentHelper, PlainTextContent, plainTextContent);
        if (string.IsNullOrEmpty(htmlContent))
            emailContent += "," + string.Format(ContentHelper, HtmlContent, htmlContent);
        emailContent += "]";

        var fileName = Path.GetFileName(fileToAttach);
        var fileContent = await Utilities.GetAttachmentContentsAsBase64(fileToAttach);

        var requestBody = $$"""
        {"personalizations":[{"to":[{"email":"{{to}}"}]}],"from":{"email":"{{from}}"},"subject":"{{subject}}","attachments":[{"content":"{{fileContent}}","type":"{{fileMimeType}}","filename":"{{fileName}}"}],{{emailContent}}}
        """;
        using var content = new StringContent(requestBody, Encoding.UTF8, JsonContent);
        using var response = await client.PostAsync(SendUriEndpoint, content).ConfigureAwait(false);

        return (response.IsSuccessStatusCode, response.StatusCode);
    }
}