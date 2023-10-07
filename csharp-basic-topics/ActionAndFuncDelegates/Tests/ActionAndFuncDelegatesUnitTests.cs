using NUnit.Framework;
using CodeMazeGuides.Delegates;
using static CodeMazeGuides.Delegates.Program;

namespace Tests
{
    public class ActionAndFuncDelegatesUnitTests
    {
        [TestCase("I like to eat", "Cake")]
        public void WhenGivenTwoStrings_ThenInvertStringOrder(string start, string suffix)
        {
            // Generate results to test against

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            ActionStringManipulator(start,suffix);

            var output = stringWriter.ToString();
            var checkString = $"{start} {suffix}";
            var checkStringInverted = $"{suffix} {start}";

            bool contains = output.Contains(checkString) && output.Contains(checkStringInverted);

            // If string from test contains calculated strings assert pass

            Assert.IsTrue(contains);
        }

        [TestCase(12, 40)]
        public void WhenGivenSlices_ThenCalculateMyShare(int slices, int share)
        {
            // Get results from calculating share of cake

            var expMyShare = Math.Round(slices * (share * 0.01), 2);
            
            // If test results are equal to expected, assert true

            Assert.That(expMyShare, Is.EqualTo(MyShare(slices, share)));
        }

        [TestCase(12, 40, 4)]
        public void WhenGivenSlicesAndShareAndGuests_ThenCalculateGuestCakeAllocation(int slices, int share, int guests)
        {
            // Calculate cake allocation

            var expMyShare = Math.Round(slices * (share * 0.01), 2);
            var expGuestShare = Math.Round((slices - expMyShare) / guests, 2);         

            // If guest allocation equal to expected, assert pass

            Assert.That(expGuestShare, Is.EqualTo(GuestShare(slices - MyShare(slices, share),guests)));
        }
    }
}