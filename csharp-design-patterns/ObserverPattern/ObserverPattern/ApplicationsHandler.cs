using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class ApplicationsHandler : IObservable<Application>
    {
        private List<IObserver<Application>> Observers { get; set; }
        public List<Application> Applications { get; set; }

        public ApplicationsHandler()
        {
            Observers = new();
            Applications = new();
        }

        public IDisposable Subscribe(IObserver<Application> observer)
        {
            // Check whether observer is already registered. If not, add it
            if (!Observers.Contains(observer))
            {
                Observers.Add(observer);
                // Provide observer with existing data.
                foreach (var item in Applications)
                    observer.OnNext(item);
            }
            return new Unsubscriber(Observers, observer);
        }

        public void CloseApplications()
        {
            foreach (var observer in Observers)
                observer.OnCompleted();

            Observers.Clear();
        }

        public void AddApplication(Application app)
        {
            Applications.Add(app);
            foreach (var observer in Observers)
                observer.OnNext(app);
        }
    }
}
