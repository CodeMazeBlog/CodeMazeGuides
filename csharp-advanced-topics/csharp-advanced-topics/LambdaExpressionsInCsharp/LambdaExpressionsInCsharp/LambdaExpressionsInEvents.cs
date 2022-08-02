namespace LambdaExpressionsInCsharp;
public class LambdaExpressionsInEvents
{
    public event EventHandler Event;
    public LambdaExpressionsInEvents()
    {
        Event += (obj, eventArgs) =>
        {
            Console.WriteLine("Event raised!");
        };
    }

    public void InvokeEvent()
    {
        Event?.Invoke(this, new());
    }
}
