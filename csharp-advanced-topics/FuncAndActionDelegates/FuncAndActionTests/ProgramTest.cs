using LibraryDemo;
using Xunit;

namespace FuncAndActionTests
{
    public class ProgramTest
    {
        static List<OrderItemModel> OrderItemList = new();
        FoodOrderingModel Order = new();

        public ProgramTest()
        {
            OrderItemList.Add(new OrderItemModel { Name = "Mushroom Soap", Price = 15.5M });
            OrderItemList.Add(new OrderItemModel { Name = "Chiken Salad", Price = 20.3M });
        }

        [Fact]
        public static void WhenDiscountCalculate_ThenReturnArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(()=>Program.DiscountCalculate(OrderItemList,0));
        }

        [Fact]
        public static void WhenDiscountCalculate_ThenReturnBillCostWithDiscount()
        {
            decimal expected = 35.8M;

            decimal actual = Program.DiscountCalculate(OrderItemList,expected);

            Assert.Equal(expected, actual);
        }

    }
}
