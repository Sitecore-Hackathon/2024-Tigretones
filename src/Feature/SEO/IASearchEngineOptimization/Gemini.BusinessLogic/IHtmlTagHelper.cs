namespace Hackaton.AI.SEO.BusinessLogic
{
    public interface IHtmlTagHelper
    {
        string GetHtmlTag(RequestType? type, string? input);
    }
}
