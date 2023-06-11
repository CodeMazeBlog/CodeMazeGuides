using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    internal class PdfRunnerTest
    {
        public void DoTest(string fileName, Action<string> action)
        {
            // file exists
            Assert.IsTrue(File.Exists(fileName));

            // is empty
            Assert.AreEqual(0, new FileInfo(fileName).Length);

            action(fileName);

            // file still exists
            Assert.IsTrue(File.Exists(fileName));

            // is not empty
            Assert.IsTrue(new FileInfo(fileName).Length > 0);

            File.Delete(fileName);
        }
    }
}
