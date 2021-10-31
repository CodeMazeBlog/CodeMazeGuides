using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests")]

namespace ActionAndFunc
{
    internal class Program
    {
        /// <summary>
        /// Summarize numbers
        /// Usage: 
        /// AdctionAndFunc.exe <summarizing function name> <final action name> <list of numbers>
        /// Examples: 
        /// AdctionAndFunc.exe sum print 1 2 3
        /// AdctionAndFunc.exe mul save 3.21 4.65 5ty -5 // invalid numbers are ignored
        /// </summary>
        /// <param name="args"></param>
        /// <returns>
        /// 0: Process copleted successfully
        /// -1: Errors have occurred
        /// </returns>
        static internal int Main(string[] args)
        {
            try
            {
                var (function, action, numbers) = ProcessInputs(args);
                var summary = Summary(numbers, _functions[function]);
                _actions[action](summary);
                return 0;
            }
            catch { return -1; }
        }

        static internal (string, string, double[]) ProcessInputs(string[] args) => 
            (args[0].ToUpperInvariant(),
            args[1].ToUpperInvariant(),
            args[2..]
            .Select(arg => (double.TryParse(arg, out var val), val))
            .Where(((bool isNumber, double _) arg) => arg.isNumber)
            .Select(((bool _, double val) arg) => arg.val)
            .ToArray());

        static internal double Summary(double[] numbers, Func<double, double, double> summarizer) => numbers.Aggregate(summarizer);

        #region Available Functions and Actions
        static readonly Dictionary<string, Func<double, double, double>> _functions =
            new Dictionary<string, Func<double, double, double>>
            {
                {"SUM", (double x1, double x2) => x1 + x2 },
                {"MUL", (double x1, double x2) => x1 * x2 },
                {"SQR",
                    (double x1, double x2) => {
                        var sumSquared = x1 * x1 + x2 * x2;
                        return Math.Sqrt(sumSquared);
                    }
                },
            };

        static readonly Dictionary<string, Action<double>> _actions =
            new Dictionary<string, Action<double>>
            {
                {"PRINT", (double x) => Console.WriteLine(x) },
                {"SAVE",
                    (double x) => {
                        var file = Path.GetTempFileName();
                        File.WriteAllText(file, x.ToString());
                    }
                },
            };
        #endregion
    }
}
