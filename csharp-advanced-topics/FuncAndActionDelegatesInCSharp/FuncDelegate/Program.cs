namespace FuncDelegate
{
    public class Program
    {
        public static string GetNotification()
        {
            Func<string, string> notify
                = (string message) => message == "build project" ? "building" : "unkown notification";

            var result = notify("build project");

            Console.WriteLine(result);

            return result;
        }
    }
}