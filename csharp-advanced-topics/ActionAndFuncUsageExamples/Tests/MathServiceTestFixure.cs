using FuncUsageExample;
using System;


namespace Tests
{
    public class MathServiceTestFixure : IDisposable
    {
        public IMathService Sut { get; private set; }
        public MathServiceTestFixure()
        {
            Sut = new MathService();

            // In actual application, dependencies will be mocked
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
