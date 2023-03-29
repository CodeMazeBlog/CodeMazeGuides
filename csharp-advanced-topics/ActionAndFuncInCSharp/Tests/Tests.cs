using ActionAndFuncInCSharp;

namespace Tests;

public class Tests
{


    [Fact]
    public void whenTotalIsSent_ReferenceFuncDelegateMethodCalculatesAndReturnsTaxValue()
    {
        Func<double, double, decimal> CalculateTaxFunc = Program.CalculateTax;
        var total = 149.47;
        decimal expected = Convert.ToDecimal(149.47 * 0.10);

        var tax = CalculateTaxFunc(total, 0.10);

        Assert.Equal(expected, tax);
    }

    [Fact]
    public void whenShoppingCartAndTaxIsSent_ReferenceActionDelegateMethodPrintsReceiptToConsole()
    {
        Action<List<CartItem>, decimal> ReceiptPrintAction = Program.PrintReceipt;

        var cart = new List<CartItem>
        {
            new CartItem { Name = "Milk", Price = 12, Quantity = 2 },
            new CartItem { Name = "Eggs", Price = 1.25, Quantity = 10 },
            new CartItem { Name = "Flour", Price = 8, Quantity = 1 },
            new CartItem { Name = "Cocoa", Price = 24.99, Quantity = 3 },
            new CartItem { Name = "Butter", Price = 15, Quantity = 2 }
        };

        var tax = Convert.ToDecimal(cart.Sum(x => x.Total) * 0.10);

        ReceiptPrintAction(cart, tax);

        // Assert
        // Assert that the output contains the expected strings
    }

    [Fact]
    public void whenRequestedForShoppingCart_ListOfCartItemsAreReturned()
    {
        var expected = new List<CartItem>
        {
            new CartItem { Name = "Milk", Price = 12, Quantity = 2 },
            new CartItem { Name = "Eggs", Price = 1.25, Quantity = 10 },
            new CartItem { Name = "Flour", Price = 8, Quantity = 1 },
            new CartItem { Name = "Cocoa", Price = 24.99, Quantity = 3 },
            new CartItem { Name = "Butter", Price = 15, Quantity = 2 }
        };

        var cart = Program.GetShoppingCart();

        Assert.Equal(expected, cart);
    }
}