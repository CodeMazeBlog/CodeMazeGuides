
namespace ActionsAndFuncs
{
    internal class DummyWorker
    {
        private readonly int fakeValue;

        public DummyWorker(int fakeValue)
        {
            this.fakeValue = fakeValue;
        }

        public double DoTheFuncJob(Func<int, double> operation)
        {
            //You'll do a heavy work here ^_^
            return operation(fakeValue);
        }

        public void DoTheActionJob(Action<double> operation)
        {
            operation(fakeValue);
        }
    }
}
