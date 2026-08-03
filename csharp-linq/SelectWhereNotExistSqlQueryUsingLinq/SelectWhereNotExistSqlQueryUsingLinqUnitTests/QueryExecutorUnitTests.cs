using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelectWhereNotExistSqlQueryUsingLinq;

namespace SelectWhereNotExistSqlQueryUsingLinqUnitTests
{
    [TestClass]
    public class QueryExecutorUnitTests
    {
        private EmployeeDbContext? _context;

        [TestInitialize]
        public void TestInitialize()
        {
            _context = new EmployeeDbContext();

            if (!_context.Database.CanConnect())
            {
                _context.Database.EnsureCreated();
                _context.AddSeedData();
            }
        }

        [TestMethod]
        public void GivenEmployeeDbContext_WhenExecuteUsingAnyWithQuerySyntax_ThenReturnUnassignedEmployees()
        {
            // Act
            var unassignedEmployees = QueryExecutor.GetUnassignedEmployeesAnyQuerySyntax(_context!);

            // Assert
            Assert.IsNotNull(unassignedEmployees);
            Assert.AreEqual(1, unassignedEmployees.ToList().Count);
        }

        [TestMethod]
        public void GivenEmployeeDbContext_WhenExecuteUsingAnyWithMethodSyntax_ThenReturnUnassignedEmployees()
        {
            // Act
            var unassignedEmployees = QueryExecutor.GetUnassignedEmployeesAnyMethodSyntax(_context!);

            // Assert
            Assert.IsNotNull(unassignedEmployees);
            Assert.AreEqual(1, unassignedEmployees.ToList().Count);
        }

        [TestMethod]
        public void GivenEmployeeDbContext_WhenExecuteUsingJoinWithQuerySyntax_ThenReturnUnassignedEmployees()
        {
            // Act
            var unassignedEmployees = QueryExecutor.GetUnassignedEmployeesJoinQuerySyntax(_context!);

            // Assert
            Assert.IsNotNull(unassignedEmployees);
            Assert.AreEqual(1, unassignedEmployees.ToList().Count);
        }

        [TestMethod]
        public void GivenEmployeeDbContext_WhenExecuteUsingJoinWithMethodSyntax_ThenReturnUnassignedEmployees()
        {
            // Act
            var unassignedEmployees = QueryExecutor.GetUnassignedEmployeesJoinMethodSyntax(_context!);

            // Assert
            Assert.IsNotNull(unassignedEmployees);
            Assert.AreEqual(1, unassignedEmployees.ToList().Count);
        }

        [TestMethod]
        public void GivenEmployeeDbContext_WhenExecuteUsingContainsWithQuerySyntax_ThenReturnUnassignedEmployees()
        {
            // Act
            var unassignedEmployees = QueryExecutor.GetUnassignedEmployeesContainsQuerySyntax(_context!);

            // Assert
            Assert.IsNotNull(unassignedEmployees);
            Assert.AreEqual(1, unassignedEmployees.ToList().Count);
        }

        [TestMethod]
        public void GivenEmployeeDbContext_WhenExecuteUsingContainsWithMethodSyntax_ThenReturnUnassignedEmployees()
        {
            // Act
            var unassignedEmployees = QueryExecutor.GetUnassignedEmployeesContainsMethodSyntax(_context!);

            // Assert
            Assert.IsNotNull(unassignedEmployees);
            Assert.AreEqual(1, unassignedEmployees.ToList().Count);
        }

        [TestMethod]
        public void GivenEmployeeDbContext_WhenExecuteUsingAllWithQuerySyntax_ThenReturnUnassignedEmployees()
        {
            // Act
            var unassignedEmployees = QueryExecutor.GetUnassignedEmployeesAllQuerySyntax(_context!);

            // Assert
            Assert.IsNotNull(unassignedEmployees);
            Assert.AreEqual(1, unassignedEmployees.ToList().Count);
        }

        [TestMethod]
        public void GivenEmployeeDbContext_WhenExecuteUsingAllWithMethodSyntax_ThenReturnUnassignedEmployees()
        {
            // Act
            var unassignedEmployees = QueryExecutor.GetUnassignedEmployeesAllMethodSyntax(_context!);

            // Assert
            Assert.IsNotNull(unassignedEmployees);
            Assert.AreEqual(1, unassignedEmployees.ToList().Count);
        }
    }
}