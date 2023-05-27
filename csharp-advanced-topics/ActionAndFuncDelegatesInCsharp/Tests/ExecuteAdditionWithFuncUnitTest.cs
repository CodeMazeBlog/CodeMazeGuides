namespace ActionAndFuncDelegates.Tests
{
    public class ExecuteAdditionWithFuncUnitTest
    {
        [Fact]
        public void GivenTwoNumbers_ThenReturnTheirSum()
        {
            var result = Program.ExecuteAdditionWithFunc(100, 200);

            Assert.True(result == 300);
        }
    }
}
