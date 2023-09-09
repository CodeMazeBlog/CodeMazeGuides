using Moq;
using System.Data;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using UsersManagerLib;

namespace ActionAndFuncDelegatesInCSharp
{
    class Program
    {
        public static void Method1()
        {
        }

        public static void ExampleMethod(Action act)
        {
            //some actions
        }

        static void Main(string[] args)
        {
            UserManagerAddUserExamplea();
            return;
            var action = new Action(() =>
            {
                //some actions
            });
            action = Method1;
            action = delegate ()
            {
                //some actions
            };
            action = () =>
            {
                //some actions
            };

            action = null;
            action?.Invoke();
            action();

            void MethodWithInt(int a) { };

            var actionWithIntParam = new Action<int>((a) => { });
            actionWithIntParam = MethodWithInt;
            actionWithIntParam = delegate (int a) { };
            actionWithIntParam = (a) => { };

            actionWithIntParam?.Invoke(1);



            void MethodWithIntInt(int a, int b) { };

            var actionWithIntIntParam = new Action<int, int>((a, b) => { });
            actionWithIntIntParam = MethodWithIntInt;
            actionWithIntIntParam = delegate (int a, int b) { };
            actionWithIntIntParam = (a, b) => { };

            actionWithIntIntParam?.Invoke(1, 2);


            int MethodWithRet() { return 1; };
            var funcWithRet = new Func<int>(() => 1);
            funcWithRet = MethodWithRet;
            funcWithRet = delegate () { return 1; };
            funcWithRet = () => { return 1; };
            funcWithRet?.Invoke();

            int MethodWithIntAndRet(int a) { return 1; };
            var funcWithIntAndRet = new Func<int, int>((a) => 1);
            funcWithIntAndRet = MethodWithIntAndRet;
            funcWithIntAndRet = delegate (int a) { return 1; };
            funcWithIntAndRet = (a) => { return 1; };
            funcWithIntAndRet?.Invoke(1);


            var users = new List<User>() {
                new User(){Id=1,Name="Name1"},
                new User(){Id=2,Name="Name2"},
                new User(){Id=3,Name="Name3"},
            };

            users.Where(new Func<User, bool>((user) => user.Id == 1));
            users.Where(user => user.Id == 1);
        }

        public static void UserManagerGetUsers()
        {
            var usersMng = new UsersManager()
            {
                Users = new List<User>() {
                            new User(){Id=1,Name="Name1"},
                            new User(){Id=2,Name="Name2"},
                            new User(){Id=3,Name="Name3"},
                        }
            };

            var filteredUsers = usersMng.GetUsers(new Func<User, bool>((user) => user.Id == 1));
            foreach (var user in filteredUsers)
            {
                Console.WriteLine(user);
            }

            filteredUsers = usersMng.GetUsers(((user) => user.Id == 1));
            foreach (var user in filteredUsers)
            {
                Console.WriteLine(user);
            }
        }

        public static void UserManagerAddUserExamplea()
        {
            var userMgr = new UsersManager();
            userMgr.AddUser(new User() { Id = 1, Name = "Name1" });
            userMgr.AddUser(new User() { Id = 2, Name = "name2" });
            Console.Write(userMgr.GetUsers(user => true).Count());
        }

    }
}