using System.Collections.Concurrent;
using UpdateDictionaryValue;

var toppingsDictionary = new ToppingsDictionary();
toppingsDictionary.AddToppings("pepperoni", 4);
toppingsDictionary.AddToppings("olive", 3);

PrintToppings(toppingsDictionary);

try
{
    // The indexer-only version of AddToppings reads the value before it writes it
    toppingsDictionary.Toppings["jalapeno"] = toppingsDictionary.Toppings["jalapeno"] + 1;
}
catch (KeyNotFoundException e)
{
    Console.WriteLine($"{e.GetType()}: {e.Message}");
}

toppingsDictionary.AddToppings("jalapeno", 1);

PrintToppings(toppingsDictionary);

var toppings = new ConcurrentDictionary<string, int>();

Console.WriteLine(toppings.AddOrUpdate("pepperoni", 4, (_, currentAmount) => currentAmount + 4));
Console.WriteLine(toppings.AddOrUpdate("pepperoni", 4, (_, currentAmount) => currentAmount + 4));

static void PrintToppings(ToppingsDictionary toppingsDictionary)
{
    foreach (var topping in toppingsDictionary.Toppings)
    {
        Console.WriteLine($"{topping.Key} = {topping.Value}");
    }

    Console.WriteLine();
}
