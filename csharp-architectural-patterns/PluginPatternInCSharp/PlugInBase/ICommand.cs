namespace PlugInBase;

public interface ICommand
{
    string Name { get; }
    string Description { get; }

    int Invoke();
}