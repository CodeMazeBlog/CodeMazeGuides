using UserApi.Models;

namespace UserApi.Database
{
    public class UsersDatabase : List<UserModel>
    {
        public UsersDatabase()
        {
            Add(new UserModel
            {
                Id = this.Count + 1,
                Email = "JohnDoe@codemaze.com",
                Password = "123456",
                FirstName = "John",
                LastName = "Doe"
            });

            Add(new UserModel
            {
                Id = this.Count + 1,
                Email = "JaneDoe@codemaze.com",
                Password = "654321",
                FirstName = "Jane",
                LastName = "Doe"
            });

            Add(new UserModel
            {
                Id = this.Count + 1,
                Email = "RichardRoe@codemaze.com",
                Password = "987456",
                FirstName = "Richard",
                LastName = "Roe"
            });
        }

        public void AddUser(UserModel userModel)
        {
            userModel.Id = this.Count + 1;
            
            Add(userModel);
        }
    }
}
