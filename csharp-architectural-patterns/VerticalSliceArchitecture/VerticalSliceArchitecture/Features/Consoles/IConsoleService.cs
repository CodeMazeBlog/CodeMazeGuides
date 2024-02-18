using VerticalSliceArchitecture.Domain;

namespace VerticalSliceArchitecture.Features.Consoles
{
    public interface IConsoleService
    {
        Task<IEnumerable<GameConsole>> GetAllConsolesAsync();
        Task<GameConsole> GetConsoleByIdAsync(int consoleId);
    }
}
