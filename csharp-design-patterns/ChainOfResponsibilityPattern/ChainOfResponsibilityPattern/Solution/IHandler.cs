namespace ChainOfResponsibilityPattern.Solution;

public interface IHandler
{
    IHandler SetNext(IHandler nextHandler);

    RentalResponse Handle(RentalRequest request);
}