using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using System.Text;

namespace DirectoryBrowsingInASPNETCore;

public class CustomDirectoryFormatter : IDirectoryFormatter
{
    public async Task GenerateContentAsync(HttpContext context, IEnumerable<IFileInfo> contents)
    {
        var html = new StringBuilder();
        html.Append("<h1>Browse the Catalogue</h1>");
        html.Append("<ul>");
        foreach (var item in contents)
        {
            html.Append("<li>");
            if (item.IsDirectory)
            {
                html.Append($"<a href=\"./{item.Name}/\">{item.Name}</a>");
            }
            else
            {
                html.Append($"{item.Name}");
            }
            html.Append("</li>");
        }
        html.Append("</ul>");

        var response = context.Response;
        response.ContentType = "text/html; charset=utf-8";

        await response.WriteAsync(html.ToString());
    }
}