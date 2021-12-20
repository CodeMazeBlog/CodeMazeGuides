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
            DemonstrateAction();

            DemonstrateFunc();
        }

        public static void DemonstrateAction()
        {
            string sender = "CodeMaze";
            string greetings = $"Hello, I'm {sender}.";
            string message = "I'm here to demonstrate some examples of Action delegates.";
            string bye = "Thanks for reading this. I hope it was useful for you. Happy coding!!";

            // Plain method calling
            Console.WriteLine($"Relaying by plain method calling:");
            AnotherMessageRelayMethod(sender, greetings);
            AnotherMessageRelayMethod(sender, message);
            AnotherMessageRelayMethod(sender, bye);

            // Using Action for referencing method, thus allow convenient, concise and clean codes
            Console.WriteLine($"\r\nRelaying by action of {nameof(MessageRelayMethodWithVeryLongName)}:");
            Action<string> relay1 = MessageRelayMethodWithVeryLongName;
            relay1(greetings);
            relay1(message);
            relay1(bye);

            // Lambda syntax for Action initialization, which allows delegating method with different signature
            Console.WriteLine($"\r\nRelaying by action of {nameof(AnotherMessageRelayMethod)}:");
            Action<string> relay2 = (m) => AnotherMessageRelayMethod(sender, m);
            relay2(greetings);
            relay2(message);
            relay2(bye);

            // Actions with similar signature can be combined just like plain value-types
            // This will eventually call both actions
            Console.WriteLine($"\r\nRelaying by combined action of {nameof(MessageRelayMethodWithVeryLongName)} and {nameof(AnotherMessageRelayMethod)}:");
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

            // Or it can be rightly instantiated as lambda expression
            Console.WriteLine($"\r\nRelaying by action as argument of another method (lambda syntax):");
            RelayMessages(m => Console.WriteLine(m), greetings, message, bye);
        }

        public static void DemonstrateFunc()
        {
            //TODO
        }

        public static void MessageRelayMethodWithVeryLongName(string message)
        {
            Console.WriteLine(message);
        }

        public static void AnotherMessageRelayMethod(string sender, string message)
        {
            Console.WriteLine($"{sender}: {message}");
        }

        public static void RelayMessages(Action<string> relay, params string[] messages)
        {
            messages?.ToList().ForEach(m => relay(m));
        }

    }
}