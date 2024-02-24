using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelectWhereNotExistSqlQueryUsingLinq;

namespace SelectWhereNotExistSqlQueryUsingLinqUnitTests
{
    [TestClass]
    public class QueryExecutorUnitTests
    {
        private EmployeeDbContext _context;

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
            var unassignedEmployees = QueryExecutor.GetUnassignedEmployeesUsingAnyWithQuerySyntax(_context);

            // Assert
            Assert.IsNotNull(unassignedEmployees);
            Assert.AreEqual(1, unassignedEmployees.Count);
        }

        [TestMethod]
        public void GivenEmployeeDbContext_WhenExecuteUsingAnyWithMethodSyntax_ThenReturnUnassignedEmployees()
        {
            // Act
            var unassignedEmployees = QueryExecutor.GetUnassignedEmployeesUsingAnyWithMethodSyntax(_context);

            // Assert
            Assert.IsNotNull(unassignedEmployees);
            Assert.AreEqual(1, unassignedEmployees.Count);
        }

        [TestMethod]
        public void GivenEmployeeDbContext_WhenExecuteUsingJoinWithQuerySyntax_ThenReturnUnassignedEmployees()
        {
            // Act
            var unassignedEmployees = QueryExecutor.GetUnassignedEmployeesUsingJoinWithQuerySyntax(_context);

            // Assert
            Assert.IsNotNull(unassignedEmployees);
            Assert.AreEqual(1, unassignedEmployees.Count);
        }

        [TestMethod]
        public void GivenEmployeeDbContext_WhenExecuteUsingJoinWithMethodSyntax_ThenReturnUnassignedEmployees()
        {
            // Act
            var unassignedEmployees = QueryExecutor.GetUnassignedEmployeesUsingJoinWithMethodSyntax(_context);

            // Assert
            Assert.IsNotNull(unassignedEmployees);
            Assert.AreEqual(1, unassignedEmployees.Count);
        }

        [TestMethod]
        public void GivenEmployeeDbContext_WhenExecuteUsingContainsWithQuerySyntax_ThenReturnUnassignedEmployees()
        {
            // Act
            var unassignedEmployees = QueryExecutor.GetUnassignedEmployeesUsingContainsWithQuerySyntax(_context);

            // Assert
            Assert.IsNotNull(unassignedEmployees);
            Assert.AreEqual(1, unassignedEmployees.Count);
        }

        [TestMethod]
        public void GivenEmployeeDbContext_WhenExecuteUsingContainsWithMethodSyntax_ThenReturnUnassignedEmployees()
        {
            // Act
            var unassignedEmployees = QueryExecutor.GetUnassignedEmployeesUsingContainsWithMethodSyntax(_context);

            // Assert
            Assert.IsNotNull(unassignedEmployees);
            Assert.AreEqual(1, unassignedEmployees.Count);
        }

        [TestMethod]
        public void GivenEmployeeDbContext_WhenExecuteUsingAllWithQuerySyntax_ThenReturnUnassignedEmployees()
        {
            // Act
            var unassignedEmployees = QueryExecutor.GetUnassignedEmployeesUsingAllWithQuerySyntax(_context);

            // Assert
            Assert.IsNotNull(unassignedEmployees);
            Assert.AreEqual(1, unassignedEmployees.Count);
        }

        [TestMethod]
        public void GivenEmployeeDbContext_WhenExecuteUsingAllWithMethodSyntax_ThenReturnUnassignedEmployees()
        {
            // Act
            var unassignedEmployees = QueryExecutor.GetUnassignedEmployeesUsingAllWithMethodSyntax(_context);

            // Assert
            Assert.IsNotNull(unassignedEmployees);
            Assert.AreEqual(1, unassignedEmployees.Count);
        }
    }
}