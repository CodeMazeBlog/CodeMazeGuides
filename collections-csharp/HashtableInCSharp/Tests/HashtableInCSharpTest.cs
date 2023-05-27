using HashtableInCSharp;
using System.Collections;

namespace Tests
{
    public class HashtableInCSharpTest
    {
        private readonly HashtableDemo _hashtableDemo;
        private readonly Hashtable _users;
        public HashtableInCSharpTest()
        {
            _hashtableDemo = new HashtableDemo();
            _users = _hashtableDemo.AddToHashTable(new Hashtable());
        }
        [Fact]
        public void GivenAnEmptyHashtable_WhenAddingToAHashtable_ThenReturnsFilledEmptyHashTable()
        {
            Assert.IsType<Hashtable>(_users);
            Assert.NotEmpty(_users);
        }

        [Fact]
        public void GivenAnEmptyHashtable_WhenRetrievingFromHashtable_ThenReturnsAUser()
        {
            var user = _hashtableDemo.RetrieveAnElementFromHashTable(_users);
            var userFirstName = user.FirstName;
            var userLastName = user.LastName;

            Assert.Equal("Goddy", userFirstName);
            Assert.Equal("Opara", userLastName);
        }

        [Fact]
        public void GivenAnEmptyHashtable_WhenUpdatingElementInHashtable_ThenReturnsUpdatedHashTable()
        {
            var newUsers = _hashtableDemo.UpdateAnElementInHashTable(_users);
            User user = (User)newUsers[1];
            var userFirstName = user.FirstName;
            var userLastName = user.LastName;

            Assert.Equal("Henry", userFirstName);
            Assert.Equal("Stafford", userLastName);
        }

        [Fact]
        public void GivenAnEmptyHashtable_WhenRemovingAnElementFromHashtable_ThenReturnsUpdatedHashTable()
        {
            var newUsers = _hashtableDemo.RemoveAnElementFromHashTable(_users);
           
            Assert.Equal(4, newUsers.Count);
        }

        [Fact]
        public void GivenAnEmptyHashtable_WhenRemovingAllElementsFromHashtable_ThenReturnsUpdatedHashTable()
        {
            var newUsers = _hashtableDemo.RemoveAllElementsFromHashTable(_users);

            Assert.Empty(newUsers);
        }

        [Fact]
        public void GivenAnEmptyHashtable_WhenCloningHashtable_ThenReturnsUpdatedHashTable()
        {
            var newUsers = _hashtableDemo.CloneHashTable(_users);

            Assert.Equal(_users.Count, newUsers.Count);
        }

        [Fact]
        public void GivenAnEmptyHashtable_WhenSynchronizingHashtable_ThenReturnsUpdatedHashTable()
        {
            var newUsers = _hashtableDemo.SynchronizeHashtable(_users);

            Assert.True(newUsers.IsSynchronized);
        }
    }
}