namespace UsingVariablesInsideStrings
{
    public class MyClass
    {
        public int MyNumber { get; set; }

        public MyClass(int num)
        {
            MyNumber = num;
        }

        public override string ToString()
        {
            return MyNumber.ToString();
        }
    }
}
