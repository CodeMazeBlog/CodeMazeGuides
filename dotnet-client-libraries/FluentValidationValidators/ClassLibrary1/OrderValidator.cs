using FluentValidation;

namespace ClassLibrary1
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(model => model.CustomerName).FullName();
            RuleFor(model => model.CustomerEmail).Cascade(CascadeMode.Stop).EmailAddress().MinimumLength(20);
            RuleFor(model => model.Price).InclusiveBetween(1, 1000);
            RuleFor(model => model.OrderStatus).IsInEnum();
            RuleForEach(model => model.Products).SetValidator(new ProductValidator());
        }
    }
}
