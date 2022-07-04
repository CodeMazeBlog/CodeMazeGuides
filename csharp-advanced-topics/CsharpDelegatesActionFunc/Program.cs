using System;

namespace CsharpDelegatesActionFunc
{
    /// Sample example of Multicast delegate 
    class Program
    {
        // Declare a delegate 
        delegate void CalculateInterestRate(double time, double rate);
        static void Main(string[] args)
        {
            double totalInterest;
            //Assign method to multi delegate by passing first method name 
            CalculateInterestRate delegateTotalInterest = new CalculateInterestRate(getTotalInterestByHours);
            //Assign method to multi delegate by passing second method name 
            delegateTotalInterest += getTotalInterestByMinutes;
            //Invoke the delegate to fire the two methods
            delegateTotalInterest.Invoke(8, 10);
            Console.ReadKey();
        }
        //Creating methods which will be assigned to delegate object 
        /// <summary> 
        /// Gets the total interest by hours. 
        /// </summary> 
        /// <param name="time" />The Time in hours. 
        /// <param name="rate" />The Rate. 
        /// <returns>Total Interest 
        static void getTotalInterestByHours(double time, double rate)
        {
            Console.WriteLine("Total Interest of {0} rate in {1} hours is {2}", rate, time, (time * rate) / 100);
        }
        /// <summary> 
        /// Gets the total interest by minutes. 
        /// </summary> 
        /// <param name="time" />The Time in minutes. 
        /// <param name="rate" />The Rate. 
        /// <returns>Total Interest 
        static void getTotalInterestByMinutes(double time, double rate)
        {
            Console.WriteLine("Total Interest of {0} rate in {1} minutes is {2}", rate, time, (time * rate) / 100);
        }
    }
}
