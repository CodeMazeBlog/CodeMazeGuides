using PassingOutputParametersToStoredProcedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class DapperSPLiveTest
    {
        private static Random random = new Random();

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [Fact]
        public void GivenParameters_WhenDuplicate_ReturnsString()
        {
            var result = BusinessLogic.InsertNewDeveloper("John", "C#");
            var expectedType = "System.String";

            Assert.Equal(expectedType, result.GetType().ToString());
        }

        [Fact]
        public void GivenParameters_WhenNotDuplicate_ReturnsInt()
        {
            var result = BusinessLogic.InsertNewDeveloper(RandomString(5), "C#");
            var expectedType = "System.Int32";

            Assert.Equal(expectedType, result.GetType().ToString());
        }
    }
}
