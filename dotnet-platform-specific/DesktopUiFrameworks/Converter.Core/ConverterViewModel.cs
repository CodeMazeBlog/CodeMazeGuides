using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Converter.Core;

public sealed class ConverterViewModel : INotifyPropertyChanged
{
    public ConverterViewModel() => ConvertCommand = new RelayCommand(Convert, CanConvert);

    public event PropertyChangedEventHandler? PropertyChanged;

    public RelayCommand ConvertCommand { get; }

    public string Celsius
    {
        get;
        set
        {
            if (field == value) return;
            field = value;
            OnPropertyChanged();
            ConvertCommand.RaiseCanExecuteChanged();
        }
    } = "";

    public string Result
    {
        get;
        private set
        {
            field = value;
            OnPropertyChanged();
        }
    } = "";

    private bool CanConvert() => double.TryParse(Celsius, out _);

    private void Convert()
    {
        if (double.TryParse(Celsius, out var celsius))
        {
            Result = $"{celsius * 9 / 5 + 32:0.#} °F";
        }
    }

    private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
