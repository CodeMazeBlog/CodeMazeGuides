namespace HowToCloneAList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var toppings = new List<string>
            {
                "Mozzarella",
                "Olive oil",
                "Basil"
            };

            var toppingsCopiedWithConstructor = new List<string>(toppings);

            var toppingsCopiedWithCopyTo = new string[toppings.Count];
            toppings.CopyTo(toppingsCopiedWithCopyTo);

            var toppingsCopiedWithAddRange = new List<string>();
            toppingsCopiedWithAddRange.AddRange(toppings);

            var toppingsCopiedWithToList = toppings.ToList();

            var toppingsCopiedWithConvertAll = toppings
                .ConvertAll(new Converter<string, string>(x => x));

            var customToppingsList = new ToppingsList<string>
            {
                "Mozzarella",
                "Olive oil",
                "Basil"                
            };

            var toppingsCopiedWithICloneable = (ToppingsList<string>)customToppingsList.Clone();

            Console.WriteLine("Original list: " + string.Join(", ", toppings));
            Console.WriteLine("Copied with Constructor: " + string.Join(", ", toppingsCopiedWithConstructor));
            Console.WriteLine("Copied with CopyTo: " + string.Join(", ", toppingsCopiedWithCopyTo));
            Console.WriteLine("Copied with AddRange: " + string.Join(", ", toppingsCopiedWithAddRange));
            Console.WriteLine("Copied with ToList: " + string.Join(", ", toppingsCopiedWithToList));
            Console.WriteLine("Copied with ConverAll: " + string.Join(", ", toppingsCopiedWithConvertAll));
            Console.WriteLine("Copied with ICloneable: " + string.Join(", ", toppingsCopiedWithICloneable));

            #region Reference Types
            //var pizzas = new List<Pizza>
            //{
            //    new Pizza
            //    {
            //        Name= "Margherita",
            //        Toppings = new List<string>
            //        {
            //            "Mozzarella",
            //            "Olive oil",
            //            "Basil"
            //        }
            //    },
            //    new Pizza
            //    {
            //        Name= "Diavola",
            //        Toppings = new List<string>
            //        {
            //            "Mozzarella",
            //            "Ventricina",
            //            "Chili peppers"
            //        }
            //    }
            //};

            //foreach(var pizza in pizzas)
            //{
            //    Console.WriteLine(pizza.ToString());
            //}
            #endregion
        }
    }
}