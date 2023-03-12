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
            Console.WriteLine($"Current Culture: {Thread.CurrentThread.CurrentCulture.Name}");

            /*
             * 
             */
            string dateString;
            string format;
            string[] formats = { };
            ReadOnlySpan<char> dateSpan;
            ReadOnlySpan<char> formatSpan;
            DateTime parsedDate;
            IFormatProvider provider;
            DateTimeStyles styles;
            Dictionary<string, string> dateStringsByFormat;

            /*
             * 
             */
            dateString = "1/12/2023 2:21:37 PM";
            Console.WriteLine($"US: {DateTime.Parse(dateString, CultureInfo.CreateSpecificCulture("en-US"))}");
            Console.WriteLine($"GB: {DateTime.Parse(dateString, CultureInfo.CreateSpecificCulture("en-GB"))}");
            Console.WriteLine($"JP: {DateTime.Parse(dateString, CultureInfo.CreateSpecificCulture("ja-JP"))}");

            #region Parse overloads

            Console.WriteLine("\nOverload: Parse(String)");
            try
            {
                /*
                 * Parse(String)
                 */
                dateString = "1/15/2023 2:21:37 PM";
                parsedDate = DateTime.Parse(dateString);
                Console.WriteLine(parsedDate); /* Output: 1/15/2023 2:21:37 PM */

                /*
                 * Parse(String, IFormatProvider) 
                 */
                Console.WriteLine("\nOverload: Parse(String, IFormatProvider)");
                dateString = "1/12/2023 2:21:37 PM";
                provider = new CultureInfo("fr-FR");
                parsedDate = DateTime.Parse(dateString, provider);
                Console.WriteLine(parsedDate); /* Output: FR: 12/1/2023 2:21:37 PM */

                /*
                 * Parse(String, IFormatProvider, DateTimeStyles)
                 */
                Console.WriteLine("\nParse(String, IFormatProvider, DateTimeStyles)");
                dateString = "1/12/2023 2:21:37 PM";
                provider = new CultureInfo("fr-FR");
                styles = DateTimeStyles.None;
                parsedDate = DateTime.Parse(dateString, provider, styles);
                Console.WriteLine(parsedDate); /* Output: 12/1/2023 2:21:37 PM */

                /*
                 * Parse(ReadOnlySpan<Char>, IFormatProvider)
                 */
                Console.WriteLine("\nParse(ReadOnlySpan<Char>, IFormatProvider)");
                dateSpan = "1/12/2023 2:21:37 PM".AsSpan();
                provider = new CultureInfo("fr-FR");
                parsedDate = DateTime.Parse(dateSpan, provider);
                Console.WriteLine(parsedDate); /* Output: 12/1/2023 2:21:37 PM */

                /*
                 * Parse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles)
                 */
                Console.WriteLine("\nParse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles)");
                dateSpan = "2023/12/01T14:21:37-3:00".AsSpan();
                provider = new CultureInfo("fr-FR");
                styles = DateTimeStyles.AssumeLocal; /* The output can change depending of current timezone */
                parsedDate = DateTime.Parse(dateSpan, provider, styles);
                Console.WriteLine(parsedDate); /* Output: 12/1/2023 9:21:37 AM */
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
            bool isValidDate = DateTime.TryParse(dateString, out parsedDate);
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
                Console.WriteLine(parsedDate); /* Output: 1/15/2023 12:00:00 AM */
            else
                Console.WriteLine($"Unable to parse date: {dateString}");

            /*
             * TryParse(String, IFormatProvider, DateTimeStyles, DateTime)
             */
            Console.WriteLine("\nOverload: TryParse(String, IFormatProvider, DateTimeStyles, DateTime)");
            dateString = "2023/1/15 14:21:37-03:00";
            provider = new CultureInfo("en-GB");
            styles = DateTimeStyles.AdjustToUniversal;
            isValidDate = DateTime.TryParse(dateString, provider, styles, out parsedDate);
            if (isValidDate)
                Console.WriteLine(parsedDate);
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
            provider = new CultureInfo("fr-FR");
            isValidDate = DateTime.TryParse(dateSpan, provider, out parsedDate);
            if (isValidDate)
                Console.WriteLine(parsedDate); /* Output: 1/15/2023 12:00:00 AM */
            else
                Console.WriteLine($"Unable to parse date: {dateSpan}");

            /*
             * TryParse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles, DateTime)
             */
            Console.WriteLine("\nOverload: TryParse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles, DateTime)");
            dateSpan = "15/1/2023".AsSpan();
            provider = new CultureInfo("fr-FR");
            styles = DateTimeStyles.None;
            isValidDate = DateTime.TryParse(dateSpan, provider, styles, out parsedDate);
            if (isValidDate)
                Console.WriteLine(parsedDate);
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
                Console.WriteLine(parsedDate);
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
                Console.WriteLine(parsedDate); /* Output: 1/15/2023 2:12:12 PM */
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
                    parsedDate = DateTime.ParseExact(dateString, newFormat, provider, styles);
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
                    parsedDate = DateTime.ParseExact(dateString.AsSpan(), newFormat, provider, styles);
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
                isValidDate = DateTime.TryParseExact(dateString, newFormat, provider, styles, out parsedDate);
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