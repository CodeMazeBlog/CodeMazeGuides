using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegatesInCsharp
{
    public class DelegateUsage
    {
        //---------------------A SAMPLE OF HOW TO CREATE AND USE A DELEGATE ------------------------------

        //We define a delegate named LengthFinder which pointer to function getting input parameter message and return an int value.
        public delegate int LengthFinder(string message);

        public int SampleLengthFinder(string message)
        {
            //set reference of method to our delegate
            LengthFinder handler = FindStringLength;

            //Pass delegate as a func parameter
            return CallDelegateFunc(message, handler);
        }

        /// <summary>
        /// CallDelegateFunc get a delegate type input and enable to call the reference method that delegate points
        /// </summary>
        /// <param name="input">parameter which we want to find length</param>
        /// <param name="callback">Our delegate as function parameter</param>
        private static int CallDelegateFunc(string input, LengthFinder callback)
        {
            //Invoke the method the delegate referenced
            return callback(input);
        }

        private int FindStringLength(string message)
        {
            Helper.Log("Delegate LengthFinder invoked with message :{0}", message);
            Helper.Log("message length is :{0}", message.Length);
            return message.Length;
        }

        //---------------------USE DELEGATES WITH EVENTS ------------------------------

        //CarAccelerateDelegate enable us to call functions with signature of input parameter gear and returning double value
        public delegate double CarAccelerateDelegate(int gear);

        //We define an event named carAccelerateEvent and type of CarAccelerateDelegate
        public event CarAccelerateDelegate carAccelerateEvent;

        public void TestDelegateWithEvent()
        {
            //Attaching callback methods
            carAccelerateEvent += new CarAccelerateDelegate(onBusAccelerate);
            carAccelerateEvent += new CarAccelerateDelegate(onTruckAccelerate);

            //Invoke event with gear parameter of 2
            carAccelerateEvent(2);

            //Invoke event with gear parameter of 5
            carAccelerateEvent(5);
        }

        public double onBusAccelerate(int gear)
        {
            var result = (5.2 + gear) * gear * gear;
            Helper.Log("Bus accelerated on gear {0} with {1} km/h", gear, result);
            return result;
        }

        public double onTruckAccelerate(int gear)
        {
            var result = (3.1 + gear) * gear * gear;
            Helper.Log("Truck accelerated on gear {0} with {1} km/h", gear, result);
            return result;
        }

    }
}
