namespace PizzaStore.Domain.Exceptions;

public sealed class MaximumPizzasPerOrderException : BadRequestException
{
    public MaximumPizzasPerOrderException() : base("Too many pizzas in this order")
    {        
    }
}