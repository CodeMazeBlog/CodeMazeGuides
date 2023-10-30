using ActionAndFuncDelegatesInCsharp;

var shirtStore = new ShirtStore();

var customer = new Customer("Mike", 22, "L");

Console.WriteLine("Welcome to the clothes store! We offer a wide range of shirts: \n");

foreach (var availableShirt in shirtStore.AvailableShirts) 
{
    Console.WriteLine(availableShirt.Brand);
}

Console.WriteLine("Here are shirts that fit Mike: \n");

IEnumerable<Shirt> shirtsThatFit = shirtStore.GetShirtsThatFit(
    shirt => shirt.Size == "L" && shirt.Brand.Contains("CodeMaze"));

foreach (var shirt in shirtsThatFit)
{
    Console.WriteLine($"{shirt.Brand} - Size {shirt.Size}");
}

// Mike wants to buy the CodeMaze Shirt

var shirtToBuy = shirtsThatFit.Single(s => s.Brand == "CodeMaze Shirt");

shirtStore.BuyShirt(shirtToBuy, (shirt) => Console.WriteLine($"{shirt.Brand} has been bought!\n"));

foreach (var availableShirt in shirtStore.AvailableShirts)
{
    Console.WriteLine(availableShirt.Brand);
}
