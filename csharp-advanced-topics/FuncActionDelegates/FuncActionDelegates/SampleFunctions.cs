namespace FuncActionDelegates
{
	public delegate void PrintMessageConsole(string text);
	public delegate string PrintMessage(string text);

	public class SampleFunctions
    {
		public static int result;
		public static void WriteTextConsole(string text) { Console.WriteLine(text); }
		public static string WriteText(string text) { return $"Text:{text}"; }
		public static int AddNumbers(int param1, int param2) { return param1 + param2; }
		public static void AddTwoNumbers(int param1, int param2) { result = param1 + param2; }
	}
}
