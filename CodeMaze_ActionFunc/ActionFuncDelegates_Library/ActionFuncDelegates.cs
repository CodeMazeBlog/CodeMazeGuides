namespace ActionFuncDelegates_Library
{
    public class ActionFuncDelegates
    {
        private static double result;
        private static double interestRate = 0.15;
        private static double principalAmount = 1000;
        public static double Result { get { return result; } }

        //in a class context
        static Action AditionDelegate = new Action(Addition); //can be invoked anywhere within this class       

        Action<int, int> AditionDelegateWithParameters = new Action<int, int>(Addition); //can be invoked anywhere within this class

        static Func<double, double> GetInterestRate = amount => amount * interestRate; //accessible within this class

        //define custom delegate
        delegate double GetInterestRateCustomDelegate(double amount);

        //create instance of custom delegate and implement delegate method option
        static GetInterestRateCustomDelegate getInterestRateCustomDelegate
               = new GetInterestRateCustomDelegate(
                   delegate (double amount)
                   {
                       result = amount * interestRate;
                       return result;
                   });

        //using pointer (lambda expression option instead of creating instance of custom delegate
        static GetInterestRateCustomDelegate getInterestRateCustomDelegatePointer = amount => amount * interestRate;

        //methods for delegate
        static void Addition(int a, int b) { result = (a + b); }
        static void Addition() { result = 0; }

        //in a method context. Defined and implemented within a method
        public static void ExecuteActionAndFuncDelegate()
        {
            Action aditionDelegate = new Action(Addition);
            Console.WriteLine($"Action delegate Result of no principal amount and no interest rate is {   Result}");

            Func<double, double> getInterestRate = amount => amount * interestRate;

            double principalAmountForInterestCalculation = 1000;
            Console.WriteLine($"Func delegate  Result of principal amount  {principalAmountForInterestCalculation} and interest rate {interestRate} is {getInterestRate(principalAmountForInterestCalculation)}");

        }

        //delegate execution /call options: by name or by invoke
        public static void ExecuteDelegateByName()
        {
            Action aditionDelegate = new Action(Addition);
            aditionDelegate();

        }
        public static void ExecuteDelegateByInvoke()
        {
            Action aditionDelegate = new Action(Addition);
            aditionDelegate.Invoke();

        }
        public static void ExecuteDelegateWithParamenters()
        {
            Action<int, int> aditionDelegateWithParameters = new Action<int, int>(Addition);
            aditionDelegateWithParameters.Invoke(4, 4);

        }



        //call or execute created instance of custom delegate
        public static void ExecuteInstantiatedCustomDelegate()
        {
            double amount = principalAmount;
            double rateAmount = getInterestRateCustomDelegate(amount);
            Console.WriteLine($" {interestRate}% interest of {amount} from custom delegate instantiated is {rateAmount}");

        }

        //call or execute custom delegate pointer
        public static void ExecuteCustomDelegatePointer()
        {
            double amount = principalAmount;
            double rateAmount = getInterestRateCustomDelegatePointer(amount);
            Console.WriteLine($" {interestRate}% interest of {amount} from custom delegate pointer is {rateAmount}");

        }



        //methods overload for testing purposes

        public static string ExecuteInstantiatedCustomDelegate(double principalAmountForInterestCalculation)
        {
            double rateAmount = getInterestRateCustomDelegate(principalAmountForInterestCalculation);
            return ($" {interestRate}% interest of {principalAmountForInterestCalculation} from custom delegate instantiated is {rateAmount}");

        }
        public static string ExecuteCustomDelegatePointer(double principalAmountForInterestCalculation)
        {
            ;
            double rateAmount = getInterestRateCustomDelegatePointer(principalAmountForInterestCalculation);
            return ($" {interestRate}% interest of {principalAmountForInterestCalculation} from custom delegate pointer is {rateAmount}");

        }
        public static string ExecuteDelegateWithParamenters(int a, int b)
        {
            Action<int, int> aditionDelegateWithParameters = new Action<int, int>(Addition);
            aditionDelegateWithParameters.Invoke(a, b);
            return ($" {a} and {b} addition {Result}");

        }

    }

}