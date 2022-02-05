using System;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var observer1 = new HRSpecialist("Bill");
            var observer2 = new HRSpecialist("John");
            var observer3 = new HRSpecialist("Sarah");

            var provider = new ApplicationsHandler();

            observer1.Subscribe(provider);
            observer2.Subscribe(provider);
            provider.AddApplication(new(1, "Jesus"));
            provider.AddApplication(new(2, "Farah"));

            observer1.ListApplications();
            observer2.ListApplications();
            observer3.ListApplications();

            observer1.Unsubscribe();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"{observer1.Name} unsubscribed");
            Console.WriteLine(Environment.NewLine);

            provider.AddApplication(new(3, "Ahmed"));

            observer1.ListApplications();
            observer2.ListApplications();
            observer3.ListApplications();

            Console.WriteLine(Environment.NewLine);

            provider.CloseApplications();
        }
    }
}
