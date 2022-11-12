class FuncDelegate{
    //Methods that takes parameters and returns a value:

    public static int sum(int a, int b)
    {
        return a + b;
    }

    public static string displaySum(int a, int b)
    {
        return string.Format("Addition of {0} and {1} is {2}",a,b,a+b);
    }
    public static int randomNumber()
    {
        Random r = new Random();
        return r.Next();
    }
}