using System.Web.Mvc;
using System.Web.Razor.Parser;
using Plasticfloor.Services.WebContent.Interface;
using Plasticfloor.Services.WebContent.Interface.Models;
using Plasticfloor.Services.WebContent.Mvc.Models;
using PageContentTypes = Plasticfloor.Services.WebContent.Interface.Models.PageContentTypes;

namespace Plasticfloor.Services.WebContent.Mvc
{
    public class ContentController : Controller
    {
        private readonly IPageService _pageService;
        private readonly IContentFragmentService _fragmentService;
        private readonly IPageRequestSettings _pageRequestSettings;

        public ContentController(IPageService pageService, IContentFragmentService fragmentService, IPageRequestSettings pageRequestSettings)
        {
            _pageService = pageService;
            _fragmentService = fragmentService;
            _pageRequestSettings = pageRequestSettings;
        }

        public ActionResult Index(string relativeUrl)
        {
            var page =
                _pageService.GetPage(new PageRequest
                {
                    UrlName = relativeUrl,
                    RelativeContentUrlPrefix = _pageRequestSettings.RelativeUrlPrefix
                });
            
            if (page.ContentType == PageContentTypes.NotFound)
            {
                return new HttpNotFoundResult();
            }
            return View(
                new PageContentView
                {
                    ContentType = page.ContentType.ToPageContentTypes(),
                    Page = page.ToViewModel()
                });
        }

        public ActionResult Fragment(string fragmentName)
        {
            var fragment = _fragmentService.GetFragment(
                new FragmentRequest
                {
                    UrlName = fragmentName,
                    RelativeContentUrlPrefix = _pageRequestSettings.RelativeUrlPrefix
                });
            return View(fragment.ToViewModel());
        }

        public string FragmentRaw(string fragmentName)
        {
              var fragment = _fragmentService.GetFragment(
                new FragmentRequest
                {
                    UrlName = fragmentName,
                });
            return fragment.Body;
        }
    }
}
