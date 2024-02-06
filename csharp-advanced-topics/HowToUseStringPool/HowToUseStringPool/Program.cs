using BenchmarkDotNet.Running;
using HowtoUseStringPool;
using HowToUseStringPool.Benchmark;

Environment.SetEnvironmentVariable("EncryptionPassword", "123abcd");

var stringPoolHelper = new StringPoolHelper();
var referenceEquals = stringPoolHelper.Init();
Console.WriteLine("Reference Equals : {0}", referenceEquals);

var userAdded = stringPoolHelper.AddUser("Mark Twain", "mark.twain@example.com");
Console.WriteLine("AddUser : {0}", userAdded);

var email = stringPoolHelper.GetUser("Mark Twain");
Console.WriteLine("GetUser : {0}", email);

var hostname = stringPoolHelper.GetHostName("https://code-maze.com/code-maze-weekly-200/");
Console.WriteLine("GetHostName : {0}", hostname);

var request = GetRequest();
var headerValue = stringPoolHelper.GetHeaderValue(request, "Authorization");
Console.WriteLine("GetHeaderValue : {0}", headerValue);

var checkResult = stringPoolHelper.CheckHeader(request);
Console.WriteLine("CheckHeader : {0}", checkResult);

var tokenResult = stringPoolHelper.CheckToken(request);
Console.WriteLine("CheckToken : {0}", tokenResult);

var encrypted = stringPoolHelper.Encrypt("CodeMaze");
Console.WriteLine("Encrypt : {0}", encrypted);

var message = stringPoolHelper.Translate("TEST", "en-US");
Console.WriteLine("Translate : {0}", message);

var contentResult = stringPoolHelper.CheckContent("lorem badword2 ipsum");
Console.WriteLine("CheckContent : {0}", contentResult);

var validationResult = stringPoolHelper.IsValidEmail("a.b@example.com");
Console.WriteLine("IsValidEmail : {0}", validationResult);

stringPoolHelper.LogError("Invalid Age");
Console.WriteLine("Log Count : {0}", stringPoolHelper.GetLogCount());

BenchmarkRunner.Run<HowtoUseStringPoolBenchmark>();

Console.ReadLine();

static HttpRequestMessage GetRequest()
{
    var request = new HttpRequestMessage(HttpMethod.Get, "https://code-maze.com/");
    request.Headers.Add("User-Agent", "chrome");
    request.Headers.Add("Authorization", "Bearer access_token");

    return request;
}