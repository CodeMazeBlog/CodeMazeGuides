namespace Tests
{
    internal class PdfRunnerTest
    {
        public void DoTest(Action<string> action)
        {
            var tmpFileName = Path.GetTempFileName();

            try
            {
                // file exists
                Assert.IsTrue(File.Exists(tmpFileName));

                // is empty
                Assert.AreEqual(0, new FileInfo(tmpFileName).Length);

                action(tmpFileName);

                // file still exists
                Assert.IsTrue(File.Exists(tmpFileName));

                // is not empty
                Assert.IsTrue(new FileInfo(tmpFileName).Length > 0);
            }
            finally
            {
                File.Delete(tmpFileName);
            }
        }
    }
}
