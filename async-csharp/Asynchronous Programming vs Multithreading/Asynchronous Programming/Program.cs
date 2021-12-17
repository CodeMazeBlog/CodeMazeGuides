using System;
using System.Text;

namespace AsynchronousProgramming
{
    public class Program
    {
        public static async Task FirstAsync()
        {
            Console.WriteLine("First Async Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000);
        }
        public static async Task SecondAsync()
        {
            Console.WriteLine("Second Async Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000);
        }
        public static async Task ThirdAsync()
        {
            Console.WriteLine("Third Async Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000);
        }

        public static async Task ExecuteAsyncFunctions()
        {
            var firstAsync = FirstAsync();
            var secondAsync = SecondAsync();
            var thirdAsync = ThirdAsync();

            await firstAsync;
            await secondAsync;
            await thirdAsync;
        }

        static async Task Main(string[] args)
        {
          
            Console.WriteLine("Main method on thread with Id : " + Thread.CurrentThread.ManagedThreadId);

            DateTime dt = DateTime.Now;
            await ExecuteAsyncFunctions();
            var ts = DateTime.Now - dt;
            Console.WriteLine("Seconds taken: " + ts.Seconds);
        }
    }
}
