using Domain.Repositories;
using Services.Abstractions;

namespace Services;

public sealed class ServiceManager(IRepositoryManager repositoryManager) : IServiceManager
{
    private readonly Lazy<ICatService> _lazyCatService = new(
        () => new CatService(repositoryManager));

    public ICatService CatService => _lazyCatService.Value;
}
