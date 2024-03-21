using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignInitialValueToAutoProperty
{
    /// <summary>
    /// Class to assign value using Constructor initialization
    /// </summary>
    public class ToyotaCars
    {
        public ToyotaCars() //Constructor for the class
        {
            Color = "Black"; //Constructor initialization
            Cost = 400000.00m; //Constructor initialization
        }

        public string Color { get; set; }
        public decimal Cost { get; set; }
    }
}
