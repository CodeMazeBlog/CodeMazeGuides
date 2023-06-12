using EFCoreBulkUpdate.Model;

namespace EFCoreBulkUpdate.Creator
{
    public static class GameCreator
    {
        public static IEnumerable<Game> CreateFootballGames(int footbalGameCount)
        {
            var newTeam = new Team
            {
                Id = Guid.NewGuid(),
                Description = $"Description {0} for Code Maze",
                Name = $"Team {0}",
                YearFounded = new Random().Next(1970, 2023)
            };

            return Enumerable.Range(1, footbalGameCount)
                .Select(j => new FootballGame()
                {
                    Opponent = $"Opponent {footbalGameCount + j}",
                    Id = Guid.NewGuid(),
                    FirstHalfTimeScore = j,
                    SecondHalfTimeScore = j,
                    Date = DateTime.Now,
                    Team = newTeam
                });
        }
    }
}
