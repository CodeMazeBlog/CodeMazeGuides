namespace FuncDelegate
{
    public class Program
    {
        public static string GetNotification()
        {
            // Func delegate with one parameter and a return type
            Func<string, string> notify
                = (string message) => message == "build project" ? "building" : "unkown notification";

            // Invoke the Func delegate
            var result = notify("build project");
            Console.WriteLine(result);

            return result;
        }
    }
}