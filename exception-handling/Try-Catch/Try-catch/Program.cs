// See https://aka.ms/new-console-template for more information
using Try_Catch;

void Start()
{
    var tryCatchSampleSetup = new TryCatchSampleSetup();

    try
    {
        tryCatchSampleSetup.GeneralCatchSetup(12);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.GetType().ToString());
    }

    try
    {
        tryCatchSampleSetup.MultipleCatchSetup();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.GetType().ToString());
    }

    try
    {
        tryCatchSampleSetup.GeneralCatchSetupWithDefaultExceptionParameter(13);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.GetType().ToString());
    }

    try
    {
        tryCatchSampleSetup.NestedCatchSetup(13);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.GetType().ToString());
    }

    try
    {
        tryCatchSampleSetup.ExceptionFilterSetup(new int[] { 23, 77 }, 5);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.GetType().ToString());
    }
}

Start();

Console.ReadLine();
