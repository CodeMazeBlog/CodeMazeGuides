namespace SplitEntityIntoDifferentTableMappings
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool RememberMe { get; set; }
        public string Theme { get; set; }

        public User(int id, string name, string email, bool rememberMe, string theme)
        {
            Id = id;
            Name = name;
            Email = email;
            RememberMe = rememberMe;
            Theme = theme;
        }
    }
}
