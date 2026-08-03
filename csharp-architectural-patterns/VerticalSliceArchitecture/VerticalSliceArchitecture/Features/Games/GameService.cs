using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.Data;
using VerticalSliceArchitecture.Domain;

namespace VerticalSliceArchitecture.Features.Games
{
    public class GameService : IGameService
    {
        private readonly DataContext _context;

        public GameService(DataContext context)
        {
            _context = context;
        }
        public void AddGameToConsole(int consoleId, Game game)
        {
            game.ConsoleId = consoleId;

            _context.Games.Add(game);
        }

        public void DeleteGame(Game game)
        {
            _context.Games.Remove(game);
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync(int consoleId)
        {
            return await _context.Games
                .Where(x => x.ConsoleId == consoleId)
                .ToListAsync();
        }

        public async Task<Game> GetGameAsync(int consoleId, int gameId)
        {
            return await _context.Games
                .FirstOrDefaultAsync(x => x.ConsoleId == consoleId && x.Id == gameId);
        }
    }
}
