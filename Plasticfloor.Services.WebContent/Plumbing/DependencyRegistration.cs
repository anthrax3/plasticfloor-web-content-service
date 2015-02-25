using System.Configuration;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Plasticfloor.Services.WebContent.Interface;
using Plasticfloor.Services.WebContent.Interface.Models;
using Plasticfloor.Services.WebContent.Sitefinity;

namespace Plasticfloor.Services.WebContent.Plumbing
{
    public class DependencyRegistration : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.AddFacility<WcfFacility>();
            container.Register(
                Component.For<IPageService>()
                    .ImplementedBy<PageService>()
                    .IsDefault(),

                Component.For<IContentFragmentService>()
                    .ImplementedBy<ContentFragmentService>()
                    .IsDefault(),
                    
                Component.For<IContentProvider<PageRequest,Page>>()
                    .ImplementedBy<SitefinityPageApiRequest>()
                    .DependsOn(Dependency.OnConfigValue("apiUrl", ConfigurationManager.AppSettings["SitefinityCmsApiPath"]))
                    .LifestyleTransient()
                    .IsDefault(),

                Component.For<IRelativeUrlRewriter>()
                    .ImplementedBy<HtmlAgilityRelativeUrlRewriter>()
                    .LifestyleTransient()
                    .IsDefault()
                    );
        }
    }
}