using System.Diagnostics.CodeAnalysis;

namespace Hackaton.AI.SEO.BusinessLogic
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _HttpClient;

        public HttpClientWrapper()
        {
            _HttpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> PostAsync(string? requestUri, HttpContent? content)
        {
            return await _HttpClient.PostAsync(requestUri, content);
        }
    }
}
