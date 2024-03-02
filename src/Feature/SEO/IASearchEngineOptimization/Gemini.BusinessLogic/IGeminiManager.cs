using Hackaton.AI.SEO.Models;

namespace Hackaton.AI.SEO.BusinessLogic
{
    public interface IGeminiManager
    {
        List<Tuple<RequestType, GeminiRequest>> ParseRequest(ApiRequest originalRequest);
        Task<Tuple<RequestType, HttpResponseMessage?>> SendRequest(RequestType type, GeminiRequest request);
        ApiResponse ParseResponse(List<Tuple<RequestType, GeminiResponse>> geminiResponses);
    }
}
