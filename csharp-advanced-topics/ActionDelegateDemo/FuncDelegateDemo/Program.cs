using System;

namespace DelegateDemo
{
    class Program
    {
        // Declare my MazeCalulate delegate
        delegate int MazeCalculateDelegate(int param1, int param2);

        static void Main(string[] args)
        {
            //Instantiatinng Delegate            
            MazeCalculateDelegate calDel = new MazeCalculateDelegate(Addition);
            // invoke the Delegate
            var result = calDel(5, 10);
            

            Console.WriteLine(string.Format("Calculate result is: {0}", result.ToString()));


            // Func delegate instantiating
            Func<int, int, int> DemoFuncDel = Addition;
            // Invoke Func Delegate
            int res = DemoFuncDel(12, 2);
            Console.WriteLine(string.Format("Func Delegate result is: {0}", result.ToString()));


            Func<EmployeePayment, int> refFuncDel = SalaryCalculate;

            EmployeePayment sc = new EmployeePayment()
            {
                Basic = 1500,
                Houserent = 500,
                Convince = 200,
                Medical = 1000
            };
            // Invoke Func Delegate with EmployeePayment reference
            int salary = refFuncDel.Invoke(sc);

            Console.WriteLine(string.Format("Func Delegate using EmployeePayment Reference: Salary is:${0}", salary.ToString()));



            // Func delegate instantiating with Anonymous Method
            Func<int, int, int> AMFuncDel = delegate (int num1, int num2)
           {
               return num1 - num2;
           };
            // Invoke Func Delegate with Anonymous Method
            int amDel = AMFuncDel(12, 2);
            Console.WriteLine(string.Format("Func Delegate with Anonymous Method is: {0}", amDel.ToString()));


            // Func delegate instantiating with lamda expression
            Func<int,int,int> leFuncDel = (int num1,int num2 ) => {
                return num1 - num2;
            };
            // Invoke Func Delegate for lamda expression
            int leResult = leFuncDel(15, 2);
            Console.WriteLine(string.Format("Lambda Expression result is: {0}", amDel.ToString()));


            Console.ReadLine();
        }

        public static int Addition(int num1, int num2)
        {
            return num1 + num2;
        }

     
        public static int SalaryCalculate(EmployeePayment employee)
        {
            return employee.Basic + employee.Houserent + employee.Convince + employee.Medical;
        }

    }

    public class EmployeePayment
    {
        public int Basic { get; set; }

        public int Houserent { get; set; }
        public int Medical { get; set; }
        public int Convince { get; set; }
        //public int TotalSal()
        //{
        //    return Basic + Houserent + Convince + Medical;
        //}

    }
}
