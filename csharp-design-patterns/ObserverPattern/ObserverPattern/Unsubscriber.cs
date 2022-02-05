using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Unsubscriber : IDisposable
    {
        private List<IObserver<Application>> _observers;
        private IObserver<Application> _observer;

        public Unsubscriber(List<IObserver<Application>> observers, IObserver<Application> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
