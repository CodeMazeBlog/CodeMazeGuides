using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class CovarianceAndContravarianceInCSharpUnitTest
    {
        delegate void personDelegate(Employee employee);

        [TestMethod]
        public void GivenLessDerivedObjectType_WhenAssigningMoreDerivedObjectType_ThenObjectsAreEqual()
        {
            var personObject = new Person();
            var employeeObject = new Employee();
            var managerObject = new Manager();

            personObject = employeeObject;
            Assert.AreEqual(personObject, employeeObject);

            personObject = managerObject;
            Assert.AreEqual(personObject, managerObject);
        }

        [TestMethod]
        public void GivenMoreDerivedDelegateParameterType_WhenAssigningLessDerivedMethodParameterType_ThenDelegateMethodParameterIsLessDerived()
        {
            personDelegate del = GreetPerson;
            Assert.IsTrue(del.Method.ToString() == "Void GreetPerson(Tests.Person)");
        }

        [TestMethod]
        public void GivenLessDerivedArray_WhenAssigningMoreDerivedObjectType_ThenArrayElementAndObjectAreEqual()
        {
            var managerObject = new Manager();
            Person[] people = new Employee[5];
            people[0] = managerObject;

            Assert.AreEqual(people[0], managerObject);
        }

        [TestMethod]
        public void GivenLessDerivedFuncDelegate_WhenAssigningMoreDerivedFuncDelegate_ThenFuncDelegatesAreEqual()
        {
            Func<string, Manager> getManager = GetEmployeeManager;
            Func<string, Employee> getEmployee = GetEmployeeManager;
            getEmployee = getManager;

            Assert.AreEqual(getEmployee, getManager);
        }

        [TestMethod]
        public void GivenMoreDerivedActionDelegate_WhenAssigningLessDerivedActionDelegate_ThenActionDelegatesAreEqual()
        {
            Action<Employee> evaluateEmployeePerformance = EvaluatePerformance;
            Action<Manager> evaluateManagerPerformance = EvaluatePerformance;
            evaluateManagerPerformance = evaluateEmployeePerformance;

            Assert.AreEqual(evaluateManagerPerformance, evaluateEmployeePerformance);
        }

        [TestMethod]
        public void GivenLessDerivedGenericType_WhenAssigningMoreDerivedGenericType_ThenGenericTypesAreEqual()
        {
            ICovariant<Person> icovPerson = new ImplementICovariant<Person>();
            ICovariant<Employee> icovEmployee = new ImplementICovariant<Employee>();
            icovPerson = icovEmployee;

            Assert.AreEqual(icovPerson, icovEmployee);
        }

        [TestMethod]
        public void GivenMoreDerivedGenericType_WhenAssigningLessDerivedGenericType_ThenGenericTypesAreEqual()
        {
            IContravariant<Person> icontraPerson = new ImplementIContravariant<Person>();
            IContravariant<Employee> icontraEmployee = new ImplementIContravariant<Employee>();
            icontraEmployee = icontraPerson;

            Assert.AreEqual(icontraEmployee, icontraPerson);
        }

        static void GreetPerson(Person person)
        {
            // Logic to greet person.
        }

        static Manager GetEmployeeManager(string employeeFullName)
        {
            // Logic to find employee's manager.
            return new Manager();
        }

        static void EvaluatePerformance(Employee employee)
        {
            // Logic to evaluate performance.
        }
    }
}