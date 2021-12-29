namespace ActionAndFuncDelegates
{
    public class Messenger
    {
        public void RelayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void RelayMessageWithDetails(string message, string sender, int reference)
        {
            Console.WriteLine($"{sender} [#{reference}]: {message}");
        }
    }
}