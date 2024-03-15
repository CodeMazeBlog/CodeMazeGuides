namespace UseMoqToReturnPassedInValue;

public class PrinterQueue
{
    private readonly IPrinter _printer;

    public PrinterQueue(IPrinter printer)
    {
        _printer = printer;
    }

    public int PrintAll(string[] jobs)
    {
        var characterCount = 0;

        foreach (var job in jobs)
        {
            var result = _printer.Print(job);
            characterCount += result.Length;
        }

        return characterCount;
    }
}