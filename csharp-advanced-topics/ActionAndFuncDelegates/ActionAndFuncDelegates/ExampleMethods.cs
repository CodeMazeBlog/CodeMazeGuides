using ActionAndFuncDelegates.Entities;
using ActionAndFuncDelegates.IO;

namespace ActionAndFuncDelegates
{
    public class ExampleMethods
    {
        private readonly IAppConsole _appConsole;

        public ExampleMethods(IAppConsole appConsole)
        {
            _appConsole = appConsole;
        }
        
        public void PrintUserName(User user) => _appConsole.WriteLine($"\t\tThe username is {user.Name}");

        public void PrintAllUserData(User user) => _appConsole.WriteLine($"\t\t{user.Name} is {user.Age} years old");
  
        public void PrintUserDaysOfLife(User user) => _appConsole.WriteLine($"\t\t{user.Name} is {user.Age * 365} days old");

        public string PrintIfUserIsAdultOrChild(User user)
        {
            if (user.Age < 18)
                return $"\t\t{user.Name} is a child";

            return $"\t\t{user.Name} is an adult";
        }

    }
}