using ActionAndFuncDelegateInCSharp.Model;

namespace ActionAndFuncDelegateInCSharp.Examples
{
    public delegate TResult FuncDelegate<out TResult>();

    public class CovarianceExamples
    {
        public FuncDelegate<Button> FuncWithButton { get; set; }

        public FuncDelegate<Control> FuncWithControl { get; set; }

        public CovarianceExamples()
        {
            FuncWithButton = () => new Button();
            FuncWithControl = () => new Control();
        }

        public void Assign()
        {
            FuncWithControl = FuncWithButton;
        }
    }
}