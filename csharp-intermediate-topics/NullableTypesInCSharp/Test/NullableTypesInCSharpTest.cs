using NullableTypesInCSharp;
using System;
using Xunit;

namespace Test
{
    public class NullableTypesInCSharpTest
    {

        [Fact]
        public void GivenSampleStart_WhenExecuted_ReturnsVoid()
        {
            Action result = Sample.Start;
            result();
            Assert.IsType<Action>(result);
        }

        [Fact]
        public void GivenSampleCompare_WhenExecuted_ReturnsATuple()
        {
            var (comparisonOne, comparisonTwo, comparisonThree, comparisonFour) = Sample.Compare();
            Assert.IsType<int>(comparisonOne); 
            Assert.Equal(-1, comparisonOne);
            
            Assert.IsType<int>(comparisonTwo); 
            Assert.Equal(1, comparisonTwo);
            
            Assert.IsType<int>(comparisonThree); 
            Assert.Equal(0, comparisonThree);
            
            Assert.IsType<int>(comparisonFour); 
            Assert.Equal(0, comparisonFour);
        }

        [Fact]
        public void GivenUsingComparisonOperatorsRun_WhenExecuted_ReturnsTrue()
        {
            var result = UsingComparisonOperators.Run();
            Assert.IsType<bool>(result);
            Assert.True(result);
        }

        [Fact]
        public void GivenUsingNullCoalescingOperatorRUn_WhenExecuted_ReturnsANullableInt()
        {
            var result = UsingNullCoalescingOperator.Run();
            Assert.IsType<int>(result);
            Assert.Equal(13, result);
        }

        [Fact]
        public void GivenUsingEqualityOperatorsRun_WhenExecuted_ReturnsATuple()
        {
            var (areEqual, areEqualTwo, areEqualThree) = UsingEqualityOperators.Run();
            Assert.IsType<bool>(areEqual);
            Assert.True(areEqual);

            Assert.IsType<bool>(areEqualTwo);
            Assert.False(areEqualTwo);

            Assert.IsType<bool>(areEqualThree);
            Assert.False(areEqualThree);
        }
        
        [Fact]
        public void GivenUsingInEqualityOperatorsRun_WhenExecuted_ReturnsATuple()
        {
            var (areEqual, areEqualTwo, areEqualThree) = UsingInEqualityOperators.Run();
            Assert.IsType<bool>(areEqual);
            Assert.False(areEqual);

            Assert.IsType<bool>(areEqualTwo);
            Assert.True(areEqualTwo);

            Assert.IsType<bool>(areEqualThree);
            Assert.True(areEqualThree);
        }
    }    
}