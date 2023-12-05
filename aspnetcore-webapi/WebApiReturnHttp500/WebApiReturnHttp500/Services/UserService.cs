namespace WebApiReturnHttp500.Services;

public class UserService : IUserService
{
    public List<User> GetAllUsers()
    {
        List<User> userList = new List<User>()
        {
            new User("John", "Doe", 30),
            new User("Jane", "Smith", 25),
            new User("Michael", "Johnson", 40)
        };

        return userList;
    }
}