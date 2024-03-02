using System.Text.Json.Serialization;

namespace Hackaton.AI.SEO.Models
{
    [Serializable]
    public class GeminiRequest
    {
        public List<Content>? contents { get; set; }
    }
}
