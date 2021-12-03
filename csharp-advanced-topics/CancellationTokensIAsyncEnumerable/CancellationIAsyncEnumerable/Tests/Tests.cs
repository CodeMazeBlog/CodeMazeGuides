using CancellationIAsyncEnumerable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public async Task GivenCancelledIndefiniteEnumerationExample_WhenMethodIsCalled_ThenCancellationOccurs()
        {
            await Assert.ThrowsExceptionAsync<TaskCanceledException>(() => Program.CancelledIndefiniteEnumerationExample());
        }

        [TestMethod]
        public async Task GivenCancelledIndefiniteEnumerationWithCancellationExample_WhenMethodIsCalled_ThenCancellationOccurs()
        {
            await Assert.ThrowsExceptionAsync<TaskCanceledException>(() => Program.CancelledIndefiniteEnumerationWithCancellationExample());
        }

    }
}
