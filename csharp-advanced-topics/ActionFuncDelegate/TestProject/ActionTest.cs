using ActionDelegate;

namespace TestProject
{
    public class ActionTest
    {
        Action<string, string> displayDel = ActionProgram.DisplayMethod;
        [Fact]

        public void Test_Action_DisplayDelegate()
        {
            string expectedOutput = "John Abraham";

            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            displayDel("John", "Abraham");

            Assert.Equal(expectedOutput, sw.ToString());
        }
    }
}
