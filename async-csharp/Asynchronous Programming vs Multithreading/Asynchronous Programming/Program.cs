using Asynchronous_Programming;
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

            DateTime dt1 = DateTime.Now;
            await ExecuteAsyncFunctions();
            var ts1 = DateTime.Now - dt1;
            Console.WriteLine("Seconds taken for asynchronous operation: " + ts1.Seconds + "\n");
          
            Multithreading multithreading = new Multithreading();
            DateTime dt2 = DateTime.Now;
            multithreading.ExecuteMultithreading();
            var ts2 = DateTime.Now - dt2;
            Console.WriteLine("Seconds taken for multithreading operation: " + ts2.Seconds);

        }
    }
}
