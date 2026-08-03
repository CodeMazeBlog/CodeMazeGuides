using VerticalSliceArchitecture.Domain;

namespace VerticalSliceArchitecture.Features.Games
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetAllGamesAsync(int consoleId);
        Task<Game> GetGameAsync(int consoleId, int gameId);
        void AddGameToConsole(int consoleId, Game game);
        void DeleteGame(Game game);
    }
}
