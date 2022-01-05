namespace ActionAndFuncDelegateInCSharp.Model
{
    public class Laptop
    {
        public decimal Price { get; set; }

        public void SwitchOn() { Console.WriteLine("Switch On .."); }

        public void SwitchOff() { Console.WriteLine("Switching Off .."); }
    }
}