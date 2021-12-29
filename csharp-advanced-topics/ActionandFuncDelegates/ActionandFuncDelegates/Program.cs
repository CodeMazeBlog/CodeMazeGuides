using System;

namespace ActionandFuncDelegates
{
    // Code samples for article writing
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Solution
    {
        public delegate int CalculateValue(int x, int y);
        CalculateValue calculate = new CalculateValue(PrintSum);
        public static int PrintSum(int x, int y)
        {
            return x + y;
        }
        public void DoBusinessLogicAndInvokeDelegate(int x, int y, CalculateValue callBack)
        {
            // Do business logic
            // Invoke the delegate
            callBack(x, y);
        }

        public void ValidatePhoeNumberAndSendSMS(string phoneNumber, Action<string> sendSMS)
        {
            if (phoneNumber.Length == 10)
            {
                sendSMS(phoneNumber);
            }
            else
            {
                Console.WriteLine("Phone Number Invalid");
            }
        }

        public void IsVehicleAllowedOrNot(int vehicleNumber, Func<int, bool> validateVehicle)
        {
            if (validateVehicle(vehicleNumber))
            {
                Console.WriteLine("Vehicle allowed on the road");
            }
            else
            {
                Console.WriteLine("Vehicle not allowed on the road");
            }
        }
        public void InvokeMethods()
        {
            ValidatePhoeNumberAndSendSMS("8413039309", x => { Console.WriteLine("SendingSMS"); });
            IsVehicleAllowedOrNot(234, x => { if (x % 2 == 1) return true; return false; });
        }
    }
}
