using System.ComponentModel;

namespace Assign_Auto_Property
{
    public class Program
    {
        static void Main(string[] args)
        {
            HondaCars hondaCars = new HondaCars();
            Console.Write("=============Inline initialization==================\n");
            Console.WriteLine($"Car Color: {hondaCars.Color}");
            Console.WriteLine($"Car Cost:  {hondaCars.Cost}");


            ToyotaCars toyotaCars = new ToyotaCars();
            Console.Write("=============Constructor initialization==================\n");
            Console.WriteLine($"Car Color:{toyotaCars.Color}");
            Console.WriteLine($"Car Cost: {toyotaCars.Cost}");

            KiaCars kiaCars = new KiaCars();
            Console.Write("=============Using Property Setter==================\n");
            Console.WriteLine($"Car Color: {kiaCars.Color}");
            Console.WriteLine($"Car Cost: {kiaCars.Cost}");


            FordCars fordCars = new FordCars();
            Console.Write("=============Default value attribute==================\n");
            DefaultValueAttribute attribute = (DefaultValueAttribute)TypeDescriptor.GetProperties(fordCars)["Color"].Attributes[typeof(DefaultValueAttribute)];
            string? defaultValue = (string)(attribute.Value);
            Console.WriteLine($"Default Car Color: {defaultValue}");
            Console.WriteLine($"Car Color: {fordCars.Color}");
            Console.ReadLine();
        }
    }

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
    /// <summary>
    /// Class to assign value with Inline initialization
    /// </summary>
    public class HondaCars
    {
        //Inline initialization
        public string Color { get; set; } = "White";
        public decimal Cost { get; set; } = 500000.00m;
    }
    /// <summary>
    /// Class to assign value using Constructor initialization
    /// </summary>
    public class ToyotaCars
    {
        public string Color { get; set; }
        public decimal Cost { get; set; }
        public ToyotaCars() //Constructor for the class
        {
            Color = "Black"; //Constructor initialization
            Cost = 400000.00m; //Constructor initialization
        }
    }
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
                return
                    _cost;
            }
            set
            {
                _cost = value;
            }
        }
    }
}