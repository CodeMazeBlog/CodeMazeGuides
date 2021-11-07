using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesInCsharp
{
	delegate void PrintMessage(string text);
	delegate T Print<T>(T param1);

	class Program
	{
		public static void WriteText(string text) { Console.WriteLine($"Text: {text}"); }
		public static void ReverseWriteText(string text) { Console.WriteLine($"Text in reverse: {Reverse(text)}"); }
		public static string ReverseText(string text) { return Reverse(text); }

		private static string Reverse(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}

		static void Main(string[] args)
		{
			PrintMessage delegate1 = new PrintMessage(WriteText);
			PrintMessage delegate2 = new PrintMessage(ReverseWriteText);
			// with + sign
			PrintMessage multicastDelegate = delegate1 + delegate2;

			// with =, +=, and -=
			multicastDelegate = delegate1;
			multicastDelegate += delegate2;

			multicastDelegate.Invoke("Go ahead, make my day.");
			multicastDelegate("You're gonna need a bigger boat.");

			Print<string> delegate3 = new Print<string>(ReverseText);
			Console.WriteLine(delegate3("I'll be back."));

			Action<string> executeReverseWrite = ReverseWriteText;
			executeReverseWrite("You're gonna need a bigger boat.");

			Func<string, string> executeReverse = ReverseText;
			Console.WriteLine(executeReverse("You're gonna need a bigger boat."));

			// comment out other stuff
			Action<string> executeReverseWriteAction = ReverseWriteText;
			executeReverseWriteAction("Are you not entertained?");
			Func<string, string> executeReverseFunc = ReverseText; 
			Console.WriteLine(executeReverse("Are you not entertained?"));
		}
	}
}
