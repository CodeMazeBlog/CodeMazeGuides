using Bogus;
using Xunit;

namespace ActionAndFuncDelegatesInCSharpTests;

public class ActionAndFuncDelegatesTests : IDisposable
{
    private readonly StringWriter _stringWriter;
    private readonly TextWriter _originalOutput;
    private readonly Faker _faker;
    private readonly List<string> _list = new List<string> { "Keyboard", "Webcam", "Mouse", "Microphone" };

    public ActionAndFuncDelegatesTests()
    {
        _stringWriter = new StringWriter();
        _originalOutput = Console.Out;
        Console.SetOut(_stringWriter);
        _faker = new Faker();
    }

    public void Dispose()
    {
        Console.SetOut(_originalOutput);
        _stringWriter.Dispose();
    }

    [Fact]
    public void WhenActionExample_ThenPrintValidString()
    {
        // Arrange
        var hardware = _faker.PickRandom(_list);
        var expected = $"Action. Preparing Hardware: {hardware}";

        // Act
        Program.ActionExample(hardware);

        // Assert
        Assert.Equal(expected, _stringWriter.ToString().Trim());
    }
    
    [Fact]
    public void WhenActionExampleWithOptions_ThenPrintProvidedOptions()
    {
        // Arrange
        var keyboard = _faker.Random.Int(1, 5);
        var webcam = _faker.Random.Int(1, 5);
        var expectedKeyboard = $"Action. Preparing Keyboard(s): {keyboard}";
        var expectedWebcam = $"Action. Preparing Webcam(s): {webcam}";

        // Act
        Program.ActionExampleWithOptions(opt =>
        {
            opt.Keyboard = keyboard;
            opt.Webcam = webcam;
        });

        // Assert
        Assert.Contains(expectedKeyboard, _stringWriter.ToString().Trim());
        Assert.Contains(expectedWebcam, _stringWriter.ToString().Trim());
    }
    
    [Fact]
    public void WhenFuncExample_ThenReturnValidString()
    {
        // Arrange
        var expected = "Func. Preparing Hardware: Webcam";

        // Act
        var response = Program.FuncExample();

        // Assert
        Assert.Equal(expected, response);
    }
    
    [Fact]
    public void WhenFuncExampleWithOptions_ThenPrintProvidedOptions()
    {
        // Arrange
        var hardware1 = _faker.PickRandom(_list);
        var hardware2 = _faker.PickRandom(_list.Except<string>(new List<string> { hardware1 }));
        var expected = $"Func. Preparing Hardware: {hardware1} and {hardware2}";

        // Act
        var response = Program.FuncExampleWithParams(hardware1, hardware2);

        // Assert
        Assert.Contains(expected, response);
    }
}
