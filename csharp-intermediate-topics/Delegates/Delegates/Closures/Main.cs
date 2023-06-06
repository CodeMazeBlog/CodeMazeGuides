namespace Delegates.Closures;

public sealed class Main
{
    public int SumUntilWrong(int rounds)
    {
        var result = 0;
        var functions = new List<Func<int>>();
        
        for (var i = 1; i <= rounds; i++)
        {
            functions.Add(() => result += i);
        }

        foreach (var func in functions)
        {
            func();
        }
        
        return result;
    }
    
    public int SumUntilFixed(int rounds)
    {
        var result = 0;
        var functions = new List<Func<int>>();
        
        for (var i = 1; i <= rounds; i++)
        {
            var j = i;
            functions.Add(() => result += j);
        }

        foreach (var func in functions)
        {
            func();
        }
        
        return result;
    }
}