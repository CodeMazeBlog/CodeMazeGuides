using Action_and_Function_Delegates;

namespace TestActionAndFunctionDelegates
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenDeterminingSalary_ApplyConstraintsForCalc()
        {
            // Arrange
            Calculator addCalc = new(SimpleDelegateExample.Add);
            Calculator subCalc = new(SimpleDelegateExample.Substract);

            // Act
            int startingSalary = SimpleDelegateExample.GetNumber();
            int deductedSalary = subCalc(20);
            int bumpedUpSalary = addCalc(150);

            int actualLeftSalary = SimpleDelegateExample.GetNumber(); 

            // Assert
            
            Assert.Multiple(() =>
            {
                Assert.That(startingSalary, Is.EqualTo(5220));
                Assert.That(deductedSalary, Is.EqualTo(startingSalary - 20));
                Assert.That(bumpedUpSalary, Is.EqualTo(deductedSalary + 150));
            });
        }

        [Test]
        public void TestRunMultiCastDelegate()
        {
            // Arrange
            // Arrange
            var expectedKillsByDept = MultiCastDelegateExample.KillsByDeptsUsingDelegate(MultiCastDelegateExample.GroupByDepts());
            var expectedEmpByDept = MultiCastDelegateExample.PersonnelByDeptsUsingDelegate(MultiCastDelegateExample.GroupByDepts());
            Func<IEnumerable<IGrouping<Departments, Employees>>, Dictionary<Departments, int>>? deptDictionaryDelegate = new(MultiCastDelegateExample.PersonnelByDeptsUsingDelegate);
            deptDictionaryDelegate += MultiCastDelegateExample.KillsByDeptsUsingDelegate!;

            // Act
            var actualKillsByDept = deptDictionaryDelegate(MultiCastDelegateExample.GroupByDepts());
            deptDictionaryDelegate -= MultiCastDelegateExample.KillsByDeptsUsingDelegate;
            var actualEmpByDept = deptDictionaryDelegate!(MultiCastDelegateExample.GroupByDepts());

            // Assert
            Assert.That(actualKillsByDept, Is.EqualTo(expectedKillsByDept));
            Assert.That(actualEmpByDept, Is.EqualTo(expectedEmpByDept));
        }
    }
}