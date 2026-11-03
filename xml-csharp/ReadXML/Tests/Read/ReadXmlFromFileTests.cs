namespace Tests.Read
{
    [TestClass]
    public class ReadXmlFromFileTests
    {
        private static readonly string[] ExpectedEmails =
        [
            "olivia.davis@code-maze.com",
            "john.davis@code-maze.com",
            "sarah.moore@code-maze.com",
            "sarah.smith@code-maze.com"
        ];

        [TestMethod]
        public void GivenPeopleFile_WhenCallingReadEmailsUsingXDocument_ThenAllEmailsAreReturned()
        {
            var result = ReadXmlFromFile.ReadEmailsUsingXDocument(ReadXmlFromFile.FilePath);

            CollectionAssert.AreEqual(ExpectedEmails, result.ToArray());
        }

        [TestMethod]
        public void GivenPeopleFile_WhenCallingReadEmailsUsingXmlReader_ThenAllEmailsAreReturned()
        {
            var result = ReadXmlFromFile.ReadEmailsUsingXmlReader(ReadXmlFromFile.FilePath);

            CollectionAssert.AreEqual(ExpectedEmails, result.ToArray());
        }

        [TestMethod]
        public void GivenPeopleFile_WhenCallingXmlDocumentReadEmails_ThenAllEmailsAreReturned()
        {
            var result = ReadXmlUsingXmlDocument.ReadEmails(ReadXmlFromFile.FilePath);

            CollectionAssert.AreEqual(ExpectedEmails, result.ToArray());
        }

        [TestMethod]
        public void GivenMissingFile_WhenCallingXDocumentLoad_ThenFileNotFoundExceptionIsThrown()
        {
            var missing = Path.Combine(AppContext.BaseDirectory, "missing.xml");

            Assert.ThrowsExactly<FileNotFoundException>(() => ReadXmlFromFile.ReadEmailsUsingXDocument(missing));
        }
    }
}
