namespace DifferencesBetweenNUnitXUnitandMStest;

public class UserService
{
    private readonly List<User> _users;

    public UserService()
    {
        _users = new List<User>();
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void RemoveUser(string username)
    {
        var userToRemove = _users.FirstOrDefault(u => u.Username.Equals(username));

        if (userToRemove != null)
        {
            _users.Remove(userToRemove);
        }
    }

    public bool Authenticate(string username, string password)
    {
        var userToAuthenticate = _users.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));

        return userToAuthenticate != null;
    }
}
