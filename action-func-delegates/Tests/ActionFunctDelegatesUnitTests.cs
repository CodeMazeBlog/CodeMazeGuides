using action_func_delegates;
using Xunit;

namespace Tests
{
    public class ActionFunctDelegatesUnitTests
    {

        private void DisplayUsers(List<User> users, Action<User> display)
        {
            foreach (var user in users)
            {
                display(user);
            }
        }

        private User Find(List<User> users, Func<User, bool> compare)
        {
            foreach (var user in users)
            {
                if (compare(user))
                {
                    return user;
                }
            }
            return null;
        }


        [Fact]
        public void WhenDisplayinUsers_ShouldCallActionForEachUser()
        {
            var users = new List<User>
            {
                new User("Marin", "Tanner", "marin.tanner@mail.com"),
                new User("Jakob", "Estes", "jakob.estes@mail.com"),
                new User("Tess", "Hansen", "tess.hansen@mail.com"),
                new User("Luka", "Lester", "luka.lester@mail.com")
            };

            var expectedUserCount = users.Count;
            var actionCallCount = 0;

            DisplayUsers(users, user => actionCallCount++);

            Assert.Equal(expectedUserCount, actionCallCount);
        }

        [Fact]
        public void WhenSearchingExistingUser_ShouldReturnMatchingUser()
        {
            var users = new List<User>
            {
                new User("Marin", "Tanner", "marin.tanner@mail.com"),
                new User("Jakob", "Estes", "jakob.estes@mail.com"),
                new User("Tess", "Hansen", "tess.hansen@mail.com"),
                new User("Luka", "Lester", "luka.lester@mail.com")
            };

            var result = Find(users, user => user.Email == "jakob.estes@mail.com");

            Assert.NotNull(result);
            Assert.Equal("Jakob", result.FirstName);
            Assert.Equal("Estes", result.LastName);
        }

        [Fact]
        public void WhenSearchingNonExistingUser_ShouldReturnNull()
        {
            var users = new List<User>
            {
                new User("Marin", "Tanner", "marin.tanner@mail.com", 20),
                new User("Jakob", "Estes", "jakob.estes@mail.com", 23),
                new User("Tess", "Hansen", "tess.hansen@mail.com", 44),
                new User("Luka", "Lester", "luka.lester@mail.com", 50)
            };

            var result = Find(users, user => user.Age < 18);

            Assert.Null(result);
        }
    }
}