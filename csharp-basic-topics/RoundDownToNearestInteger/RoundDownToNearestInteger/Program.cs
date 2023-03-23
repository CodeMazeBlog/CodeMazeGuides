using System.Diagnostics;
using System.Globalization;

namespace RoundDownToNearestInteger
{
    internal class Program
    {
        private static double positiveDoubleAboveMiddle = 1.75;
        private static double positiveDoubleInTheMiddle = 1.5;
        private static double positiveDoubleBellowMiddle = 1.25;
        private static double negativeDoubleAboveMiddle = -1.75;
        private static double negativeDoubleInTheMiddle = -1.5;
        private static double negativeDoubleBellowMiddle = -1.25;

        private static int RoundDownUsingMathFloor(double num)
        {
            return (int)Math.Floor(num);
        }

        private static int RoundDownUsingMathRoundWithToNegativeInfinityMode(double num)
        {
            return (int)Math.Round(num, 0, MidpointRounding.ToNegativeInfinity);
        }

        private static int RoundDownUsingMathRoundWithToPositiveInfinityMode(double num)
        {
            return (int)Math.Round(num, 0, MidpointRounding.ToPositiveInfinity);
        }

        private static int RoundDownUsingMathRoundWithToZeroMode(double num)
        {
            return (int)Math.Round(num, 0, MidpointRounding.ToZero);
        }

        private static int RoundDownUsingMathRoundWithAwayFromZeroMode(double num)
        {
            return (int)Math.Round(num, 0, MidpointRounding.AwayFromZero);
        }

        private static int RoundDownUsingMathRoundWithToEvenMode(double num)
        {
            return (int)Math.Round(num, 0, MidpointRounding.ToEven);
        }

        private static int RoundDownUsingMathTruncate(double num)
        {
            return (int)Math.Truncate(num);
        }

        private static int RoundDownUsingConvertToInt32(double num)
        {
            return Convert.ToInt32(num);
        }

        private static int RoundDownUsingCasting(double num)
        {
            return (int)num;
        }

        private static int RoundDownUsingSubtractionWithModulo(double num)
        {
            return (int)(num - (num % 1));
        }

        private static int RoundDownUsingStringParsing(double num)
        {
            return int.Parse(num.ToString().Split(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)[0]);
        }

        private static void RoundDownUsingMathFloor()
        {
            Console.WriteLine($"Round down using Math.Floor: ");
            Console.WriteLine($"Rounding {positiveDoubleBellowMiddle} results in {RoundDownUsingMathFloor(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleInTheMiddle} results in {RoundDownUsingMathFloor(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleAboveMiddle} results in {RoundDownUsingMathFloor(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleBellowMiddle} results in {RoundDownUsingMathFloor(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleInTheMiddle} results in {RoundDownUsingMathFloor(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleAboveMiddle} results in {RoundDownUsingMathFloor(negativeDoubleAboveMiddle)}");
        }

        private static void RoundDownUsingMathTruncate()
        {
            Console.WriteLine($"Round down using Math.Truncate: ");
            Console.WriteLine($"Rounding {positiveDoubleBellowMiddle} results in {RoundDownUsingMathTruncate(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleInTheMiddle} results in {RoundDownUsingMathTruncate(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleAboveMiddle} results in {RoundDownUsingMathTruncate(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleBellowMiddle} results in {RoundDownUsingMathTruncate(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleInTheMiddle} results in {RoundDownUsingMathTruncate(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleAboveMiddle} results in {RoundDownUsingMathTruncate(negativeDoubleAboveMiddle)}");
        }

        private static void RoundDownUsingMathRoundWithToNegativeInfinityMode()
        {
            Console.WriteLine($"Round down using Math.Round with ToNegativeInfinity mode: ");
            Console.WriteLine($"Rounding {positiveDoubleBellowMiddle} results in {RoundDownUsingMathRoundWithToNegativeInfinityMode(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleInTheMiddle} results in {RoundDownUsingMathRoundWithToNegativeInfinityMode(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleAboveMiddle} results in {RoundDownUsingMathRoundWithToNegativeInfinityMode(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleBellowMiddle} results in {RoundDownUsingMathRoundWithToNegativeInfinityMode(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleInTheMiddle} results in {RoundDownUsingMathRoundWithToNegativeInfinityMode(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleAboveMiddle} results in {RoundDownUsingMathRoundWithToNegativeInfinityMode(negativeDoubleAboveMiddle)}");
        }

