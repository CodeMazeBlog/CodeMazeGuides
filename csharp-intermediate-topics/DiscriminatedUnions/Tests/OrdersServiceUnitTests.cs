using API;

namespace Tests;

public class OrdersServiceUnitTests
{
    private readonly OrdersService _ordersService = new();    

    [Fact]
    public void GivenAProductIdThatDoesntExist_WhenCallingPlaceOrder_ThenPlaceOrderErrorDoesntExistIsReturned()
    {
        var order = new Order(100, 1);

        var result = _ordersService.PlaceOrder(order);

        Assert.True(result.IsT1);
        Assert.Equal(PlaceOrderError.DoesntExist, result.AsT1);
    }

    [Fact]
    public void GivenAnOrderWithAPaymentLessThanCost_WhenCallingPlaceOrder_ThenPlaceOrderErrorInsufficientFundsIsReturned()
    {
        var order = new Order(1, 10);

        var result = _ordersService.PlaceOrder(order);

        Assert.True(result.IsT1);
        Assert.Equal(PlaceOrderError.InsufficientFunds, result.AsT1);
    }

    [Fact]
    public void GivenAValidOrder_WhenCallingPlaceOrder_ThenAReceiptIsReturned()
    {
        var order = new Order(1, 200);

        var result = _ordersService.PlaceOrder(order);

        Assert.True(result.IsT0);
        Assert.True(result.AsT0.ReceiptId > 0);
    }
}