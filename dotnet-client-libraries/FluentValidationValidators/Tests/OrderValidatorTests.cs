using ClassLibrary1;
using FluentValidation;

namespace Tests;

[TestClass]
public class OrderValidatorTests
{
    private readonly OrderValidator _validator = new();

    private static Order ValidOrder() => new()
    {
        CustomerName = "Joe Bloggsworth",
        CustomerEmail = "joebloggs@someemaildomain.com",
        Price = 100,
        OrderStatus = OrderStatus.Accepted,
        Products = [new Product { Name = "Keyboard" }]
    };

    [TestMethod]
    public void WhenOrderIsValid_ThenValidationSucceeds()
    {
        var result = _validator.Validate(ValidOrder());

        Assert.IsTrue(result.IsValid);
        Assert.AreEqual(0, result.Errors.Count);
    }

    [TestMethod]
    public void WhenCustomerNameHasNoSpace_ThenFullNameValidatorReportsItsOwnMessage()
    {
        var order = ValidOrder();
        order.CustomerName = "JoeBloggsworth";

        var result = _validator.Validate(order);

        Assert.IsFalse(result.IsValid);
        var failure = result.Errors.Single(e => e.PropertyName == nameof(Order.CustomerName));
        Assert.AreEqual("Name must contain a single space and be at least 10 characters long", failure.ErrorMessage);
    }

    [TestMethod]
    public void WhenCascadeModeIsStop_ThenOnlyTheFirstEmailFailureIsReported()
    {
        var order = ValidOrder();
        order.CustomerEmail = "AAAAA";

        var result = _validator.Validate(order);

        var emailFailures = result.Errors.Where(e => e.PropertyName == nameof(Order.CustomerEmail)).ToList();
        Assert.AreEqual(1, emailFailures.Count);
        StringAssert.Contains(emailFailures[0].ErrorMessage, "valid email address");
    }

    [TestMethod]
    public void WhenOrderStatusIsNotADeclaredMember_ThenIsInEnumRejectsIt()
    {
        var order = ValidOrder();
        order.OrderStatus = (OrderStatus)42;

        var result = _validator.Validate(order);

        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Any(e => e.PropertyName == nameof(Order.OrderStatus)));
    }

    [TestMethod]
    public void WhenOneProductIsInvalid_ThenRuleForEachReportsTheItemIndex()
    {
        var order = ValidOrder();
        order.Products = [new Product { Name = "Keyboard" }, new Product { Name = string.Empty }];

        var result = _validator.Validate(order);

        Assert.IsFalse(result.IsValid);
        Assert.AreEqual("Products[1].Name", result.Errors.Single().PropertyName);
    }

    [TestMethod]
    public void WhenValidationFails_ThenValidateAndThrowThrowsValidationException()
    {
        var order = ValidOrder();
        order.Price = 5000;

        Assert.ThrowsExactly<ValidationException>(() => _validator.ValidateAndThrow(order));
    }
}
