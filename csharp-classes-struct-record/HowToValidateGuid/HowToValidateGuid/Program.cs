using BenchmarkDotNet.Running;
using HowToUseStringPool.Benchmark;
using HowToValidateGuid;

BenchmarkRunner.Run<HowToValidateGuidBenchmark>();

var guidString = Guid.NewGuid().ToString();
const string nonGuidString = "loremipsum-sid-dolar-amet-34648208e86d";
const string messageFormat = "{0} | guidString is {1}, nonGuidString is {2}";

Message("Regex", GuidHelper.ValidateWithRegex(guidString), GuidHelper.ValidateWithRegex(nonGuidString));

Message("GuidParse", GuidHelper.ValidateWithGuidParse(guidString), GuidHelper.ValidateWithGuidParse(nonGuidString));

const string formatKey = "D";

Message("GuidParseExact", GuidHelper.ValidateWithGuidParseExact(guidString, formatKey),
    GuidHelper.ValidateWithGuidParseExact(nonGuidString, formatKey));

Message("GuidTryParse", GuidHelper.ValidateWithGuidTryParse(guidString),
    GuidHelper.ValidateWithGuidTryParse(nonGuidString));

Message("GuidTryParseExact", GuidHelper.ValidateWithGuidTryParseExact(guidString, formatKey),
    GuidHelper.ValidateWithGuidTryParseExact(nonGuidString, formatKey));

Message("NewGuid", GuidHelper.ValidateWithNewGuid(guidString),
    GuidHelper.ValidateWithNewGuid(nonGuidString));

static void Message(string prefix, bool result1, bool result2)
{
    var guidInfo1 = result1 ? "GUID" : "not a GUID";
    var guidInfo2 = result2 ? "GUID" : "not a GUID";
    Console.WriteLine(messageFormat, prefix, guidInfo1, guidInfo2);
}