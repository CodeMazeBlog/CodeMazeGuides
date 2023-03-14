namespace Tests
{
    public class ActionDelegateUnitTest
    {
        [Fact]
        public void MakeSurePrintAWordMethodWorks()
        {
            ActionDelegate.Program.PrintAWord("test");
        }

        [Fact]
        public void MakeSureMainMethodWorks()
        {
            ActionDelegate.Program.Main(new string[0]);
        }
    }
}