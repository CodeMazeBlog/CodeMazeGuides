using BenchmarkDotNet.Running;
using HowtoUseStringPool;
using HowToUseStringPool.Benchmark;

const int POOL_SIZE = 256;

var stringPoolHelper = new StringPoolHelper();
var referenceEquals = stringPoolHelper.Init(POOL_SIZE);
Console.WriteLine("Reference Equals : {0}", referenceEquals);

var size = stringPoolHelper.GetPoolSize();
Console.WriteLine("GetPoolSize : {0}", size);

referenceEquals = StringPoolHelper.UseSharedInstance();
Console.WriteLine("Shared Reference Equals : {0}", referenceEquals);

var userAdded = stringPoolHelper.AddUser("Mark Twain", "mark.twain@example.com");
Console.WriteLine("AddUser : {0}", userAdded);

var email = stringPoolHelper.GetUser("Mark Twain");
Console.WriteLine("GetUser : {0}", email);

var hostname = stringPoolHelper.GetHostName("https://code-maze.com/code-maze-weekly-200/");
Console.WriteLine("GetHostName : {0}", hostname);

var request = GetRequest();
var headerValue = StringPoolHelper.GetHeaderValue(request, "Authorization");
Console.WriteLine("GetHeaderValue : {0}", headerValue);

var checkResult = StringPoolHelper.CheckHeader(request);
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