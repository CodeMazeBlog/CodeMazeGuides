using ActionsAndFuncDelegatesInCsharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	public class SendResultUnitTests
	{
		const string newLine = "\r\n";
		[Fact]
		public void GivenEmail_WhenSendByEmailIsRequested_ThenSendsByEmail()
		{
			var email = "an-eamil@address.com";
			var result = 20;
			var stringWriter = new StringWriter();
			Console.SetOut(stringWriter);

			SendResult.SendByEmail(result, email);

			var output = stringWriter.ToString();
			Assert.Equal($"Sending email to {email} with result as {result}{newLine}", output);
		}

		[Fact]
		public void GivenCallbackUrl_WhenSendByCallbackIsRequested_ThenSendsByCallback()
		{
			var callbackUrl = "http://callbackurl.codemaze.com";
			var result = 20;
			var stringWriter = new StringWriter();
			Console.SetOut(stringWriter);

			SendResult.SendByCallback(result, callbackUrl);

			var output = stringWriter.ToString();
			Assert.Equal($"Making Http Call to CallbackUrl: {callbackUrl} to send result: {result}{newLine}", output);
		}

		[Fact]
		public void GivenWhoOperationIsPerformedBy_WhenSendByConsoleIsRequested_ThenSendsByCallback()
		{
			var requestedBy = "Code Maze";
			var result = 20;
			var stringWriter = new StringWriter();
			Console.SetOut(stringWriter);

			SendResult.SendToConsole(result, requestedBy);

			var output = stringWriter.ToString();
			Assert.Equal($"The result for the operation given is {result} and was performed by {requestedBy}{newLine}", output);
		}
	}
}
