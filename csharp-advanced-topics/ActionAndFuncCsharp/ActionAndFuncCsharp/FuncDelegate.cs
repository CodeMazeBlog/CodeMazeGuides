namespace ActionAndFuncCsharp;
public class FuncDelegate
{
    public int TakePower(int x, int power)
    {
        if(power == 0)
            return 1;
        if (power == 1)
            return x;

        var result = x;
        for (var i = 0; i < power-1; i++)
        {
            result *= x;
        }
        return result;
    }
    public string DisplaySum(int a, int b)
    {
        return string.Format($"Sum of {a} and {b} is: {a+b}");
    }
    public string StringAppend(string first, string last)
    {
        if(!string.IsNullOrEmpty(first) && !string.IsNullOrEmpty(last))
            return first + last;
        else if (!string.IsNullOrEmpty(first) && string.IsNullOrEmpty(last))
            return first;
        else if (string.IsNullOrEmpty(first) && !string.IsNullOrEmpty(last))
            return last;
        else
            return string.Empty;
    }
}

