using HowToImplementIDisposableInterface.DisposePattern;
using NSubstitute;

namespace HowToImplementIDisposableInterface.Tests.DisposePattern;

public class MyChildClassTests
{
    [Fact]
    public void Dispose_Called_ForTheWholeHierarchy()
    {
        // Arrange
        var parentManagedResource = Substitute.For<IManagedResource>();
        var childManagedResource = Substitute.For<IManagedResource>();

        {
            using var myClass = new MyChildClass(parentManagedResource, childManagedResource);
            myClass.DoSomething();
        }

        // Assert
        parentManagedResource.Received().Dispose();
        childManagedResource.Received().Dispose();
    }
}