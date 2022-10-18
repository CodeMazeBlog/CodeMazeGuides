using LINQAdvancedTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace LINQAdvancedTests
{
    [TestClass]
    public class LINQAdvancedTests
    {
        public List<Employee> employees = new List<Employee>()
        {
            new() { EmployeeId = 1, Name = "Alvin Johnston", Department = "Sales", Salary = 55000.00 },
            new() { EmployeeId = 2, Name = "Jessica Cuevas", Department = "Engineering", Salary = 65000.00 },
            new() { EmployeeId = 3, Name = "Grace Silver", Department = "Sales", Salary = 75000.00 },
            new() { EmployeeId = 4, Name = "Justin Vilches", Department = "Engineering", Salary = 85000.00 },
            new() { EmployeeId = 5, Name = "Joey Delgado", Department = "IT", Salary = 85000.00 },
            new() { EmployeeId = 6, Name = "Ashley Montoya", Department = "Engineering", Salary = 85000.00 },
            new() { EmployeeId = 7, Name = "Silvio Mora", Department = "IT", Salary = 85000.00 },
            new() { EmployeeId = 8, Name = "Arjen Robben", Department = "Administration", Salary = 105000.00 },
            new() { EmployeeId = 9, Name = "Mohammad Salah", Department = "Administration", Salary = 115000.00 },
            new() { EmployeeId = 10, Name = "Nasir Jones", Department = "Customer Service", Salary = 45000.00 },
        };

        public List<Director> directors = new List<Director>() 
        { 
            new Director() 
            {
                AbleToHire = true, Permissions = "READ_WRITE_CREATE_DELETE", EmployeeId = 100, 
                Name = "Nikola Jokic", Department = "Leadership", Salary = 175000.00, DepartmentResponsibleFor = "Engineering" 
            },
            new Director() 
            {
                AbleToHire = true, Permissions = "READ_WRITE_CREATE_DELETE", EmployeeId = 101,
                Name = "Petr Cech", Department = "Leadership", Salary = 175000.00, DepartmentResponsibleFor = "IT" 
            },
            new Director() 
            {
                AbleToHire = true, Permissions = "READ_WRITE_CREATE_DELETE", EmployeeId = 102, 
                Name = "Carl Friedrich Gauss", Department = "Leadership", Salary = 175000.00, DepartmentResponsibleFor = "R&D"
            }, 
        };

        public List<Employee> mixedEmployees = new List<Employee>()
        {
            new Director() {
                AbleToHire = true, Permissions = "READ_WRITE_CREATE_DELETE", EmployeeId = 1,
                Name = "Rodrigo Suarez", Department = "Leadership", Salary = 175000.00
            },
            new() { EmployeeId = 2, Name = "Jessica Cuevas", Department = "Engineering", Salary = 65000.00 },
            new() { EmployeeId = 7, Name = "Silvio Mora", Department = "IT", Salary = 85000.00 },
            new Administrator() { AbleToFire = false, EmployeeId = 8, Name = "Arjen Robben", Department = "Administration", Salary = 105000.00 },
            new Administrator() { AbleToFire = true, EmployeeId = 9, Name = "Mohammad Salah", Department = "Administration", Salary = 115000.00 },
            new() { EmployeeId = 10, Name = "Nasir Jones", Department = "Customer Service", Salary = 45000.00 },
        };

        public List<int> ints = new List<int>() { 2, 7, 2, 4, 5, 8, 9, 6, 1, 8, 9, 7 };

        [TestMethod]
        public void WhenGroupByIsCalled_ThenCollectionIsGrouped()
        {
            var expectedGroups = 5;
            var employeeDepartmentGroups = employees.GroupBy(x => x.Department);

            Assert.IsNotNull(employeeDepartmentGroups);
            Assert.AreEqual(expectedGroups, employeeDepartmentGroups.Count());
        }

        [TestMethod]
        public void WhenGroupByWithCompsiteKeysIsCalled_ThenCollectionIsGrouped()
        {
            var expectedGroups = 8;
            var employeeDepartmentGroups = employees.GroupBy(x => new { x.Department, x.Salary });

            Assert.IsNotNull(employeeDepartmentGroups);
            Assert.AreEqual(expectedGroups, employeeDepartmentGroups.Count());
        }

        [TestMethod]
        public void WhenOfTypeIsCalled_ThenCollectionFilteredByType ()
        {
            var expectedAdmins = 2;
            var admins = mixedEmployees.OfType<Administrator>();

            Assert.IsNotNull(admins);
            Assert.AreEqual(expectedAdmins, admins.Count());
            CollectionAssert.AllItemsAreInstancesOfType(admins.ToList(), typeof(Administrator));
        }

        [TestMethod]
        public void WhenConvertAllIsCalled_ThenCollectionElementsAreCast()
        {
            var expectedAdmins = 2;
            var admins = mixedEmployees.OfType<Administrator>();
            var adminsConverted = admins.ToList().ConvertAll(d => JsonSerializer.Serialize(d));

            Assert.IsNotNull(admins);
            Assert.AreEqual(expectedAdmins, admins.Count());
            CollectionAssert.AllItemsAreInstancesOfType(adminsConverted.ToList(), typeof(string));
        }

        [TestMethod]
        public void WhenAsQueryableIsCalled_ThenCollectionIsCastAsIQueryable()
        {
            var employeeQueryable = employees.AsQueryable();

            Assert.IsNotNull(employeeQueryable);
            Assert.IsInstanceOfType(employeeQueryable, typeof(IQueryable));
        }

        [TestMethod]
        public void WhenJoinIsCalled_ThenCollectionsAreJoined()
        {
            var expectedEmployeeDirectorPairings = 5;
            var join = employees.Join(directors,
                                                em => em.Department,
                                                dir => dir.DepartmentResponsibleFor,
                                                (em, dir) => new { EmployeeName = em.Name, DirectorName = dir.Name, Department = em.Department });

            Assert.IsNotNull(join);
            Assert.AreEqual(expectedEmployeeDirectorPairings, join.Count());
        }

        [TestMethod]
        public void WhenGroupJoinIsCalled_ThenCollectionsAreJoinedAndGrouped()
        {
            var expectedEmployeeDirectorGroupedPairings = 3;
            var groupJoin = directors.GroupJoin(employees,
                                                dir => dir.DepartmentResponsibleFor,
                                                em => em.Department,
                                                (dir, emGroup) => new { dir.Name, EmployeeGroup = emGroup });

            Assert.IsNotNull(groupJoin);
            Assert.AreEqual(expectedEmployeeDirectorGroupedPairings, groupJoin.Count());
            Assert.AreEqual(1, groupJoin.Where(g => g.Name == "Carl Friedrich Gauss" && g.EmployeeGroup.Count() == 0).Count());
        }

        [TestMethod]
        public void WhenGroupJoinIsCalled_ThenCollectionsAreLeftOuterJoined()
        {
            var expectedLeftOuterJoinedEmployeeDirectorPairings = 3;
            var groupJoin = directors.GroupJoin(employees,
                                    dir => dir.DepartmentResponsibleFor,
                                    em => em.Department,
                                    (dir, emGroup) => new { dir.DepartmentResponsibleFor, dir.Name, EmployeeGroup = emGroup.DefaultIfEmpty(new() { Name = "No Name" }) });

            Assert.IsNotNull(groupJoin);
            Assert.AreEqual(expectedLeftOuterJoinedEmployeeDirectorPairings, groupJoin.Count());
            Assert.AreEqual(1, groupJoin.Where(g => g.Name == "Carl Friedrich Gauss" && g.EmployeeGroup.Count() == 1).Count());
        }

        [TestMethod]
        public void WhenSkipIsCalled_ThenCollectionIsPartitioned()
        {
            var expectedNumberOfElementsAfterSkip = 5;
            var skipResult = ints.Skip(7);

            Assert.AreEqual(expectedNumberOfElementsAfterSkip, skipResult.Count());
        }

        [TestMethod]
        public void WhenSkipWhileIsCalled_ThenCollectionIsPartitioned()
        {
            var expectedNumberOfElementsAfterSkip = 6;
            var skipResult = ints.SkipWhile(i => i < 9);

            Assert.AreEqual(expectedNumberOfElementsAfterSkip, skipResult.Count());
        }

        [TestMethod]
        public void WhenTakeIsCalled_ThenCollectionIsPartitioned()
        {
            var expectedNumberOfElementsAfterSkip = 5;
            var takeResult = ints.Take(5);

            Assert.AreEqual(expectedNumberOfElementsAfterSkip, takeResult.Count());
        }

        [TestMethod]
        public void WhenTakeWhileIsCalled_ThenCollectionIsPartitioned()
        {
            var expectedNumberOfElementsAfterSkip = 6;
            var takeResult = ints.SkipWhile(i => i < 9);

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