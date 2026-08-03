using UsingStaticAnonymousFunctionsInCSharp;
using UsingStaticAnonymousFunctionsInCSharp.Demo;

namespace Tests;

public class UsingStaticAnonymousFunctionsInCSharpTest
{
    [Fact]
    public void GivenDemoNonStaticClass_WhenDisplayMethodIsCalled_ThenResultIsCalculatedCorrectly()
    {
        // Arrange
        var demoNonStatic = new DemoNonStatic();
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        demoNonStatic.Display();
        var output = stringWriter.ToString().Trim();

        // Assert
        var expected = "4096";
        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenDemoStaticWithConstVariableClass_WhenDisplayMethodIsCalled_ThenResultIsCalculatedCorrectly()
    {
        // Arrange
        var demoStatic = new DemoStaticWithConstVariable();
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        demoStatic.Display();
        var output = stringWriter.ToString().Trim();

        // Assert
        var expected = "4096";
        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenDemoStaticWithStaticVariableClass_WhenDisplayMethodIsCalled_ThenResultIsCalculatedCorrectly()
    {
        // Arrange
        var demoStatic = new DemoStaticWithStaticVariable();
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        demoStatic.Display();
        var output = stringWriter.ToString().Trim();

        // Assert
        var expected = "4096";
        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenDemoStaticWithNonStaticLocalMethod_WhenDisplayMethodIsCalled_ThenResultIsCalculatedCorrectly()
    {
        // Arrange
        var demoStatic = new DemoStaticWithNonStaticLocalMethod();
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        demoStatic.Display();
        var output = stringWriter.ToString().Trim();

        // Assert
        var expected = "121";
        Assert.Equal(expected, output);
    }
       
    [Fact]
    public void WhenMultiplyNonStaticMethodIsCalled_ThenResultIsCalculatedCorrectly()
    {
        // Arrange
        var anonymousFunctionsBenchmark = new AnonymousFunctionsBenchmark();
        
        // Act
        var result = anonymousFunctionsBenchmark.MultiplyNonStatic();
        
        // Assert
        var expected = "60";            
        Assert.Equal(expected, result.ToString());
    }

    [Fact]
    public void WhenMultiplyNonStaticWithConstMethodIsCalled_ThenResultIsCalculatedCorrectly()
    {
        // Arrange
        var anonymousFunctionsBenchmark = new AnonymousFunctionsBenchmark();

        // Act
        var result = anonymousFunctionsBenchmark.MultiplyNonStaticWithConst();

        // Assert
        var expected = "60";
        Assert.Equal(expected, result.ToString());
    }

    [Fact]
    public void WhenMultiplyStaticMethodIsCalled_ThenResultIsCalculatedCorrectly()
    {
        // Arrange
        var anonymousFunctionsBenchmark = new AnonymousFunctionsBenchmark();

        // Act
        var result = anonymousFunctionsBenchmark.MultiplyStatic();

        // Assert
        var expected = "60";
        Assert.Equal(expected, result.ToString());
    }    
}