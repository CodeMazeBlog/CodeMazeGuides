using ActionDelegatesInCSharp.Classes;
namespace ActionDelegatesInCsharpUnitTest;

[TestClass]
public class ActionDelegateTest
{
    [TestMethod]
    public void WhenMakerIsADelegate_ThenCheckForItType()
    {
        //Arrange
        var sound = new Sounds();

        //Act
        Action soundMaker = sound.Cow;

        //Assert
        Assert.IsNotInstanceOfType(soundMaker, typeof(ActionDelegateSoundMaker));
    }
}