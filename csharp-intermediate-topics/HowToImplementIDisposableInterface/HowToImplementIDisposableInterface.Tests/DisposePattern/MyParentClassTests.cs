using HowToImplementIDisposableInterface.DisposePattern;
using NSubstitute;

namespace HowToImplementIDisposableInterface.Tests.DisposePattern;

public class MyParentClassTests
{
    [Fact]
    public void Dispose_NotCalled_Automatically()
    {
        // Arrange
        var managedResource = Substitute.For<IManagedResource>();

        // Act
        {
            var myClass = new MyParentClass(managedResource);

            myClass.DoSomething();
        }

        // Assert
        managedResource.DidNotReceive().Dispose();
    }

    [Fact]
    public void Dispose_Called_Explicitly()
    {
        // Arrange
        var managedResource = Substitute.For<IManagedResource>();

        // Act
        {
            var myClass = new MyParentClass(managedResource);

            myClass.DoSomething();

            myClass.Dispose();
        }

        // Assert
        managedResource.Received().Dispose();
    }

    [Fact]
    public void Dispose_Called_Implicitly()
    {
        // Arrange
        var managedResource = Substitute.For<IManagedResource>();

        // Act
        {
            using var myClass = new MyParentClass(managedResource);

            myClass.DoSomething();
        }

        // Assert
        managedResource.Received().Dispose();
    }

    [Fact]
    public void Dispose_Called_ExactlyOnce()
    {
        // Arrange
        var managedResource = Substitute.For<IManagedResource>();

        {
            using var myClass = new MyParentClass(managedResource);

            myClass.DoSomething();
        }

        // Assert
        managedResource.Received(1).Dispose();
    }

    [Fact]
    public void DoSomething_ThrowsException_WhenAlreadyDisposed()
    {
        // Arrange
        var managedResource = Substitute.For<IManagedResource>();
        var myClass = new MyParentClass(managedResource);

        // Act
        myClass.Dispose();

        // Assert
        Assert.Throws<ObjectDisposedException>(() => myClass.DoSomething());
    }
}