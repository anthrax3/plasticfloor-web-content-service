using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plasticfloor.Services.WebContent.Interface;
using Plasticfloor.Services.WebContent.Interface.Models;
using Plasticfloor.Services.WebContent.Mvc.Models;

namespace Plasticfloor.Services.WebContent.IntegrationTests
{
    [TestClass]
    public class HelloWorld
    {
        [TestMethod]
        public void GetABlogPost()
        {
            var service = GlobalSetup.Container.Resolve<IPageService>();
            try
            {
                var page = service.GetPage(new PageRequest
                {
                    RelativeContentUrlPrefix = "content",
                    UrlName = "tech-blueprint/finding-the-right-tool"
                });
                var pageView = page.ToViewModel();
                var blogPostView = pageView.ToBlogPostView();
            }
            finally
            {
                GlobalSetup.Container.Release(service);
            }
        }
    }
}
