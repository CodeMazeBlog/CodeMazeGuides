using System;

namespace Framework
{
    public class DelegateHelper
    {
        const double HRA_Percentage = 0.4;
        const string TEXT = "programming delegates in csharp";
        static double GetHra(double basic) => (double)(basic * HRA_Percentage);
        string ConvertToLower(string str) => str.ToLower();

        Func<double, double> func = new Func<double, double>(GetHra);

        internal delegate string MyDelegate(string str);
        public string GetTextInLowercase()
        {            
            var myDelegate = new MyDelegate(ConvertToLower);
            return myDelegate("PROGRAMMING DELEGATES IN CSHARP");
        }
    }
}
