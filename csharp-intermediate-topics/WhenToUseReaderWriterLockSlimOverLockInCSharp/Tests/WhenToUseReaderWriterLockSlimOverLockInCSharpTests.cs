using System.Reflection;
using WhenToUseReaderWriterLockSlimOverLockInCSharp;

namespace Tests
{
    [TestClass]
    public class WhenToUseReaderWriterLockSlimOverLockInCSharpTests
    {
        [TestMethod]
        public void WhenLockReadWriteAddNumberToList_ListCountIsEqualConfiguredValue()
        {
            var config = new Configuration();

            LockReadWrite.AddNumbersToList(config);

            Assert.AreEqual(config.writerExecutionsCount, LockReadWrite.ListOfNumbers.Count);

            LockReadWrite.ListOfNumbers.Clear();
        }

        [TestMethod]
        public void WhenLockReadWriteReadListCount_ListCountIsEqualZero()
        {
            var config = new Configuration();

            LockReadWrite.ReadListCount(config);

            Assert.AreEqual(0, LockReadWrite.ListOfNumbers.Count);
        }

        [TestMethod]
        public void WhenReaderWriterLockReadWriteAddNumberToList_ListCountIsEqualConfiguredValue()
        {
            var config = new Configuration();

            ReaderWriterLockReadWrite.AddNumbersToList(config);

            Assert.AreEqual(config.writerExecutionsCount, ReaderWriterLockReadWrite.ListOfNumbers.Count);

            ReaderWriterLockReadWrite.ListOfNumbers.Clear();
        }

        [TestMethod]
        public void WhenReaderWriterLockReadWriteReadListCount_ListCountIsEqualZero()
        {
            var config = new Configuration();

            ReaderWriterLockReadWrite.ReadListCount(config);

            Assert.AreEqual(0, ReaderWriterLockReadWrite.ListOfNumbers.Count);
        }

        [TestMethod]
        public void WhenReaderWriterLockSlimReadWriteAddNumberToList_ListCountIsEqualConfiguredValue()
        {
            var config = new Configuration();

            ReaderWriterLockSlimReadWrite.AddNumbersToList(config);

            Assert.AreEqual(config.writerExecutionsCount, ReaderWriterLockSlimReadWrite.ListOfNumbers.Count);

            ReaderWriterLockSlimReadWrite.ListOfNumbers.Clear();
        }

        [TestMethod]
        public void WhenReaderWriterLockSlimReadWriteReadListCount_ListCountIsEqualZero()
        {
            var config = new Configuration();

            ReaderWriterLockSlimReadWrite.ReadListCount(config);

            Assert.AreEqual(0, ReaderWriterLockSlimReadWrite.ListOfNumbers.Count);
        }

        [TestMethod]
        public void WhenReaderWriterLockSlimReadWriteReadOrWrite_ListCountIsEqualOne()
        {
            var config = new Configuration();

            ReaderWriterLockSlimReadWrite.ReadOrAdd(config);

            Assert.AreEqual(1, ReaderWriterLockSlimReadWrite.ListOfNumbers.Count);
        }
    }
}