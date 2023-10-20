using ActionDelegatesInCSharp.Classes;
using System.Diagnostics.Metrics;

namespace ActionDelegatesInCsharpUnitTest
{
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
           // soundMaker += sound.Goat;


            //Assert
            maker.Make(soundMaker);
            Assert.IsNotInstanceOfType(soundMaker, typeof(ActionDelegateSoundMaker));

        }
    }
}