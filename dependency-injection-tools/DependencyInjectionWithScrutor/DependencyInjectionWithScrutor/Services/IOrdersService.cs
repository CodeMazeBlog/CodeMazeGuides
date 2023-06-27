using IntroductionToScrutorInDotNET.Models;

namespace IntroductionToScrutorInDotNET.Services;

public interface IOrdersService
{
    void Create(Order newOrder);
}
