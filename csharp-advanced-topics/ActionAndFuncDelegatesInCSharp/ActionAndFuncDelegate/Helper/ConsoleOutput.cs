namespace ActionAndFuncDelegate.Helper
{
	public class ConsoleOutput : IDisposable
	{
		private readonly StringWriter _consoleOutputWriter;
		private readonly TextWriter _originalOutputWriter;

		public ConsoleOutput()
		{
			_consoleOutputWriter = new StringWriter();
			_originalOutputWriter = Console.Out;
			Console.SetOut(_consoleOutputWriter);
		}

		public string GetOutput()
		{
			return _consoleOutputWriter.ToString();
		}

		public void Dispose()
		{
			Console.SetOut(_originalOutputWriter);
			_consoleOutputWriter.Dispose();
		}
	}
}