        private static void RoundDownUsingMathRoundWithToPositiveInfinityMode()
        {
            Console.WriteLine($"Round down using Math.Round with ToPositiveInfinity mode: ");
            Console.WriteLine($"Rounding {positiveDoubleBellowMiddle} results in {RoundDownUsingMathRoundWithToPositiveInfinityMode(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleInTheMiddle} results in {RoundDownUsingMathRoundWithToPositiveInfinityMode(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleAboveMiddle} results in {RoundDownUsingMathRoundWithToPositiveInfinityMode(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleBellowMiddle} results in {RoundDownUsingMathRoundWithToPositiveInfinityMode(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleInTheMiddle} results in {RoundDownUsingMathRoundWithToPositiveInfinityMode(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleAboveMiddle} results in {RoundDownUsingMathRoundWithToPositiveInfinityMode(negativeDoubleAboveMiddle)}");
        }

        private static void RoundDownUsingMathRoundWithToZeroMode()
        {
            Console.WriteLine($"Round down using Math.Round with ToZero mode: ");
            Console.WriteLine($"Rounding {positiveDoubleBellowMiddle} results in {RoundDownUsingMathRoundWithToZeroMode(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleInTheMiddle} results in {RoundDownUsingMathRoundWithToZeroMode(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleAboveMiddle} results in {RoundDownUsingMathRoundWithToZeroMode(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleBellowMiddle} results in {RoundDownUsingMathRoundWithToZeroMode(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleInTheMiddle} results in {RoundDownUsingMathRoundWithToZeroMode(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleAboveMiddle} results in {RoundDownUsingMathRoundWithToZeroMode(negativeDoubleAboveMiddle)}");
        }

        private static void RoundDownUsingMathRoundWithAwayFromZeroMode()
        {
            Console.WriteLine($"Round down using Math.Round with AwayFromZero mode: ");
            Console.WriteLine($"Rounding {positiveDoubleBellowMiddle} results in {RoundDownUsingMathRoundWithAwayFromZeroMode(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleInTheMiddle} results in {RoundDownUsingMathRoundWithAwayFromZeroMode(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleAboveMiddle} results in {RoundDownUsingMathRoundWithAwayFromZeroMode(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleBellowMiddle} results in {RoundDownUsingMathRoundWithAwayFromZeroMode(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleInTheMiddle} results in {RoundDownUsingMathRoundWithAwayFromZeroMode(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleAboveMiddle} results in {RoundDownUsingMathRoundWithAwayFromZeroMode(negativeDoubleAboveMiddle)}");
        }

        private static void RoundDownUsingMathRoundWithToEvenMode()
        {
            Console.WriteLine($"Round down using Math.Round with ToEven mode: ");
            Console.WriteLine($"Rounding {positiveDoubleBellowMiddle} results in {RoundDownUsingMathRoundWithToEvenMode(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleInTheMiddle} results in {RoundDownUsingMathRoundWithToEvenMode(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleAboveMiddle} results in {RoundDownUsingMathRoundWithToEvenMode(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleBellowMiddle} results in {RoundDownUsingMathRoundWithToEvenMode(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleInTheMiddle} results in {RoundDownUsingMathRoundWithToEvenMode(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleAboveMiddle} results in {RoundDownUsingMathRoundWithToEvenMode(negativeDoubleAboveMiddle)}");
        }

        private static void RoundDownUsingConvertToInt32()
        {
            Console.WriteLine($"Round down using Convert.ToInt32: ");
            Console.WriteLine($"Rounding {positiveDoubleBellowMiddle} results in {RoundDownUsingConvertToInt32(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleInTheMiddle} results in {RoundDownUsingConvertToInt32(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleAboveMiddle} results in {RoundDownUsingConvertToInt32(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleBellowMiddle} results in {RoundDownUsingConvertToInt32(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleInTheMiddle} results in {RoundDownUsingConvertToInt32(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleAboveMiddle} results in {RoundDownUsingConvertToInt32(negativeDoubleAboveMiddle)}");
        }

