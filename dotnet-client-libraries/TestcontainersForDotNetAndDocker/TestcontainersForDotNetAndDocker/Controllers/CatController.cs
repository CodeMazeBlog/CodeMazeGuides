using TestcontainersForDotNetAndDocker.Services;

namespace TestcontainersForDotNetAndDocker.Controllers;

public class CatController
{
    private readonly ICatService _catService;

    public CatController(ICatService catService)
    {
        _catService = catService;
    }
}
