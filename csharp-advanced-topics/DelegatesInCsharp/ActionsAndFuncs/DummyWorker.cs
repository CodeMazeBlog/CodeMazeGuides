
namespace ActionsAndFuncs
{
    internal class DummyWorker
    {
        private readonly int _fakeValue;

        public DummyWorker(int fakeValue)
        {
            this._fakeValue = fakeValue;
        }

        public double DoTheFuncJob(Func<int, double> operation)
        {
            return operation(_fakeValue);
        }

        public void DoTheActionJob(Action<double> operation)
        {
            operation(_fakeValue);
        }
    }
}
