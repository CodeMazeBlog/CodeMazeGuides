using ActionAndFuncDemo.BusinessModels;
using ActionAndFuncDemo.BusinessProcesses;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class UnitTests
{
    private static readonly List<Item> items = new();
    [Test]
    public void WhenCreateCart_ThenCalculateProperDiscount()
    {
        var cartItems = GetCartItems();
        var checkoutProcess = new CheckoutProcess();
        checkoutProcess.CreateCart(cartItems, DiscountProcesses.CalculateDiscount);
        var discount = GetDiscountOnTotalBill(GetTotalBill());
        var priceAfterDiscount = GetTotalBill() - discount;
        checkoutProcess.GetCartValues(cart =>
        {
            Assert.AreEqual(cart.GrandTotal, priceAfterDiscount);
        });
    }
    public static List<Item> GetItems()
    {
        if (!(items?.Any() ?? false))
        {
            items.Add(new Item(1, "Apples", 4.3m, 20m));
            items.Add(new Item(2, "Mangoes", 0.53m, 200m));
            items.Add(new Item(3, "Pineapple", 2.28m, 150m));
        }
        return items;
    }
    public static decimal GetDiscountOnTotalBill(decimal totalBill)
    {
        decimal discount = 0.0m;
        if (totalBill >= 25)
        {
            discount = totalBill * 0.3m;
        }
        else if (totalBill >= 20)
        {
            discount = totalBill * 0.2m;
        }
        else if (totalBill >= 15)
        {
            discount = totalBill * 0.1m;
        }
        else if (totalBill >= 10)
        {
            discount = totalBill * 0.05m;
        }
        return decimal.Round(discount, 2);
    }
    public static List<CartItem> GetCartItems()
    {
        List<CartItem> cartItems = new();
        var item = GetItems().FirstOrDefault(x => x.Id == 1);
        if (item is not null)
        {
            cartItems.Add(new CartItem(item.Id, item.Name, item.Price, 3)); //3x4.3=12.9
        }
        item = items.FirstOrDefault(x => x.Id == 2);
        if (item is not null)
        {
            cartItems.Add(new CartItem(item.Id, item.Name, item.Price, 6)); //6x0.53=3.18
        }
        item = items.FirstOrDefault(x => x.Id == 3);
        if (item is not null)
        {
            cartItems.Add(new CartItem(item.Id, item.Name, item.Price, 2)); //2x2.28=4.56
        }
        return cartItems;
    }
    public static decimal GetTotalBill()
    {
        var cartItems = GetCartItems();
        var totalBill = cartItems.Sum(x => x.PurchasedQuantity * x.PurchasedPrice); //20.64
        return totalBill;
    }
}
