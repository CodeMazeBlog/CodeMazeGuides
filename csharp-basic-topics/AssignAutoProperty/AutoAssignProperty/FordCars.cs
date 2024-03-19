using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAssignProperty
{
    /// <summary>
    /// Class to set initial value with DefaultValue attribute
    /// </summary>
    public class FordCars
    {
        private string? _color = "Red";

        [DefaultValue("Blue")] // Set default value using DefaultValueAttribute
        public string? Color
        {
            get { return _color; }
            set { _color = value; }
        }
    }
}
