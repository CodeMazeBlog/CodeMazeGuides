using Avalonia;
using Avalonia.Controls;
using Avalonia.Headless;
using Avalonia.Input;
using Converter.Avalonia;

[assembly: AvaloniaTestApplication(typeof(App))]

namespace Converter.Tests;

public class AvaloniaWindowTests
{
    [Fact]
    public async Task TypingAndClickingConvert_ShowsFahrenheit()
    {
        var session = HeadlessUnitTestSession.GetOrStartForAssembly(typeof(AvaloniaWindowTests).Assembly);

        var (enabledBefore, enabledAfterTyping, result) = await session.Dispatch(() =>
        {
            var window = new MainWindow();
            window.Show();
            var panel = (StackPanel)window.Content!;
            var celsiusBox = (TextBox)panel.Children[0];
            var convertButton = (Button)panel.Children[1];
            var resultText = (TextBlock)panel.Children[2];

            var before = convertButton.IsEffectivelyEnabled;
            celsiusBox.Focus();
            window.KeyTextInput("100");
            var afterTyping = convertButton.IsEffectivelyEnabled;

            var center = convertButton.TranslatePoint(
                new Point(convertButton.Bounds.Width / 2, convertButton.Bounds.Height / 2), window)!.Value;
            window.MouseDown(center, MouseButton.Left);
            window.MouseUp(center, MouseButton.Left);

            return (before, afterTyping, resultText.Text);
        }, TestContext.Current.CancellationToken);

        Assert.False(enabledBefore);
        Assert.True(enabledAfterTyping);
        Assert.Equal("212 °F", result);
    }
}
