using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Tests
{
    public class ActionTests
    {
        [Fact]
        public void ContractBasedEmployeeBonus()
        {
            Employee e = new Employee
            {
                Name = "John",
                Salary = 20,
                Type = EmployeeType.Regular
            };

            MyActionDelegate bonusAction = new MyActionDelegate();
            bonusAction.PerformAction(e);
            Assert.Equal(40, e.Bonus);
        }

        [Fact]
        public void SalaryBasedEmployeeBonus()
        {
            Employee e = new Employee
            {
                Name = "Kate",
                Salary = 20,
                Type = EmployeeType.ContractBased
            };

            MyActionDelegate bonusAction = new MyActionDelegate();
            bonusAction.PerformAction(e);
            Assert.Equal(30, e.Bonus);
        }
    }
}
