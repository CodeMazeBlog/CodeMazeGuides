using ActionAndFuncDelegate;

namespace Test
{
    public class ActionAndFuncDelegateUnitTest
    {

        private readonly Utility _utility;

        public ActionAndFuncDelegateUnitTest()
        {
            _utility = new Utility();
        }

        [Fact]
        public void WhenLambdaInputString_ThenReturnString()
        {
            //Arrange
            string actual = "Janelle";

            //Act
            string expected = _utility.GetByCondition(x => x.FirstOrDefault(a => a.Equals(actual)));

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenMethodInputString_ThenReturnString()
        {
            //Arrange
            string actual = "Peculiar";

            string Get(List<string> items)
            {
                string request = actual;

                string name = "Not Found";

                foreach (var item in items)
                {
                    if (item.Equals(request))
                        return name = item;
                }
                return name;
            }

            //Act
            string expected = _utility.GetByCondition(Get);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}