using LockingMechanismInCSharp;

namespace Tests
{
    [TestClass]
    public class LockingMechanismInCSharpTests
    {
        [TestMethod]
        public void WhenMultithreadWithoutLock_ThenDifferentResultSmallerThan3000()
        {
            var result = MultithreadWithoutLocking.Execute();

            Assert.IsTrue(result < 300000, "Result is not smaller than 300000");
        }

        [TestMethod]
        public void WhenMultithreadWithInterlockedClass_ThenCorrectResultOfIncrements()
        {
            var result = InterlockedClass.Execute();

            Assert.AreEqual(result, 300000);
        }

        [TestMethod]
        public void WhenMultithreadWithLockStatement_ThenCorrectResultOfIncrements()
        {
            var result = LockStatement.Execute();

            Assert.AreEqual(result, 300000);
        }

        [TestMethod]
        public void WhenMultithreadWitMonitorClass_ThenCorrectResultOfIncrements()
        {
            var result = MonitorClass.Execute();

            Assert.AreEqual(result, 300000);
        }

        [TestMethod]
        public void WhenMultithreadWithSpinLock_ThenCorrectResultOfIncrements()
        {
            var result = SpinLockClass.Execute();

            Assert.AreEqual(result, 300000);
        }

        [TestMethod]
        public void WhenMultithreadWithReaderWriterLock_ThenCorrectResultOfIncrements()
        {
            var result = ReaderWriterLockClass.Execute();

            Assert.AreEqual(result, 30);
        }

        [TestMethod]
        public void WhenMultithreadWitNestedLock_ThenCorrectResultOfIncrements()
        {
            var result = NestedLock.Execute();

            Assert.AreEqual(result, 300000);
        }
    }
}