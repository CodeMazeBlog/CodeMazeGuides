using ActionFuncDelegatesInCsharp.Logger;

namespace ActionFuncDelegatesInCsharp
{
    public class DelegateUsage
    {
        public delegate int LengthFinder(string message);
        private readonly ILogger _logger;

        public DelegateUsage(ILogger logger)
        {
            _logger = logger;
        }

        public int DelegateAsCallbackParameterUsage(string message)
        {
            LengthFinder handler = FindStringLength;

            return CallDelegateFunc(message, handler);
        }

        private int CallDelegateFunc(string input, LengthFinder callback)
        {
            _logger.Log("CallDelegateFunc called with parameter :{0}", input);

            return callback(input);
        }

        private int FindStringLength(string message)
        {
            _logger.Log("Delegate LengthFinder invoked with message :{0}", message);
            _logger.Log("message length is :{0}", message.Length);

            return message.Length;
        }

        public delegate double CarAccelerateDelegate(int gear);
        public event CarAccelerateDelegate carAccelerateEvent;

        public void DelegateWithEventUsage(int gear)
        {
            carAccelerateEvent += new CarAccelerateDelegate(onBusAccelerate);
            carAccelerateEvent += new CarAccelerateDelegate(onTruckAccelerate);

            carAccelerateEvent(gear);
        }

        public double onBusAccelerate(int gear)
        {
            var result = (5.2 + gear) * gear * gear;
            _logger.Log("Bus accelerated on gear {0} with {1} km/h", gear, result);

            return result;
        }

        public double onTruckAccelerate(int gear)
        {
            var result = (3.1 + gear) * gear * gear;
            _logger.Log("Truck accelerated on gear {0} with {1} km/h", gear, result);

            return result;
        }
    }
}