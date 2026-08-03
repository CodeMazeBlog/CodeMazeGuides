namespace ArrayPool.Tests;

public class Tests
{
    [Test]
    public void UsingArrayPoolShared_WhenIntType_ThenSuccessfulInitialization()
    {
        var defaultPool = Methods.GetDefaultArrayPool<int>();

        Assert.That(defaultPool, Is.Not.EqualTo(null));
    }

    [Test]
    public void UsingArrayPoolShared_WhenByteType_ThenSuccessfulInitialization()
    {
        var defaultPool = Methods.GetDefaultArrayPool<byte>();

        Assert.That(defaultPool, Is.Not.EqualTo(null));
    }

    [Test]
    public void UsingArrayPoolShared_WhenStringType_ThenSuccessfulInitialization()
    {
        var defaultPool = Methods.GetDefaultArrayPool<string>();

        Assert.That(defaultPool, Is.Not.EqualTo(null));
    }

    [Test]
    public void UsingCustomArrayPool_WhenIntType_ThenSuccessfulInitialization()
    {
        var defaultPool = Methods.CreateArrayPool<int>(10, 5);

        Assert.That(defaultPool, Is.Not.EqualTo(null));
    }

    [Test]
    public void UsingCustomArrayPool_WhenByteType_ThenSuccessfulInitialization()
    {
        var defaultPool = Methods.CreateArrayPool<byte>(10, 5);

        Assert.That(defaultPool, Is.Not.EqualTo(null));
    }

    [Test]
    public void UsingCustomArrayPool_WhenStringType_ThenSuccessfulInitialization()
    {
        var defaultPool = Methods.CreateArrayPool<string>(10, 5);

        Assert.That(defaultPool, Is.Not.EqualTo(null));
    }
}