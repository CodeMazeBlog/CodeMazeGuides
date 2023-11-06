using ActionAndFuncDelegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Test;

[TestClass]
public class MealGeneratorServiceTest
{
    private readonly MealGenerator _mealGenerator;

    public MealGeneratorServiceTest () 
    {
        _mealGenerator = new MealGenerator(MealGeneratorService.CookDelicousMeal, MealGeneratorService.ServeDeliciousMeal);
    }

    [TestMethod]
    public void GivenValidList_WhenGenerateAndDisplayMeal_ThenReturnSuccesfulOrder()
    {
        var selectedIngredients = new List<string> { "Chicken breast", "Rice", "Olive oil" };

        var result = _mealGenerator.GenerateAndDisplayMeal(selectedIngredients);
        Assert.AreEqual(result, "order completed succesfully");
    }
}