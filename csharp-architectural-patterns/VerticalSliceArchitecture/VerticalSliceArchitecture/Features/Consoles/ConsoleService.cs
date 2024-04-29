using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.Data;
using VerticalSliceArchitecture.Domain;

namespace VerticalSliceArchitecture.Features.Consoles
{
    public class ConsoleService : IConsoleService
    {
        private readonly DataContext _context;

        public ConsoleService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GameConsole>> GetAllConsolesAsync()
        {
            return await _context.Consoles
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<GameConsole> GetConsoleByIdAsync(int consoleId)
        {
            return await _context.Consoles
                .FirstOrDefaultAsync(x => x.Id == consoleId);
        }
    }
}
