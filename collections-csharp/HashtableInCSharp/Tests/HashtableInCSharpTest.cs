using HashtableInCSharp;
using System.Collections;

namespace Tests
{
    public class HashtableInCSharpTest
    {
        private readonly Hashtable _userHashtable = new(SharedData.UserDictionary);

        [Fact]
        public void WhenCreatingHashtable_ThenReturnsEmptyHashTable()
        {
            var userHashtable = HashtableDemo.CreateEmptyHashTable();

            Assert.IsType<Hashtable>(userHashtable);
            Assert.Empty(userHashtable);
        }

        [Fact]
        public void WhenCreatingHashtableWithInitialCapacity_ThenReturnsHashTableWithInitialCapacity()
        {
            var userHashtable = HashtableDemo.CreateHashTableWithInitialCapacity(SharedData.InitialCapacity);

            Assert.IsType<Hashtable>(userHashtable);
            Assert.Empty(userHashtable);
        }

        [Fact]
        public void WhenCreatingHashtableFromDictionary_ThenReturnsHashTable()
        {
            var userHashtable = HashtableDemo.CreateHashTableFromDictionary(SharedData.UserDictionary);

            Assert.IsType<Hashtable>(userHashtable);
            Assert.NotEmpty(userHashtable);
            Assert.Equal(SharedData.UserDictionary.Count, userHashtable.Count);
        }

        [Fact]
        public void WhenAddingSampleDataToHashtable_ThenReturnsPopulatedHashTable()
        {
            var userList = SharedData.UserList;
            var expectedCount = _userHashtable.Count + userList.Count;
            var populatedUserHashtable = HashtableDemo.AddSampleDataToHashTable(_userHashtable, userList);

            Assert.IsType<Hashtable>(populatedUserHashtable);
            Assert.NotEmpty(populatedUserHashtable);
            Assert.Equal(expectedCount, populatedUserHashtable.Count);

            foreach (var user in userList)
            {
                Assert.Contains(user.Id, populatedUserHashtable.Keys.Cast<int>());
                var retrievedUser = (User)populatedUserHashtable[user.Id];
                Assert.Equal(user.FirstName, retrievedUser.FirstName);
                Assert.Equal(user.LastName, retrievedUser.LastName);
            }
        }

        [Fact]
        public void WhenRetrievingElementFromHashtable_ThenReturnsUser()
        {
            var user = HashtableDemo.RetrieveElementFromHashTable(_userHashtable, 3);
            var userFirstName = user.FirstName;
            var userLastName = user.LastName;

            Assert.Equal("Sam", userFirstName);
            Assert.Equal("Manalt", userLastName);
        }

        [Fact]
        public void WhenRetrievingAllElementFromHashtable_ThenReturnsAllUsers()
        {
            var users = HashtableDemo.RetrieveAllElementsFromHashTable(_userHashtable);

            Assert.IsType<List<User>>(users);
            Assert.NotEmpty(users);
            Assert.Equal(_userHashtable.Count, users.Count);
        }

        [Fact]
        public void WhenUpdatingElementInHashtable_ThenReturnsUpdatedHashTable()
        {
            var expectedCount = _userHashtable.Count;
            var newUsers = HashtableDemo.UpdateElementInHashTable(_userHashtable, 3);
            User user = (User)newUsers[3];
            var userFirstName = user.FirstName;
            var userLastName = user.LastName;

            Assert.Equal(expectedCount, newUsers.Count);
            Assert.Equal("Henry", userFirstName);
            Assert.Equal("Stafford", userLastName);
        }

        [Fact]
        public void WhenRemovingElementFromHashtable_ThenReturnsHashtableWithRemovedElement()
        {
            var expectedCount = _userHashtable.Count - 1;
            var newUsers = HashtableDemo.RemoveElementFromHashTable(_userHashtable, 2);

            Assert.Equal(expectedCount, newUsers.Count);
            Assert.False(_userHashtable.ContainsKey(2));
        }

        [Fact]
        public void WhenRemovingAllElementsFromHashtable_ThenReturnsEmptyHashTable()
        {
            var newUsers = HashtableDemo.RemoveAllElementsFromHashTable(_userHashtable);

            Assert.Empty(newUsers);
        }

        [Fact]
        public void WhenCloningHashtable_ThenReturnsClonedHashTable()
        {
            var newUsers = HashtableDemo.CloneHashTable(_userHashtable);

            Assert.Equal(_userHashtable.Count, newUsers.Count);
        }

        [Fact]
        public void WhenSynchronizingHashtable_ThenReturnsSynchronizedHashTable()
        {
            var newUsers = HashtableDemo.SynchronizeHashtable(_userHashtable);

            Assert.True(newUsers.IsSynchronized);
        }
    }
}