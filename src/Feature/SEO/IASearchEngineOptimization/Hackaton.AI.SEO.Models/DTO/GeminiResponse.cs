using System.Text.Json.Serialization;

namespace Hackaton.AI.SEO.Models
{
    [Serializable]
    public class SafetyRating
    {
        public string? category { get; set; }
        public string? probability { get; set; }
    }

    [Serializable]
    public class Candidate
    {
        public Content? content { get; set; }
        public string? finishReason { get; set; }
        public int? index { get; set; }
        public List<SafetyRating>? safetyRatings { get; set; }
    }

    [Serializable]
    public class PromptFeedback
    {
        public List<SafetyRating>? safetyRatings { get; set; }
    }

    [Serializable]
    public class GeminiResponse
    {
        public List<Candidate>? candidates { get; set; }
        public PromptFeedback? promptFeedback { get; set; }
    }
}
