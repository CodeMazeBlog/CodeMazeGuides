using System;
using System.Text;
using System.Diagnostics;

namespace ConvertInt2String
{
    public static class Benchmark
    {
        const int formatOffsetLeft = 23;
        const int formatOffsetRight = 10;

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

        public static string Run(int number, int repetitions)
        {
            var benchmarkResultsBuilder = new StringBuilder($"\r\nBenchmarks with {repetitions:N0} repetitions: \r\n")
                .AppendLine($"|{"Method",formatOffsetLeft} | {"Speed (ms)",formatOffsetRight}|")
                .AppendLine($"|{"-----------------------",formatOffsetLeft}-|-{"----------",formatOffsetRight}|")
                .AppendLine(BenchmarkToString(number, repetitions))
                .AppendLine(BenchmarkConvertToString(number, repetitions))
                .AppendLine(BenchmarkStringFormat(number, repetitions))
                .AppendLine(BenchmarkStringInterpolation(number, repetitions))
                .AppendLine(BenchmarkStringConcat(number, repetitions))
                .AppendLine(BenchmarkStringJoin(number, repetitions))
                .AppendLine(BenchmarkPlusSign(number, repetitions))
                .AppendLine(BenchmarkStringBuilderAppend(number, repetitions));

            return benchmarkResultsBuilder.ToString();
        }
    }
}
