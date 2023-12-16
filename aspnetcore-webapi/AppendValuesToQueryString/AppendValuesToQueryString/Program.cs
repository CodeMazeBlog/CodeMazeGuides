using AppendValuesToQueryString;

var url = "https://test.com/Books?author=rowling&language=english";

var queryParams = new Dictionary<string, string>
{
    {"genre", "fantasy" },
    {"author", "james" }
};

Console.WriteLine("\n***************** Modify Query String ParseQueryString Method ***************\n");
Console.WriteLine(QueryStringHelper.CreateURLUsingParseQueryString(url, queryParams));

Console.WriteLine("\n***************** Modify Query String ParseQuery Method ***************\n");
Console.WriteLine(QueryStringHelper.CreateURLUsingParseQuery(url, queryParams));

Console.WriteLine("\n***************** Modify Query String AddQueryString Method ***************\n");
Console.WriteLine(QueryStringHelper.CreateURLUsingAddQueryString(url, new Dictionary<string, string?> { { "genre", "fantasy" } }));

Console.WriteLine("\n***************** Modify Query String Manually ***************\n");
Console.WriteLine(QueryStringHelper.CreateURL(url, queryParams));