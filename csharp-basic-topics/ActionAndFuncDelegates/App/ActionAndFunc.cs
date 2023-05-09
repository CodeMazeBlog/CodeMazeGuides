namespace App;

public class ActionAndFunc
{
    readonly Func<string,string,string> _getFullName = (firstName, lastName) => $"{firstName} {lastName}";

    readonly Action<string> _printFullName = Console.WriteLine;
    
    public string? FullName { get; private set; }
    
    public void Run(string firstName, string lastName)
    {
        FullName = _getFullName(firstName, lastName);
        _printFullName(FullName);
    }
}