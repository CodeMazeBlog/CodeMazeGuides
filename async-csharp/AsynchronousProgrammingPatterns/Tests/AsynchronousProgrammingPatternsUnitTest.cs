namespace Tests;

public class AsynchronousProgrammingPatternsUnitTest
{
    [Fact]
    public void WhenValidatorForValidTypeFetched_ThenReturnValidator()
    {
    }

    [Fact]
    public void WhenValidatorForInValidTypeFetched_ThenReturnNull()
    {
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(false, false)]
    public void WhenCarValidated_ThenValidatesType(bool isConvertible, bool expectedValidationResult)
    {
    }
}