namespace UseMoqToReturnPassedInValue;

//Not used, but included to demonstrate that if the actual dependency called in tests then an exception will be thrown
public class Printer : IPrinter
{
    public Printer()
    {
        throw new NotImplementedException();
    }

    public string Print(string value)
    {
        throw new NotImplementedException();
    }
}