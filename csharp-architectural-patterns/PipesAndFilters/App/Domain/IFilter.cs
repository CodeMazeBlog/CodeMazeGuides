namespace App.Domain;

public interface IFilter
{
    public string ProcessAsync(string input);
}