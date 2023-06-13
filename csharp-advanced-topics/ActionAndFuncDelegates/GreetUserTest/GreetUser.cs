using Func_and_Action_Delegates;

namespace GreetUserTest
{
    public class GreetUserUnitTest
    {
        private GreetUser _greetUser { get; set; } = null!;
      

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void SayHi()
        {
            //Assign
            string ActualMessage = null!;
            Action<string> greetUser = message => ActualMessage = message;
            _greetUser = new GreetUser(greetUser);
            //Act 
            string ExpectedMessage = "Hi Dan!";
            _greetUser.SayHi(ExpectedMessage);
           

            Assert.That(ExpectedMessage, Is.EqualTo(ActualMessage));

        }
    }
}