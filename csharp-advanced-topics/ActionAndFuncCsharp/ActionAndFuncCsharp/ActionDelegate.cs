namespace ActionAndFuncCsharp;
public class ActionDelegate
{
    //Methods that takes input parameters but returns nothing;
    public void DisplayText()
    {
        Console.WriteLine($"Action<> - Learning Delegates is Fun - Awesome!");
    }
    public void DisplaySum(int num1, int num2)
    {
        var sum = num1 + num2;
        Console.WriteLine($"Action<int,int> - Sum is: {sum}");
    }
    public void DisplayMessage(string msg)
    {
        Console.WriteLine($"Action<T> : {msg}");
    }
}

