using QueryStringParametersWithMinimalAPIs;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

app.MapGet("/search1", (string author, int yearPublished) =>
{
    return $"Author: {author}, Year published: {yearPublished}";
});

app.MapGet("/search2", ArticleMapping);

string ArticleMapping(string author = "N/A", int yearPublished = 0) 
{
    return $"Author: {author}, Year published: {yearPublished}";
}

app.MapGet("/search3", (SearchCriteria criteria) =>
{
    return $"Author: {criteria.Author}, Year published: {criteria.YearPublished}";
});

app.MapGet("/search4", (string ids) =>
{
    var idList = new List<int>();
    var trimmedValue = ids?.TrimStart('(').TrimEnd(')');
    var segments = trimmedValue?.Split(',',
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

    if (segments == null)
        return "No ids!";

    foreach (var segment in segments)
    {
        int.TryParse(segment, out var id);
        idList.Add(id);
    }

    //now print the ids
    var text = new StringBuilder();
    foreach (var id in idList)
    {
        text.Append(id + " ");
    }
    return $"IDs: {text.ToString()}";
});

app.MapGet("/search5", (ArticleIDs ids) =>
{
    var text = new StringBuilder();
    foreach(var id in ids.IDs)
    {
        text.Append(id + " ");
    }
    return $"IDs: {text.ToString()}";
});

app.Run();

// Make the implicit Program class public so test projects can access it
public partial class Program { }