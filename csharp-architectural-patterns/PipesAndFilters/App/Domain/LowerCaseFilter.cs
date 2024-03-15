namespace App.Domain;

public class LowerCaseFilter : IFilter
{
    public string Process(string input)
    {
        return input.ToLower();
    }
}