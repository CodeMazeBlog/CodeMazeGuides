using HowToImplementIDisposableInterface.DisposePattern;
using NSubstitute;

namespace HowToImplementIDisposableInterface.Tests.DisposePattern;

public class MyParentClassUnitTest
{
    [Fact]
    public void GivenManagedResource_WhenDisposeNotCalled_ThenResourceNotDisposed()
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
    public void GivenManagedResource_WhenDisposeCalledExplicitly_ThenResourceDisposed()
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
    public void GivenManagedResource_WhenDisposeCalledImplicitly_ThenResourceDisposed()
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
    public void GivenManagedResource_WhenDisposeCalled_ThenDisposeCalledExactlyOnce()
    {
        // Arrange
        var managedResource = Substitute.For<IManagedResource>();

        // Act
        {
            using var myClass = new MyParentClass(managedResource);
            myClass.DoSomething();
        }

        // Assert
        managedResource.Received(1).Dispose();
    }

    [Fact]
    public void GivenDisposedClass_WhenDoSomethingCalled_ThenThrowsObjectDisposedException()
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