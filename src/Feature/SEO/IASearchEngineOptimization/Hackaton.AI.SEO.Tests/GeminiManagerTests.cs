using Moq;
using Hackaton.AI.SEO.Models;
using Hackaton.AI.SEO.BusinessLogic;
using Hackaton.AI.SEO.BusinessLogic.Extensions;
using Microsoft.Extensions.Configuration;

namespace Hackaton.AI.SEO.Tests
{
    public class GeminiManagerTests
    {
        [Fact]
        public void ParseRequest_ReturnsCorrectTupleList()
        {
            // Arrange
            var originalRequest = new ApiRequest
            {
                TitleTag = "true",
                TitlePrompt = "title prompt",
                MetaDescription = "true",
                MetaDescriptionPrompt = "meta prompt",
                Keyword = "true",
                KeywordPrompt = "keyword prompt",
                Content = "content"
            };

            var mockConfiguration = new Mock<IConfiguration>();
            var mockHttpClient = new Mock<IHttpClientWrapper>();
            mockHttpClient.Setup(x => x.PostAsync(It.IsAny<string?>(), It.IsAny<HttpContent?>()))
                .Returns(Task.FromResult(new HttpResponseMessage()));

            var manager = new GeminiManager(mockConfiguration.Object, mockHttpClient.Object);

            // Act
            var result = manager.ParseRequest(originalRequest);

            // Assert
            Assert.Collection(result,
                item =>
                {
                    Assert.Equal(RequestType.Title, item.Item1);
                    Assert.Equal("title prompt\r\ncontent", item?.Item2?.contents?[0].parts?[0].text);
                },
                item =>
                {
                    Assert.Equal(RequestType.MetaDescription, item.Item1);
                    Assert.Equal("meta prompt\r\ncontent", item?.Item2?.contents?[0].parts?[0].text);
                },
                item =>
                {
                    Assert.Equal(RequestType.Keywords, item.Item1);
                    Assert.Equal("keyword prompt\r\ncontent", item?.Item2?.contents?[0].parts?[0].text);
                });
        }

        [Fact]
        public async Task SendRequest_ReturnsCorrectHttpResponseMessage()
        {
            // Arrange
            var type = RequestType.Title;
            var request = new GeminiRequest();

            var mockConfiguration = new Mock<IConfiguration>();
            var mockHttpClient = new Mock<IHttpClientWrapper>();
            mockHttpClient.Setup(x => x.PostAsync(It.IsAny<string?>(), It.IsAny<HttpContent?>()))
                .Returns(Task.FromResult(new HttpResponseMessage()));

            var manager = new GeminiManager(mockConfiguration.Object, mockHttpClient.Object);

            // Act
            var result = await manager.SendRequest(type, request);

            // Assert
            Assert.Equal(type, result.Item1);
            Assert.NotNull(result.Item2);
            Assert.Equal(System.Net.HttpStatusCode.OK, result.Item2!.StatusCode);
        }

        [Fact]
        public void ParseResponse_ReturnsCorrectApiResponse()
        {
            // Arrange
            var geminiResponses = new List<Tuple<RequestType, GeminiResponse>>
            {
                Tuple.Create(RequestType.Title, new GeminiResponse
                {
                    candidates = new List<Candidate>
                    {
                        new Candidate
                        {
                            content = new Content
                            {
                                parts = new List<Part>
                                {
                                    new Part { text = "<title>generated title</title>" }
                                }
                            }
                        }
                    }
                }),
                Tuple.Create(RequestType.MetaDescription, new GeminiResponse
                {
                    candidates = new List<Candidate>
                    {
                        new Candidate
                        {
                            content = new Content
                            {
                                parts = new List<Part>
                                {
                                    new Part { text = "<meta name=\"description\">" }
                                }
                            }
                        }
                    }
                }),
                Tuple.Create(RequestType.Keywords, new GeminiResponse
                {
                    candidates = new List<Candidate>
                    {
                        new Candidate
                        {
                            content = new Content
                            {
                                parts = new List<Part>
                                {
                                    new Part { text = "<meta name=\"keywords\">" }
                                }
                            }
                        }
                    }
                })
            };

            var mockConfiguration = new Mock<IConfiguration>();
            var mockHttpClient = new Mock<IHttpClientWrapper>();
            mockHttpClient.Setup(x => x.PostAsync(It.IsAny<string?>(), It.IsAny<HttpContent?>()))
                .Returns(Task.FromResult(new HttpResponseMessage()));

            var manager = new GeminiManager(mockConfiguration.Object, mockHttpClient.Object);

            // Act
            var result = manager.ParseResponse(geminiResponses);

            // Assert
            Assert.Equal("<title>generated title</title>e".GetHtmlTag(RequestType.Title), result.TitleTag);
            Assert.Equal("<meta name=\"description\">".GetHtmlTag(RequestType.MetaDescription), result.MetaDescriptionTag);
            Assert.Equal("<meta name=\"keywords\">".GetHtmlTag(RequestType.Keywords), result.KeywordsTag);
        }
    }
}
