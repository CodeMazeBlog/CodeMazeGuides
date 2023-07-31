using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionsAndFuncDelegatesInCsharp
{
	public static class SendResult
	{
		public static void SendByEmail(double result, string email)
		{
			Console.WriteLine($"Sending email to {email} with result as {result}");
		}

		public static void SendByCallback(double result, string callbackUrl)
		{
			Console.WriteLine($"Making Http Call to CallbackUrl: {callbackUrl} to send result: {result}");
		}

		public static void SendToConsole(double result, string performedBy)
		{
			Console.WriteLine($"The result for the operation given is {result} and was performed by {performedBy}");
		}
	}
}
