namespace DifferencesBetweenNUnitXUnitandMStest;

public class UserService
{
    private readonly List<User> users;

    public UserService()
    {
        users = new List<User>();
    }

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void RemoveUser(string username)
    {
        var userToRemove = users.FirstOrDefault(u => u.Username.Equals(username));

        if (userToRemove != null)
        {
            users.Remove(userToRemove);
        }
    }

    public bool Authenticate(string username, string password)
    {
        var userToAuthenticate = users.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));

        return userToAuthenticate != null;
    }
}
