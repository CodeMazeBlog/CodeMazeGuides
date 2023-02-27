namespace _Action
{
    public class Actions
    {
        Action action = Method;

        public static void Method()
        {
            Console.WriteLine("Action Method Called");
        }

        public void ActionMethod()
        {
            action();
        }

      Action<string> printMessage = (message) => Console.WriteLine(message);
      public void ActionMethod2()
      {
        printMessage("Action Method Called 2");
      }
    }
}