        private static void RoundDownUsingCasting()
        {
            Console.WriteLine($"Round down using casting: ");
            Console.WriteLine($"Rounding {positiveDoubleBellowMiddle} results in {RoundDownUsingCasting(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleInTheMiddle} results in {RoundDownUsingCasting(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleAboveMiddle} results in {RoundDownUsingCasting(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleBellowMiddle} results in {RoundDownUsingCasting(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleInTheMiddle} results in {RoundDownUsingCasting(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleAboveMiddle} results in {RoundDownUsingCasting(negativeDoubleAboveMiddle)}");
        }

        private static void RoundDownUsingSubtractionWithModulo()
        {
            Console.WriteLine($"Round down using subtraction with modulo: ");
            Console.WriteLine($"Rounding {positiveDoubleBellowMiddle} results in {RoundDownUsingSubtractionWithModulo(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleInTheMiddle} results in {RoundDownUsingSubtractionWithModulo(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleAboveMiddle} results in {RoundDownUsingSubtractionWithModulo(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleBellowMiddle} results in {RoundDownUsingSubtractionWithModulo(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleInTheMiddle} results in {RoundDownUsingSubtractionWithModulo(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleAboveMiddle} results in {RoundDownUsingSubtractionWithModulo(negativeDoubleAboveMiddle)}");
        }

        private static void RoundDownUsingStringParsing()
        {
            Console.WriteLine($"Round down using string parsing: ");
            Console.WriteLine($"Rounding {positiveDoubleBellowMiddle} results in {RoundDownUsingStringParsing(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleInTheMiddle} results in {RoundDownUsingStringParsing(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {positiveDoubleAboveMiddle} results in {RoundDownUsingStringParsing(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleBellowMiddle} results in {RoundDownUsingStringParsing(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleInTheMiddle} results in {RoundDownUsingStringParsing(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Rounding {negativeDoubleAboveMiddle} results in {RoundDownUsingStringParsing(negativeDoubleAboveMiddle)}");
        }

        private static void RoundDownPositiveDoubleBellowMiddle()
        {
            //var positiveDoubleBelowMiddle = 1.25d;
            Console.WriteLine($"Round down {positiveDoubleBellowMiddle} (positive double number bellow middle point).");
            Console.WriteLine($"Using Math.Floor results in {RoundDownUsingMathFloor(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Using Math.Truncate results in {RoundDownUsingMathTruncate(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Using Math.Round with ToNegativeInfinity mode results in {RoundDownUsingMathRoundWithToNegativeInfinityMode(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Using Math.Round with ToPositiveInfinity mode results in {RoundDownUsingMathRoundWithToPositiveInfinityMode(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Using Math.Round with ToZero mode results in {RoundDownUsingMathRoundWithToZeroMode(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Using Math.Round with AwayFromZero mode results in {RoundDownUsingMathRoundWithAwayFromZeroMode(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Using Math.Round with ToEven mode results in {RoundDownUsingMathRoundWithToEvenMode(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Using Convert.ToInt32 results in {RoundDownUsingConvertToInt32(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Using casting results in {RoundDownUsingCasting(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Using subtraction with modulo results in {RoundDownUsingSubtractionWithModulo(positiveDoubleBellowMiddle)}");
            Console.WriteLine($"Using string parsing results in {RoundDownUsingStringParsing(positiveDoubleBellowMiddle)}");
        }

