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
            int ageMargin = 24;
            ActionDelegate actionDelegate = new();

            //Act            
            actionDelegate.ActionWithLambda(name, age);            
            
            //Assert
            Assert.Equal("rachel", ActionDelegate.updatedName);
            Assert.Equal(age + ageMargin, ActionDelegate.updatedage);
        }

        [Fact]
        public void GivenActionWithAnon_WhenCalled_ThenUpdatesNameAndAgeValues()
        {
            //Arrange
            string name = "ALEX";
            int age = 23;
            int ageMargin = 24;
            ActionDelegate actionDelegate = new();

            //Act            
            actionDelegate.ActionWithAnon(name, age);

            //Assert
            Assert.Equal("alex", ActionDelegate.updatedName);
            Assert.Equal(age + ageMargin, ActionDelegate.updatedage);
        }
    }
}