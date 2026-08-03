using EFCoreBulkUpdate.Model;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EFCoreBulkUpdate.Services
{
    public class TeamService
    {
        private readonly TeamDBContext _context;

        public TeamService(TeamDBContext context)
        {
            _context = context;
        }

        public async Task AddTeams(IEnumerable<Team> teams)
        {
            _context.AddRange(teams);

            await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAllTeamsYearFounded_V1()
        {
            var teams = await _context.Teams
                .ToListAsync();

            foreach (var team in teams)
            {
                team.YearFounded += 1;
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateTeamsYearFounded_V1(int minYearFounded)
        {
            var teams = await _context.Teams
                .Where(t => t.YearFounded >= minYearFounded)
                .ToListAsync();

            foreach (var team in teams)
            {
                team.YearFounded += 1;
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAllTeamsYearAndDescription_V1(string addedDescription)
        {
            var teams = await _context.Teams
                .ToListAsync();

            foreach (var team in teams)
            {
                team.YearFounded += 1;
                team.Description += " " + addedDescription;
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAllTeamsYearFounded_V2()
        {
            return await _context.Teams
                .ExecuteUpdateAsync(t => t.SetProperty(b => b.YearFounded, b => b.YearFounded + 1));
        }

        public async Task UpdateTeamsYearFounded_V2(int minYearFounded)
        {
            await _context.Teams
                .Where(t => t.YearFounded >= minYearFounded)
                .ExecuteUpdateAsync(t => t.SetProperty(b => b.YearFounded, b => b.YearFounded + 1));
        }

        public async Task<int> UpdateTeamsYearAndDescription_V1(int minYearFounded, string addedDescription)
        {
            var teams = await _context.Teams
                .Where(t => t.YearFounded >= minYearFounded)
                .ToListAsync();

            foreach (var team in teams)
            {
                team.YearFounded += 1;
                team.Description += " " + addedDescription;
            }

            return await _context.SaveChangesAsync();
        }

        public async Task UpdateTeamsYearAndDescription_V2(int minYearFounded, string description)
        {
            await _context.Teams
                .Where(t => t.YearFounded >= minYearFounded)
                .ExecuteUpdateAsync(t =>
                   t.SetProperty(b => b.YearFounded, b => b.YearFounded + 1)
                    .SetProperty(b => b.Description, b => b.Description + " " + description));
        }

        public async Task<int> UpdateAllTeamsYearAndDescription_V2(string description)
        {
            return await _context.Teams
                .ExecuteUpdateAsync(t =>
                   t.SetProperty(b => b.YearFounded, b => b.YearFounded + 1)
                    .SetProperty(b => b.Description, b => b.Description + " " + description));
        }

        public async Task<List<Team>> FindAllTeams()
        {
            return await _context.Teams
                .Include("Players")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Team>> FindTeams(int minFoundedYear)
        {
            return await _context.Teams
                .Where(p => p.YearFounded >= minFoundedYear)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddPlayersToTeams(ICollection<Player> players)
        {
            await _context.Players
                .AddRangeAsync(players);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllTeams()
        {
            await _context.Teams
                .ExecuteDeleteAsync();
        }

        public async Task<int> DeleteAllTeams_V1()
        {
            var teams = await _context.Teams
                .ToListAsync();

            _context.RemoveRange(teams);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAllTeams_V2()
        {
            return await _context.Teams
                .ExecuteDeleteAsync();
        }

        public async Task DeleteTeams_V2(int minYearFounded)
        {
            await _context.Teams
                .Where(t => t.YearFounded >= minYearFounded)
                .ExecuteDeleteAsync();
        }

        public string PrintTeams(ICollection<Team> teams)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name" + "    " + "YearFounded" + "    " + "Description");
            sb.AppendLine("------------------------------------------------------");
            if (!teams.Any())
                sb.AppendLine("[Empty]");
            
            foreach (var team in teams)
            {
                sb.AppendLine(team.Name + "    " + team.YearFounded + "    " + team.Description);
            }

            return sb.ToString();
        }
    }
}
