using HowToImplementIDisposableInterface;
using HowToImplementIDisposableInterface.Basic;
using HowToImplementIDisposableInterface.DisposePattern;

{
    Console.WriteLine("Dispose not called...");
    var managedResource = new ManagedResource();
    var myClass = new MyClass(managedResource);
    myClass.DoSomething();
}

{
    Console.WriteLine("Dispose called explicitly...");
    var managedResource = new ManagedResource();
    var myClass = new MyClass(managedResource);
    myClass.DoSomething();
    myClass.Dispose();
}

{
    Console.WriteLine("Dispose called implicitly...");
    var managedResource = new ManagedResource();
    using var myClass = new MyClass(managedResource);
    myClass.DoSomething();
}

{
    Console.WriteLine("Dispose called for the whole hierarchy...");
    var parentManagedResource = new ManagedResource();
    var childManagedResource = new ManagedResource();
    using var childClass = new MyChildClass(parentManagedResource, childManagedResource);
    childClass.DoSomething();
}

namespace HowToImplementIDisposableInterface
{
    public partial class Program;
}