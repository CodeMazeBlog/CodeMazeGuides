namespace ActionAndFuncDelegates
{
    public class Demo
    {
        public static void ExampleCallDirectMethod()
        {
            var messenger = new Messenger();
            messenger.RelayMessage("Line1");
            messenger.RelayMessage("Line2");
            messenger.RelayMessage("Line3");
        }

        public static void ExampleCallMethodByAction()
        {
            var messenger = new Messenger();
            var relay = messenger.RelayMessage;
            relay("Line1");
            relay("Line2");
            relay("Line3");
        }

        public static void ExampleMultiParamMethodByAction()
        {
            var messenger = new Messenger();
            var relay = messenger.RelayMessageWithDetails;
            relay("Line1", "Demo", 1);
            relay("Line2", "Demo", 2);
            relay("Line3", "Demo", 3);
        }

        public static void ExampleMultiParamMethodByShortenedAction()
        {
            var messenger = new Messenger();
            Action<string, int> relay = (msg, no) => messenger.RelayMessageWithDetails(msg, "Demo", no);
            relay("Line1", 1);
            relay("Line2", 2);
            relay("Line3", 3);
        }

        public static void ExampleCombinedAction()
        {
            Action<string> relay1 = (msg) => Console.WriteLine($"Relay1: {msg}");
            Action<string> relay2 = (msg) => Console.WriteLine($"Relay2: {msg}");

            var relay = relay1 + relay2;
            relay("Welcome");
        }

        public static void ExamplePassActionAsMethodParameter()
        {
            Action<string> relay = (msg) => Console.WriteLine(msg);
            RelayMessages(relay, "Line1", "Line2", "Line3");
        }

        public static void RelayMessages(Action<string> relay, params string[] messages)
        {
            messages?.ToList().ForEach(msg => relay(msg));
        }

        public static string[] FormatAll(Func<string, string> formatter, params string[] inputs)
        {
            return inputs.Select(formatter).ToArray();
        }

        static void Execute(Action example)
        {
            Console.WriteLine($"\r\nOutput of {example.Method.Name}:");
            example();
        }

        public static void ActionExamples()
        {
            var messenger = new Messenger();

            Execute(ExampleCallDirectMethod);

            Execute(ExampleCallMethodByAction);

            Execute(ExampleMultiParamMethodByAction);

            Execute(ExampleMultiParamMethodByShortenedAction);

            Execute(ExampleCombinedAction);

            Execute(ExamplePassActionAsMethodParameter);
        }

        public static void ExampleResultOfMethodByFunc()
        {
            var formatter = new StringFormatter();

            // Explicit type declaration is not necessary here, this actually exists for convenient demonstration
            Func<string, string> upperCase = formatter.FormatStringAsUppercase;
            Console.WriteLine(upperCase("C# Basics"));

            Func<DateTime, string> dateString = formatter.FormatDateAsString;
            Console.WriteLine(dateString(new DateTime(2021, 12, 27)));
        }

        public static void ExampleFuncUsingInlineLambdaSyntax()
        {
            Func<string, bool> isAuthor = (user) => user == "CodeMaze";

            Console.WriteLine(isAuthor("CodeMaze"));
            Console.WriteLine(isAuthor("Anonymous"));
        }

        public static void ExamplePassFuncAsMethodParameter()
        {
            Func<string, string> format = (str) => str.ToUpper();
            
            var outputs = FormatAll(format, "C# Basics", "C# Delegates", "Actions and Funcs");
            outputs.ToList().ForEach(o => Console.WriteLine(o));
        }

        public static void FuncExamples()
        {
            Execute(ExampleResultOfMethodByFunc);

            Execute(ExampleFuncUsingInlineLambdaSyntax);

            Execute(ExamplePassFuncAsMethodParameter);
        }

    }
}