        private static void RoundDownPositiveDoubleInTheMiddle()
        {
            //            var positiveDoubleInTheMiddle = 1.5d;
            Console.WriteLine($"Round down {positiveDoubleInTheMiddle} (positive double number in the middle point).");
            Console.WriteLine($"Using Math.Floor results in {RoundDownUsingMathFloor(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Using Math.Truncate results in {RoundDownUsingMathTruncate(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Using Math.Round with ToNegativeInfinity mode results in {RoundDownUsingMathRoundWithToNegativeInfinityMode(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Using Math.Round with ToPositiveInfinity mode results in {RoundDownUsingMathRoundWithToPositiveInfinityMode(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Using Math.Round with ToZero mode results in {RoundDownUsingMathRoundWithToZeroMode(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Using Math.Round with AwayFromZero mode results in {RoundDownUsingMathRoundWithAwayFromZeroMode(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Using Math.Round with ToEven mode results in {RoundDownUsingMathRoundWithToEvenMode(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Using Convert.ToInt32 results in {RoundDownUsingConvertToInt32(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Using casting results in {RoundDownUsingCasting(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Using subtraction with modulo results in {RoundDownUsingSubtractionWithModulo(positiveDoubleInTheMiddle)}");
            Console.WriteLine($"Using string parsing results in {RoundDownUsingStringParsing(positiveDoubleInTheMiddle)}");
        }

        private static void RoundDownPositiveDoubleAboveMiddle()
        {
            //            var positiveDoubleAboveMiddle = 1.75d;
            Console.WriteLine($"Round down {positiveDoubleAboveMiddle} (positive double number above middle point).");
            Console.WriteLine($"Using Math.Floor results in {RoundDownUsingMathFloor(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Using Math.Truncate results in {RoundDownUsingMathTruncate(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Using Math.Round with ToNegativeInfinity mode results in {RoundDownUsingMathRoundWithToNegativeInfinityMode(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Using Math.Round with ToPositiveInfinity mode results in {RoundDownUsingMathRoundWithToPositiveInfinityMode(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Using Math.Round with ToZero mode results in {RoundDownUsingMathRoundWithToZeroMode(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Using Math.Round with AwayFromZero mode results in {RoundDownUsingMathRoundWithAwayFromZeroMode(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Using Math.Round with ToEven mode results in {RoundDownUsingMathRoundWithToEvenMode(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Using Convert.ToInt32 results in {RoundDownUsingConvertToInt32(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Using casting results in {RoundDownUsingCasting(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Using subtraction with modulo results in {RoundDownUsingSubtractionWithModulo(positiveDoubleAboveMiddle)}");
            Console.WriteLine($"Using string parsing results in {RoundDownUsingStringParsing(positiveDoubleAboveMiddle)}");
        }

        private static void RoundDownNegativeDoubleBellowMiddle()
        {
            //var negativeDoubleBellowMiddle = -1.25d;
            Console.WriteLine($"Round down {negativeDoubleBellowMiddle} (negative double number bellow middle point).");
            Console.WriteLine($"Using Math.Floor results in {RoundDownUsingMathFloor(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Using Math.Truncate results in {RoundDownUsingMathTruncate(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Using Math.Round with ToNegativeInfinity mode results in {RoundDownUsingMathRoundWithToNegativeInfinityMode(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Using Math.Round with ToPositiveInfinity mode results in {RoundDownUsingMathRoundWithToPositiveInfinityMode(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Using Math.Round with ToZero mode results in {RoundDownUsingMathRoundWithToZeroMode(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Using Math.Round with AwayFromZero mode results in {RoundDownUsingMathRoundWithAwayFromZeroMode(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Using Math.Round with ToEven mode results in {RoundDownUsingMathRoundWithToEvenMode(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Using Convert.ToInt32 results in {RoundDownUsingConvertToInt32(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Using casting results in {RoundDownUsingCasting(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Using subtraction with modulo results in {RoundDownUsingSubtractionWithModulo(negativeDoubleBellowMiddle)}");
            Console.WriteLine($"Using string parsing results in {RoundDownUsingStringParsing(negativeDoubleBellowMiddle)}");
        }

