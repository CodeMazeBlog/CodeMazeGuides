
namespace UsersManagerLib
{
    public class UsersManager
    {
        public List<User> Users { get; set; }
        public Func<string, bool> UserNameValidation { get; set; } = new Func<string, bool>((name) => char.IsUpper(name[0]));
        public IEnumerable<User> GetUsers(Func<User, bool> userFilter)
        {
            List<User> users = new List<User>();
            if (userFilter == null || Users == null)
                return users;
            foreach (var user in Users)
            {
                if (userFilter(user))
                    users.Add(user);
            }
            return users;
        }
        public bool AddUser(User user)
        {
            if (user == null || !UserNameValidation(user.Name))
                return false;
            if (Users == null)
                Users = new List<User>();
            Users.Add(user);
            return true;
        }
    }
}