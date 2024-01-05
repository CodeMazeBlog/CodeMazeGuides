namespace FuncAndActionDelegate;
public class ActionEx
{
    public void ActionExample()
    {
        Action<string> PrintMessage = Console.WriteLine;
        PerformOperation(5, PrintMessage); // Invokes PrintMessage indirectly
        
    }
    public string PerformOperation(int value, Action<string> action)
    {
        string message = $"The value is: {value}";
        action(message); // Output: The value is: 5
        return message;
    }
    public List<string> ActionRealExample(List<string> data)
    {
       data.ForEach(x => Console.WriteLine(x));
        return data;
    }
}
