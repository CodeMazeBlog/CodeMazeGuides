using EFCoreBulkUpdate.Model;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EFCoreBulkUpdate.Services
{
    public class EmployeeService
    {
        private readonly TeamDBContext _context;

        public EmployeeService(TeamDBContext context)
        {
            _context = context;
        }

        public async Task<List<Referee>> FindAllReferess()
        {
            return await _context.Set<Referee>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> DeleteAllReferees()
        {
            return await _context.Set<Referee>()
                .ExecuteDeleteAsync();
        }

        public async Task DeleteEmployees(int minYearExperience)
        {
            await _context.Employees
                .Where(p => p.YearsExperience > minYearExperience)
                .ExecuteDeleteAsync();
        }

        public async Task<int> UpdateAllRefereesYearsExperience()
        {
            return await _context.Set<Referee>()
                 .ExecuteUpdateAsync(r => r.SetProperty(t => t.YearsExperience, t => t.YearsExperience + 1));
        }

        public async Task AddReferees(ICollection<Referee> referees)
        {
            _context.Set<Referee>()
                .AddRange(referees);

            await _context.SaveChangesAsync();
        }

        public string PrintReferees(ICollection<Referee> referees)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("First Name" + "    " + "Last Name" + "    " + "Referee Code" + "    " + "LicenceNo");
            sb.AppendLine("-----------------------------------------------------------------");
            if (!referees.Any())
                sb.AppendLine("[Empty]");

            foreach (var referee in referees)
            {
                sb.AppendLine(referee.FirstName + "    " + referee.LastName + "    " + referee.RefereeCode + "    " + referee.LicenceNo);
            }

            return sb.ToString();
        }
    }
}