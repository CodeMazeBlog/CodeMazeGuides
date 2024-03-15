namespace Tests
{
    [TestClass]
    public class ConvertCsv2XmlTests
    {
        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void GivenCaptions_WhenStringIsEmpty_ThenArrayMustHaveOneElement(bool hasCaptions)
        {
            var convertCsv2Xml = new ConvertCsv2Xml([], hasCaptions);

            var captions = convertCsv2Xml.GetCaptions("");

            Assert.AreEqual(1, captions.Length);
        }

        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void GivenCaptions_WhenStringDoesNotContainsCommas_ThenArrayMustHaveOneElement(bool hasCaptions)
        {
            var convertCsv2Xml = new ConvertCsv2Xml([], hasCaptions);

            var captions = convertCsv2Xml.GetCaptions("this is a value");

            Assert.AreEqual(1, captions.Length);
        }

        [TestMethod]
        [DataRow("", 1)]
        [DataRow("Apple", 1)]
        [DataRow("Apple, Banana", 2)]
        [DataRow("Orange, Grape, Pineapple", 3)]
        [DataRow("Kiwi, Mango, Strawberry, Blueberry", 4)]
        [DataRow("Lemon, Lime, Plum, Peach, Apricot", 5)]
        public void GivenCaptions_WhenStringDoesContainsCommas_ThenArrayMustHaveEqualNumerOfElementsAsThereAreCommas(
            string firstLine, int expectedNumberOfElements)
        {
            var convertCsv2Xml = new ConvertCsv2Xml([], true);

            var captions = convertCsv2Xml.GetCaptions(firstLine);

            Assert.AreEqual(expectedNumberOfElements, captions.Length);
        }

        [TestMethod]
        [DataRow("Green Grape, Strawberry, Blueberry, Passion Fruit, Watermelon, Sweet Cherry, Honeydew Melon")]
        public void GivenCaptions_WhenElementsHasSpaces_ThenTheArrayMustHaveUnderscores(
            string firstLine)
        {
            var convertCsv2Xml = new ConvertCsv2Xml([], true);

            var captions = convertCsv2Xml.GetCaptions(firstLine);
            var captionsWithoutSpaces = captions.Where(c => c.Contains(' '));

            Assert.AreEqual(0, captionsWithoutSpaces.Count());
        }

        [TestMethod]
        [DataRow("Green Grape, Strawberry, Blueberry, Passion Fruit, Watermelon, Sweet Cherry, Honeydew Melon")]
        public void GivenCaptions_WhenThereIsNoLineWithCaptions_ThenAllElementsInArrayMustBeginWithConstant(
            string firstLine)
        {
            var constantName = "Field";
            var convertCsv2Xml = new ConvertCsv2Xml([], false);

            var captions = convertCsv2Xml.GetCaptionReplacements(firstLine);
            var captionsNotBeginningWithField = captions.Where(c => !c.StartsWith(constantName));

            Assert.AreEqual(0, captionsNotBeginningWithField.Count());
        }

        [TestMethod]
        public void GivenTestCSV_WhenExecutingConvertWithoutCaptions_ThenXmlDocumentMustHaveFourRows()
        {
            var convertCsv2Xml = new ConvertCsv2Xml(GetTestCsvLines(), false);

            var resultXml = convertCsv2Xml.Convert();

            Assert.AreEqual(4, resultXml.Descendants("row").Count());
        }

        [TestMethod]
        public void GivenTestCSV_WhenExecutingConvertWithCaptions_ThenXmlDocumentMustHaveThreeRows()
        {
            var convertCsv2Xml = new ConvertCsv2Xml(GetTestCsvLines(), true);

            var resultXml = convertCsv2Xml.Convert();

            Assert.AreEqual(3, resultXml.Descendants("row").Count());
        }


        [TestMethod]
        public void GivenTestCsv_WhenExecutingConvertWithoutCaptions_ShouldReturnXmlDocumentWithFourFields1()
        {
            var convertCsv2Xml = new ConvertCsv2Xml(GetTestCsvLines(), false);

            var resultXml = convertCsv2Xml.Convert();

            Assert.AreEqual(4, resultXml.Descendants("Field1").Count());
        }

        [TestMethod]
        public void GivenTestCsv_WhenExecutingConvertWithCaptions_ShouldReturnXmlDocumentWithThreeNames()
        {
            var convertCsv2Xml = new ConvertCsv2Xml(GetTestCsvLines(), true);

            var resultXml = convertCsv2Xml.Convert();

            Assert.AreEqual(3, resultXml.Descendants("Name").Count());
        }

        private static string[] GetTestCsvLines()
        {
            return
            [
                "Name,Email",
                "John Doe,john.doe@email.com",
                "Jane Smith,jane.smith@email.com",
                "Bob Johnson,bob.johnson@email.com",
            ];
        }
    }
}
