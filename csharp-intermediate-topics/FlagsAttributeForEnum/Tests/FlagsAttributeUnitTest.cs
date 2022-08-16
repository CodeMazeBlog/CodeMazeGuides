using FlagsAttributeForEnum;
using Xunit;

namespace Tests
{
    public class FlagsAttributeUnitTest
    {
        [Fact]
        public void GivenUserTypeIsNone_WhenCallingAdd_ThenUserTypeIsEmployee()
        {
            var types = UserType.None;

            var result = types.Add(UserType.Employee);

            Assert.Equal(UserType.Employee, result);
        }

        [Fact]
        public void GivenUserTypeIsEmployee_WhenCallingRemove_ThenUserTypeIsDriver()
        {
            var types = UserType.Employee;

            var result = types.Remove(UserType.Admin);

            Assert.Equal(UserType.Driver, result);
        }

        [Fact]
        public void GivenUserTypeIsEmployee_WhenCallingHasFlagWithAdmin_ThenTrue()
        {
            var types = UserType.Employee;

            var result = types.CustomHasFlag(UserType.Admin);

            Assert.True(result);
        }

        [Fact]
        public void GivenUserTypeIsEmployee_WhenCallingHasFlagWithCustomer_ThenFalse()
        {
            var types = UserType.Employee;

            var result = types.CustomHasFlag(UserType.Customer);

            Assert.False(result);
        }
    }
}