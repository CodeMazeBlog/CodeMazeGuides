
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActionFuncDelegate.UnitTest
{
    //Declaration
    public delegate void WriterDelegate(string first, string last);
    
    [TestClass]
    public class DelegationTest
    {
        // arrangements 
        public static string _fullName = string.Empty;
        public static void WriteName(string first, string last)
        {
            _fullName = first + " " + last;
            Console.WriteLine(_fullName);
        }
        public static string JoinName(string first, string last)
        {
            return first + last;
        }
        // Action Delegate Testing
        [TestMethod]
        public void ActionDelegate_WhenStringSent_IsExecutingRefferedMethod()
        {
            // arrange
            Action<string, string> WriteFullName = WriteName;
            // act
            WriteFullName("Code", "Maze");
            //assert 
            Assert.AreEqual("Code Maze", _fullName);

        }
        // Func Delegate Testing 
        [TestMethod]
        public void FuncDelegate_WhenStringSent_IsExecutingRefferedMethod()
        {
            //arrange
            Func<string, string, string> JoinString = JoinName;
            // act
            var result = JoinString("code-", "maze.com");
            // assert 
            Assert.AreEqual("code-maze.com", JoinName("code-", "maze.com"));
        }
    }
}