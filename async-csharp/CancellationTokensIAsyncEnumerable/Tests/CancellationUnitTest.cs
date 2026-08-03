using CancellationIAsyncEnumerable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class CancellationUnitTest
    {
        [TestMethod]
        public async Task GivenIndefinitelyRunningMethodCancelled_WhenMethodIsCalled_ThenCancellationOccurs()
        {
            await Assert.ThrowsExceptionAsync<TaskCanceledException>(() => Program.IndefinitelyRunningMethodCancelled());
        }

        [TestMethod]
        public async Task GivenIndefinitelyRunningWrappedMethodCancelled_WhenMethodIsCalled_ThenCancellationOccurs()
        {
            await Assert.ThrowsExceptionAsync<TaskCanceledException>(() => Program.IndefinitelyRunningWrappedMethodCancelled());
        }

    }
}
