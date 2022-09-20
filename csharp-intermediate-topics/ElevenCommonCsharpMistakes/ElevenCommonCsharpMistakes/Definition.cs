using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenCommonCsharpMistakes
{
    public class Definitions
    {
    }
    public enum Taste
    {
        Sugary,
        Bitter,
        Sour
    }

    public class Drink
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        public string Taste { get; set; }

        public void Break()
        {
            Console.WriteLine("Broken into pieces");
        }

        public void Evaporate()
        {
            Console.WriteLine("Eveporating into thin air");
        }
    }

    public class Bottle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public void Break()
        {
            Console.WriteLine("Broken into pieces");
        }
    }

    public class Wine
    {
        public string Color { get; set; }
        public string Taste { get; set; }
        public void Evaporate()
        {
            Console.WriteLine("Eveporating into thin air");
        }
    }

    public class WineBottle
    {
        public Wine Wine { get; set; }
        public Bottle Bottle { get; set; }
    }
}
