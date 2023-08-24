namespace Asynchronous_Programming
{
    public class Multithreading
    {
        public void FirstMethod()
        {
            Console.WriteLine("First Multithreading Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("First Multithreading Method Continuation on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
        }

        public void SecondMethod()
        {
            Console.WriteLine("Second Multithreading Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("Second Multithreading Method Continuation on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
        }

        public void ThirdMethod()
        {
            Console.WriteLine("Third Multithreading Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("Third Multithreading Method Continuation on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
        }

        public void ExecuteMultithreading()
        {
            Thread t1 = new Thread(new ThreadStart(FirstMethod));
            Thread t2 = new Thread(new ThreadStart(SecondMethod));
            Thread t3 = new Thread(new ThreadStart(ThirdMethod));

            t1.Start();
            t2.Start();
            t3.Start();
        }
    }
}
