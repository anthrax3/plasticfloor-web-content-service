using Plasticfloor.Services.WebContent.Interface;
using Plasticfloor.Services.WebContent.Interface.Models;

namespace Plasticfloor.Services.WebContent
{
    public class PageService : IPageService
    {
        private readonly IContentProvider<PageRequest, Page> _pageProvider;
        private readonly IRelativeUrlRewriter _relativeUrlRewriter;

        public PageService(IContentProvider<PageRequest, Page> pageProvider, IRelativeUrlRewriter relativeUrlRewriter)
        {
            _pageProvider = pageProvider;
            _relativeUrlRewriter = relativeUrlRewriter;
        }

        public Page GetPage(PageRequest request)
        {
            var page = _pageProvider.GetContent(request);
            if (string.IsNullOrEmpty(request.RelativeContentUrlPrefix)) return page;
            page.Body = _relativeUrlRewriter.RewriteRelativeUrls(page.Body, request.RelativeContentUrlPrefix);
            page.UrlName = _relativeUrlRewriter.RewriteRelativeUrl(page.UrlName, request.RelativeContentUrlPrefix);
            if (page.RelatedContent == null) return page;
            page.RelatedContent.UrlName = _relativeUrlRewriter.RewriteRelativeUrl(page.RelatedContent.UrlName,
                request.RelativeContentUrlPrefix);
            if (page.RelatedContent.PageRelatedContentElements == null) return page;
            foreach (var element in page.RelatedContent.PageRelatedContentElements)
            {
                element.UrlName = _relativeUrlRewriter.RewriteRelativeUrl(element.UrlName,
                    request.RelativeContentUrlPrefix);
            }
            return page;
        }
    }

   

}
