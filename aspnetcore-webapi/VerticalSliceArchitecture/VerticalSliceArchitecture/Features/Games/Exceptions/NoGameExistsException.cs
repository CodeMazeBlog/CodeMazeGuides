namespace VerticalSliceArchitecture.Features.Games.Exceptions
{
    public class NoGameExistsException : Exception
    {
        public NoGameExistsException(int consoleId, int gameId) : base($"Game with id: {gameId} doesn't exist for console id {consoleId}")
        {
            ConsoleId = consoleId;
            GameId = gameId;
        }

        public int ConsoleId { get; set; }
        public int GameId { get; set; }
    }
}
