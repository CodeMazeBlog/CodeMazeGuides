using HowToRegisterMultipleInstancesOfInterface.Exceptions;
using HowToRegisterMultipleInstancesOfInterface.Interfaces;
using HowToRegisterMultipleInstancesOfInterface.Requests;

namespace HowToRegisterMultipleInstancesOfInterface.Services;

public class FulfillmentService : IFulfilmentService
{
    public Task Fulfill(FulfilmentRequest request)
    {
        switch (request.DeliveryMethod)
        {
            case DeliveryMethods.Postal:
                break;
            case DeliveryMethods.Barcode:
                break;
            case DeliveryMethods.Smartcard:
                break;
            default:
                throw new UnknownDeliveryMethodException();
        }
    }
}