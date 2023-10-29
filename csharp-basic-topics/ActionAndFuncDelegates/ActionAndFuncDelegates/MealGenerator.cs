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
    public void GenerateAndDisplayMeal(List<string> ingredients)
    {
        var meal = generateMeal(ingredients);
        displayMeal(meal);
    }
}
