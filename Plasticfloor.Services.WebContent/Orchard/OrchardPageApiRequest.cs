using Plasticfloor.Services.WebContent.Interface.Models;

namespace Plasticfloor.Services.WebContent.Orchard
{
    public class OrchardPageApiRequest : ApiGetRequestBase<PageRequest,Page>
    {
        public OrchardPageApiRequest(string apiUrl)
            : base(apiUrl, OrchardApiActions.GetPage) { }

        protected override string FormatInput(PageRequest input)
        {
            return input.UrlName;
        }
    }
}