using System.Diagnostics;
using System.Text;

var luckyNumber = 3;

Console.WriteLine(luckyNumber);
Console.WriteLine(luckyNumber.ToString());
Console.WriteLine(Convert.ToString(luckyNumber));
Console.WriteLine(string.Format("This is our number {0}", luckyNumber));
Console.WriteLine($"This is our number {luckyNumber}");
Console.WriteLine(string.Concat(string.Empty, luckyNumber));
Console.WriteLine(string.Join(string.Empty, luckyNumber));
Console.WriteLine(string.Empty + luckyNumber);
Console.WriteLine(luckyNumber + luckyNumber + string.Empty + luckyNumber + luckyNumber);
Console.WriteLine(new StringBuilder().Append(luckyNumber).ToString());

var repsV1 = 20000;
var repsV2 = 1000000000;
const int formatOffsetLeft = 23;
const int formatOffsetRight = 10;
StringBuilder benchmarkResultsBuilder = new StringBuilder($"\r\nBenchmarks with {repsV1:N0} repetitions: \r\n")
    .AppendLine($"|{"Method",formatOffsetLeft} | {"Speed (ms)",formatOffsetRight}|")
    .AppendLine($"|{"-----------------------",formatOffsetLeft}-|-{"----------",formatOffsetRight}|")
    .AppendLine(BenchmarkToString(luckyNumber, repsV1))
    .AppendLine(BenchmarkConvertToString(luckyNumber, repsV1))
    .AppendLine(BenchmarkStringFormat(luckyNumber, repsV1))
    .AppendLine(BenchmarkStringInterpolation(luckyNumber, repsV1))
    .AppendLine(BenchmarkStringConcat(luckyNumber, repsV1))
    .AppendLine(BenchmarkStringJoin(luckyNumber, repsV1))
    .AppendLine(BenchmarkPlusSign(luckyNumber, repsV1))
    .AppendLine(BenchmarkStringBuilderAppend(luckyNumber, repsV1))
    .AppendLine($"\r\n \r\nBenchmarks with {repsV2:N0} repetitions:")
    .AppendLine($"|{"Method",formatOffsetLeft} | {"Speed (ms)",formatOffsetRight}|")
    .AppendLine($"|{"-----------------------",formatOffsetLeft}-|-{"----------",formatOffsetRight}|")
    .AppendLine(BenchmarkToString(luckyNumber, repsV2))
    .AppendLine(BenchmarkConvertToString(luckyNumber, repsV2))
    .AppendLine(BenchmarkStringFormat(luckyNumber, repsV2))
    .AppendLine(BenchmarkStringInterpolation(luckyNumber, repsV2))
    .AppendLine(BenchmarkStringConcat(luckyNumber, repsV2))
    .AppendLine(BenchmarkStringJoin(luckyNumber, repsV2))
    .AppendLine(BenchmarkPlusSign(luckyNumber, repsV2))
    .AppendLine(BenchmarkStringBuilderAppend(luckyNumber, repsV2));
Console.WriteLine(benchmarkResultsBuilder.ToString());

Console.ReadLine();

#region Benchmark Methods
static string BenchmarkToString(int num, int reps)
{
    var watch = new Stopwatch();
    watch.Start();
    for (int i = 0; i < reps; i++)
    {
        var tmpResult = num.ToString();
    }
    watch.Stop();

    return $"|{"'ToString'",formatOffsetLeft} | {watch.ElapsedMilliseconds,formatOffsetRight:N0}|";
}
static string BenchmarkConvertToString(int num, int reps)
{
    var watch = new Stopwatch();
    watch.Start();
    for (int i = 0; i < reps; i++)
    {
        var tmpResult = num.ToString();
    }
    watch.Stop();

    return $"|{"'ConvertToString'",formatOffsetLeft} | {watch.ElapsedMilliseconds,formatOffsetRight:N0}|";
}
static string BenchmarkStringFormat(int num, int reps)
{
    var watch = new Stopwatch();
    watch.Start();
    for (int i = 0; i < reps; i++)
    {
        var tmpResult = string.Format("{0}", num);
    }
    watch.Stop();

    return $"|{"'String.Format'",formatOffsetLeft} | {watch.ElapsedMilliseconds,formatOffsetRight:N0}|";
}
static string BenchmarkStringInterpolation(int num, int reps)
{
    var watch = new Stopwatch();
    watch.Start();
    for (int i = 0; i < reps; i++)
    {
        var tmpResult = $"{num}";
    }
    watch.Stop();

    return $"|{"'String Interpolation'",formatOffsetLeft} | {watch.ElapsedMilliseconds,formatOffsetRight:N0}|";
}
static string BenchmarkStringConcat(int num, int reps)
{
    var watch = new Stopwatch();
    watch.Start();
    for (int i = 0; i < reps; i++)
    {
        var tmpResult = string.Concat(string.Empty, num);
    }
    watch.Stop();

    return $"|{"'String.Concat'",formatOffsetLeft} | {watch.ElapsedMilliseconds,formatOffsetRight:N0}|";
}
static string BenchmarkStringJoin(int num, int reps)
{
    var watch = new Stopwatch();
    watch.Start();
    for (int i = 0; i < reps; i++)
    {
        var tmpResult = string.Join(string.Empty, num);
    }
    watch.Stop();

    return $"|{"'String.Join'",formatOffsetLeft} | {watch.ElapsedMilliseconds,formatOffsetRight:N0}|";
}
static string BenchmarkPlusSign(int num, int reps)
{
    var watch = new Stopwatch();
    watch.Start();
    for (int i = 0; i < reps; i++)
    {
        var tmpResult = string.Empty + num;
    }
    watch.Stop();

    return $"|{"'Plus sign'",formatOffsetLeft} | {watch.ElapsedMilliseconds,formatOffsetRight:N0}|";
}
static string BenchmarkStringBuilderAppend(int num, int reps)
{
    var watch = new Stopwatch();
    watch.Start();
    for (int i = 0; i < reps; i++)
    {
        var tmpResult = new StringBuilder().Append(num).ToString();
    }
    watch.Stop();

    return $"|{"'Stringbuilder Append'",formatOffsetLeft} | {watch.ElapsedMilliseconds,formatOffsetRight:N0}|";
}
#endregion




