using Plasticfloor.Services.WebContent.Interface.Models;

namespace Plasticfloor.Services.WebContent.Sitefinity
{
    public class SitefinityBlogApiRequest : ApiGetRequestBase<BlogPostRequest, Page>
    {
        public SitefinityBlogApiRequest(string apiUrl)
            : base(apiUrl, SitefinityApiActions.GetBlogPost)
        {
        }

        protected override string FormatInput(BlogPostRequest input)
        {
            return string.Concat(input.BlogName, "/", input.BlogPostName);
        }
    }
}