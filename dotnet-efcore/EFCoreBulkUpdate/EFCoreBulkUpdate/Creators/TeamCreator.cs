using EFCoreBulkUpdate.Model;

namespace EFCoreBulkUpdate.Creator
{
    public static class TeamCreator
    {
        public static IEnumerable<Team> CreateTeamsWithPlayers(int teamCount, int playerPerTeam)
        {
            return Enumerable.Range(1, teamCount)
                .Select(i => new Team
                {
                    Id = Guid.NewGuid(),
                    Description = $"Description for Code Maze",
                    Name = $"Team {i}",
                    YearFounded = 2000,
                    Players = Enumerable.Range(1, playerPerTeam).Select(j => new Player()
                    {
                        Name = $"Player {teamCount * i + j}",
                        Id = Guid.NewGuid(),
                        Age = j
                    }).ToList()
                });
        }
    }
}
