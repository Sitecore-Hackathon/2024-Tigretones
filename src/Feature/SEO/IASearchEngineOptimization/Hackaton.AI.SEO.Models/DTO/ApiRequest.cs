namespace Hackaton.AI.SEO.Models
{
    [Serializable]
    public class ApiRequest
    {
        public string? Content { get; set; }
        public string? TitleTag { get; set; }
        public string? TitlePrompt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaDescriptionPrompt { get; set; }
        public string? Keyword { get; set; }
        public string? KeywordPrompt { get; set; }
        public string? ReferenceLinks { get; set; }
        public string? ReferenceLinksPrompt { get; set; }
    }
}
