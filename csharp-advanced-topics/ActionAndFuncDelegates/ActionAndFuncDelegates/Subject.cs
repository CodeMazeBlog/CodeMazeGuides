namespace ActionAndFuncDelegates
{
    public class Subject<T>
    {
        private List<Action<T>> _observers = new List<Action<T>>();

        public void Subscribe(Action<T> observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(Action<T> observer)
        {
            _observers.Remove(observer);
        }

        public void Next(T state)
        {
            foreach (Action<T> observer in _observers)
            {
                observer(state);
            }
        }
    }
}
