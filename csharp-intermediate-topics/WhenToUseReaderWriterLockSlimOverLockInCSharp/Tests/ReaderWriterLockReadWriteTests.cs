namespace Tests;

[TestClass]
public class ReaderWriterLockReadWriteTests
{
    private ThreadExecutionConfiguration _config = new();

    [TestInitialize]
    public void Initialize()
    {
        _config = new ThreadExecutionConfiguration
        {
            ReaderThreadsCount = 5,
            WriterThreadsCount = 1,
            ReaderExecutionDelay = 100,
            WriterExecutionDelay = 100,
            ReaderExecutionsCount = 100000,
            WriterExecutionsCount = 100000,
        };
    }

    [TestMethod]
    public void WhenAddNumberToList_ListCountIsEqualConfiguredValue()
    {
        var readerWriterLockReadWrite = new ReaderWriterLockReadWrite();

        readerWriterLockReadWrite.AddNumbersToList(_config.WriterExecutionsCount, _config.WriterExecutionDelay);

        Assert.AreEqual(_config.WriterExecutionsCount, readerWriterLockReadWrite.ListOfNumbers.Count);
    }

    [TestMethod]
    public void WhenReadListCount_ListCountIsEqualZero()
    {
        var readerWriterLockReadWrite = new ReaderWriterLockReadWrite();

        readerWriterLockReadWrite.ReadListCount(_config.ReaderExecutionsCount, _config.ReaderExecutionDelay);

        Assert.AreEqual(0, readerWriterLockReadWrite.ListOfNumbers.Count);
    }
}