using EFCoreBulkUpdate.Model;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EFCoreBulkUpdate
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

        public async Task<int> DeleteAllFootballs()
        {
            return await _context.Games.Where(p => p is FootballGame)
                                .OfType<FootballGame>().ExecuteDeleteAsync();
        }

        public async Task<int> UpdateAllGames(string newOponent)
        {
            return await _context.Games.ExecuteUpdateAsync(g => g.SetProperty(b => b.Opponent,b=> newOponent));
        }

        public async Task DeleteAllBasketballs()
        {
            await _context.Games.Where(p => p is BasketballGame)
                                .OfType<BasketballGame>().ExecuteDeleteAsync();
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
                var footballs = games.Where(p => p is FootballGame).OfType<FootballGame>().ToList();
                var basketballs = games.Where(p => p is BasketballGame).OfType<BasketballGame>().ToList();
                sb.AppendLine("Team Name" + "    " + "Opponent Name" + "    " + "FirstHalfTimeScore" + "    " + "SecondHalfTimeScore");
                sb.AppendLine("-----------------------------------------------------------------");
                if (!footballs.Any())
                    sb.AppendLine("[Empty]");
                foreach (var football in footballs)
                {
                    sb.AppendLine(football.Team.Name + "    " + football.Opponent + "    " + football.FirstHalfTimeScore + "    " + football.SecondHalfTimeScore);
                }

                sb.AppendLine("TeamName" + "    " + "OpponentName" + "    " + "Q1Score" + "    " + "Q2Score"+"    "+"Q3Score"+"    "+"Q4Score"+"    ");
                sb.AppendLine("----------------------------------------------------------------------------");
                if (!basketballs.Any())
                    sb.AppendLine("[Empty]");
                foreach (var basketball in basketballs)
                {
                    sb.AppendLine(basketball.Team.Name + "    " + basketball.Opponent + "    " + basketball.Quarter1Score + "    " + basketball.Quarter2Score + "    " + basketball.Quarter3Score + "    " + basketball.Quarter4Score);
                }
            }

            return sb.ToString();
        }
    }
}