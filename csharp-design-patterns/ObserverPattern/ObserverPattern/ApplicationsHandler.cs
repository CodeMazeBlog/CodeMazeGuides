using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    public class ApplicationsHandler : IObservable<Application>
    {
        private readonly List<IObserver<Application>> _observers;
        public List<Application> Applications { get; set; }

        public ApplicationsHandler()
        {
            _observers = new();
            Applications = new();
        }

        public IDisposable Subscribe(IObserver<Application> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                foreach (var item in Applications)
                    observer.OnNext(item);
            }
            return new Unsubscriber(_observers, observer);
        }

        public void AddApplication(Application app)
        {
            Applications.Add(app);
            foreach (var observer in _observers)
                observer.OnNext(app);
        }

        public void CloseApplications()
        {
            foreach (var observer in _observers)
                observer.OnCompleted();

            _observers.Clear();
        }
    }
}
