namespace MutexClassInCSharp.Tests;

public sealed class MutexOwnershipTests
{
    [Fact]
    public void WhenOwnerThreadExitsWithoutRelease_ThenNextWaiterGetsAbandonedMutexExceptionAndOwnsMutex()
    {
        using var mutex = new Mutex();

        var owner = new Thread(() => mutex.WaitOne());
        owner.Start();
        owner.Join();

        Assert.Throws<AbandonedMutexException>(() => mutex.WaitOne());

        mutex.ReleaseMutex();
    }

    [Fact]
    public void WhenAnotherThreadReleasesMutex_ThenApplicationExceptionIsThrown()
    {
        using var mutex = new Mutex();
        mutex.WaitOne();

        Exception? releaseError = null;
        var other = new Thread(() => releaseError = Record.Exception(mutex.ReleaseMutex));
        other.Start();
        other.Join();

        Assert.IsType<ApplicationException>(releaseError);

        mutex.ReleaseMutex();
    }
}
