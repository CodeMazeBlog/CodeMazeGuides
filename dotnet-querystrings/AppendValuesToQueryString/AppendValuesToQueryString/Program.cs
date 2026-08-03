using AppendValuesToQueryString;

var url = "https://test.com/Books?author=rowling&language=english#section1";

var queryParams = new Dictionary<string, string>
{
    {"genre", "science fiction" },
    {"author", "james martin" }
};

Console.WriteLine("\n***************** Modify Query String Using ParseQueryString Method ***************\n");
Console.WriteLine(QueryStringHelper.CreateURLUsingParseQueryString(url, queryParams));

Console.WriteLine("\n***************** Modify Query String Using ParseQuery Method ***************\n");
Console.WriteLine(QueryStringHelper.CreateURLUsingParseQuery(url, queryParams));

Console.WriteLine("\n***************** Append Query String Using AddQueryString Method ***************\n");
Console.WriteLine(QueryStringHelper.CreateURLUsingAddQueryString(url, new Dictionary<string, string?> { { "genre", "science fiction" } }));

Console.WriteLine("\n***************** Modify Query String Manually ***************\n");
Console.WriteLine(QueryStringHelper.CreateURL(url, queryParams));