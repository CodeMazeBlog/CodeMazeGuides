using FluentAssertions;

namespace HowToCloneAList.Tests
{
    public class Tests
    {
        [Fact]
        public void GivenAValidList_WhenConstructorIsInvoked_ThenConstructorReturnsNewListInstance()
        {
            var list = new List<string> { "one", "two", "three" };

            var listClone = new List<string>(list);

            listClone.Should().BeEquivalentTo(list);
        }

        [Fact]
        public void GivenAValidList_WhenCopyToMethodIsInvoked_ThenCopyToMethodReturnsNewListInstance()
        {
            var list = new List<string> { "one", "two", "three" };

            var listClone = new string[list.Count];
            list.CopyTo(listClone);

            listClone.Should().BeEquivalentTo(list);
        }

        [Fact]
        public void GivenAValidList_WhenAddRangeMethodIsInvoked_ThenAddRangeMethodReturnsNewListInstance()
        {
            var list = new List<string> { "one", "two", "three" };

            var listClone = new List<string>();
            listClone.AddRange(list);

            listClone.Should().BeEquivalentTo(list);
        }

        [Fact]
        public void GivenAValidList_WhenToListMethodIsInvoked_ThenToListMethodReturnsNewListInstance()
        {
            var list = new List<string> { "one", "two", "three" };

            var listClone = list.ToList();

            listClone.Should().BeEquivalentTo(list);
        }

        [Fact]
        public void GivenAValidList_WhenConvertAllMethodIsInvoked_ThenConvertAllMethodReturnsNewListInstance()
        {
            var list = new List<string> { "one", "two", "three" };

            var listClone = list
                .ConvertAll(new Converter<string, string>(x => x));

            listClone.Should().BeEquivalentTo(list);
        }
    }
}
