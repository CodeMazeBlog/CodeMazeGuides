namespace CSharp_Action_Delegate
{
    public class LambdaActionDelegate
    {
        public Action BmiWithNonGenericAction = () =>
        {
            var height = 175d;
            var weight = 75d;
            var bmi = 0d;
            if (height > 0d && weight > 0d)
            {
                var convertedheight = height / 100d;

                bmi = weight / convertedheight / convertedheight;
            }

            Console.WriteLine($"The BMI is : {bmi:N}.");
        };

        public Action<double, double> BmiWithGenericAction = (height, weight) =>
        {
            var bmi = 0d;
            if (height > 0d && weight > 0d)
            {
                var convertedheight = height / 100d;

                bmi = weight / convertedheight / convertedheight;
            }

            Console.WriteLine($"The BMI is : {bmi:N}.");
        };
    }
}
