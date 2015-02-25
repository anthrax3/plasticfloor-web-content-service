using System.IO;
using System.Linq;
using HtmlAgilityPack;

namespace Plasticfloor.Services.WebContent
{
    public interface IRelativeUrlRewriter
    {
        string RewriteRelativeUrls(string html, string relativeUrlPrefix);
        string RewriteRelativeUrl(string relativeUrl, string relativeUrlPrefix);

    }

    public abstract class RelativeUrlRewriterBase
    {
        public string RewriteRelativeUrl(string relativeUrl, string relativeUrlPrefix)
        {
            return string.Concat(relativeUrlPrefix, "/", relativeUrl);
        }
    }

    public class HtmlAgilityRelativeUrlRewriter : RelativeUrlRewriterBase, IRelativeUrlRewriter
    {
        public string RewriteRelativeUrls(string html, string relativeUrlPrefix)
        {
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var links = document.DocumentNode.SelectNodes("//a[@href]");
            if (links==null || !links.Any()) return html;
            foreach (var link in links)
            {
                var href = link.Attributes["href"].Value;
                if (href.StartsWith("/") && !href.StartsWith("//"))
                {
                    link.SetAttributeValue("href", string.Concat("/",relativeUrlPrefix,href));
                }
            }
            using (var sw = new StringWriter())
            {
                document.Save(sw);
                return sw.ToString();
            }
        }
    }

}
