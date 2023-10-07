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
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Program.ActionStringManipulator(start,suffix);

            var output = stringWriter.ToString();

            string equalTo = $"The string reads: {start} {suffix}\r\nThe string order inverted reads: {suffix} {start}\r\n";


            Assert.That( output, Is.EqualTo(equalTo));
        }

        [TestCase(12, 40)]
        public void WhenGivenSlices_ThenCalculateMyShare(int slices, int share)
        {
            var expMyShare = Math.Round(slices * (share * 0.01), 2);

            Func<int, int, double> TestMyShare = Program.Cake.CalculateShare;
            

            Assert.That(expMyShare, Is.EqualTo(TestMyShare(slices, share)));
        }

        [TestCase(12, 40, 4)]
        public void WhenGivenSlicesAndShareAndGuests_ThenCalculateGuestCakeAllocation(int slices, int share, int guests)
        {
            var expMyShare = Math.Round(slices * (share * 0.01), 2);
            var expGuestShare = Math.Round((slices - expMyShare) / guests, 2);         

            Assert.That(expGuestShare, Is.EqualTo(Program.GuestShare(slices - Program.MyShare(slices, share),guests)));
        }
    }
}