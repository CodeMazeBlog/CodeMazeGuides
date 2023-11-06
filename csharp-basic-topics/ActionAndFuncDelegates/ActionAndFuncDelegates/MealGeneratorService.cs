namespace ActionAndFuncDelegates;

public static class MealGeneratorService
{
    public static string CookDelicousMeal(List<string> ingredients)
    {
        var ingredientList = string.Join("\n", ingredients);
        return $"Your meal includes:\n{ingredientList}\n\nEnjoy your delicious meal!";
    }
    
    public static void ServeDeliciousMeal(string meal)
    {
        Console.WriteLine("Meal Recipe:\n");
        Console.WriteLine(meal);
    }
}
