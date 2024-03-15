using EFCoreBulkUpdate.Model;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EFCoreBulkUpdate.Services
{
    public class GameService
    {
        private readonly TeamDBContext _context;

        public GameService(TeamDBContext context)
        {
            _context = context;
        }

        public async Task AddGames(IEnumerable<Game> games)
        {
            _context.Games.AddRange(games);

            await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAllFootballGames()
        {
            return await _context.Games
                .OfType<FootballGame>()
                .ExecuteDeleteAsync();
        }

        public async Task<int> UpdateAllGames(string newOponent)
        {
            return await _context.Games
                .ExecuteUpdateAsync(g => g.SetProperty(b => b.Opponent, b => newOponent));
        }

        public async Task DeleteAllBasketballGames()
        {
            await _context.Games
                .OfType<BasketballGame>()
                .ExecuteDeleteAsync();
        }

        public string PrintGames(ICollection<Game> games)
        {
            StringBuilder sb = new StringBuilder();
            if (!games.Any())
            {
                sb.AppendLine("[Empty]");
            }
            else
            {                              
                sb.AppendLine("TeamName" + "    " + "Opponent" + "      " + "1stHalfScore" + "    " + "2ndHalfScore");
                sb.AppendLine("-----------------------------------------------------------------");
                var footballGames = games.OfType<FootballGame>().ToList();
                if (!footballGames.Any())
                    sb.AppendLine("[Empty]");
                foreach (var football in footballGames)
                {
                    sb.AppendLine(football.Team.Name + "    " + football.Opponent + "         " + football.FirstHalfTimeScore + "             " + football.SecondHalfTimeScore);
                }
                sb.AppendLine();                
                
                sb.AppendLine("TeamName" + "    " + "Opponent" + "      " + "Q1Score" + "      " + "Q2Score" + "      " + "Q3Score" + "      " + "Q4Score" + "      ");
                sb.AppendLine("----------------------------------------------------------------------------");
                var basketballGames = games.OfType<BasketballGame>().ToList();
                if (!basketballGames.Any())
                    sb.AppendLine("[Empty]");
                foreach (var basketball in basketballGames)
                {
                    sb.AppendLine(basketball.Team.Name + "    " + basketball.Opponent + "         " + basketball.Quarter1Score + "         " + basketball.Quarter2Score + "    " + basketball.Quarter3Score + "    " + basketball.Quarter4Score);
                }
            }

            return sb.ToString();
        }
    }
}