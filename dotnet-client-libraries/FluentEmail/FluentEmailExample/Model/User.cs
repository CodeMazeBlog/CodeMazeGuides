namespace FluentEmailExample.Model
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? MemberType { get; set; }

        public User(string name, string email, string? memberType)
        {
            Name = name;
            Email = email;
            MemberType = memberType;
        }
    }
}
