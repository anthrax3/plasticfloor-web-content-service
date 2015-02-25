using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plasticfloor.Services.WebContent.Mvc
{
    public interface IRelativeUrlRewriter
    {
        void RewriteUrls(string html);
    }

    public class HtmlAgilityRelativeUrlRewriter : IRelativeUrlRewriter
    {
        public void RewriteUrls(string html)
        {
            throw new NotImplementedException();
        }
    }
}
