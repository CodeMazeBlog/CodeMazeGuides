
using ReplaceSpecialCharactersInString;

namespace ReplaceSpecialCharactersInStringTests
{
    [TestClass]
    public class ReplaceSpecialCharactersInStringTests
    {
        private const string OriginalString = "a*b*c*d*e*f*g#h#i#j*k*l*m*n*o*p*q*r*s*t*u*v*w#x#y#z";

        [TestMethod]
        public void WhenUsingStringReplace_ThenReplaceSpecialCharacters()
        {
            var expected = "a*b*c*d*e*f*g h i j*k*l*m*n*o*p*q*r*s*t*u*v*w x y z";
            var result = StringReplacer.ReplaceUsingStringReplace(OriginalString, '#', ' ');

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenUsingStringBuilder_ThenReplaceMultipleSpecialCharacters()
        {
            var expected = "a*b*c*d*e*f*g h i j*k*l*m*n*o*p*q*r*s*t*u*v*w x y z";
            var result = StringReplacer.ReplaceUsingStringBuilder(OriginalString, '#', ' ');

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenUsingRegex_ThenReplaceSpecialCharacters()
        {
            var expected = "a*b*c*d*e*f*g h i j*k*l*m*n*o*p*q*r*s*t*u*v*w x y z";
            var result = StringReplacer.ReplaceUsingRegex(OriginalString, '#', ' ');

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenUsingSpan_ThenReplaceSpecialCharactersWithMemoryEfficient()
        {
            var expected = "a*b*c*d*e*f*g h i j*k*l*m*n*o*p*q*r*s*t*u*v*w x y z";
            var result = StringReplacer.ReplaceUsingSpan(OriginalString, '#', ' ');

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenUsingInefficientMultipleReplacementsStringReplace_ThenReplaceSpecialCharacters()
        {
            var expected = "a*b**d*e*f*g h i j*k*l*m*n*o*p*q*r*s*t*u*v*w x y z";
            var result = StringReplacer.ReplaceUsingInefficientMultipleReplacementsStringReplace(OriginalString, '#', ' ');

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenUsingMemoryImpactStringReplace_ThenReplaceSpecialCharacters()
        {
            var expected = "a*b*c*d*e*f*g h i j*k*l*m*n*o*p*q*r*s*t*u*v*w x y z";
            var result = StringReplacer.ReplaceUsingMemoryImpactStringReplace(OriginalString, '#', ' ');

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenUsingCompiledRegex_ThenReplaceSpecialCharacters()
        {
            var expected = "a*b*c*d*e*f*ghij*k*l*m*n*o*p*q*r*s*t*u*v*wxyz";
            var result = StringReplacer.ReplaceUsingCompiledRegex(OriginalString, '#', ' ');

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenUsingDotNet8Features_ThenReplaceSpecialCharacters()
        {
            var expected = "a*b*c*d*e*f*ghij*k*l*m*n*o*p*q*r*s*t*u*v*wxyz";
            var result = StringReplacer.ReplaceUsingDotNet8Features(OriginalString, '#', ' ');

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenUsingUnsafeCode_ThenReplaceSpecialCharacters()
        {
            var expected = "a*b*c*d*e*f*g h i j*k*l*m*n*o*p*q*r*s*t*u*v*w x y z";
            var result = StringReplacer.ReplaceUsingUnsafeCode(OriginalString, '#', ' ');

            Assert.AreEqual(expected, result);
        }
    }
}
