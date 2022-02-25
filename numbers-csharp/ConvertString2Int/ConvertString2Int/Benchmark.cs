using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertString2Int
{
    public static class Benchmark
    {
        const int formatOffsetLeft = -19;
        const int formatOffsetRight = 13;

        static string BenchmarkIntParse(string strValue, int reps)
        {
            int number;
            var watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < reps; i++)
            {
                number = int.Parse(strValue);
            }
            watch.Stop();

            return $"|{"'IntParse'",formatOffsetLeft} | {watch.ElapsedMilliseconds,formatOffsetRight:N0}|";
        }
        static string BenchmarkIntTryParse(string strValue, int reps)
        {
            int number;
            var watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < reps; i++)
            {
                number = int.TryParse(strValue, out number) ? number : 0;
            }
            watch.Stop();

            return $"|{"'IntTryParse'",formatOffsetLeft} | {watch.ElapsedMilliseconds,formatOffsetRight:N0}|";
        }
        static string BenchmarkConvertToInt32(string strValue, int reps)
        {
            int number;
            var watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < reps; i++)
            {
                number = Convert.ToInt32(strValue);
            }
            watch.Stop();

            return $"|{"'Convert ToInt32'",formatOffsetLeft} | {watch.ElapsedMilliseconds,formatOffsetRight:N0}|";
        }
        static string BenchmarkCustomConvert(string strValue, int reps)
        {
            int number;
            var watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < reps; i++)
            {
                number = CustomConvert.Parse(strValue);
            }
            watch.Stop();

            return $"|{"'Custom Convert'",formatOffsetLeft} | {watch.ElapsedMilliseconds,formatOffsetRight:N0}|";
        }

        public static string Run(string strValue, int repetitions)
        {
            var benchmarkResultsBuilder = new StringBuilder($"\r\nBenchmarks with {repetitions:N0} repetitions: \r\n")
                .AppendLine($"|{"Method",formatOffsetLeft} | {"Speed (ms)",formatOffsetRight}|")
                .AppendLine($"|{"-------------------",formatOffsetLeft}-|-{"-------------",formatOffsetRight}|")
                .AppendLine(BenchmarkIntParse(strValue, repetitions))
                .AppendLine(BenchmarkIntTryParse(strValue, repetitions))
                .AppendLine(BenchmarkConvertToInt32(strValue, repetitions))
                .AppendLine(BenchmarkCustomConvert(strValue, repetitions));

            return benchmarkResultsBuilder.ToString();
        }
    }
}
