using FuncAndActionDelegates;

namespace Tests
{
    public class FuncTest
    {
        [Fact]
        public void FuncSampleTest()
        {
            var name = "John";
            var message = "How are you?";

            var funcSample = new FuncSample();

            var result = funcSample.SayHello(name, message);

            if (result != "Hello John, How are you?")
                throw new Exception("FuncSample_Test failed");
        }
    }
}