using System.Web;

namespace Hackaton.AI.SEO.BusinessLogic.Extensions
{
    public static class StringExtensions
    {
        public static string GetHtmlTag(this string input, RequestType type)
        {
            switch(type)
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
