using System.Reflection;

namespace Delegates.Test
{
    public class Delegate
    {
        public delegate bool AnotherDelegate(int number);

        [Theory]
        [InlineData(4)]
        public void RegularDelegateTest(int number)
        {
            RegularDelegate regularDelegate = new();
            bool result = regularDelegate.EvenNumber(number);
            Assert.True(result);


            AnotherDelegate even = RegularDelegate.IsEven;
            Assert.True(even(number));
        }

        [Theory]
        [InlineData(4)]
        public void FuncDelegateTest(int number)
        {
            FuncDelegate funcDelegate = new();
            Func<bool> result = funcDelegate.EvenNumber(number);
            //Assert.IsType<bool>(result());
            //Assert.IsType<Func<bool>>(result);
            Assert.True(result());
        }
    }
}