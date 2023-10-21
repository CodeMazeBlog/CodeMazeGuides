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
        var maker = new ActionDelegateSoundMaker();

        //Act
        Action soundMaker = sound.Cow;

        //Assert
        maker.Make(soundMaker);
        Assert.IsNotInstanceOfType(soundMaker, typeof(ActionDelegateSoundMaker));
    }
}