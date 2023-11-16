using HowToRegisterMultipleInstancesOfInterface.Interfaces;

namespace HowToRegisterMultipleInstancesOfInterface.Requests;

public class FulfilmentRequest
{
    public string RequestId { get; set; }
    public DeliveryMethods DeliveryMethod { get; set; }
}