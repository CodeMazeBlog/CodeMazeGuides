using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncInCSharp
{
    public static class DataProcessorFunc
    {
        public static string ProcessData(string data, Func<string, string> processingFunc)
        {
            Console.WriteLine($"Preparing to process data: {data}");
            return processingFunc(data);
        }
    }
}
