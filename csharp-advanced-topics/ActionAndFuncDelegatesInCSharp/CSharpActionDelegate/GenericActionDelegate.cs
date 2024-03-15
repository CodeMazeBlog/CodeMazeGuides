namespace CSharp_Action_Delegate
{
    public class GenericActionDelegate
    {
        public void ProcessBmi(double height, double weight)
        {
            double bmi = 0d;
            if (height > 0d && weight > 0d)
            {
                var convertedheight = height / 100d;

                bmi = weight / convertedheight / convertedheight;
            }

            Console.WriteLine($"The BMI is : {bmi:N}.");
        }
        
        //public Action<double, double> doWorkAction = ProcessBmi;
    }
}
