using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using ConvertString2Int;

namespace BenchmarkRunner
{
    public class ConvertString2IntBenchmark
    {
        public string strValue = "3";
        public int number = 0;

        [Benchmark]
        public void BenchmarkIntParse()
        {
            number = int.Parse(strValue);
        }

        [Benchmark]
        public void BenchmarkIntTryParse()
        {
            int.TryParse(strValue, out number);
        }

        [Benchmark]
        public void BenchmarkConvertToInt32()
        {
            number = Convert.ToInt32(strValue);
        }

        [Benchmark]
        public void BenchmarkCustomConvert()
        {
            number = CustomConvert.Parse(strValue);
        }
    }
}
