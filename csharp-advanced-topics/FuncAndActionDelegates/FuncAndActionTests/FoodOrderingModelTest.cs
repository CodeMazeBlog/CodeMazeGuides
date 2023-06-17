using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using LibraryDemo;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace FuncAndActionTests
{
    public class FoodOrderingModelTest
    {
        List<OrderItemModel> OrderItemList = new();
        FoodOrderingModel Order = new();

        public FoodOrderingModelTest()
        {
            OrderItemList.Add(new OrderItemModel { Name = "Mushroom Soap", Price = 15.5M });
            OrderItemList.Add(new OrderItemModel { Name = "Chiken Salad", Price = 20.3M });
        }

        [Fact]
        public void WhenGetSumPrice_ThenReturnSumPrice()
        {
            decimal expected = 35.8M;

            decimal actual=Order.GetSumPrice(OrderItemList);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenGetSumPrice_ThenReturnNullException()
        {
            Assert.Throws<ArgumentNullException>("OrderItemList", ()=>Order.GetSumPrice(null)) ;
        }
    }
}
