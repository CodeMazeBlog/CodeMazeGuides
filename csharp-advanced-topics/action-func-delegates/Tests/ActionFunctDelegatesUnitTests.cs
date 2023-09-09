using action_func_delegates;
using Xunit;
using static action_func_delegates.FuncDelegate;
using static action_func_delegates.ActionDelegate;

namespace Tests
{
    public class ActionFunctDelegatesUnitTests
    {
        private readonly List<User> _users = new()
        {
            new User("Marin", "Tanner", "marin.tanner@mail.com", 20),
            new User("Jakob", "Estes", "jakob.estes@mail.com", 23),
            new User("Tess", "Hansen", "tess.hansen@mail.com", 44),
            new User("Luka", "Lester", "luka.lester@mail.com", 50)
        };

        [Fact]
        public void WhenDisplayinUsers_ThenCallActionForEachUser()
        {
            var expectedUserCount = _users.Count;
            var actionCallCount = 0;

            DisplayUsers(_users, user => actionCallCount++);

            Assert.Equal(expectedUserCount, actionCallCount);
        }

        [Fact]
        public void WhenSearchingExistingUser_ThenReturnMatchingUser()
        {
            var result = Find(_users, user => user.Email == "jakob.estes@mail.com");

            Assert.NotNull(result);
            Assert.Equal("Jakob", result.FirstName);
            Assert.Equal("Estes", result.LastName);
        }

        [Fact]
        public void WhenSearchingNonExistingUser_ThenReturnNull()
        {
            var result = Find(_users, user => user.Age < 18);

            Assert.Null(result);
        }
    }
}