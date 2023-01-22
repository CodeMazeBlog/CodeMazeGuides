using System;
namespace FunctionAndAction.Services
{
	public static class Utils
	{
		public static void MethodStarted()
		{
			Console.WriteLine($"The method started | {DateTime.Now}");
		}
	}
}

