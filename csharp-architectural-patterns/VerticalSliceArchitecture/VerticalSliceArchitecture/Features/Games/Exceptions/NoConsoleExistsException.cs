namespace VerticalSliceArchitecture.Features.Games.Exceptions
{
    public class NoConsoleExistsException : Exception
    {
        public NoConsoleExistsException(int consoleId) : base($"Console with id: {consoleId} doesn't exist.") { }
    }
}
