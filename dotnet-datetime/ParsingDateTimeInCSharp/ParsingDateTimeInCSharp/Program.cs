using System.Globalization;

namespace ParsingDateTimeInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Printing the Current Culture
             */
            DateTime date = new DateTime(2023, 1, 15, 14, 21, 37);
            Console.WriteLine($"My current culture: {CultureInfo.CurrentCulture}");
            Console.WriteLine($"My date in the current culture({CultureInfo.CurrentCulture}): {date}");

            /*
             * Changing the Current Culture
             */
            CultureInfo culture = CultureInfo.GetCultureInfo("en-GB");
            Console.WriteLine($"My date in the culture({culture}): {date.ToString(culture)}");
            Console.WriteLine($"Current Culture: {Thread.CurrentThread.CurrentCulture.Name}");

            string dateString;
            string format;
            bool isValidDate;
            string[] formats;
            ReadOnlySpan<char> dateSpan;
            ReadOnlySpan<char> formatSpan;
            DateTime parsedDate;
            IFormatProvider provider;
            DateTimeStyles styles;
            Dictionary<string, string> dateStringsByFormat;


            #region Parse overloads

            Console.WriteLine("\nOverload: Parse()");
            try
            {
                /*
                 * Parse(String)
                 */
                dateString = "15/1/2023 02:21:37";
                parsedDate = DateTime.Parse(dateString);
                Console.WriteLine(parsedDate); /* Output: 1/15/2023 2:21:37 AM */

                /*
                 * Parse(String, IFormatProvider) 
                 */
                Console.WriteLine("\nOverload: Parse(String, IFormatProvider)");
                dateString = "15/1/2023 02:21:37";
                provider = new CultureInfo("fr-FR");
                parsedDate = DateTime.Parse(dateString, provider);
                Console.WriteLine(parsedDate); /* Output: 15/1/2023 2:21:37 AM */

                /*
                 * Parse(String, IFormatProvider, DateTimeStyles)
                 */
                Console.WriteLine("\nParse(String, IFormatProvider, DateTimeStyles)");
                dateString = "15/1/2023 02:21:37";
                provider = new CultureInfo("fr-FR");
                styles = DateTimeStyles.AssumeUniversal;
                parsedDate = DateTime.Parse(dateString, provider, styles);
                Console.WriteLine(parsedDate); /* Output: 15/01/2023 1:21:37 PM */

                /*
                 * Parse(ReadOnlySpan<Char>, IFormatProvider)
                 */
                Console.WriteLine("\nParse(ReadOnlySpan<Char>, IFormatProvider)");
                dateSpan = "15/1/2023 02:21:37".AsSpan();
                provider = new CultureInfo("fr-FR");
                parsedDate = DateTime.Parse(dateSpan, provider);
                Console.WriteLine(parsedDate); /* Output: 15/01/2023 2:21:37 AM */

                /*
                 * Parse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles)
                 */
                Console.WriteLine("\nParse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles)");
                dateSpan = "15/1/2023 02:21:37".AsSpan();
                provider = new CultureInfo("fr-FR");
                styles = DateTimeStyles.AssumeUniversal;
                parsedDate = DateTime.Parse(dateSpan, provider, styles);
                Console.WriteLine(parsedDate); /* Output: 15/01/2023 1:21:37 PM */
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion

            #region TryParse overloads

            /*
             * TryParse(String, DateTime)
             */
            Console.WriteLine("\nOverload: TryParse(String, DateTime)");
            dateString = "1/15/2023";
            isValidDate = DateTime.TryParse(dateString, out parsedDate);
            if (isValidDate)
                Console.WriteLine(parsedDate); /* Output: 1/15/2023 12:00:00 AM */
            else
                Console.WriteLine($"Unable to parse date: {dateString}");

            /*
             * TryParse(String, IFormatProvider, DateTime)
             */
            Console.WriteLine("\nOverload: TryParse(String, IFormatProvider, DateTime)");
            dateString = "15/1/2023";
            provider = new CultureInfo("en-GB");
            isValidDate = DateTime.TryParse(dateString, provider, out parsedDate);
            if (isValidDate)
                Console.WriteLine(parsedDate); /* Output: 15/01/2023 12:00:00 AM */
            else
                Console.WriteLine($"Unable to parse date: {dateString}");

            /*
             * TryParse(String, IFormatProvider, DateTimeStyles, DateTime)
             */
            Console.WriteLine("\nOverload: TryParse(String, IFormatProvider, DateTimeStyles, DateTime)");
            dateString = "2023/1/15 14:21:37-05:00";
            provider = new CultureInfo("en-GB");
            styles = DateTimeStyles.AdjustToUniversal;
            isValidDate = DateTime.TryParse(dateString, provider, styles, out parsedDate);
            if (isValidDate)
                Console.WriteLine(parsedDate); /* Output: 15/01/2023 7:21:37 PM */
            else
                Console.WriteLine($"Unable to parse date: {dateString}");

            /*
             * TryParse(ReadOnlySpan<Char>, DateTime)
             */
            Console.WriteLine("\nOverload: TryParse(ReadOnlySpan<Char>, DateTime)");
            dateSpan = "1/15/2023".AsSpan();
            isValidDate = DateTime.TryParse(dateSpan, out parsedDate);
            if (isValidDate)
                Console.WriteLine(parsedDate); /* Output: 1/15/2023 12:00:00 AM */
            else
                Console.WriteLine($"Unable to parse date: {dateSpan}");

            /*
             * TryParse(ReadOnlySpan<Char>, IFormatProvider, DateTime)
             */
            Console.WriteLine("\nOverload: TryParse(ReadOnlySpan<Char>, IFormatProvider, DateTime)");
            dateSpan = "15/1/2023".AsSpan();
            provider = new CultureInfo("en-GB");
            isValidDate = DateTime.TryParse(dateSpan, provider, out parsedDate);
            if (isValidDate)
                Console.WriteLine(parsedDate); /* Output: 15/01/2023 12:00:00 AM */
            else
                Console.WriteLine($"Unable to parse date: {dateSpan}");

            /*
             * TryParse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles, DateTime)
             */
            Console.WriteLine("\nOverload: TryParse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles, DateTime)");
            dateSpan = "15/1/2023".AsSpan();
            provider = new CultureInfo("en-GB");
            styles = DateTimeStyles.None;
            isValidDate = DateTime.TryParse(dateSpan, provider, styles, out parsedDate);
            if (isValidDate)
                Console.WriteLine(parsedDate); /* Output: 15/01/2023 12:00:00 AM */
            else
                Console.WriteLine($"Unable to parse date: {dateSpan}");

            #endregion

            #region ParseExact
            /*
             * ParseExact(String, String, IFormatProvider)
             */
            Console.WriteLine("\nOverload: ParseExact(String, String, IFormatProvider)");
            dateString = "15/1/2023 10:12:12";
            format = "dd/M/yyyy hh:mm:ss";
            provider = new CultureInfo("fr-FR");
            try
            {
                parsedDate = DateTime.ParseExact(dateString, format, provider);
                Console.WriteLine(parsedDate); /* Output: 15/01/2023 10:12:12 AM */
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            /*
             * ParseExact(String, String, IFormatProvider, DateTimeStyles)
             */
            Console.WriteLine("\nOverload: ParseExact(String, String, IFormatProvider, DateTimeStyles)");
            dateString = "2023-01-15T14:12:12.0000000Z";
            provider = new CultureInfo("fr-FR");
            styles = DateTimeStyles.RoundtripKind;
            try
            {
                parsedDate = DateTime.ParseExact(dateString, "o", provider, styles);
                Console.WriteLine(parsedDate); /* Output: 15/01/2023 2:12:12 PM */
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            /*
             * ParseExact(ReadOnlySpan<Char>, ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles)
             */
            Console.WriteLine("\nOverload: ParseExact(ReadOnlySpan<Char>, ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles)");
            dateSpan = "2023-01-15T14:12:12.0000000Z".AsSpan();
            provider = new CultureInfo("fr-FR");
            styles = DateTimeStyles.RoundtripKind;
            try
            {
                parsedDate = DateTime.ParseExact(dateSpan, "o", provider, styles);
                Console.WriteLine(parsedDate); /* Output: 1/15/2023 2:12:12 PM */
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            /*
             * ParseExact(String, String[], IFormatProvider, DateTimeStyles)
             */
            Console.WriteLine("\nOverload: ParseExact(String, String[], IFormatProvider, DateTimeStyles)");
            formats = new string[] { "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", "yyyy-MM-dd'T'HH:mm:ss'Z'", "yyyyMMdd'T'HH:mm:ss.fff'Z'", "yyyyMMdd'T'HH:mm:ss'Z'", "dd-MM-yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss" };
            provider = CultureInfo.InvariantCulture;
            styles = DateTimeStyles.None;
            dateStringsByFormat = new Dictionary<string, string>
            {
                { "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", "2023-01-15T14:12:12.000Z" },
                { "yyyy-MM-dd'T'HH:mm:ss'Z'", "2023-01-15T14:12:12Z" },
                { "yyyyMMdd'T'HH:mm:ss.fff'Z'", "20230115T14:12:12.000Z" },
                { "yyyyMMdd'T'HH:mm:ss'Z'", "20230115T14:12:12Z" },
                { "dd-MM-yyyy HH:mm:ss", "15-01-2023 14:12:12" },
                { "dd/MM/yyyy HH:mm:ss", "15/01/2023 14:12:12" }
            };

            try
            {
                foreach (string newFormat in formats)
                {
                    dateString = dateStringsByFormat[newFormat];
                    parsedDate = DateTime.ParseExact(dateString, formats, provider, styles);
                    Console.WriteLine(parsedDate);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            /*
             * ParseExact(ReadOnlySpan<Char>, String[], IFormatProvider, DateTimeStyles)
             */
            Console.WriteLine("\nOverload: ParseExact(ReadOnlySpan<Char>, String[], IFormatProvider, DateTimeStyles)");
            formats = new string[] { "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", "yyyy-MM-dd'T'HH:mm:ss'Z'", "yyyyMMdd'T'HH:mm:ss.fff'Z'", "yyyyMMdd'T'HH:mm:ss'Z'", "dd-MM-yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss" };
            provider = CultureInfo.InvariantCulture;
            styles = DateTimeStyles.None;
            dateStringsByFormat = new Dictionary<string, string>
            {
                { "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", "2023-01-15T14:12:12.000Z" },
                { "yyyy-MM-dd'T'HH:mm:ss'Z'", "2023-01-15T14:12:12Z" },
                { "yyyyMMdd'T'HH:mm:ss.fff'Z'", "20230115T14:12:12.000Z" },
                { "yyyyMMdd'T'HH:mm:ss'Z'", "20230115T14:12:12Z" },
                { "dd-MM-yyyy HH:mm:ss", "15-01-2023 14:12:12" },
                { "dd/MM/yyyy HH:mm:ss", "15/01/2023 14:12:12" }
            };

            try
            {
                foreach (string newFormat in formats)
                {
                    dateString = dateStringsByFormat[newFormat];
                    parsedDate = DateTime.ParseExact(dateString.AsSpan(), formats, provider, styles);
                    Console.WriteLine(parsedDate);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion

            #region TryParseExact

            /*
             * TryParseExact(String, String, IFormatProvider, DateTimeStyles, DateTime)
             */
            Console.WriteLine("\nOverload: TryParseExact(String, String, IFormatProvider, DateTimeStyles, DateTime)");
            dateString = "15-01-2023";
            format = "dd-MM-yyyy";
            provider = CultureInfo.InvariantCulture;
            styles = DateTimeStyles.None;
            isValidDate = DateTime.TryParseExact(dateString, format, provider, styles, out parsedDate);
            if (isValidDate)
                Console.WriteLine(parsedDate); /* Output: 1/15/2023 12:00:00 AM */
            else
                Console.WriteLine($"Unable to parse date:{dateString}");

            /*
             * TryParseExact(ReadOnlySpan<Char>, ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles, DateTime)
             */
            Console.WriteLine("\nOverload: TryParseExact(ReadOnlySpan<Char>, ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles, DateTime)");
            dateSpan = "15-01-2023".AsSpan();
            formatSpan = "dd-MM-yyyy".AsSpan();
            provider = CultureInfo.InvariantCulture;
            styles = DateTimeStyles.None;
            isValidDate = DateTime.TryParseExact(dateSpan, formatSpan, provider, styles, out parsedDate);
            if (isValidDate)
                Console.WriteLine(parsedDate); /* Output: 1/15/2023 12:00:00 AM */
            else
                Console.WriteLine($"Unable to parse date:{dateSpan}");

            /*
             * TryParseExact(String, String[], IFormatProvider, DateTimeStyles, DateTime)
             */
            Console.WriteLine("\nOverload: TryParseExact(String, String[], IFormatProvider, DateTimeStyles, DateTime)");
            formats = new string[] { "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", "yyyy-MM-dd'T'HH:mm:ss'Z'", "yyyyMMdd'T'HH:mm:ss.fff'Z'", "yyyyMMdd'T'HH:mm:ss'Z'", "dd-MM-yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss" };
            provider = CultureInfo.InvariantCulture;
            styles = DateTimeStyles.None;
            dateStringsByFormat = new Dictionary<string, string>
            {
                { "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", "2023-01-15T14:12:12.000Z" },
                { "yyyy-MM-dd'T'HH:mm:ss'Z'", "2023-01-15T14:12:12Z" },
                { "yyyyMMdd'T'HH:mm:ss.fff'Z'", "20230115T14:12:12.000Z" },
                { "yyyyMMdd'T'HH:mm:ss'Z'", "20230115T14:12:12Z" },
                { "dd-MM-yyyy HH:mm:ss", "15-01-2023 14:12:12" },
                { "dd/MM/yyyy HH:mm:ss", "15/01/2023 14:12:12" },
            };

            foreach (var newFormat in formats)
            {
                dateString = dateStringsByFormat[newFormat];
                isValidDate = DateTime.TryParseExact(dateString, formats, provider, styles, out parsedDate);
                if (isValidDate)
                    Console.WriteLine(parsedDate);
                else
                    Console.WriteLine($"Unable to parse date:{dateString}");
            }

            /*
             * TryParseExact(ReadOnlySpan<Char>, String[], IFormatProvider, DateTimeStyles, DateTime)
             */
            Console.WriteLine("\nOverload: TryParseExact(ReadOnlySpan<Char>, String[], IFormatProvider, DateTimeStyles, DateTime)");
            formats = new string[] { "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", "yyyy-MM-dd'T'HH:mm:ss'Z'", "yyyyMMdd'T'HH:mm:ss.fff'Z'", "yyyyMMdd'T'HH:mm:ss'Z'", "dd-MM-yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss" };
            provider = CultureInfo.InvariantCulture;
            styles = DateTimeStyles.None;
            dateStringsByFormat = new Dictionary<string, string>
            {
                { "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", "2023-01-15T14:12:12.000Z" },
                { "yyyy-MM-dd'T'HH:mm:ss'Z'", "2023-01-15T14:12:12Z" },
                { "yyyyMMdd'T'HH:mm:ss.fff'Z'", "20230115T14:12:12.000Z" },
                { "yyyyMMdd'T'HH:mm:ss'Z'", "20230115T14:12:12Z" },
                { "dd-MM-yyyy HH:mm:ss", "15-01-2023 14:12:12" },
                { "dd/MM/yyyy HH:mm:ss", "15/01/2023 14:12:12" },
            };

            foreach (var newFormat in formats)
            {
                dateSpan = dateStringsByFormat[newFormat].AsSpan();
                isValidDate = DateTime.TryParseExact(dateSpan, newFormat, provider, styles, out parsedDate);
                if (isValidDate)
                    Console.WriteLine(parsedDate);
                else
                    Console.WriteLine($"Unable to parse date:{dateString}");
            }

            #endregion

            Console.ReadKey();
        }
    }
}