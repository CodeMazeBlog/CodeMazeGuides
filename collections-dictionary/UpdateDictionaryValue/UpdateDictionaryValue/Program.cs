using UpdateDictionaryValue;

var toppingsDictionary = new ToppingsDictionary();
toppingsDictionary.AddToppings("pepperoni", 4);

try
{
    // Throws when trying to get toppingsDictionary.Toppings["jalepeno"]
    toppingsDictionary.Toppings["jalepeno"] = toppingsDictionary.Toppings["jalepeno"] + 1;
}
catch (Exception e)
{
    Console.WriteLine(e);
}

// This implementation will work
toppingsDictionary.AddToppings("jalepeno", 1);

foreach (var topping in toppingsDictionary.Toppings)
{
    Console.WriteLine($"{topping.Key} = {topping.Value}");
}