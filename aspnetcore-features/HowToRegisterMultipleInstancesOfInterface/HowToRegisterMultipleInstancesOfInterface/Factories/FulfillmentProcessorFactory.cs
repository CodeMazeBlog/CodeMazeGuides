using HowToRegisterMultipleInstancesOfInterface.Interfaces;

namespace HowToRegisterMultipleInstancesOfInterface.Factories;

public class FulfillmentProcessorFactory : IFulfillmentProcessorFactory
{
    private readonly IEnumerable<IFulfillTickets> _fulfilmentProcessors;

    public FulfillmentProcessorFactory(ServiceResolver serviceAccessor)
    {
        _fulfilmentProcessors = fulfilmentProcessors;
    }
    
    public IFulfillTickets GetFulfillmentProcessor(DeliveryMethods deliveryMethod)
    {
        switch (deliveryMethod)
        {
            case DeliveryMethods.Barcode:
                return _
        }
    }
}