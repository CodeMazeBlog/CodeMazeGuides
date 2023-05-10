namespace ActionAndFuncDelegate.Helper
{
	public class ConsoleOutput : IDisposable
	{
		private readonly StringWriter consoleOutputWriter;
		private readonly TextWriter originalOutputWriter;

		public ConsoleOutput()
		{
			consoleOutputWriter = new StringWriter();
			originalOutputWriter = Console.Out;
			Console.SetOut(consoleOutputWriter);
		}

		public string GetOutput()
		{
			return consoleOutputWriter.ToString();
		}

		public void Dispose()
		{
			Console.SetOut(originalOutputWriter);
			consoleOutputWriter.Dispose();
		}
	}
}
