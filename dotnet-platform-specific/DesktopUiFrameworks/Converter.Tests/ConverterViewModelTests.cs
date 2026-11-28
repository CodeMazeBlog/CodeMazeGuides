using Converter.Core;

namespace Converter.Tests;

public class ConverterViewModelTests
{
    [Fact]
    public void ConvertCommand_IsDisabled_UntilCelsiusParses()
    {
        var viewModel = new ConverterViewModel();
        Assert.False(viewModel.ConvertCommand.CanExecute(null));

        viewModel.Celsius = "warm";
        Assert.False(viewModel.ConvertCommand.CanExecute(null));

        viewModel.Celsius = "100";
        Assert.True(viewModel.ConvertCommand.CanExecute(null));
    }

    [Theory]
    [InlineData("100", "212 °F")]
    [InlineData("0", "32 °F")]
    public void ConvertCommand_WritesFahrenheitToResult(string celsius, string expected)
    {
        var viewModel = new ConverterViewModel { Celsius = celsius };

        viewModel.ConvertCommand.Execute(null);

        Assert.Equal(expected, viewModel.Result);
    }

    [Fact]
    public void SettingCelsius_NotifiesTheView()
    {
        var viewModel = new ConverterViewModel();
        var changedProperties = new List<string?>();
        var canExecuteChanges = 0;
        viewModel.PropertyChanged += (_, e) => changedProperties.Add(e.PropertyName);
        viewModel.ConvertCommand.CanExecuteChanged += (_, _) => canExecuteChanges++;

        viewModel.Celsius = "25";

        Assert.Equal([nameof(ConverterViewModel.Celsius)], changedProperties);
        Assert.Equal(1, canExecuteChanges);
    }
}
