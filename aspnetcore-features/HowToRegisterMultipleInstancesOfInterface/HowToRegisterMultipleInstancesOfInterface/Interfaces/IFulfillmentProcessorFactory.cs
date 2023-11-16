namespace HowToRegisterMultipleInstancesOfInterface.Interfaces;

public interface IFulfillmentProcessorFactory
{
    IFulfillTickets GetFulfillmentProcessor(DeliveryMethods deliveryMethod);
}