namespace Delegates
{
public class FuncDelegate
{
    public static bool IsEven(int number) => number % 2 == 0;
    public Func<bool> EvenNumber(int number)
    {
        Func<bool> even = () => IsEven(number);
        return even;
    }

    public bool EvenNumber2(int number)
    {
        Func<int, bool> even = IsEven;
        return even(number);
    }

}

}
