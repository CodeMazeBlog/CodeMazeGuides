namespace CSharp_Func_Delegate
{
    public class FuncDelegateWithoutInputParameter
    {
        public double ProcessBmi()
        {
            var height = 175d;
            var weight = 75d;
            var bmi = 0d;
            if (height > 0d && weight > 0d)
            {
                var convertedheight = height / 100d;

                bmi = weight / convertedheight / convertedheight;
            }

            return bmi;
        }
    }
}
