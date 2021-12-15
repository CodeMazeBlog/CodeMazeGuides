namespace RealWorldActionDelegate
{
	using System;
	using System.Collections.Generic;
	public class TTMixDoubleParticipants
	{
		public List<string> players;
		public TTMixDoubleParticipants()
		{
			players = new List<string>();
			players.Add("Bruce");
			players.Add("Tina");
			players.Add("Tim");
			players.Add("Mina");
		}
	}

	public class Helpers
	{
		public static void PrintUpperCase(string word)
		{
			Console.WriteLine(word.ToUpper());
		}
	}

	public class ActionDelegateRealWorld
	{
		public static void Main()
		{
			TTMixDoubleParticipants ttMixDoubleParticipants = new TTMixDoubleParticipants();
			Action<string> toUpperFunctionPointer = Helpers.PrintUpperCase;
			ttMixDoubleParticipants.players.ForEach(toUpperFunctionPointer);
		}
	}

}
