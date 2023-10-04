using ActionAndFuncDelegatesInCSharp;
using Bogus;
using Xunit;

namespace ActionAndFuncDelegatesInCSharpTests;

public class ActionAndFuncDelegatesTests : IDisposable
{
    private readonly StringWriter _stringWriter;
    private readonly TextWriter _originalOutput;
    private readonly Faker _faker;

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
        var hardware = _faker.PickRandom("Keyboard", "Webcam", "Mouse", "Microphone");
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
}
