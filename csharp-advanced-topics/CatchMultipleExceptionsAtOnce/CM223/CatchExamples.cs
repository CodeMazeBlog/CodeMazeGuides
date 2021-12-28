using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM223
{
    public class CatchExamples
    {
        public static int StrDivision_MultipleCatches(string strNumerator, string strDenominator)
        {
            try
            {
                var numerator = Convert.ToByte(strNumerator);
                var denominator = Convert.ToByte(strDenominator);

                if (numerator > 10 || denominator < 1 || denominator > 10)
                    throw new ArgumentOutOfRangeException();

                return numerator / denominator;
            }
            catch (FormatException)
            {
                return -1;
            }
            catch (DivideByZeroException)
            {
                return -1;
            }
            catch (OverflowException)
            {
                return -1;
            }
            catch (ArgumentOutOfRangeException)
            {
                return -1;
            }
        }

        public static int StrDivision_SingleCatch(string strNumerator, string strDenominator)
        {
            try
            {
                var numerator = Convert.ToByte(strNumerator);
                var denominator = Convert.ToByte(strDenominator);

                if (numerator > 10 || denominator < 1 || denominator > 10)
                    throw new ArgumentOutOfRangeException();

                return numerator / denominator;
            }
            catch(Exception)
            {
                return -1;
            }
        }

        public static int StrDivision_OptimizedSingleCatch(string strNumerator, string strDenominator)
        {
            try
            {
                var numerator = Convert.ToByte(strNumerator);
                var denominator = Convert.ToByte(strDenominator);

                if (numerator > 10 || denominator < 1 || denominator > 10)
                    return -1;

                return numerator / denominator;
            }
            catch
            {
                return -1;
            }
        }
    }
}
