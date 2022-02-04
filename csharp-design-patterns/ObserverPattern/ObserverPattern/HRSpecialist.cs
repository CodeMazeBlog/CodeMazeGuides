using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class HRSpecialist : IObserver<Application>
    {
        private IDisposable cancellation;

        public HRSpecialist(string name)
        {
            Name = name;
            Applications = new();
        }

        public string Name { get; set; }
        public List<Application> Applications { get; set; }

        public virtual void Subscribe(ApplicationsHandler provider)
        {
            cancellation = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            cancellation.Dispose();
            Applications.Clear();
        }

        public void OnCompleted()
        {
            Console.WriteLine($"Hey, {Name}! We are not accepting any more applications");
        }

        public void OnError(Exception error)
        {
            // This is called by the provider if any exception is raised, no need to implement it here
        }

        public void OnNext(Application value)
        {
            Applications.Add(value);
        }

        public void ListApplications()
        {
            foreach (var app in Applications)
                Console.WriteLine($"Hey, {Name}! {app.ApplicantName} has just applied for job no. {app.JobId}");
            if(Applications.Count < 1)
                Console.WriteLine($"Hey, {Name}! No applications yet.");
        }
    }
}
