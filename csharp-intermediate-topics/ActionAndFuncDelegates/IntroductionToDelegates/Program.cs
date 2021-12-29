using System;

namespace IntroductionToDelegates
{
	class Program
	{
		delegate string SaySomething();

		static string SayHi() { return "Hi!"; }

		static void Main(string[] args)
		{
			SaySomething methodSayHi = SayHi;
			Console.WriteLine(methodSayHi.Invoke());
		}
	}
}
