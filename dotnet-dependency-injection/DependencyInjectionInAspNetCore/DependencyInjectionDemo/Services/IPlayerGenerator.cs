using DependencyInjectionDemo.Models;

namespace DependencyInjectionDemo.Services;

public interface IPlayerGenerator
{
    Player CreateNewPlayer();
}
