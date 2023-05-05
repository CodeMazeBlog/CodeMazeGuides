using System;

namespace DelegatesInCsharp
{
	delegate void PrintMessage(string text);
	delegate T Print<T>(T param1);

	public delegate string FormatString(string s); 	
	public readonly FormatString Format = s => s.Trim();

	class Program
	{
		public static void WriteText(string text) => Console.WriteLine($"Text: {text}");
		public static void ReverseWriteText(string text) => Console.WriteLine($"Text in reverse: {Reverse(text)}");
		public static string ReverseText(string text) => Reverse(text);

		private static string Reverse(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}

		public static string DoSomething(FormatString format)
		{
			var s = "a string";
			return format(s);
		}

		static void Main(string[] args)
		{
			var delegate1 = new PrintMessage(WriteText);
			var delegate2 = new PrintMessage(ReverseWriteText);
			// with + sign
			var multicastDelegate = delegate1 + delegate2;

			// with =, +=, and -=
			multicastDelegate = delegate1;
			multicastDelegate += delegate2;

			multicastDelegate.Invoke("Go ahead, make my day.");
			multicastDelegate("You're gonna need a bigger boat.");

			var delegate3 = new Print<string>(ReverseText);
			Console.WriteLine(delegate3("I'll be back."));

			// comment out other stuff
			Action<string> executeReverseWriteAction = ReverseWriteText;
			executeReverseWriteAction("Are you not entertained?");
			Func<string, string> executeReverseFunc = ReverseText;
			Console.WriteLine(executeReverseFunc("Are you not entertained?"));

			// Action delegate
			var doSomething = () => Console.WriteLine("action");
			doSomething();

			Action<string> print = Console.WriteLine;
			print("hello world");

			Action<int, int> printSum = (x, y) => Console.WriteLine(x + y);
			printSum(3, 4);

			// Func delegate
			Func<string> getString = () => "hardcoded string";
			var s = getString();

			Func<int, int, int> sum = (x, y) => x + y;
			var result = sum(5, 6);

			Func<int, bool> isOdd = x => x % 2 == 0;
			var numbers = new[] { 1, 2, 3 };
			var oddNumbers = numbers.Where(isOdd);
		}
	}
}
