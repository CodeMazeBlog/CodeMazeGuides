namespace WeakEventsInCSharp;

public class Subscriber
{
    public void HandleEvent(object sender, EventArgs e)
    {
        Console.WriteLine("Event received.");
    }
}
