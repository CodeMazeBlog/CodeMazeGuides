namespace CatchMultipleExceptionsAtOnes
{
    public class CatchExamples
    {
        public static int MultipleCatches(string numeratorParam, string denominatorParam)
        {
            try
            {
                var numerator = Convert.ToUInt32(numeratorParam);
                var denominator = Convert.ToUInt32(denominatorParam);

                return (int)(numerator / denominator);
            }
            catch (FormatException)
            {
                Console.WriteLine("Format Exception!");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Divide By Zero Exception!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow Exception!");
            }

            return -1;
        }

        public static int SingleCatchWithWhen(string numeratorParam, string denominatorParam)
        {
            try
            {
                var numerator = Convert.ToUInt32(numeratorParam);
                var denominator = Convert.ToUInt32(denominatorParam);

                return (int)(numerator / denominator);
            }
            catch (Exception ex) when (ex is FormatException or DivideByZeroException or OverflowException)
            {
                return -1;
            }
        }

        public static int SingleCatchSwitchCase(string numeratorParam, string denominatorParam)
        {
            try
            {
                var numerator = Convert.ToUInt32(numeratorParam);
                var denominator = Convert.ToUInt32(denominatorParam);

                return (int)(numerator / denominator);
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case FormatException:
                        Console.WriteLine("Format Exception!");
                        break;
                    case DivideByZeroException:
                        Console.WriteLine("Divide By Zero Exception!");
                        break;
                    case OverflowException:
                        Console.WriteLine("Overflow Exception!");
                        break;
                    default:
                        throw;
                }
            }

            return -1;
        }

        public static int SingleCatchSwitchPattern(string numeratorParam, string denominatorParam)
        {
            try
            {
                var numerator = Convert.ToUInt32(numeratorParam);
                var denominator = Convert.ToUInt32(denominatorParam);

                return (int)(numerator / denominator);
            }
            catch (Exception ex)
            {
                string str = ex switch
                {
                    FormatException => "Format Exception!",
                    DivideByZeroException => "Divide By Zero Exception!",
                    OverflowException => "Overflow Exception!",
                    _ => "Unknown Exception!"
                };

                Console.WriteLine(str);
            }

            return -1;
        }

        public static List<string> FilterRunsBeforeUnwinding()
        {
            var steps = new List<string>();

            try
            {
                ThrowFromInnerMethod(steps);
            }
            catch (FormatException) when (Record(steps, "filter"))
            {
                steps.Add("catch");
            }

            return steps;
        }

        private static void ThrowFromInnerMethod(List<string> steps)
        {
            try
            {
                throw new FormatException();
            }
            finally
            {
                steps.Add("inner finally");
            }
        }

        private static bool Record(List<string> steps, string step)
        {
            steps.Add(step);
            return true;
        }
    }
}
