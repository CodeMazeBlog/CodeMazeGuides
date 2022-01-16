using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class StringSplitUnitTest
    {
        [TestMethod]
        public void WhenSplitByNewLine_ThenCreateArrayOfSubstrings()
        {
            string highScoresText = $"15562{ Environment.NewLine }12988{ Environment.NewLine }9876{ Environment.NewLine }" +
                $"6584{ Environment.NewLine }6292";

            // Split the string by new line. The array will contain as many members as the number of lines in the text
            string[] highScoresArray = highScoresText.Split(Environment.NewLine);

            // Print each array member
            for (int i = 0; i < highScoresArray.Length; i++)
            {
                Console.WriteLine($"High Score { i + 1 }: { highScoresArray[i] }");
            }

            //// Output:
            ////High Score 1: 15562
            ////High Score 2: 12988
            ////High Score 3: 9876
            ////High Score 4: 6584
            ////High Score 5: 6292

            Assert.IsTrue(highScoresArray.Length == 5);
            Assert.IsTrue(highScoresArray[0] == "15562");
            Assert.IsTrue(highScoresArray[1] == "12988");
            Assert.IsTrue(highScoresArray[2] == "9876");
            Assert.IsTrue(highScoresArray[3] == "6584");
            Assert.IsTrue(highScoresArray[4] == "6292");
        }

        [TestMethod]
        public void WhenSplitByCharacter_ThenCreateArrayOfSubstrings()
        {
            // Example text
            string exampleText = "The quick brown fox jumps over the lazy dog";

            // Split by 'e'
            string[] allLines = exampleText.Split('e');

            // Print each array member
            for (int i = 0; i < allLines.Length; i++)
            {
                Console.WriteLine($"Line { i + 1 }: { allLines[i] }");
            }

            // Output:
            //Line 1: Th
            //Line 2:  quick brown fox jumps ov
            //Line 3: r th
            //Line 4:  lazy dog

            Assert.IsTrue(allLines.Length == 4);
            Assert.IsTrue(allLines[0] == "Th");
            Assert.IsTrue(allLines[1] == " quick brown fox jumps ov");
            Assert.IsTrue(allLines[2] == "r th");
            Assert.IsTrue(allLines[3] == " lazy dog");
        }

        [TestMethod]
        public void WhenSplitByString_ThenCreateArrayOfSubstrings()
        {
            // Example text
            string exampleText = "The quick brown fox jumps over the lazy dog";

            // Split by "the"
            string[] allLines = exampleText.Split("the");

            // Print each array member
            for (int i = 0; i < allLines.Length; i++)
            {
                Console.WriteLine($"Line { i + 1 }: { allLines[i] }");
            }

            // Output:
            //Line 1: The quick brown fox jumps over
            //Line 2:  lazy dog

            Assert.IsTrue(allLines.Length == 2);
            Assert.IsTrue(allLines[0] == "The quick brown fox jumps over ");
            Assert.IsTrue(allLines[1] == " lazy dog");
        }

        [TestMethod]
        public void WhenSplitByStringWithTrimEntries_ThenCreateArrayOfTrimmedSubstrings()
        {
            // Example text
            string exampleText = "The quick brown fox jumps over the lazy dog";

            // Split by "the"
            string[] allLines = exampleText.Split("the", StringSplitOptions.TrimEntries);

            // Print each array member
            for (int i = 0; i < allLines.Length; i++)
            {
                Console.WriteLine($"Line { i + 1 }: { allLines[i] }");
            }

            // Output:
            //Line 1: The quick brown fox jumps over
            //Line 2: lazy dog

            Assert.IsTrue(allLines.Length == 2);
            Assert.IsTrue(allLines[0] == "The quick brown fox jumps over");
            Assert.IsTrue(allLines[1] == "lazy dog");
        }

        [TestMethod]
        public void WhenSplitByStringWithEmptyEntries_ThenCreateArrayOfSubstrings()
        {
            // Example text
            string exampleText = "The quick brown fox jumps over the lazy dog";

            // Split by "the"
            string[] allLines = exampleText.Split("The");

            // Print each array member
            for (int i = 0; i < allLines.Length; i++)
            {
                Console.WriteLine($"Line { i + 1 }: { allLines[i] }");
            }

            // Output:
            //Line 1:
            //Line 2:  quick brown fox jumps over the lazy dog

            Assert.IsTrue(allLines.Length == 2);
            Assert.IsTrue(allLines[0] == "");
            Assert.IsTrue(allLines[1] == " quick brown fox jumps over the lazy dog");
        }

        [TestMethod]
        public void WhenSplitByStringWithRemoveEmptyEntries_ThenCreateArrayOfSubstringsWithoutEmptyEntries()
        {
            // Example text
            string exampleText = "The quick brown fox jumps over the lazy dog";

            // Split by "the"
            string[] allLines = exampleText.Split("The", StringSplitOptions.RemoveEmptyEntries);

            // Print each array member
            for (int i = 0; i < allLines.Length; i++)
            {
                Console.WriteLine($"Line { i + 1 }: { allLines[i] }");
            }

            // Output:
            //Line 1:  quick brown fox jumps over the lazy dog

            Assert.IsTrue(allLines.Length == 1);
            Assert.IsTrue(allLines[0] == " quick brown fox jumps over the lazy dog");
        }

        [TestMethod]
        public void WhenSplitByStringWithCaseInsensitiveSeparator_ThenCreateArrayOfSubstrings()
        {
            // Example text
            string exampleText = "The quick brown fox jumps over the lazy dog";

            // Split by "the" (case insensitive)
            string[] allLines = System.Text.RegularExpressions.Regex.Split(
                exampleText, "the", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // Print each array member
            for (int i = 0; i < allLines.Length; i++)
            {
                Console.WriteLine($"Line { i + 1 }: { allLines[i] }");
            }

            // Output:
            //Line 1:
            //Line 2:  quick brown fox jumps over
            //Line 3:  lazy dog

            Assert.IsTrue(allLines.Length == 3);
            Assert.IsTrue(allLines[0] == "");
            Assert.IsTrue(allLines[1] == " quick brown fox jumps over ");
            Assert.IsTrue(allLines[2] == " lazy dog");
        }
    }
}
