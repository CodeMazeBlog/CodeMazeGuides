using IndexersInCSharp;
using System;
using Xunit;

namespace Tests
{
    public class SentenceUnitTest
    {
        [Fact]
        public void WhenCreateInstanceFromSetanceWithNullArg_ThenFailsWithAArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Sentence(null)
            );
        }

        [Fact]
        public void WhenCreateInstanceFromSetanceWithAValidString_ThenSuccess()
        {
            var sentence = new Sentence("Hello from Code Maze");
            var actual1 = sentence[0];
            var actual2 = sentence[1];
            var actual3 = sentence[2];
            var actual4 = sentence[3];

            var expected1 = "Hello";
            var expected2 = "from";
            var expected3 = "Code";
            var expected4 = "Maze";

            Assert.Multiple(
                () => Assert.Equal(expected1, actual1),
                () => Assert.Equal(expected2, actual2),
                () => Assert.Equal(expected3, actual3),
                () => Assert.Equal(expected4, actual4)
            );
        }


        [Fact]
        public void WhenGivenIndexOutOfRange_ThenFailsWithAArgumentOutOfRangeException()
        {
            var sentence = new Sentence("Hello from Code Maze");

            Assert.Throws<ArgumentOutOfRangeException>(
                () => sentence[5]
            );
        }

        [Fact]
        public void WhenSetAWordByAValidValue_ThenSuccess()
        {
            var sentence = new Sentence("Hello from Code Maze");
            sentence[0] = "Hey";

            var expected = "Hey";
            
            Assert.Equal(expected, sentence[0]);
        }

        [Fact]
        public void WhenSetAWordOfByANull_ThenFailsWithDoNothing()
        {
            var sentence = new Sentence("Hello from Code Maze");
            sentence[0] = null;

            var expected = "Hello";

            Assert.Equal(expected, sentence[0]);
        }

    }
}