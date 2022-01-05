using ActionAndFuncDelegateInCSharp.Model;

namespace ActionAndFuncDelegateInCSharp.Examples
{
    public delegate void ActionDelegate<in T>(T obj);

    public class ContravarianceExamples
    {
        public ActionDelegate<Button> ActWithButton { get; set; }

        public ActionDelegate<Control> ActWithControl { get; set; }

        public ContravarianceExamples()
        {
            ActWithButton = button => button.Click();
            ActWithControl = control => control.Operate();
        }

        public void Assign()
        {
            ActWithButton = ActWithControl;
        }
    }
}