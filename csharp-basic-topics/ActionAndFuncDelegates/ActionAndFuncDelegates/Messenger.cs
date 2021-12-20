namespace CodeMaze
{
    public class Messenger
    {
        public void MessageRelayMethod(string message)
        {
            Console.WriteLine(message);
        }

        public void AnotherMessageRelayMethod(string sender, string message)
        {
            Console.WriteLine($"{sender}: {message}");
        }
    }
}