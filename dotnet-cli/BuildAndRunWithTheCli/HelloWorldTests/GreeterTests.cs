using HelloWorldCore;

namespace HelloWorldTests;

public class GreeterTests
{
    [Test]
    public void GivenAName_WhenGreetIsCalled_ThenReturnsAGreetingForThatName()
    {
        var greeting = Greeter.Greet("World");

        Assert.That(greeting, Is.EqualTo("Hello, World!"));
    }
}
