namespace ActionAndFuncDelegate;

public class Utility
{
    private static readonly List<string> _data = new List<string>
    {
        "Keneth", "Peculiar", "Harrison", "Jason", "Janelle", "Amara", "Josh"
    };

    public void DisplayAll(Action<List<string>> action)
    {
        action(_data);
    }

    public string GetByCondition(Func<List<string>, string> func)
    {
        return func(_data);
    }
}

