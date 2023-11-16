using HowToRegisterMultipleInstancesOfInterface.Requests;
using HowToRegisterMultipleInstancesOfInterface.Services;

namespace HowToRegisterMultipleInstancesOfInterface.Interfaces;

public interface IFulfilmentService
{
    Task Fulfill(FulfilmentRequest request);
}