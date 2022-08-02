using VerticalSliceArchitecture.Features.Consoles;
using VerticalSliceArchitecture.Features.Games;

namespace VerticalSliceArchitecture.ServiceManager
{
    public interface IServiceManager
    {
        IConsoleService Console { get; }
        IGameService Game { get; }
        Task SaveAsync();
    }
}
