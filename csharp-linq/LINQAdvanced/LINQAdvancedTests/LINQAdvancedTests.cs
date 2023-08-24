using LINQAdvancedTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text.Json;

namespace LINQAdvancedTests
{
    [TestClass]
    public class LINQAdvancedTests
    {
        [TestMethod]
        public void WhenGroupByIsCalled_ThenCollectionIsGrouped()
        {
            var expectedGroups = 5;
            var employeeDepartmentGroups = TestData.Employees.GroupBy(x => x.Department);

            Assert.IsNotNull(employeeDepartmentGroups);
            Assert.AreEqual(expectedGroups, employeeDepartmentGroups.Count());
        }

        [TestMethod]
        public void WhenGroupByWithCompsiteKeysIsCalled_ThenCollectionIsGrouped()
        {
            var expectedGroups = 8;
            var employeeDepartmentGroups = TestData.Employees.GroupBy(x => new { x.Department, x.Salary });

            Assert.IsNotNull(employeeDepartmentGroups);
            Assert.AreEqual(expectedGroups, employeeDepartmentGroups.Count());
        }

        [TestMethod]
        public void WhenOfTypeIsCalled_ThenCollectionFilteredByType ()
        {
            var expectedAdmins = 2;
            var admins = TestData.MixedEmployees.OfType<Administrator>();

            Assert.IsNotNull(admins);
            Assert.AreEqual(expectedAdmins, admins.Count());
            CollectionAssert.AllItemsAreInstancesOfType(admins.ToList(), typeof(Administrator));
        }

        [TestMethod]
        public void WhenConvertAllIsCalled_ThenCollectionElementsAreCast()
        {
            var expectedAdmins = 2;
            var admins = TestData.MixedEmployees.OfType<Administrator>();
            var adminsConverted = admins.ToList().ConvertAll(d => JsonSerializer.Serialize(d));

            Assert.IsNotNull(admins);
            Assert.AreEqual(expectedAdmins, admins.Count());
            CollectionAssert.AllItemsAreInstancesOfType(adminsConverted.ToList(), typeof(string));
        }

        [TestMethod]
        public void WhenAsQueryableIsCalled_ThenCollectionIsCastAsIQueryable()
        {
            var employeeQueryable = TestData.Employees.AsQueryable();

            Assert.IsNotNull(employeeQueryable);
            Assert.IsInstanceOfType(employeeQueryable, typeof(IQueryable));
        }

        [TestMethod]
        public void WhenJoinIsCalled_ThenCollectionsAreJoined()
        {
            var expectedEmployeeDirectorPairings = 5;
            var join = TestData.Employees.Join(TestData.Directors,
                em => em.Department,
                dir => dir.DepartmentResponsibleFor,
                (em, dir) => new 
                { 
                    EmployeeName = em.Name, 
                    DirectorName = dir.Name, 
                    Department = em.Department 
                });

            Assert.IsNotNull(join);
            Assert.AreEqual(expectedEmployeeDirectorPairings, join.Count());
        }

        [TestMethod]
        public void WhenGroupJoinIsCalled_ThenCollectionsAreJoinedAndGrouped()
        {
            var expectedEmployeeDirectorGroupedPairings = 3;
            var groupJoin = TestData.Directors.GroupJoin(TestData.Employees,
                dir => dir.DepartmentResponsibleFor,
                em => em.Department,
                (dir, emGroup) => new 
                { 
                    dir.Name, 
                    EmployeeGroup = emGroup 
                });

            Assert.IsNotNull(groupJoin);
            Assert.AreEqual(expectedEmployeeDirectorGroupedPairings, groupJoin.Count());
            Assert.AreEqual(1, groupJoin.Where(g => g.Name == "Carl Friedrich Gauss" && g.EmployeeGroup.Count() == 0).Count());
        }

        [TestMethod]
        public void WhenGroupJoinIsCalled_ThenCollectionsAreLeftOuterJoined()
        {
            var expectedLeftOuterJoinedEmployeeDirectorPairings = 3;
            var groupJoin = TestData.Directors.GroupJoin(TestData.Employees,
                dir => dir.DepartmentResponsibleFor,
                em => em.Department,
                (dir, emGroup) => new 
                { 
                    dir.DepartmentResponsibleFor, 
                    dir.Name, 
                    EmployeeGroup = emGroup.DefaultIfEmpty(new() { Name = "No Name" }) 
                });

            Assert.IsNotNull(groupJoin);
            Assert.AreEqual(expectedLeftOuterJoinedEmployeeDirectorPairings, groupJoin.Count());
            Assert.AreEqual(1, groupJoin.Where(g => g.Name == "Carl Friedrich Gauss" && g.EmployeeGroup.Count() == 1).Count());
        }

        [TestMethod]
        public void WhenSkipIsCalled_ThenCollectionIsPartitioned()
        {
            var expectedNumberOfElementsAfterSkip = 5;
            var skipResult = TestData.ints.Skip(7);

            Assert.AreEqual(expectedNumberOfElementsAfterSkip, skipResult.Count());
        }

        [TestMethod]
        public void WhenSkipWhileIsCalled_ThenCollectionIsPartitioned()
        {
            var expectedNumberOfElementsAfterSkip = 6;
            var skipResult = TestData.ints.SkipWhile(i => i < 9);

            Assert.AreEqual(expectedNumberOfElementsAfterSkip, skipResult.Count());
        }

        [TestMethod]
        public void WhenTakeIsCalled_ThenCollectionIsPartitioned()
        {
            var expectedNumberOfElementsAfterSkip = 5;
            var takeResult = TestData.ints.Take(5);

            Assert.AreEqual(expectedNumberOfElementsAfterSkip, takeResult.Count());
        }

        [TestMethod]
        public void WhenTakeWhileIsCalled_ThenCollectionIsPartitioned()
        {
            var expectedNumberOfElementsAfterSkip = 6;
            var takeResult = TestData.ints.SkipWhile(i => i < 9);

            Assert.AreEqual(expectedNumberOfElementsAfterSkip, takeResult.Count());
        }

        [TestMethod]
        public void WhenRangeIsCalled_ThenSequenceIsCreated()
        {
            var simpleRange = Enumerable.Range(5, 5); // 5, 6, 7, 8, 9, 10
            var rangeSquared = Enumerable.Range(1, 10).Select(n => n * n); // 1, 4, 9, 16, 25 ... 100
            var rangeAllEvens = Enumerable.Range(1, 100).Where(n => n % 2 == 0); // 2, 4, 6, 8 ... 100

            Assert.AreEqual(expected: 5, simpleRange.Count());
            Assert.AreEqual(expected: 5, simpleRange.Where(ele => ele >= 5 && ele <= 10).Count());
            Assert.AreEqual(expected: 0, simpleRange.Where(ele => ele < 5 && ele > 10).Count());

            var index = 5;
            Assert.AreEqual(expected: 10, rangeSquared.Count());
            Assert.AreEqual(expected: index * index, rangeSquared.ElementAt(index - 1));

            Assert.AreEqual(expected: 50, rangeAllEvens.Count());
            Assert.IsTrue(rangeAllEvens.All(ele => ele % 2 == 0));
        }

        [TestMethod]
        public void WhenRepeatIsCalled_ThenSequenceIsCreated()
        {
            var expectedNumberOfEmployees = 100;
            var employeesRepeated = Enumerable.Repeat(new Employee(), 100);

            Assert.AreEqual(expectedNumberOfEmployees, employeesRepeated.Count());
            CollectionAssert.AllItemsAreInstancesOfType(employeesRepeated.ToList(), typeof(Employee));
        }
    }
}