namespace VisitorPatternTests
{
    public interface IDetector
    {
        AlertReport DetectFrom(IResult sample);
    }
}