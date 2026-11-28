using System.Buffers;

namespace ArrayPool.Tests;

public class Tests
{
    [Test]
    public void UsingArrayPoolShared_WhenIntType_ThenSuccessfulInitialization()
    {
        var defaultPool = Methods.GetDefaultArrayPool<int>();

        Assert.That(defaultPool, Is.Not.Null);
    }

    [Test]
    public void UsingArrayPoolShared_WhenByteType_ThenSuccessfulInitialization()
    {
        var defaultPool = Methods.GetDefaultArrayPool<byte>();

        Assert.That(defaultPool, Is.Not.Null);
    }

    [Test]
    public void UsingArrayPoolShared_WhenStringType_ThenSuccessfulInitialization()
    {
        var defaultPool = Methods.GetDefaultArrayPool<string>();

        Assert.That(defaultPool, Is.Not.Null);
    }

    [Test]
    public void UsingCustomArrayPool_WhenIntType_ThenSuccessfulInitialization()
    {
        var customPool = Methods.CreateArrayPool<int>(10, 5);

        Assert.That(customPool, Is.Not.Null);
    }

    [Test]
    public void UsingCustomArrayPool_WhenByteType_ThenSuccessfulInitialization()
    {
        var customPool = Methods.CreateArrayPool<byte>(10, 5);

        Assert.That(customPool, Is.Not.Null);
    }

    [Test]
    public void UsingCustomArrayPool_WhenStringType_ThenSuccessfulInitialization()
    {
        var customPool = Methods.CreateArrayPool<string>(10, 5);

        Assert.That(customPool, Is.Not.Null);
    }

    [Test]
    public void UsingArrayPoolShared_WhenRentingTen_ThenArrayIsAtLeastTenLong()
    {
        var pool = Methods.GetDefaultArrayPool<int>();

        var array = pool.Rent(10);

        Assert.That(array, Has.Length.GreaterThanOrEqualTo(10));

        pool.Return(array);
    }

    [Test]
    public void UsingCustomArrayPool_WhenArrayReturnedWithoutClearing_ThenNextRentSeesOldValues()
    {
        var pool = Methods.CreateArrayPool<int>(100, 10);
        var array = pool.Rent(10);
        array[0] = 42;
        pool.Return(array);

        var nextArray = pool.Rent(10);

        Assert.That(nextArray, Is.SameAs(array));
        Assert.That(nextArray[0], Is.EqualTo(42));
    }

    [Test]
    public void UsingCustomArrayPool_WhenArrayReturnedWithClearArray_ThenNextRentSeesZeros()
    {
        var pool = Methods.CreateArrayPool<int>(100, 10);
        var array = pool.Rent(10);
        array[0] = 42;
        pool.Return(array, clearArray: true);

        var nextArray = pool.Rent(10);

        Assert.That(nextArray, Is.SameAs(array));
        Assert.That(nextArray[0], Is.EqualTo(0));
    }

    [Test]
    public void UsingCustomArrayPool_WhenRentingAboveMaxLength_ThenArrayIsNotReused()
    {
        var pool = Methods.CreateArrayPool<int>(100, 10);
        var array = pool.Rent(200);
        pool.Return(array);

        var nextArray = pool.Rent(200);

        Assert.That(array, Has.Length.EqualTo(200));
        Assert.That(nextArray, Is.Not.SameAs(array));
    }
}
