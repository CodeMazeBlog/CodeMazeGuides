namespace ActionAndFunc;

public class ActionDelegate
{
    public string ExecuteActionDelegate(string name)
    {
        var myName = string.Empty;
        Action<string> greet = (name) =>
        {
            myName = name;
        };
        greet(name); 
        Console.WriteLine($"Hello, {myName}!"); // Output: Hello, Yohan!
        return myName;
    }
}