using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Action_and_Function_Delegates.MultiCastDelegateExample;

namespace Action_and_Function_Delegates
{
    public static class Services
    {
public static void RunSimpleDelegateExample()
{
    //Initiate our delegates with each method

    Calculator addCalc = new(SimpleDelegateExample.Add);
    Calculator subCalc = new(SimpleDelegateExample.Substract);
    Calculator multCalc = new(SimpleDelegateExample.Multiply);
    Calculator divCalc = new(SimpleDelegateExample.Divide);
    Calculator modCalc = new(SimpleDelegateExample.Modulus);

    //Given a situation where the static defined is the base salary of an employee
    //That base salary is subject to change, we can thus use our delegates to be be able
    //change that salary accordingly

    //Console.WriteLine($"Salary before anything has happened {SimpleDelegateExample.GetNumber()}");

    //For instance we deduct some arrears for extra holidays
    int deductedSalary = subCalc(20);
    //Console.WriteLine($"After the arrear deduction, salary now is {deductedSalary}");

    //However there were some over head tasks the employee completed as well
    int bumpedUpSalary = addCalc(150);
    //Console.WriteLine($"After getting the bonus, salary now is {bumpedUpSalary}");

    //Console.WriteLine($"After the deductions and bonuses, salary now is {SimpleDelegateExample.GetNumber()}");
}

        public static void RunMultiCastDelegate()
        {
            Func<IEnumerable<IGrouping<Departments, Employees>>, Dictionary<Departments, int>>? deptDictionaryDelegate = new(PersonnelByDeptsUsingDelegate);

            //CHAINING delegates together - MULTICAST delegates
            deptDictionaryDelegate += KillsByDeptsUsingDelegate!;

            //Lets check the invocation list 
            Delegate[] DeptDictionaryDelegateInvocationList = deptDictionaryDelegate.GetInvocationList();

            Action<Delegate> PrintListItem = new(PrintItem);

            //Departments Dictionary delegate methods we have chained together

            Array.ForEach(DeptDictionaryDelegateInvocationList, PrintListItem);


            //Now we invoke our multicast delegate

            //"Invoke first method in chain"
            var killDeptDict = deptDictionaryDelegate(GroupByDepts());

            //Remove the method chained
            deptDictionaryDelegate -= KillsByDeptsUsingDelegate;

            //Invoke the second method in chain
            var empDeptDict = deptDictionaryDelegate!(GroupByDepts());

            Console.ReadKey();
        }
    }
}
