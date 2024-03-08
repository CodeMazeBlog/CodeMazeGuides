using ReplaceSpecialCharactersInString;

namespace ReplaceSpecialCharactersInStringTests
{
    [TestClass]
    public class ReplaceSpecialCharactersInStringTests
    {
        private const string OriginalString = "a*b*c*d*e*f*g#h#i#j*k*l*m*n*o*p*q*r*s*t*u*v*w#x#y#z";

        private const string ExpectedOutput = "a*b*c*d*e*f*g h i j*k*l*m*n*o*p*q*r*s*t*u*v*w x y z";

        private char OldChar { get; set; } = '#';

        private char NewChar { get; set; } = ' ';

        [TestMethod]
        public void WhenUsingStringReplace_ThenReplaceSpecialCharacters()
        {
            var result = StringReplacer.ReplaceUsingStringReplace(OriginalString, OldChar, NewChar);

            Assert.AreEqual(ExpectedOutput, result);
        }

        [TestMethod]
        public void WhenUsingStringBuilder_ThenReplaceMultipleSpecialCharacters()
        {
            var result = StringReplacer.ReplaceUsingStringBuilder(OriginalString, OldChar, NewChar);

            Assert.AreEqual(ExpectedOutput, result);
        }

        [TestMethod]
        public void WhenUsingRegex_ThenReplaceSpecialCharacters()
        {
            var result = StringReplacer.ReplaceUsingRegex(OriginalString, OldChar.ToString(), NewChar.ToString());

            Assert.AreEqual(ExpectedOutput, result);
        }

        [TestMethod]
        public void WhenUsingSpan_ThenReplaceSpecialCharactersWithMemoryEfficient()
        {
            var result = StringReplacer.ReplaceUsingSpan(OriginalString, OldChar, NewChar);

            Assert.AreEqual(ExpectedOutput, result);
        }

        [TestMethod]
        public void WhenUsingInefficientMultipleReplacementsStringReplace_ThenReplaceSpecialCharacters()
        {
            var expectedOutput = "a*b**d*e*f*g h i j*k*l*m*n*o*p*q*r*s*t*u*v*w x y z";
            var result = StringReplacer.ReplaceUsingInefficientMultipleReplacementsStringReplace(OriginalString, OldChar, NewChar);

            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void WhenUsingMemoryImpactStringReplace_ThenReplaceSpecialCharacters()
        {
            var result = StringReplacer.ReplaceUsingMemoryImpactStringReplace(OriginalString, OldChar, NewChar);

            Assert.AreEqual(ExpectedOutput, result);
        }

        [TestMethod]
        public void WhenUsingCompiledRegex_ThenReplaceSpecialCharacters()
        {
            var result = StringReplacer.ReplaceUsingCompiledRegex(OriginalString, OldChar.ToString(), NewChar.ToString());

            Assert.AreEqual(ExpectedOutput, result);
        }

        [TestMethod]
        public void WhenUsingNonBacktrackingRegex_ThenReplaceSpecialCharacters()
        {
            var result = StringReplacer.ReplaceUsingNonBacktrackingRegex(OriginalString, OldChar.ToString(), NewChar.ToString());

            Assert.AreEqual(ExpectedOutput, result);
        }

        [TestMethod]
        public void WhenUsingUnsafeCode_ThenReplaceSpecialCharacters()
        {
            var result = StringReplacer.ReplaceUsingUnsafeCode(OriginalString, OldChar, NewChar);

            Assert.AreEqual(ExpectedOutput, result);
        }
    }
}
