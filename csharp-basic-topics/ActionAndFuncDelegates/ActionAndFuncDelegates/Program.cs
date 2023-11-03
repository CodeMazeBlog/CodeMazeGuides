namespace ActionAndFuncDelegates;

class Program 
{
    static void Main(string[] args)
    {
        var mealGenerator = new MealGenerator(CookDelicousMeal, ServeDeliciousMeal);

        List<string> selectedIngredients = new List<string> { "Chicken breast", "Rice", "Olive oil" };
        mealGenerator.GenerateAndDisplayMeal(selectedIngredients);

    }
    static string CookDelicousMeal(List<string> ingredients)
        {
             string ingredientList = string.Join("\n", ingredients);
            string meal = $"Your meal includes:\n{ingredientList}\n\nEnjoy your delicious meal!";
            return meal;
        }
    static void ServeDeliciousMeal(string meal)
    {
         Console.WriteLine("Meal Recipe:\n");
         Console.WriteLine(meal);
    }
        
}