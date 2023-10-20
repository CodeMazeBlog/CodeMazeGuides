namespace App.Domain;

public class LowerCaseFilter : IFilter
{
    public string ProcessAsync(string input)
    {
        return input.ToLower();
    }
}