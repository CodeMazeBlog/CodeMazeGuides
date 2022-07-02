namespace Tests;

public class UnitTest1
{
    [Fact]
    public void BasicFunc()
    {
        //arrange
        Func<string> greetings = () => "Hello World!";
        //act
        var result = greetings();
        //assert
        Assert.Equal("Hello World!", result);
    }

    [Fact]
    public void FunWithMultipleParameter()
    {
        //arrange
        Func<string, string, bool> checkInput = (wordOne, wordTwo) => wordOne.Equals(wordTwo);
        //act
        var result = checkInput("CodeMaze", "CodeMaze");
        //assert
        Assert.True(result);
    }

    [Fact]
    public void FuncClosures()
    {
        //arrange
        Func<int, int> customMultiple = multipleBy();
        Func<int, int> multipleBy()
        {
            var num = 7;
            return n => n * num;
        }
        //act
        var result = customMultiple(8);
        //assert
        Assert.Equal(56, result);
    }
}