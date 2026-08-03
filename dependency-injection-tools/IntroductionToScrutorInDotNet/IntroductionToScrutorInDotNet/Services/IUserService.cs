using IntroductionToScrutorInDotNet.Entities;

namespace IntroductionToScrutorInDotNet.Services;

public interface IUserService
{
    User GetUser(int id);
    
}