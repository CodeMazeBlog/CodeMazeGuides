using ActionAndFuncDelegatesInCsharp;

namespace ActionAndFuncDelegatesInCsharpTests
{
    public class ActionAndFuncDelegatesTests
    {
        [Fact]
        public void WhenGetShirtsThatFit_FuncShouldReturnSingleShirt()
        {
            var shirtStore = new ShirtStore();

            var shirts = shirtStore.GetShirtsThatFit(
                shirt => shirt.Size == "L" && shirt.Brand.Contains("CodeMaze"));

            Assert.Single(shirts);
        }

        [Fact]
        public void WhenGetShirtsThatFit_FuncShouldReturnEmptyCollection()
        {
            var shirtStore = new ShirtStore();

            var shirts = shirtStore.GetShirtsThatFit(
                shirt => shirt.Size == "XXL" && shirt.Brand.Contains("CodeMaze"));

            Assert.Empty(shirts);
        }

        [Fact]
        public void WhenGetShirtsThatFit_SizeShouldReturnSingleShirt()
        {
            var shirtStore = new ShirtStore();

            var shirts = shirtStore.GetShirtsThatFit("L");

            Assert.True(shirts.Count() > 1);
        }

        [Fact]
        public void WhenBuyShirt_ShouldWriteToConsole()
        {
            var currConsoleOut = Console.Out;

            var shirtStore = new ShirtStore();

            shirtStore.BuyShirt(
                shirtStore.AvailableShirts.First(), 
                (shirt) => Console.WriteLine($"{shirt.Brand} has been bought")
            );

            Assert.Equal(currConsoleOut, Console.Out);
        }
    }
}