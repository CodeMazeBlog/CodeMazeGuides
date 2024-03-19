using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignAutoProperty
{
    /// <summary>
    /// Class to assign value using property setter
    /// </summary>
    public class KiaCars
    {
        private string _color = "Silver";
        private decimal _cost = 600000.00m;

        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public decimal Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
            }
        }
    }
}
