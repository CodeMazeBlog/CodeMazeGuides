using ActionAndFuncDelegateInCSharp.Model;

namespace ActionAndFuncDelegateInCSharp.Examples
{
    public class ActionExamples
    {
        public Action<Laptop> LaptopPriceUpdater { get; set; }

        public ActionExamples()
        {
            LaptopPriceUpdater = laptop => laptop.Price = 56;
        }
    }
}