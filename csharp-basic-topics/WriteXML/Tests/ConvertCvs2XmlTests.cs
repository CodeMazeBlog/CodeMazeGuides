namespace Tests
{
    [TestClass]
    public class ConvertCvs2XmlTests
    {
        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void ExecutingGetCaptions_WhenStringIsEmpty_ShouldReturnArrayWithOneElement(bool hasCaptions)
        {
            var convertCvs2Xml = new ConvertCvs2Xml([], hasCaptions);

            var captions = convertCvs2Xml.GetCaptions("");

            Assert.AreEqual(1, captions.Length);
        }

        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void ExecutingGetCaptions_WhenStringDoesNotContainsCommas_ShouldReturnArrayWithOneElement(bool hasCaptions)
        {
            var convertCvs2Xml = new ConvertCvs2Xml([], hasCaptions);

            var captions = convertCvs2Xml.GetCaptions("this is a value");

            Assert.AreEqual(1, captions.Length);
        }

        [TestMethod]
        [DataRow("", 1)]
        [DataRow("Apple", 1)]
        [DataRow("Apple, Banana", 2)]
        [DataRow("Orange, Grape, Pineapple", 3)]
        [DataRow("Kiwi, Mango, Strawberry, Blueberry", 4)]
        [DataRow("Lemon, Lime, Plum, Peach, Apricot", 5)]
        public void ExecutingGetCaptions_WhenStringDoesContainsCommas_ShouldReturnArrayWithNumberOfElementsEqualToNumberOfCommas(
            string firstLine, int expectedNumberOfElements)
        {
            var convertCvs2Xml = new ConvertCvs2Xml([], true);

            var captions = convertCvs2Xml.GetCaptions(firstLine);

            Assert.AreEqual(expectedNumberOfElements, captions.Length);
        }

        [TestMethod]
        [DataRow("Green Grape, Strawberry, Blueberry, Passion Fruit, Watermelon, Sweet Cherry, Honeydew Melon")]
        public void ExecutingGetCaptions_WhenElementsHasSpaces_ShouldReturnArrayWithElementsWithoutSpaces(
            string firstLine)
        {
            var convertCvs2Xml = new ConvertCvs2Xml([], true);

            var captions = convertCvs2Xml.GetCaptions(firstLine);
            var captionsWithoutSpaces = captions.Where(c => c.Contains(' '));

            Assert.AreEqual(0, captionsWithoutSpaces.Count());
        }

        [TestMethod]
        [DataRow("Green Grape, Strawberry, Blueberry, Passion Fruit, Watermelon, Sweet Cherry, Honeydew Melon")]
        public void ExecutingGetCaptions_WhenThereIsNoCaptions_ShouldReturnArrayWithAllElementsBeginningWithFieldKeyword(
            string firstLine)
        {
            var convertCvs2Xml = new ConvertCvs2Xml([], false);

            var captions = convertCvs2Xml.GetCaptions(firstLine);
            var captionsNotBeginningWithField = captions.Where(c => !c.StartsWith("Field"));

            Assert.AreEqual(0, captionsNotBeginningWithField.Count());
        }

        [TestMethod]
        public void GivenTestCsv_WhenExecutingConvertWithoutCaptions_ShouldReturnXMLDocumentWithFourRows()
        {
            var convertCvs2Xml = new ConvertCvs2Xml(GetTestCsvLines(), false);

            var resultXml = convertCvs2Xml.Convert();

            Assert.AreEqual(4, resultXml.Descendants("row").Count());
        }

        [TestMethod]
        public void GivenTestCsv_WhenExecutingConvertWithCaptions_ShouldReturnXMLDocumentWithThreeRows()
        {
            var convertCvs2Xml = new ConvertCvs2Xml(GetTestCsvLines(), true);

            var resultXml = convertCvs2Xml.Convert();

            Assert.AreEqual(3, resultXml.Descendants("row").Count());
        }


        [TestMethod]
        public void GivenTestCsv_WhenExecutingConvertWithoutCaptions_ShouldReturnXMLDocumentWithFourFields1()
        {
            var convertCvs2Xml = new ConvertCvs2Xml(GetTestCsvLines(), false);

            var resultXml = convertCvs2Xml.Convert();

            Assert.AreEqual(4, resultXml.Descendants("Field1").Count());
        }

        [TestMethod]
        public void GivenTestCsv_WhenExecutingConvertWithCaptions_ShouldReturnXMLDocumentWithThreeNames()
        {
            var convertCvs2Xml = new ConvertCvs2Xml(GetTestCsvLines(), true);

            var resultXml = convertCvs2Xml.Convert();

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
