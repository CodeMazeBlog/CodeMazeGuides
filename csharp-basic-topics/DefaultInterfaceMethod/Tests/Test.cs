using DefaultInterfaceMethod;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
   
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void DefaultInterfaceMethod_DisplayMessage()
        {
            IDefaultInterface di = new IDefaultInterfaceImplementation();
            di.year = 2902;
            di.ShowMessage();
        }
        [TestMethod]
        public void WhenAddNewDefaultInterfaceMethod_ThenBuildWithSuccess()
        {
            var sql = new SqlServerConnection();
            sql.Open();
            sql.Close();
            var oracle = new OracleConnection();
            oracle.Open();
            oracle.Close();
        }

        [TestMethod]
        public void WhenMultipleInheritance_ThenNoDiamondProblem()
        {
            AllTransaction trn = new AllTransaction();
            trn.Transaction();
        }
    }
}
