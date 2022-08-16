namespace ActionFuncDelegates;

public partial class Delegate
{
    public delegate void Prnt(string msg);

    void ConsolePrice(string msg)
    {
        Console.WriteLine($"[Delegate -> ConsolePrice]: {msg}");
    }

    public void ActionRun()
    {
        Prnt del = ConsolePrice;
        del("Hello from delegate!");
    }
}

public class ActionDelegate
{
    public int MessageLength { get; private set; }

    void ConsolePrnt(string msg)
    {
        MessageLength = msg.Length;
        Console.WriteLine($"[Action -> ConsolePrice]: {msg}");
    }

    public int Run()
    {
        Action<string> actionDel = ConsolePrnt;
        actionDel("Hello from the other side!");
        return MessageLength;
    }
}