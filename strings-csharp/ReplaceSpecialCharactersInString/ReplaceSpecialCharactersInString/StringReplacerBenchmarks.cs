using BenchmarkDotNet.Attributes;

namespace ReplaceSpecialCharactersInString
{
    public class StringReplacerBenchmarks
    {
        private string originalString = "";

        [Params(' ')]
        public char charToReplace;

        [Params('#')]
        public char charToBeReplaced;

        [GlobalSetup]
        public void Setup()
        {
            originalString = "a*b*c*d*e*f*g#h#i#j*k*l*m*n*o*p*q*r*s*t*u*v*w#x#y#z";
        }

        [Benchmark]
        public string ReplaceUsingStringReplace()
        {
            return StringReplacer.ReplaceUsingStringReplace(originalString, charToBeReplaced, charToReplace);
        }

        [Benchmark]
        public string ReplaceUsingStringBuilder()
        {
            return StringReplacer.ReplaceUsingStringBuilder(originalString, charToBeReplaced, charToReplace);
        }

        [Benchmark]
        public string ReplaceUsingRegex()
        {
            return StringReplacer.ReplaceUsingRegex(originalString, charToBeReplaced, charToReplace);
        }

        [Benchmark]
        public string ReplaceUsingSpan()
        {
            return StringReplacer.ReplaceUsingSpan(originalString, charToBeReplaced, charToReplace);
        }

        [Benchmark]
        public string ReplaceUsingInefficientMultipleReplacementsStringReplace()
        {
            return StringReplacer.ReplaceUsingInefficientMultipleReplacementsStringReplace(originalString, charToBeReplaced, charToReplace);
        }

        [Benchmark]
        public string ReplaceUsingMemoryImpactStringReplace()
        {
            return StringReplacer.ReplaceUsingMemoryImpactStringReplace(originalString, charToBeReplaced, charToReplace);
        }

        [Benchmark]
        public string ReplaceUsingCompiledRegex()
        {
            return StringReplacer.ReplaceUsingCompiledRegex(originalString, charToBeReplaced, charToReplace);
        }

        [Benchmark]
        public string ReplaceUsingDotNet8Features()
        {
            return StringReplacer.ReplaceUsingDotNet8Features(originalString, charToBeReplaced, charToReplace);
        }

        [Benchmark]
        public string ReplaceUsingUnsafeCode()
        {
            return StringReplacer.ReplaceUsingUnsafeCode(originalString, charToBeReplaced, charToReplace);
        }

    }

}
