using System;
using System.Collections.Generic;

namespace RealWorldFuncDelegate
{
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
		public static List<string> ConvertToUpperCaseList(List<string> words)
		{
			List<string> converted = new List<string>();
			foreach(string word in words)
			{
				converted.Add(word.ToUpper());
			}

			return converted;
		}

		public static void Print(string word)
		{
			Console.WriteLine(word);
		}
	}

	public class FuncDelegateRealWorld
	{
		public static void Main()
		{
			TTMixDoubleParticipants ttMixDoubleParticipants = new TTMixDoubleParticipants();
			Func<List<string>, List<string>> toUpperFunctionPointer = Helpers.ConvertToUpperCaseList;
			Action<string> printerFunctionPointer = Helpers.Print;
			List<string> upperCaseList = toUpperFunctionPointer(ttMixDoubleParticipants.players);
			upperCaseList.ForEach(printerFunctionPointer);
			Console.ReadLine();
		}
	}
}
