using AppendValuesToQueryString;

var url = "https://test.com/api/Books?author=rowling&language=english";

var queryParams = new Dictionary<string, string>
{
    {"genre", "fantasy" },
    {"author", "james" }
};

Console.WriteLine(QueryStringHelper.CreateURLUsingParseQueryString(url, queryParams));

Console.WriteLine(QueryStringHelper.CreateURLUsingParseQuery(url, queryParams));

Console.WriteLine(QueryStringHelper.CreateURLUsingAddQueryString(url, new Dictionary<string, string?> { { "genre", "fantasy" } }));