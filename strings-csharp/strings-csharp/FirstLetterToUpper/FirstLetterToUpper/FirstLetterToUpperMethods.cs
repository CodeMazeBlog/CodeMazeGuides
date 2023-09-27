using BenchmarkDotNet.Attributes;
using System.Text.RegularExpressions;

namespace FirstLetterToUpper
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class FirstLetterToUpperMethods
    {
        public IEnumerable<object[]> SampleStrings()
        {
            yield return new object[] { GenerateRandomString(2000)};
        }

        [Benchmark]
        [ArgumentsSource(nameof(SampleStrings))]
        public string FirstCharSubstring(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            return $"{input[0].ToString().ToUpper()}{input.Substring(1)}";
        }

        [Benchmark]
        [ArgumentsSource(nameof(SampleStrings))]
        public string FirstCharToUpper(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            return $"{char.ToUpper(input[0])}{input[1..]}";
        }

        [Benchmark]
        [ArgumentsSource(nameof(SampleStrings))]
        public string FirstCharToCharArray(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            var stringArray = input.ToCharArray();

            if (char.IsLower(stringArray[0]))
            {
                stringArray[0] = char.ToUpper(stringArray[0]);
            }

            return new string(stringArray);
        }

        [Benchmark]
        [ArgumentsSource(nameof(SampleStrings))]
        public string FirstCharToUpperAsSpan(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            Span<char> destination = stackalloc char[1];

            input.AsSpan(0, 1).ToUpperInvariant(destination);

            return $"{destination}{input.AsSpan(1)}";
        }

        [Benchmark]
        [ArgumentsSource(nameof(SampleStrings))]
        public string FirstCharToUpperRegex(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            return Regex.Replace(input, "^[a-z]", c => c.Value.ToUpper());
        }

        [Benchmark]
        [ArgumentsSource(nameof(SampleStrings))]
        public string FirstCharToUpperLinq(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            return $"{input.FirstOrDefault().ToString().ToUpper()}{input.Substring(1)}";
        }


        [Benchmark]
        [ArgumentsSource(nameof(SampleStrings))]
        public string FirstCharToUpperStringCreate(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            return string.Create(input.Length, input, static (Span<char> chars, string str) =>
            {
                chars[0] = char.ToUpperInvariant(str[0]);
                str.AsSpan(1).CopyTo(chars[1..]);
            });
        }

        [Benchmark]
        [ArgumentsSource(nameof(SampleStrings))]
        public string FirstCharToUpperUnsafeCode(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            unsafe
            {
                fixed (char* p = input)
                {
                    *p = char.ToUpper(*p);
                }
            }

            return input;
        }

        private string GenerateRandomString(int size)
        {
            var random = new Random();

            var charOptions = "abcdefghijklmnopqrstuvwxyz";

            return new string(Enumerable.Repeat(charOptions, size).Select(s => s[random.Next(s.Length)]).ToArray()).ToLower();
        }
    }
}
