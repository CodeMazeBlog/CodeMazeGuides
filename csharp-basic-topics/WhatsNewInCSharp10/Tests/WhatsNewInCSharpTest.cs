using WhatsNewInCSharp10;
using Xunit;

namespace Tests
{
    public class WhatsNewInCSharpTest
    {
        [Fact]
        public void WhenMazeIsCreatedWithParameterlessConstructor_ThenPropertyIsInitialized()
        {
            // When
            var maze = new Maze();

            // Then
            Assert.Equal(10, maze.Size);
        }

        [Fact]
        public void GivenCustomInterpolatedStringHandler_WhenStringIsFormatted_ThenCustomFormatIsApplied()
        {
            // Given
            var attribute = "not awesome";
            CustomInterpolatedStringHandler builder = $"Code maze is {attribute}.";

            // When
            var proccesedString = builder.GetFormattedText();

            // Then
            Assert.Equal("Code maze is awesome.", proccesedString);
        }

        [Fact]
        public void GivenArticleAndCodeMazeArticleWithSameAuthorAndTitle_WhenTheyAreRepresentedAsString_ThenTheirRepresentationIsEqual()
        {
            // Given
            var article = new Article("Author", "Title");
            var codeMazeArticle = new CodeMazeArticle("Author", "Title", "Comment");

            // When
            var articleStringRepresentation = article.ToString();
            var codeMazeArticleStringRepresentation = codeMazeArticle.ToString();

            // Then
            Assert.Equal(codeMazeArticleStringRepresentation, articleStringRepresentation);
        }
    }
}