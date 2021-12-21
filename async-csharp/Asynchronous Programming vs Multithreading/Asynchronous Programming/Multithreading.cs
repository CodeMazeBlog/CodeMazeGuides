using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous_Programming
{
    public class Multithreading
    {
        public void ExecuteMultithreading()
        {
            Thread t1 = new Thread(new ThreadStart(FirstMethod));
            Thread t2 = new Thread(new ThreadStart(SecondMethod));
            Thread t3 = new Thread(new ThreadStart(ThirdMethod));

            t1.Start();
            t2.Start();
            t3.Start();

        }

        public void FirstMethod()
        {
            Console.WriteLine("First Multithreading Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
        }

        public void SecondMethod()
        {
            Console.WriteLine("Second Multithreading Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
        }
        
        public void ThirdMethod()
        {
            Console.WriteLine("Third Multithreading Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
        }
    }
}
