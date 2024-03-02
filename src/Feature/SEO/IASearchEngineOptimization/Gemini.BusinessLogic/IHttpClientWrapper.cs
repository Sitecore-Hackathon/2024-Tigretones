using System.Diagnostics.CodeAnalysis;

namespace Hackaton.AI.SEO.BusinessLogic
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> PostAsync(string? requestUri, HttpContent? content);
    }
}
