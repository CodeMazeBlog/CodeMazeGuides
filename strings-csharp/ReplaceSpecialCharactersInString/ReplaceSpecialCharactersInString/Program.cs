namespace ReplaceSpecialCharactersInString
{
    public class ReplaceSpecialCharactersInString
    {
        public static void Main(string[] args)
        {
            var originalString = "a*b*c*d*e*f*g#h#i#j*k*l*m*n*o*p*q*r*s*t*u*v*w#x#y#z";

            Console.WriteLine("Original String :" + originalString);

            var resultUsingStringReplace = StringReplacer.
                ReplaceUsingStringReplace(originalString, '#', ' ');
            var resultUsingStringBuilder = StringReplacer.
                ReplaceUsingStringBuilder(originalString, '#', ' ');
            var resultUsingRegex = StringReplacer.
                ReplaceUsingRegex(originalString, "#", " ");
            var resultUsingSpan = StringReplacer.
                ReplaceUsingSpan(originalString, '#', ' ');
            var resultInefficientMultipleReplacements = StringReplacer.
                ReplaceUsingInefficientMultipleReplacementsStringReplace(originalString, '#', ' ');
            var resultMemoryImpactStringReplace = StringReplacer.
                ReplaceUsingMemoryImpactStringReplace(originalString, '#', ' ');
            var resultCompiledRegex = StringReplacer.
                ReplaceUsingCompiledRegex(originalString, "#", "-");
            var resultNonBacktrackingRegex = StringReplacer.
                ReplaceUsingNonBacktrackingRegex(originalString, "#", " ");
            var resultUnsafeCode = StringReplacer.
                ReplaceUsingUnsafeCode(originalString, '#', ' ');

            Console.WriteLine("ReplaceUsingStringReplace: " + resultUsingStringReplace);
            Console.WriteLine("ReplaceUsingStringBuilder: " + resultUsingStringBuilder);
            Console.WriteLine("ReplaceUsingRegex: " + resultUsingRegex);
            Console.WriteLine("ReplaceUsingSpan: " + resultUsingSpan);
            Console.WriteLine("ReplaceUsingInefficientMultipleReplacementsStringReplace: " + 
                resultInefficientMultipleReplacements);
            Console.WriteLine("ReplaceUsingMemoryImpactStringReplace: " +
                resultMemoryImpactStringReplace);
            Console.WriteLine("ReplaceUsingCompiledRegex: " + resultCompiledRegex);
            Console.WriteLine("ReplaceUsingNonBacktrackingRegex: " + resultNonBacktrackingRegex);
            Console.WriteLine("ReplaceUsingUnsafeCode: " + resultUnsafeCode);

            //BenchmarkRunner.Run<StringReplacerBenchmarks>();
        }
    }
}

