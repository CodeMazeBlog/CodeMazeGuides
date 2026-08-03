using IndexersInCSharp;
using System;
using Xunit;

namespace Tests
{
    public class TicTacToeUnitTest
    {
        [Fact]
        public void WhenGivenRowOrColOutOfRange_ThenFailsWithAArgumentOutOfRangeException()
        {
            var ticTacToe = new TicTacToe();

            Assert.Throws<ArgumentOutOfRangeException>(
                () => ticTacToe[3,3]
            );
        }

        [Fact]
        public void WhenGivenACellNumberOutOfRange_ThenFailsWithAArgumentOutOfRangeException()
        {
            var ticTacToe = new TicTacToe();

            Assert.Throws<ArgumentOutOfRangeException>(
                () => ticTacToe[10]
            );
        }

        [Fact]
        public void WhenFillACellByAValidRowAndCol_ThenSuccess()
        {
            var ticTacToe = new TicTacToe();
            ticTacToe[0, 0] = CellStatus.X;

            var expected = CellStatus.X;

            Assert.Equal(expected, ticTacToe[0, 0]);
        }

        [Fact]
        public void WhenFillACellThatAlreaadyFilled_ThenFailsWithDoNothing()
        {
            var ticTacToe = new TicTacToe();
            ticTacToe[0, 0] = CellStatus.X;
            ticTacToe[0, 0] = CellStatus.O;

            var expected = CellStatus.X;

            Assert.Equal(expected, ticTacToe[0, 0]);
        }

        [Fact]
        public void WhenFillACellByAValidNumber_ThenSuccess()
        {
            var ticTacToe = new TicTacToe();
            ticTacToe[5] = CellStatus.O;

            var expected = CellStatus.O;

            Assert.Equal(expected, ticTacToe[5]);
        }
    }
}
