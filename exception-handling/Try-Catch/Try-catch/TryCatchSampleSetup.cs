namespace Try_Catch;

public class TryCatchSampleSetup
{
    public void MultipleCatchSetup()
    {
        try
        {
            var counter = new int[5];
            counter[10] = 12;
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("{0} First exception caught.", ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Last exception caught.", ex.Message);
            throw new NullReferenceException("Undefined array");
        }
    }


    public void NestedCatchSetup(int divider)
    {
        try
        {
            var result = 100 / divider;
            try
            {
                var array = new int[0];
                result = array[result];

            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("{0} First exception caught.", ex.Message);
                throw;
            }
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Outer catch", ex.Message);
            throw;
        }
    }

    public void GeneralCatchSetup(int divider)
    {
        try
        {
            var result = 3000 / divider;
            Math.Sign(double.NaN);
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine("Inner catch", e.Message);
            throw;
        }
        catch
        {
            Console.WriteLine("Outer catch");
            throw;
        }
    }

    public void GeneralCatchSetupWithDefaultExceptionParameter(int divider)
    {
        try
        {
            var result = 3000 / divider;
            Math.Sign(double.NaN);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Inner catch", ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Outer catch", ex.Message);
            throw;
        }
    }

    public int ExceptionFilterSetup(int[] words, int index)
    {
        try
        {
            return words[index];
        }
        catch (IndexOutOfRangeException) when (index < 0)
        {
            throw new IndexOutOfRangeException(
                "index of an array cannot be negative.");
        }
        catch (IndexOutOfRangeException)
        {
            throw new IndexOutOfRangeException(
                "index cannot be greater than the array size.");
        }

    }
}

