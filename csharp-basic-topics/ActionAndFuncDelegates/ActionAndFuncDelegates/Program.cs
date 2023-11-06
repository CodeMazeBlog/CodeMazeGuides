namespace ActionAndFuncDelegates;

class Program 
{
    static void Main(string[] args)
    {
        var mealGenerator = new MealGenerator(MealGeneratorService.CookDelicousMeal, MealGeneratorService.ServeDeliciousMeal);
        var selectedIngredients = new List<string> { "Chicken breast", "Rice", "Olive oil" };

        mealGenerator.GenerateAndDisplayMeal(selectedIngredients);
    }   
}