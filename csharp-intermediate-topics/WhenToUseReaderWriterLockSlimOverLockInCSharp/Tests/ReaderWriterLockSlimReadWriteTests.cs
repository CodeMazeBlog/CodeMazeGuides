namespace Tests;

[TestClass]
public class ReaderWriterLockSlimReadWriteTests
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
        var readerWriterLockSlimReadWrite = new ReaderWriterLockSlimReadWrite();

        readerWriterLockSlimReadWrite.AddNumbersToList(_config.WriterExecutionsCount, _config.WriterExecutionDelay);

        Assert.AreEqual(_config.WriterExecutionsCount, readerWriterLockSlimReadWrite.ListOfNumbers.Count);
    }

    [TestMethod]
    public void WhenReadListCount_ListCountIsEqualZero()
    {
        var readerWriterLockSlimReadWrite = new ReaderWriterLockSlimReadWrite();

        readerWriterLockSlimReadWrite.ReadListCount(_config.ReaderExecutionsCount, _config.ReaderExecutionDelay);

        Assert.AreEqual(0, readerWriterLockSlimReadWrite.ListOfNumbers.Count);
    }

    [TestMethod]
    public void WhenReadOrAdd_ListCountIsEqualOne()
    {
        var readerWriterLockSlimReadWrite = new ReaderWriterLockSlimReadWrite();

        readerWriterLockSlimReadWrite.ReadOrAdd(_config.WriterExecutionDelay);

        Assert.AreEqual(1, readerWriterLockSlimReadWrite.ListOfNumbers.Count);
    }

    [TestMethod]
    public void WhenReadLockIsEnteredTwiceWithDefaultPolicy_ThrowsLockRecursionException()
    {
        using var readerWriterLockSlim = new ReaderWriterLockSlim();
        readerWriterLockSlim.EnterReadLock();

        Assert.ThrowsExactly<LockRecursionException>(() => readerWriterLockSlim.EnterReadLock());

        readerWriterLockSlim.ExitReadLock();
    }

    [TestMethod]
    public void WhenReadLockIsEnteredTwiceWithSupportsRecursion_RecursiveReadCountIsTwo()
    {
        using var readerWriterLockSlim = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        readerWriterLockSlim.EnterReadLock();
        readerWriterLockSlim.EnterReadLock();

        Assert.AreEqual(2, readerWriterLockSlim.RecursiveReadCount);

        readerWriterLockSlim.ExitReadLock();
        readerWriterLockSlim.ExitReadLock();
    }

    [TestMethod]
    public void WhenReadLockHolderEntersWriteLock_ThrowsLockRecursionException()
    {
        using var readerWriterLockSlim = new ReaderWriterLockSlim();
        readerWriterLockSlim.EnterReadLock();

        Assert.ThrowsExactly<LockRecursionException>(() => readerWriterLockSlim.EnterWriteLock());

        readerWriterLockSlim.ExitReadLock();
    }
}