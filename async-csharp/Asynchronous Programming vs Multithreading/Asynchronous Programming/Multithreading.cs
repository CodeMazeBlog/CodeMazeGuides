namespace Asynchronous_Programming
{
    public class Multithreading
    {
        public void FirstMethod()
        {
            Console.WriteLine("First Multithreading Method on Thread with Id: " + Environment.CurrentManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("First Multithreading Method Continuation on Thread with Id: " + Environment.CurrentManagedThreadId);
        }

        public void SecondMethod()
        {
            Console.WriteLine("Second Multithreading Method on Thread with Id: " + Environment.CurrentManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("Second Multithreading Method Continuation on Thread with Id: " + Environment.CurrentManagedThreadId);
        }

        public void ThirdMethod()
        {
            Console.WriteLine("Third Multithreading Method on Thread with Id: " + Environment.CurrentManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("Third Multithreading Method Continuation on Thread with Id: " + Environment.CurrentManagedThreadId);
        }

        public void ExecuteMultithreading()
        {
            Thread t1 = new Thread(FirstMethod);
            Thread t2 = new Thread(SecondMethod);
            Thread t3 = new Thread(ThirdMethod);

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();
        }
    }
}
