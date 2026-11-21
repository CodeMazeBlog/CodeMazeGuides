namespace Converter.WinForms;

public sealed class ClassicForm : Form
{
    private readonly TextBox _celsiusBox = new() { Width = 200 };
    private readonly Button _convertButton = new() { Text = "Convert", Enabled = false };
    private readonly Label _resultLabel = new() { AutoSize = true };

    public ClassicForm()
    {
        Text = "Converter (WinForms, classic)";
        Controls.Add(new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            Controls = { _celsiusBox, _convertButton, _resultLabel }
        });

        _celsiusBox.TextChanged += (_, _) =>
            _convertButton.Enabled = double.TryParse(_celsiusBox.Text, out _);

        _convertButton.Click += (_, _) =>
        {
            var celsius = double.Parse(_celsiusBox.Text);
            _resultLabel.Text = $"{celsius * 9 / 5 + 32:0.#} °F";
        };
    }
}
