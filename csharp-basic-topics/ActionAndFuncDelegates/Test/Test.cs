using ActionAndFuncDelegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test;

[TestClass]
public class Test
{
    private readonly MealGenerator _mealGenerator;

    public Test () 
    {
        _mealGenerator = new MealGenerator(CookDelicousMeal, ServeDeliciousMeal);
    }
    [TestMethod]
    public void GenerateMeal_WithIngredients_ShouldReturnValidMeal()
    {
         var selectedIngredients = new List<string>
        { "Chicken breast", "Rice", "Olive oil" };

        var res = _mealGenerator.GenerateAndDisplayMeal(selectedIngredients);
        Assert.AreEqual(res, "order completed succesfully");
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