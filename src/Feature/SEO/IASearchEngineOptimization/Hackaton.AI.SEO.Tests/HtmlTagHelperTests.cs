using Hackaton.AI.SEO.BusinessLogic;

namespace Hackaton.AI.SEO.Tests
{
    public class HtmlTagHelperTests
    {
        [Theory]
        [InlineData("<title>Test Title</title>", RequestType.Title, "<title>Test Title</title>")]
        [InlineData("<meta name=\"description\" content=\"Test Description\">", RequestType.MetaDescription, "<meta name=\"description\" content=\"Test Description\">")]
        [InlineData("<meta name=\"keywords\" content=\"Test Keywords\">", RequestType.Keywords, "<meta name=\"keywords\" content=\"Test Keywords\">")]
        public void GetHtmlTag_ReturnsCorrectTag(string input, RequestType type, string expected)
        {
            // Arrange
            var helper = new HtmlTagHelper();

            // Act
            var result = helper.GetHtmlTag(type, input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetHtmlTag_ReturnsEmptyStringForUnknownType()
        {
            // Arrange
            var helper = new HtmlTagHelper();

            // Act
            var result = helper.GetHtmlTag((RequestType)10, "<title>Test Title</title>");

            // Assert
            Assert.Equal(string.Empty, result);
        }
    }
}
