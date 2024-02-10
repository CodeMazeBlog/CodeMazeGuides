using BenchmarkDotNet.Running;
using HowtoUseStringPool;
using HowToUseStringPool.Benchmark;

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

var message = stringPoolHelper.Translate("TEST", "en-US");
Console.WriteLine("Translate : {0}", message);

BenchmarkRunner.Run<HowtoUseStringPoolBenchmark>();

static HttpRequestMessage GetRequest()
{
    var request = new HttpRequestMessage(HttpMethod.Get, "https://code-maze.com/");
    request.Headers.Add("User-Agent", "chrome");
    request.Headers.Add("Authorization", "Bearer access_token");

    return request;
}