using LockingMechanismInCSharp;

namespace Tests
{
    [TestClass]
    public class LockingMechanismInCSharpTests
    {
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
        public void WhenMultithreadWithMonitorClass_ThenCorrectResultOfIncrements()
        {
            var result = MonitorClass.Execute();

            Assert.AreEqual(result, 300000);
        }

        [TestMethod]
        public void WhenMultithreadWithMutexClass_ThenCorrectResultOfIncrements()
        {
            var result = MutexClass.Execute();

            Assert.AreEqual(result, 300000);
        }

        [TestMethod]
        public void WhenMultithreadWithSpinLock_ThenCorrectResultOfIncrements()
        {
            var result = SpinLockClass.Execute();

            Assert.AreEqual(result, 300000);
        }

        [TestMethod]
        public void WhenMultithreadWithReaderWriterSlimLock_ThenCorrectResultOfIncrements()
        {
            var result = ReaderWriterLockSlimClass.Execute();

            Assert.AreEqual(result, 30);
        }
    }
}