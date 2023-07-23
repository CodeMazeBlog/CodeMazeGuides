using VerticalSliceArchitecture.Data;
using VerticalSliceArchitecture.Features.Consoles;
using VerticalSliceArchitecture.Features.Games;

namespace VerticalSliceArchitecture.ServiceManager
{
    public class ServiceManager : IServiceManager
    {
        private readonly DataContext _context;
        private IConsoleService _consoleService;
        private IGameService _gameService;

        public ServiceManager(DataContext context)
        {
            _context = context;
        }

        public IConsoleService Console
        {
            get
            {
                if (_consoleService == null)
                    _consoleService = new ConsoleService(_context);

                return _consoleService;
            }
        }

        public IGameService Game
        {
            get
            {
                if (_gameService == null)
                    _gameService = new GameService(_context);

                return _gameService;
            }
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
