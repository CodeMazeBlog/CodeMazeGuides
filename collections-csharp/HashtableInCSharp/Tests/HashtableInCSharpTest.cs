using HashtableInCSharp;
using System.Collections;

namespace Tests
{
    public class HashtableInCSharpTest
    {
        private readonly Hashtable _userHashtable;

        public HashtableInCSharpTest()
        {
            _userHashtable = HashtableDemo.CreateHashTableFromDictionary();
        }

        [Fact]
        public void GivenHashtable_WhenCreatingHashtable_ThenReturnsEmptyHashTable()
        {
            var userHashtable = HashtableDemo.CreateEmptyHashTable();

            Assert.IsType<Hashtable>(userHashtable);
            Assert.Empty(userHashtable);
        }

        [Fact]
        public void GivenHashtable_WhenCreatingHashtableWithInitialCapacity_ThenReturnsHashTable()
        {
            var userHashtable = HashtableDemo.CreateHashTableWithInitialCapacity();

            Assert.IsType<Hashtable>(userHashtable);
            Assert.Empty(userHashtable);
        }

        [Fact]
        public void GivenHashtable_WhenCreatingHashtableFromDictionary_ThenReturnsHashTable()
        {
            var userHashtable = HashtableDemo.CreateHashTableFromDictionary();

            Assert.IsType<Hashtable>(userHashtable);
            Assert.NotEmpty(userHashtable);
            Assert.Equal(5, userHashtable.Count);
        }

        [Fact]
        public void GivenHashtable_WhenAddingSampleDataToHashtable_ThenReturnsHashTable()
        {
            List<User> userList = new()
            {
                new User() { Id = 6, FirstName = "Judit", LastName = "Peter" },
                new User() { Id = 7, FirstName = "Steve", LastName = "Billing" },
                new User() { Id = 8, FirstName = "Goddy", LastName = "Opara" },
            };

            var populatedUserHashtable = HashtableDemo.AddSampleDataToHashTable(_userHashtable, userList);

            Assert.IsType<Hashtable>(populatedUserHashtable);
            Assert.NotEmpty(populatedUserHashtable);
            Assert.Equal(8, populatedUserHashtable.Count);
        }

        [Fact]
        public void GivenEmptyHashtable_WhenRetrievingElementFromHashtable_ThenReturnsUser()
        {
            var user = HashtableDemo.RetrieveElementFromHashTable(_userHashtable, 3);
            var userFirstName = user.FirstName;
            var userLastName = user.LastName;

            Assert.Equal("Sam", userFirstName);
            Assert.Equal("Manalt", userLastName);
        }

        [Fact]
        public void GivenEmptyHashtable_WhenRetrievingAllElementFromHashtable_ThenReturnsAllUsers()
        {
            var users = HashtableDemo.RetrieveAllElementsFromHashTable(_userHashtable);

            Assert.IsType<List<User>>(users);
            Assert.NotEmpty(users);
            Assert.Equal(5, users.Count);
        }

        [Fact]
        public void GivenEmptyHashtable_WhenUpdatingElementInHashtable_ThenReturnsUpdatedHashTable()
        {
            var newUsers = HashtableDemo.UpdateElementInHashTable(_userHashtable, 3);
            User user = (User)newUsers[3];
            var userFirstName = user.FirstName;
            var userLastName = user.LastName;

            Assert.Equal(5, newUsers.Count);
            Assert.Equal("Henry", userFirstName);
            Assert.Equal("Stafford", userLastName);
        }

        [Fact]
        public void GivenEmptyHashtable_WhenRemovingElementFromHashtable_ThenReturnsUpdatedHashTable()
        {
            var newUsers = HashtableDemo.RemoveElementFromHashTable(_userHashtable, 2);

            Assert.Equal(4, newUsers.Count);
        }

        [Fact]
        public void GivenEmptyHashtable_WhenRemovingAllElementsFromHashtable_ThenReturnsUpdatedHashTable()
        {
            var newUsers = HashtableDemo.RemoveAllElementsFromHashTable(_userHashtable);

            Assert.Empty(newUsers);
        }

        [Fact]
        public void GivenEmptyHashtable_WhenCloningHashtable_ThenReturnsUpdatedHashTable()
        {
            var newUsers = HashtableDemo.CloneHashTable(_userHashtable);

            Assert.Equal(_userHashtable.Count, newUsers.Count);
        }

        [Fact]
        public void GivenEmptyHashtable_WhenSynchronizingHashtable_ThenReturnsUpdatedHashTable()
        {
            var newUsers = HashtableDemo.SynchronizeHashtable(_userHashtable);

            Assert.True(newUsers.IsSynchronized);
        }
    }
}