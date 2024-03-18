using BenchmarkDotNet.Running;
using HowtoUseStringPool;
using HowToUseStringPool.Benchmark;

const int poolSize = 256;

var stringPoolHelper = new StringPoolHelper();
var referenceEquals = stringPoolHelper.Init(poolSize);
Console.WriteLine($"Reference Equals : {referenceEquals}");

var size = stringPoolHelper.GetMyPoolSize();
Console.WriteLine($"GetPoolSize : {size}");

referenceEquals = StringPoolHelper.UseSharedInstance();
Console.WriteLine($"Shared Reference Equals : {referenceEquals}");

var userAdded = stringPoolHelper.AddUser("Mark Twain", "mark.twain@example.com");
Console.WriteLine($"AddUser : {userAdded}");

var email = stringPoolHelper.GetUser("Mark Twain");
Console.WriteLine($"GetUser : {email}");

var hostname = StringPoolHelper.GetHostName("https://code-maze.com/code-maze-weekly-200/");
Console.WriteLine($"GetHostName : {hostname}");

var message = stringPoolHelper.Translate("TEST", "en-US");
Console.WriteLine($"Translate : {message}");

BenchmarkRunner.Run<HowtoUseStringPoolBenchmark>();