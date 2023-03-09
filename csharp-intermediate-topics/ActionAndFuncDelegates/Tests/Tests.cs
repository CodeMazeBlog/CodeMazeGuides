using ActionAndFuncDelegates;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void UsingFunc_WhenFilterCollection_ThenReturnValidItemOnly()
        {
            var personList = (new PersonListProvider()).PersonList;
            var filteredList = personList.Filter(x => x.Age >= 30);
            
            Assert.Equal(2, filteredList.Count);
        }

        [Fact]
        public void UsingFilter_WhenMapPersonListToListOfAges_ThenReturnListofInt()
        {
            var personList = (new PersonListProvider()).PersonList;
            var ageList = personList.Map<int>(x => x.Age);

            Assert.Equal(typeof(List<int>), ageList.GetType());
        }

        [Fact]
        public void UsingAction_WhenIncrementPersonAgeByOne_ThenPersonAgeWillBeGreaterByOne()
        {

            var personList = (new PersonListProvider()).PersonList;
            var firstPersonAge = personList[0].Age;
            var secondPersonAge = personList[1].Age;
            var thirdPersonAge = personList[2].Age;
            personList.Update(x => x.Age++);

            Assert.Equal(personList[0].Age, firstPersonAge + 1);
            Assert.Equal(personList[1].Age, secondPersonAge + 1);
            Assert.Equal(personList[2].Age, thirdPersonAge + 1);
        }
    }
}