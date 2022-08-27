using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CountingCharOccurences
{
    public class CountChars
    {
        public void RunIterations()
        {
            string source = "Mary had a little lamb and a little hut too.";
            char toFind = 'l';
            int iterations = 100000000;

            Console.WriteLine("|                             Method |   Time(in ms) |");
            Console.WriteLine("|----------------------------------- |--------------:|");

            var sw = new Stopwatch();
            var iterationDetails = new List<IterationDetail>();

            sw.Start();

            for (int i = 0; i < iterations; i++)
            {
                CountCharsUsingLinqCount(source, toFind);
            }
            iterationDetails.Add(new IterationDetail("Using Linq Count() ", sw.ElapsedMilliseconds));

            sw.Restart();

            for (int i = 0; i < iterations; i++)
            {
                CountCharsUsingForeach(source, toFind);
            }
            iterationDetails.Add(new IterationDetail("Using Foreach      ", sw.ElapsedMilliseconds));

            sw.Restart();

            for (int i = 0; i < iterations; i++)
            {
                CountCharsUsingForeachSpan(source, toFind);
            }
            iterationDetails.Add(new IterationDetail("Using Foreach Span ", sw.ElapsedMilliseconds));

            sw.Restart();

            for (int i = 0; i < iterations; i++)
            {
                CountCharsUsingIndex(source, toFind);
            }
            iterationDetails.Add(new IterationDetail("Using IndexOf()    ", sw.ElapsedMilliseconds));

            sw.Restart();

            for (int i = 0; i < iterations; i++)
            {
                CountCharsUsingFor(source, toFind);
            }
            iterationDetails.Add(new IterationDetail("Using For          ", sw.ElapsedMilliseconds));

            sw.Restart();

            for (int i = 0; i < iterations; i++)
            {
                CountCharsUsingForReverseIteration(source, toFind);
            }
            iterationDetails.Add(new IterationDetail("Using For (Reverse)", sw.ElapsedMilliseconds));

            sw.Restart();

            for (int i = 0; i < iterations; i++)
            {
                CountCharsUsingForUsingSpan(source, toFind);
            }
            iterationDetails.Add(new IterationDetail("Using For (Span)   ", sw.ElapsedMilliseconds));

            sw.Restart();

            for (int i = 0; i < iterations; i++)
            {
                CountCharsUsingSplit(source, toFind.ToString());
            }
            iterationDetails.Add(new IterationDetail("Using Split()      ", sw.ElapsedMilliseconds));

            sw.Restart();

            for (int i = 0; i < iterations; i++)
            {
                CountCharsUsingReplace(source, toFind.ToString());
            }
            iterationDetails.Add(new IterationDetail("Using Replace()    ", sw.ElapsedMilliseconds));

            sw.Restart();

            for (int i = 0; i < iterations; i++)
            {
                CountCharsUsingRegex(source, toFind.ToString());
            }
            iterationDetails.Add(new IterationDetail("Using Regex        ", sw.ElapsedMilliseconds));

            iterationDetails.Sort((a, b) => a.Time.CompareTo(b.Time));

            foreach (var item in iterationDetails)
            {
                Console.WriteLine($"|                {item.Name} |          {item.Time} |");
            }
        }

        public int CountCharsUsingLinqCount(string source, char toFind)
        {
            return source.Count(t => t == toFind);
        }

        public int CountCharsUsingForeach(string source, char toFind)
        {
            int count = 0;

            foreach (var ch in source)
            {
                if (ch == toFind)
                    count++;
            }

            return count;
        }

        public int CountCharsUsingForeachSpan(string source, char toFind)
        {
            int count = 0;

            foreach (var c in source.AsSpan())
            {
                if (c == toFind)
                    count++;
            }

            return count;
        }

        public int CountCharsUsingIndex(string source, char toFind)
        {
            int count = 0;
            int n = 0;

            while ((n = source.IndexOf(toFind, n) + 1) != 0)
            {
                n++;
                count++;
            }

            return count;
        }

        public int CountCharsUsingFor(string source, char toFind)
        {
            int count = 0;

            for (int n = 0; n < source.Length; n++)
            {
                if (source[n] == toFind)
                    count++;
            }

            return count;
        }

        public int CountCharsUsingForReverseIteration(string source, char toFind)
        {
            int count = 0;

            for (int n = source.Length - 1; n >= 0; n--)
            {
                if (source[n] == toFind)
                    count++;
            }

            return count;
        }

        public int CountCharsUsingForUsingSpan(string source, char toFind)
        {
            int count = 0;

            for (int n = 0; n < source.AsSpan().Length; n++)
            {
                if (source[n] == toFind)
                    count++;
            }

            return count;
        }

        public int CountCharsUsingSplit(string source, string toFind)
        {
            return source.Split(toFind).Length - 1;
        }

        public int CountCharsUsingReplace(string source, string toFind)
        {
            return (source.Length - source.Replace(toFind, "").Length) / toFind.Length;
        }

        public int CountCharsUsingRegex(string source, string toFind)
        {
            return new Regex(Regex.Escape(toFind)).Matches(source).Count;
        }
    }
}
