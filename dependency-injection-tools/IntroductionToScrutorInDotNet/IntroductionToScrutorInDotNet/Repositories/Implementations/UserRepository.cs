using IntroductionToScrutorInDotNet.Entities;

namespace IntroductionToScrutorInDotNet.Repositories.Implementations;

public class UserRepository : IRepository<User>
{
    private readonly List<User> _users = new()
    {
        new User
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe"
        },
        new User
        {
            Id = 2,
            FirstName = "Janine",
            LastName = "Doe"
        }
    };

    public IEnumerable<User> GetAll()
    {
        return _users;
    }
}