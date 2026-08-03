using Microsoft.VisualStudio.TestTools.UnitTesting;
using PopulateArrayWithTheSameValue;
using System;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private readonly ArrayPopulator _arrayPopulator = new();
        private readonly Article _article = new() 
        { 
            Title = "How to Find the Maximum Value of an Array in C#", 
            LastUpdate = new DateTime(2022, 02, 07) 
        };

        [TestMethod]
        public void GivenTheMainProgram_ThenRunTheMainMethodAndWriteResultsAtTheConsole()
        {
            Program.Main(Array.Empty<string>());

            Assert.AreEqual(1, Program.OutputResult);
        }

        [TestMethod]
        public void GivenTheMainProgram_ThenReturnAnEmptyArray()
        {
            var emptyArray = Program.InstantiateInitialArray();

            Assert.IsNotNull(emptyArray);
            Assert.IsNull(emptyArray[0]);
        }

        [TestMethod]
        public void GivenTheMainProgram_ThenReturnANewArticle()
        {
            var article = Program.InstantiateNewArticle();

            Assert.IsNotNull(article);
        }

        [TestMethod]
        public void GivenTheArrayPopulator_ThenReturnANewPopulatedArrayManually()
        {
            var populatedArray = _arrayPopulator.InstantiateArrayManually();

            //It can't be null
            Assert.IsNotNull(populatedArray);
            //It has at least one element
            Assert.IsTrue(populatedArray.Any());
        }

        [TestMethod]
        public void GivenAnEmptyInitialArrayAndAnObject_ThenReturnAFilledArrayUsingArrayFill()
        {
            var populatedArray = _arrayPopulator.FillArray(new Article[10], _article);

            Assert.IsNotNull(populatedArray);
            Assert.IsTrue(populatedArray.Any());
            Assert.AreEqual(populatedArray[0], _article);
        }

        [TestMethod]
        public void GivenAnInitialArrayAndAnObject_ThenReturnAnArrayFilledInIndexFiveAndSixUsingArrayFill()
        {
            var partiallyFilledArray = _arrayPopulator.FillArrayWithAditionalParameter(new Article[10], _article);

            Assert.IsNotNull(partiallyFilledArray);
            Assert.IsTrue(partiallyFilledArray.Any());
            Assert.IsNull(partiallyFilledArray[0]);
            Assert.IsNotNull(partiallyFilledArray[5]);
            Assert.IsNotNull(partiallyFilledArray[6]);
            Assert.AreEqual(partiallyFilledArray[5], _article);
            Assert.AreEqual(partiallyFilledArray[6], _article);
        }

        [TestMethod]
        public void GivenAnObject_ThenReturnAnArrayFilledWithThisObjectUsingEnumerableRepeat()
        {
            var populatedArticle = _arrayPopulator.EnumerableRepeat(_article, 10);

            Assert.IsNotNull(populatedArticle);
            Assert.IsTrue(populatedArticle.Any());
        }

        [TestMethod]
        public void GiveAnArticleAndAnObject_ThenReturnAFilledArrayUsingFor()
        {
            var populatedArticle = _arrayPopulator.ForStatement(new Article[10], _article);
            
            Assert.IsNotNull(populatedArticle);
            Assert.IsTrue(populatedArticle.Any());
            Assert.AreNotSame(populatedArticle[0], _article);
            Assert.AreNotSame(populatedArticle[0], populatedArticle[1]);
        }

        [TestMethod]
        public void GiveAnArticleAndAnObject_ThenReturnAFilledArrayUsingForWithShallowCopy()
        {
            var populatedArticle = _arrayPopulator.ForStatementShallowCopy(new Article[10], _article);

            Assert.IsNotNull(populatedArticle);
            Assert.IsTrue(populatedArticle.Any());
            Assert.AreSame(populatedArticle[0], _article);
            Assert.AreSame(populatedArticle[0], populatedArticle[1]);
        }
    }
}