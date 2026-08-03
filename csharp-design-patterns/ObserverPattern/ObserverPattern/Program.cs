using System;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var observer1 = new HRSpecialist("Bill");
            var observer2 = new HRSpecialist("John");

            var provider = new ApplicationsHandler();

            observer1.Subscribe(provider);
            observer2.Subscribe(provider);
            provider.AddApplication(new(1, "Jesus"));
            provider.AddApplication(new(2, "John"));

            observer1.ListApplications();
            observer2.ListApplications();

            observer1.Unsubscribe();

            Console.WriteLine();
            Console.WriteLine($"{observer1.Name} unsubscribed");
            Console.WriteLine();

            provider.AddApplication(new(3, "Sofia"));

            observer1.ListApplications();
            observer2.ListApplications();

            Console.WriteLine();

            provider.CloseApplications();
        }
    }
}
