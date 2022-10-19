namespace ActionAndFuncDelegatesInCsharp
{
    public delegate void SendMailDelegate(string email, string mailbody);

    public class DelegateExample
    {
        public static void SendMailDelegate()
        {
            var handler = new SendMailDelegate(SendMailHandler);

            handler("abc@example.com", "This is sample message");
        }

        private static void SendMailHandler(string email, string mailbody)
        {
            Console.WriteLine("Message has been sent successfully!");
        }
    }
}
