namespace CSharp_Func_Delegate
{
    public class FuncDelegateWithoutInputParameter
    {
        public double ProcessBmi()
        {
            double height = 175d;
            double weight = 75d;
            double bmi = 0d;
            if (height > 0d && weight > 0d)
            {
                var convertedheight = height / 100d;

                bmi = weight / convertedheight / convertedheight;
            }

            return bmi;
        }
    }
}
