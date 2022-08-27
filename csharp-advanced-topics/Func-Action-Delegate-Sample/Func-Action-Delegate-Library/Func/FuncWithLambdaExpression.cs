namespace Func_Action_Delegate_Library.Func
{
    public class FuncWithLambdaExpression
    {
        public List<string> Fruits = new List<string> { "apple", "mango", "dates", "orange", "orange" };
        public string FruitToFind { set; get; } = "orange";
        public Func<string, bool> IsFruitExist;
    }
}