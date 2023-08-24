using System.Numerics;
using System.Text.RegularExpressions;
using System.Linq;

namespace StaticVsNonstaticMethods
{
    public partial class User
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public bool CheckEmail()
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(Email);

            return match.Success;
        }

        public static bool CheckPassword(string password)
        {
            return password.Any(c => char.IsUpper(c))
                && password.Any(c => char.IsLower(c))
                && password.Any(c => char.IsNumber(c));
        }

        public bool CheckUser()
        {
            return CheckEmail() && CheckPassword(Password);
        }
    }
}
