using ConsumerApp.Domain.Interfaces;
using ConsumerApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerApp.Application.cs
{
    public class ProgramApplication
    {
        private readonly IUserApiRepository _userRepository;
        private readonly ILoginApiRepository _loginApiRepository;

        public ProgramApplication(IUserApiRepository userRepository, ILoginApiRepository loginApiRepository)
        {
            _userRepository = userRepository;
            _loginApiRepository = loginApiRepository;
        }

        public async Task SignIn()
        {
            Console.WriteLine("----- Let's sign in");

            Console.Write("Type the Email: ");
            var email = Console.ReadLine() ?? "johnDoe@codemaze.com";

            Console.Write("Type the password: ");
            var password = Console.ReadLine() ?? "123456";

            Environment.SetEnvironmentVariable("email", email);
            Environment.SetEnvironmentVariable("password", password);

            var token = await _loginApiRepository.AuthenticateAsync();
            Environment.SetEnvironmentVariable("token", token.Token);
        }

        public async Task RunAsync()
        {
            Console.WriteLine();

            int option;
            do
            {
                Console.WriteLine("----------------- Menu -----------------");
                Console.WriteLine("Choose an option");
                Console.WriteLine(" 1) Create new User");
                Console.WriteLine(" 2) List all users");
                Console.WriteLine(" 3) Get Users by Id");
                Console.WriteLine(" 4) Reenter credentials");
                Console.WriteLine(" 5) Quit");
                Console.Write("  Option: ");
                option = int.Parse(Console.ReadLine() ?? "4");
                
                Console.WriteLine("---");
                
                switch (option)
                {
                    case 1:
                        var user = CreateNewUser();
                        await _userRepository.CreateUserAsync(user, Environment.GetEnvironmentVariable("token"));
                        break;
                    case 2:
                        PrintEveryUser(await GetAllUsers());
                        break;
                    case 3:
                        var userId = GetUserId();
                        PrintEveryUser(new List<UserModel> { await GetUserById(userId) });
                        break;
                    case 4:
                        await SignIn();
                        break;
                    case 5:
                    default:
                        continue;
                }

                Console.WriteLine("---");
                Console.WriteLine();
                Console.WriteLine("Hit any key to proceed.");
                Console.ReadKey();

                Console.Clear();

            } while (option != 5);

            Console.WriteLine();
            Console.WriteLine("-- End of execution. hit <ENTER> to finish.");
            Console.ReadLine();
        }

        public async Task<UserModel> GetUserById(int userId)
        {
            return await _userRepository.GetUserAsync(userId);
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            return await _userRepository.GetUsersAsync();
        }

        private int GetUserId()
        {
            Console.Write("Type the userId: ");
            return int.Parse(Console.ReadLine() ?? "0");
        }

        private void PrintEveryUser(IEnumerable<UserModel> userModel)
        {
            var users = userModel.ToList();

            foreach (var item in users)
            {
                Console.WriteLine($"   {item.Email}");
            }
        }

        private UserModel CreateNewUser()
        {
            Console.Write(" Type the User first name: ");
            var firstName = Console.ReadLine();

            Console.Write(" Type the user last name: ");
            var lastName = Console.ReadLine();

            Console.Write(" Type the email address: ");
            var email = Console.ReadLine();

            Console.Write(" Type the password: ");
            var password = Console.ReadLine();

            return new UserModel
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Password = password
            };
        }
    }
}
