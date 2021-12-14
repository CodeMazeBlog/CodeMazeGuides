using System;

namespace ActionDelegateDemo
{
    class Program
    {
        // Declare my MazeCalulate delegate
        delegate int MazeCalculateDelegate(int param1, int param2);

        static void Main(string[] args)
        {

            // Action delegate instantiating
            Action<int, int> DemoActionDel = Addition;
            // Invoke Action Delegate
            DemoActionDel(12, 2);


            // Action delegate instantiating
            Action<EmployeePayment> refActionDel = new Action<EmployeePayment>(SalaryCalculate);

            EmployeePayment es = new EmployeePayment()
            {
                Basic = 1500,
                Houserent = 500,
                Convince = 200,
                Medical = 1000
            };
            // Invoke Action Delegate with EmployeePayment reference
            refActionDel.Invoke(es);



            // Action delegate instantiating with Anonymous Method
            Action<int, int> AMActionDel = delegate (int num1, int num2)
            {
                Console.WriteLine(string.Format("Action Delegate with Anonymous Method is: {0}", num1 - num2));
            };
            // Invoke Action Delegate with Anonymous Method
            AMActionDel(12, 2);



            // Action delegate instantiating with lamda expression
            Action<int, int> leActionDel = (int num1, int num2) =>
            {
                Console.WriteLine(string.Format("Lambda Expression result is: {0}", num1 - num2));
            };
            // Invoke Action Delegate for lamda expression
            leActionDel(15, 2);

            Console.ReadLine();
        }

        public static void Addition(int num1, int num2)
        {
            Console.WriteLine(string.Format("Action Delegate result is: {0}", num1+num2));
        }
      
        public static void SalaryCalculate(EmployeePayment employee)
        {
            int sal= employee.Basic + employee.Houserent + employee.Convince + employee.Medical;
            Console.WriteLine(string.Format("Action Delegate using EmployeePayment Reference: Salary is:${0}", sal));

        }

    }

    public class EmployeePayment
    {
        public int Basic { get; set; }

        public int Houserent { get; set; }
        public int Medical { get; set; }
        public int Convince { get; set; }
   

    }
}
