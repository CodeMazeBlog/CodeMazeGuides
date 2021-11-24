using System;

namespace DelegatesInCsharp
{
	delegate void PrintMessage(string text);
	delegate T Print<T>(T param1);

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

		private static void WriteRandomNumber()
		{
			Console.WriteLine(GenerateRandomNumber());
		}
		private static void WriteRandomNumberWithSeed(int seed)
		{
			Console.WriteLine(GenerateRandomNumberWithSeed(seed));
		}
		private static int GenerateRandomNumber()
		{
			return new Random().Next();
		}
		private static int GenerateRandomNumberWithSeed(int seed)
		{
			return new Random(seed).Next();
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

			//Action and Func Delegates in C# Example
			Action executeWriteRandomNumber = WriteRandomNumber;
			Action<int> executeWriteRandomNumberWithSeed = WriteRandomNumberWithSeed;
			executeWriteRandomNumber();
			executeWriteRandomNumberWithSeed(1);

			Func<int> executeGenerateRandomNumber = GenerateRandomNumber;
			Func<int,int> executeGenerateRandomNumberWithSeed = GenerateRandomNumberWithSeed;
			executeGenerateRandomNumber();
			executeGenerateRandomNumberWithSeed(11);

			Action executeLambdaWriteRandomNumber = () => Console.WriteLine(GenerateRandomNumber());
			Action<int> executeLambdaWriteRandomNumberWithSeed = (s) => Console.WriteLine(GenerateRandomNumberWithSeed(s));
			executeLambdaWriteRandomNumber();
			executeLambdaWriteRandomNumberWithSeed(2);

			Func<int> executeLambdaGenerateRandomNumber = () => new Random().Next();
			Func<int, int> executeLambdaGenerateRandomNumberWithSeed = (s) => new Random(s).Next();
			executeLambdaGenerateRandomNumber();
			executeLambdaGenerateRandomNumberWithSeed(22);
		}
    }
}
