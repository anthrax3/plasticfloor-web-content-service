using Plasticfloor.Services.WebContent.Interface;
using Plasticfloor.Services.WebContent.Interface.Models;

namespace Plasticfloor.Services.WebContent
{
    public class ContentFragmentService : IContentFragmentService
    {
        private readonly IContentProvider<FragmentRequest, ContentFragment> _fragmentProvider;
        private readonly IRelativeUrlRewriter _relativeUrlRewriter;

        public ContentFragmentService(IContentProvider<FragmentRequest, ContentFragment> fragmentProvider, IRelativeUrlRewriter relativeUrlRewriter)
        {
            _fragmentProvider = fragmentProvider;
            _relativeUrlRewriter = relativeUrlRewriter;
        }

        public ContentFragment GetFragment(FragmentRequest request)
        {
            var fragment = _fragmentProvider.GetContent(request);
            if (string.IsNullOrEmpty(request.RelativeContentUrlPrefix)) return fragment;
            fragment.Body = _relativeUrlRewriter.RewriteRelativeUrls(fragment.Body, request.RelativeContentUrlPrefix);
            fragment.UrlName = _relativeUrlRewriter.RewriteRelativeUrl(fragment.UrlName, request.RelativeContentUrlPrefix);
            return fragment;
        }
    }
}
