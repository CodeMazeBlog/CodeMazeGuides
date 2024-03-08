using BenchmarkDotNet.Attributes;

namespace ReplaceSpecialCharactersInString
{
    [MemoryDiagnoser]
    public class StringReplacerBenchmarks
    {
        private string originalString = "";

        private char OldChar { get; set; } = '#';

        private char NewChar { get; set; } = ' ';

        [Params(50, 100)]
        public int Iterations { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            originalString = "a*b*c*d*e*f*g#h#i#j*k*l*m*n*o*p*q*r*s*t*u*v*w#x#y#z";
        }

        [Benchmark]
        public void ReplaceUsingStringReplace()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringReplacer.ReplaceUsingStringReplace(originalString, OldChar, NewChar);
            }
        }

        [Benchmark]
        public void ReplaceUsingStringBuilder()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringReplacer.ReplaceUsingStringBuilder(originalString, OldChar, NewChar);
            }
        }

        [Benchmark]
        public void ReplaceUsingRegex()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringReplacer.ReplaceUsingRegex(originalString, OldChar.ToString(), NewChar.ToString());
            }
        }

        [Benchmark]
        public void ReplaceUsingSpan()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringReplacer.ReplaceUsingSpan(originalString, OldChar, NewChar);
            }
        }

        [Benchmark]
        public void ReplaceUsingInefficientMultipleReplacementsStringReplace()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringReplacer.ReplaceUsingInefficientMultipleReplacementsStringReplace(originalString, OldChar, NewChar);
            }
        }

        [Benchmark]
        public void ReplaceUsingMemoryImpactStringReplace()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringReplacer.ReplaceUsingMemoryImpactStringReplace(originalString, OldChar, NewChar);
            }
        }

        [Benchmark]
        public void ReplaceUsingCompiledRegex()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringReplacer.ReplaceUsingCompiledRegex(originalString, OldChar.ToString(), NewChar.ToString());
            }
        }

        [Benchmark]
        public void ReplaceUsingNonBacktrackingRegex()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringReplacer.ReplaceUsingNonBacktrackingRegex(originalString, OldChar.ToString(), NewChar.ToString());
            }
        }

        [Benchmark]
        public void ReplaceUsingUnsafeCode()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringReplacer.ReplaceUsingUnsafeCode(originalString, OldChar, NewChar);
            }
        }

    }
}
