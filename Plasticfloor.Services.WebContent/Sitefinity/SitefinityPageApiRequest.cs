using Plasticfloor.Services.WebContent.Interface.Models;

namespace Plasticfloor.Services.WebContent.Sitefinity
{
    public class SitefinityPageApiRequest : ApiGetRequestBase<PageRequest, Page>
    {
        public SitefinityPageApiRequest(string apiUrl)
            : base(apiUrl, SitefinityApiActions.GetPage) { }

        protected override string FormatInput(PageRequest input)
        {
            return input.UrlName;
        }
    }

    public class SitefinityContentFragmentApiRequest : ApiGetRequestBase<FragmentRequest, ContentFragment>
    {
        public SitefinityContentFragmentApiRequest(string apiUrl)
            : base(apiUrl, SitefinityApiActions.GetContentFragment) { }

        protected override string FormatInput(FragmentRequest input)
        {
            return input.UrlName;
        }
    }
}