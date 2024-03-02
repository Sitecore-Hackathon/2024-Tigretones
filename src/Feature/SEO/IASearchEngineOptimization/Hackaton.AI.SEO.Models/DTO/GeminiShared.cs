using System.Text.Json.Serialization;

namespace Hackaton.AI.SEO.Models
{
    [Serializable]
    public class Content
    {
        public List<Part>? parts { get; set; }
        public string? role { get; set; }
    }

    [Serializable]
    public class Part
    {
        public string? text { get; set; }
    }
}
