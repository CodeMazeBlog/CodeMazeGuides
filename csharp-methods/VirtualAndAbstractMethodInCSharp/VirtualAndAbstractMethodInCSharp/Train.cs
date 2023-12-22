using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualAndAbstractMethodInCSharp
{
    // Class representing a train
    internal class Train : TransportMode
    {
        private double fixedJourneyTime;

        public Train(double fixedJourneyTime)
        {
            this.fixedJourneyTime = fixedJourneyTime;
        }

        public override double GetTravelTime(double distance)
        {
            return fixedJourneyTime; // Assume fixed travel time regardless of distance
        }

        // Override base fare calculation specific to trains (apply discounts for longer distances)
        public override double CalculateBaseFare(double distance)
        {
            double baseFare = base.CalculateBaseFare(distance);
            
            if (distance > 500)
            {
                baseFare *= 0.9; // Apply 10% discount for longer trips                
            }
            return baseFare;
        }
    }
}