        private static void RoundDownNegativeDoubleInTheMiddle()
        {
            //var negativeDoubleInTheMiddle = -1.5d;
            Console.WriteLine($"Round down {negativeDoubleInTheMiddle} (negative double number in the middle point).");
            Console.WriteLine($"Using Math.Floor results in {RoundDownUsingMathFloor(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Using Math.Truncate results in {RoundDownUsingMathTruncate(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Using Math.Round with ToNegativeInfinity mode results in {RoundDownUsingMathRoundWithToNegativeInfinityMode(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Using Math.Round with ToPositiveInfinity mode results in {RoundDownUsingMathRoundWithToPositiveInfinityMode(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Using Math.Round with ToZero mode results in {RoundDownUsingMathRoundWithToZeroMode(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Using Math.Round with AwayFromZero mode results in {RoundDownUsingMathRoundWithAwayFromZeroMode(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Using Math.Round with ToEven mode results in {RoundDownUsingMathRoundWithToEvenMode(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Using Convert.ToInt32 results in {RoundDownUsingConvertToInt32(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Using casting results in {RoundDownUsingCasting(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Using subtraction with modulo results in {RoundDownUsingSubtractionWithModulo(negativeDoubleInTheMiddle)}");
            Console.WriteLine($"Using string parsing results in {RoundDownUsingStringParsing(negativeDoubleInTheMiddle)}");
        }

        private static void RoundDownNegativeDoubleAboveMiddle()
        {
            //var negativeDoubleAboveMiddle = -1.75d;
            Console.WriteLine($"Round down {negativeDoubleAboveMiddle} (negative double number bellow middle point).");
            Console.WriteLine($"Using Math.Floor results in {RoundDownUsingMathFloor(negativeDoubleAboveMiddle)}");
            Console.WriteLine($"Using Math.Truncate results in {RoundDownUsingMathTruncate(negativeDoubleAboveMiddle)}");
            Console.WriteLine($"Using Math.Round with ToNegativeInfinity mode results in {RoundDownUsingMathRoundWithToNegativeInfinityMode(negativeDoubleAboveMiddle)}");
            Console.WriteLine($"Using Math.Round with ToPositiveInfinity mode results in {RoundDownUsingMathRoundWithToPositiveInfinityMode(negativeDoubleAboveMiddle)}");
            Console.WriteLine($"Using Math.Round with ToZero mode results in {RoundDownUsingMathRoundWithToZeroMode(negativeDoubleAboveMiddle)}");
            Console.WriteLine($"Using Math.Round with AwayFromZero mode results in {RoundDownUsingMathRoundWithAwayFromZeroMode(negativeDoubleAboveMiddle)}");
            Console.WriteLine($"Using Math.Round with ToEven mode results in {RoundDownUsingMathRoundWithToEvenMode(negativeDoubleAboveMiddle)}");
            Console.WriteLine($"Using Convert.ToInt32 results in {RoundDownUsingConvertToInt32(negativeDoubleAboveMiddle)}");
            Console.WriteLine($"Using casting results in {RoundDownUsingCasting(negativeDoubleAboveMiddle)}");
            Console.WriteLine($"Using subtraction with modulo results in {RoundDownUsingSubtractionWithModulo(negativeDoubleAboveMiddle)}");
            Console.WriteLine($"Using string parsing results in {RoundDownUsingStringParsing(negativeDoubleAboveMiddle)}");
        }

