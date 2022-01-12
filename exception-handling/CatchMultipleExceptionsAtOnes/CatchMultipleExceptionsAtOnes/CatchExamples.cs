using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            catch (Exception ex) when (ex is FormatException ||
                                       ex is DivideByZeroException ||
                                       ex is OverflowException)
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
    }
}
