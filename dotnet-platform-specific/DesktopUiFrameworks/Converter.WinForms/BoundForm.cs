using Converter.Core;

namespace Converter.WinForms;

public sealed class BoundForm : Form
{
    public BoundForm(ConverterViewModel viewModel)
    {
        Text = "Converter (WinForms, bound)";

        var celsiusBox = new TextBox { Width = 200 };
        celsiusBox.DataBindings.Add(nameof(TextBox.Text), viewModel,
            nameof(ConverterViewModel.Celsius), false, DataSourceUpdateMode.OnPropertyChanged);

        var convertButton = new Button { Text = "Convert", Command = viewModel.ConvertCommand };

        var resultLabel = new Label { AutoSize = true };
        resultLabel.DataBindings.Add(nameof(Label.Text), viewModel, nameof(ConverterViewModel.Result));

        Controls.Add(new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            Controls = { celsiusBox, convertButton, resultLabel }
        });
    }
}
