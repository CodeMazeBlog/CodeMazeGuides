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

        public static int SingleCatch_SwitchCase(string numeratorParam, string denominatorParam)
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

        public static int SingleCatch_SwitchWhen(string numeratorParam, string denominatorParam)
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
                    _ when ex is FormatException => "Format Exception!",
                    _ when ex is DivideByZeroException => "Divide By Zero Exception!",
                    _ when ex is OverflowException => "Overflow Exception!",
                    _ => "Unknwon Exception!"
                };

                Console.WriteLine(str);
            }

            return -1;
        }
    }
}
