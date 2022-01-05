namespace ActionAndFuncDelegateInCSharp.Model
{
    public class Button : Control
    {
        public int ClickCount { get; set; }

        public void Click() => ClickCount++;
    }
}