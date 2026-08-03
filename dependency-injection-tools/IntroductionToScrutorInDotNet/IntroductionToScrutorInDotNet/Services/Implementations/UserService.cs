using IntroductionToScrutorInDotNet.Entities;

namespace IntroductionToScrutorInDotNet.Services.Implementations;

public class UserService : IUserService
{
    public User GetUser(int id)
    {
        return new User
        {
            Id = id,
            FirstName = "John",
            LastName = "Doe",
        };
    }
}