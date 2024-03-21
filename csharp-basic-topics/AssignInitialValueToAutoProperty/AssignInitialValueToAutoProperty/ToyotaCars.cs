using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignInitialValueToAutoProperty;

/// <summay>
/// Class to assign value using Constructor initialization
/// </summary>
public class ToyotaCars
{
    public ToyotaCars()
    {
        Color = "Black";
        Cost = 400000.00m;
    }

    public string Color { get; set; }
    public decimal Cost { get; set; }
}