        private static void MeasureTime()
        {
            var stopwatch = new Stopwatch();
            var numberCount = 100000000;

            stopwatch.Start();
            for (var cnt = 0; cnt < numberCount; cnt++)
            {
                RoundDownUsingMathFloor(positiveDoubleBellowMiddle);
            }
            Console.WriteLine($"Time for Math.Floor: {stopwatch.Elapsed.ToString(@"m\:ss\.ff")}");

            stopwatch.Restart();
            for (var cnt = 0; cnt < numberCount; cnt++)
            {
                RoundDownUsingMathTruncate(positiveDoubleBellowMiddle);
            }
            Console.WriteLine($"Time for Math.Truncate: {stopwatch.Elapsed.ToString(@"m\:ss\.ff")}");

            stopwatch.Restart();
            for (var cnt = 0; cnt < numberCount; cnt++)
            {
                RoundDownUsingMathRoundWithToNegativeInfinityMode(positiveDoubleBellowMiddle);
            }
            Console.WriteLine($"Time for Math.Round with ToNegativeInfinity mode: {stopwatch.Elapsed.ToString(@"m\:ss\.ff")}");

            stopwatch.Restart();
            for (var cnt = 0; cnt < numberCount; cnt++)
            {
                RoundDownUsingMathRoundWithToPositiveInfinityMode(positiveDoubleBellowMiddle);
            }
            Console.WriteLine($"Time for Math.Round with ToPositiveInfinity mode: {stopwatch.Elapsed.ToString(@"m\:ss\.ff")}");

            stopwatch.Restart();
            for (var cnt = 0; cnt < numberCount; cnt++)
            {
                RoundDownUsingMathRoundWithToZeroMode(positiveDoubleBellowMiddle);
            }
            Console.WriteLine($"Time for Math.Round with ToZero mode: {stopwatch.Elapsed.ToString(@"m\:ss\.ff")}");

            stopwatch.Restart();
            for (var cnt = 0; cnt < numberCount; cnt++)
            {
                RoundDownUsingMathRoundWithAwayFromZeroMode(positiveDoubleBellowMiddle);
            }
            Console.WriteLine($"Time for Math.Round with AwayFromZero mode: {stopwatch.Elapsed.ToString(@"m\:ss\.ff")}");

            stopwatch.Restart();
            for (var cnt = 0; cnt < numberCount; cnt++)
            {
                RoundDownUsingMathRoundWithToEvenMode(positiveDoubleBellowMiddle);
            }
            Console.WriteLine($"Time for Math.Round with ToEven mode: {stopwatch.Elapsed.ToString(@"m\:ss\.ff")}");

            stopwatch.Restart();
            for (var cnt = 0; cnt < numberCount; cnt++)
            {
                RoundDownUsingConvertToInt32(positiveDoubleBellowMiddle);
            }
            Console.WriteLine($"Time for Convert.ToInt32: {stopwatch.Elapsed.ToString(@"m\:ss\.ff")}");

            stopwatch.Restart();
            for (var cnt = 0; cnt < numberCount; cnt++)
            {
                RoundDownUsingCasting(positiveDoubleBellowMiddle);
            }
            Console.WriteLine($"Time for casting: {stopwatch.Elapsed.ToString(@"m\:ss\.ff")}");

            stopwatch.Restart();
            for (var cnt = 0; cnt < numberCount; cnt++)
            {
                RoundDownUsingSubtractionWithModulo(positiveDoubleBellowMiddle);
            }
            Console.WriteLine($"Time for subtraction with modulo: {stopwatch.Elapsed.ToString(@"m\:ss\.ff")}");

            stopwatch.Restart();
            for (var cnt = 0; cnt < numberCount; cnt++)
            {
                RoundDownUsingStringParsing(positiveDoubleBellowMiddle);
            }
            Console.WriteLine($"Time for string parsing: {stopwatch.Elapsed.ToString(@"m\:ss\.ff")}");
        }

        public static void Main(string[] args)
        {
            //RoundDownPositiveDoubleBellowMiddle();
            //Console.WriteLine();

            //RoundDownPositiveDoubleInTheMiddle();
            //Console.WriteLine();

            //RoundDownPositiveDoubleAboveMiddle();
            //Console.WriteLine();

            //RoundDownNegativeDoubleBellowMiddle();
            //Console.WriteLine();

            //RoundDownNegativeDoubleInTheMiddle();
            //Console.WriteLine();

            //RoundDownNegativeDoubleAboveMiddle();
            //Console.WriteLine();

            RoundDownUsingMathFloor();
            Console.WriteLine();

            RoundDownUsingMathTruncate();
            Console.WriteLine();

            RoundDownUsingMathRoundWithToNegativeInfinityMode();
            Console.WriteLine();

            RoundDownUsingMathRoundWithToPositiveInfinityMode();
            Console.WriteLine();

            RoundDownUsingMathRoundWithToZeroMode();
            Console.WriteLine();

            RoundDownUsingMathRoundWithAwayFromZeroMode();
            Console.WriteLine();

            RoundDownUsingMathRoundWithToEvenMode();
            Console.WriteLine();

            RoundDownUsingConvertToInt32();
            Console.WriteLine();

            RoundDownUsingCasting();
            Console.WriteLine();

            RoundDownUsingSubtractionWithModulo();
            Console.WriteLine();

            RoundDownUsingStringParsing();
            Console.WriteLine();

            MeasureTime();
        }
    }
}