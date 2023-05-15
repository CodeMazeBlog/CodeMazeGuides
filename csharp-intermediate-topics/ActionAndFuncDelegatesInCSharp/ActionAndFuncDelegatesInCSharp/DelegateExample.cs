namespace ActionAndFuncDelegatesInCSharp
{
    public class DelegateExample
    {
        public delegate DateTime SayDate();
        public DelegateExample()
        {
            SayDate sayDate = SayCurrentDate;
            sayDate();
        }

        public DateTime SayCurrentDate()
        {
            return DateTime.Today;
        }
    }
}