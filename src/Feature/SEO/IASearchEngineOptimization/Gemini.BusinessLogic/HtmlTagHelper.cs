namespace Hackaton.AI.SEO.BusinessLogic
{
    public class HtmlTagHelper : IHtmlTagHelper
    {
        public string GetHtmlTag(RequestType? type, string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            switch (type)
            {
                case RequestType.Title:
                    var titleTag = input[input.IndexOf("<title>")..];
                    int titleEndIndex = titleTag.IndexOf("</title>");
                    return titleTag[..(titleEndIndex + "</title>".Length)];
                case RequestType.MetaDescription:
                case RequestType.Keywords:
                    var metaTag = input[input.IndexOf("<meta")..];
                    int metaEndIndex = metaTag.IndexOf("/>");
                    if (metaEndIndex == -1)
                        metaEndIndex = metaTag.IndexOf(">");
                    return metaTag[..(metaEndIndex)] + ">";
                default:
                    return string.Empty;
            }
        }
    }
}
