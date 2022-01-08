using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RunCodeInNewThreadConsoleApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"{ThreadInfo.Log()} Starting up PDF validations");

            var tasks = new List<Task>();

            for (int i = 0; i <= 2; i++)
            {
                int instanceNumber = i;
                tasks.Add(Task.Run(() => new PdfValidator(instanceNumber).ValidateFile()).ContinueWith(LogResult));
            }

            Console.WriteLine($"{ThreadInfo.Log()} Now waiting for results...");

            await Task.WhenAll(tasks).ConfigureAwait(true);

            Console.WriteLine($"{ThreadInfo.Log()} All done.");

            Console.ReadKey();
        }

        private static void LogResult(Task<string> task)
        {
            Console.WriteLine($"{ThreadInfo.Log()} Is Valid: {task.Result}");
        }
    }
}
