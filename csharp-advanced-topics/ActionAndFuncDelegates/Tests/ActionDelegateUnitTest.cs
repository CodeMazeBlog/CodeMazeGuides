using ActionAndFuncDelegates;

namespace Tests
{
    public class ActionDelegateUnitTest
    {
        [Fact]
        public void GivenActionWithLambda_WhenCalled_ThenUpdatesNameAndAgeValues()
        {
            //Arrange
            string name = "RACHEL";
            int age = 12;

            ActionDelegate actionDelegate = new();

            //Act            
            actionDelegate.ActionWithLambda(name, age);            
            
            //Assert
            Assert.Equal("rachel", ActionDelegate.UpdatedName);
            Assert.Equal(age + 24, ActionDelegate.UpdatedAge);
        }

        [Fact]
        public void GivenActionWithAnon_WhenCalled_ThenUpdatesNameAndAgeValues()
        {
            //Arrange
            string name = "ALEX";
            int age = 23;

            ActionDelegate actionDelegate = new();

            //Act            
            actionDelegate.ActionWithAnon(name, age);

            //Assert
            Assert.Equal("alex", ActionDelegate.UpdatedName);
            Assert.Equal(age + 24, ActionDelegate.UpdatedAge);
        }
    }
}