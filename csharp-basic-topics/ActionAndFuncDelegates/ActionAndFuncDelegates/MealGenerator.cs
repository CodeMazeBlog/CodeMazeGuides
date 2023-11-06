namespace ActionAndFuncDelegates;

public class MealGenerator
{
    private Func<List<string>, string> generateMeal;
    private Action<string> displayMeal;
    public MealGenerator(Func<List<string>, string> mealGenerator, Action<string> mealDisplay)
    {
        generateMeal = mealGenerator;
        displayMeal = mealDisplay;
    }
    
    public string GenerateAndDisplayMeal(List<string> ingredients)
    {
        var meal = generateMeal(ingredients);
        displayMeal(meal);
        return "order completed succesfully";
    }
}
