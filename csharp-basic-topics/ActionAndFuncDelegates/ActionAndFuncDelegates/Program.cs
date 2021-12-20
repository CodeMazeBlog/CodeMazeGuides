using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CodeMaze
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"----Action Demonstration----");
            DemonstrateAction();

            Console.WriteLine($"----Func Demonstration----");
            DemonstrateFunc();
        }

        public static void DemonstrateAction()
        {
            string sender = "CodeMaze";
            string greetings = $"Hello, I'm {sender}.";
            string message = "I'm here to demonstrate some examples of Action delegates.";
            string bye = "Thanks for reading this. I hope it was useful for you. Happy coding!!";

            var messenger = new Messenger();

            // Plain method calling
            Console.WriteLine($"Relaying by plain method calling:");
            messenger.MessageRelayMethod(greetings);
            messenger.MessageRelayMethod(message);
            messenger.MessageRelayMethod(bye);

            // Using Action for referencing method, thus allow convenient, concise and clean codes
            Console.WriteLine($"\r\nRelaying by action of {nameof(messenger.MessageRelayMethod)}:");
            Action<string> relay1 = messenger.MessageRelayMethod;
            relay1(greetings);
            relay1(message);
            relay1(bye);

            Console.WriteLine($"\r\nRelaying by action of {nameof(messenger.AnotherMessageRelayMethod)}:");
            Action<string, string> anotherRelay = messenger.AnotherMessageRelayMethod;
            anotherRelay(sender, greetings);
            anotherRelay(sender, message);
            anotherRelay(sender, bye);

            // Lambda syntax for Action initialization, which allows delegating method with different signature
            Console.WriteLine($"\r\nRelaying by action of {nameof(messenger.AnotherMessageRelayMethod)} (lambda syntax):");
            Action<string> relay2 = (m) => messenger.AnotherMessageRelayMethod(sender, m);
            relay2(greetings);
            relay2(message);
            relay2(bye);

            // Actions with similar signature can be combined just like plain value-types
            // This will eventually call both actions
            Console.WriteLine($"\r\nRelaying by combined action of {nameof(messenger.MessageRelayMethod)} and {nameof(messenger.AnotherMessageRelayMethod)}:");
            var relay3 = relay1 + relay2;
            relay3(greetings);
            relay3(message);
            relay3(bye);

            // Action can be usable in conditional assignment
            Console.WriteLine($"\r\nRelaying from a conditionally instantiated action:");
            var relay4 = sender == "CodeMaze" ? relay2 : relay1;
            relay4(greetings);
            relay4(message);
            relay4(bye);

            // Action variable can be passed to another method as usual
            Console.WriteLine($"\r\nRelaying by action as argument of another method:");
            RelayMessages(relay1, greetings, message, bye);

            // Or it can be passed as lambda form
            Console.WriteLine($"\r\nRelaying by action as argument of another method (lambda syntax):");
            RelayMessages(m => Console.WriteLine(m), greetings, message, bye);
        }

        public static void RelayMessages(Action<string> relay, params string[] messages)
        {
            messages?.ToList().ForEach(m => relay(m));
        }

        public static void DemonstrateFunc()
        {
            var formatter = new StringFormatter();
            // Plain method calling
            Console.WriteLine($"\r\nFormatting topics by plain method call:");
            var output = formatter.FormatStringAsUppercase("C# Basics");
            output = formatter.FormatStringAsUppercase("C# Delegates");

            // Referencing method as Func
            Console.WriteLine($"\r\nFormatting topics by func:");
            Func<string, string> format = formatter.FormatStringAsUppercase;
            output = format("C# Basics");
            output = format("C# Delegates");

            // Referencing method as Func (lambda syntax)
            Console.WriteLine($"\r\nFormatting by func (lambda syntax):");
            Func<string> timeStamp = () => formatter.FormatDateAsString(DateTime.UtcNow);
            output = timeStamp();

            // Func must return a value according to its out datatype
            Console.WriteLine($"\r\nFunc must return a value according to its out datatype:");
            Func<string, bool> isAuthor = (sender) => sender == "CodeMaze";
            Console.WriteLine(isAuthor("CodeMaze"));
            Console.WriteLine(isAuthor("Anonymous"));

            // Func can be passed as argument of another method
            Console.WriteLine($"\r\nFormatting topics by func passed as argument of another method:");
            FormatAll(format, "C# Basics", "C# Delegates", "Actions and Funcs");

            // Func can be passed as argument of another method (lambda syntax)
            Console.WriteLine($"\r\nFormatting topics by func passed as argument of another method (lambda syntax):");
            FormatAll(input => input.ToLower(), "C# Basics", "C# Delegates", "Actions and Funcs");
        }

        public static string[] FormatAll(Func<string, string> formatter, params string[] inputs)
        {
            return inputs.Select(formatter).ToArray();
        }
    }
}