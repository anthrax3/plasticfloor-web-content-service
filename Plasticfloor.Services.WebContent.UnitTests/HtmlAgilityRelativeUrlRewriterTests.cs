using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Plasticfloor.Services.WebContent.UnitTests
{
    [TestClass]
    public class HtmlAgilityRelativeUrlRewriterTests
    {
        [TestMethod]
        public void AddsPrefixToRelativeUrls()
        {
            const string html = @"<div><a href=""/a/b"">test</a></div><A href=""/b/c"">test2</A>";
            var rewriter = new HtmlAgilityRelativeUrlRewriter();
            var rewritten = rewriter.RewriteRelativeUrls(html, "/prefix");
            //Note - tag names all become lowercase.
            Assert.IsTrue(string.Equals(rewritten, @"<div><a href=""/prefix/a/b"">test</a></div><a href=""/prefix/b/c"">test2</a>"));
        }

        [TestMethod]
        public void IgnoresProtocolAgnosticUrls()
        {
            const string html = @"<div><a href=""/a/b"">test</a></div><a href=""//b/c"">test2</a>";
            var rewriter = new HtmlAgilityRelativeUrlRewriter();
            var rewritten = rewriter.RewriteRelativeUrls(html, "/prefix");
            Assert.IsTrue(string.Equals(rewritten, @"<div><a href=""/prefix/a/b"">test</a></div><a href=""//b/c"">test2</a>"));
        }

        [TestMethod]
        public void MakesNoChangeIfThereAreNoLinks()
        {
            const string html = @"<div><a>abc</a></div>";
            var rewriter = new HtmlAgilityRelativeUrlRewriter();
            var rewritten = rewriter.RewriteRelativeUrls(html, "/prefix");
            Assert.IsTrue(string.Equals(rewritten, html));
        }
    }
}
